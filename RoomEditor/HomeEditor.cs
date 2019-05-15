using HomeEditor.Elements;
using HomeEditor.MQTT;
using HomeEditor.Rules;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace HomeEditor {
    /// <summary>
    /// Main window of the application.
    /// </summary>
    public partial class HomeEditor : Form {
        MQTTHandler MQTT;
        /// <summary>
        /// Cached default window title.
        /// </summary>
        string defaultTitle;

        /// <summary>
        /// Selected control to configure.
        /// </summary>
        SerializablePanel selection;

        /// <summary>
        /// List of parent elements (rooms, doors, and obstacles) in the house.
        /// </summary>
        public IReadOnlyList<SerializablePanel> Elements => drawingPanel.Controls.OfType<SerializablePanel>().ToList();

        /// <summary>
        /// Background color of the room name input field if the room name is valid.
        /// </summary>
        Color roomNameBackground;

        /// <summary>
        /// Check if each rule's criteria has been met every seond.
        /// </summary>
        Timer ruleEngineTicker = new Timer() { Interval = 1000 };

        /// <summary>
        /// Send an alert when a rule has triggered.
        /// </summary>
        void SendAlert(Rule rule) =>
            Alert.SendAlert(rule.targetRoom, "The following rule has triggered a notification: " + rule.name);

        /// <summary>
        /// Call the rule engine's update function.
        /// </summary>
        void RuleTick(object sender, EventArgs e) => RuleLibrary.Tick();

        /// <summary>
        /// Main window of the application.
        /// </summary>
        public HomeEditor() {
            Form loading = new Loading();
            loading.Show();
            loading.Refresh();
            InitializeComponent();
            defaultTitle = Text;
            roomNameBackground = roomName.BackColor;
            LoadRecents();
            if (File.Exists(defaultFileName)) {
                try {
                    DeserializeHome(defaultFileName);
                } catch (Exception exception) {
                    MessageBox.Show("Invalid XML file.\nError: " + exception.Message, "Error");
                }
            }
            LoadConfiguration();
            Rule.OnNotification += SendAlert;
            ruleEngineTicker.Tick += RuleTick;
            ruleEngineTicker.Start();
#if DEBUG
            simulator.Visible = true;
            spoofSensor.Visible = true;
            spoofDoor.Visible = true;
            openDebugger.Visible = true;
#endif
            MQTT = new MQTTHandler(Config.MQTTHost, Config.MQTTPort, Config.MQTTUser, Config.MQTTPass);
            loading.Close();
        }

        /// <summary>
        /// Auto-save and export logs on close.
        /// </summary>
        private void HomeEditor_FormClosed(object sender, FormClosedEventArgs e) {
            ruleEngineTicker.Stop();
            ruleEngineTicker.Dispose();
            MQTT.Disconnect();
            SerializeHome(defaultFileName);
            try {
                if (!Directory.Exists("Logs"))
                    Directory.CreateDirectory("Logs");
                if (!LogViewer.IsEmpty)
                    File.WriteAllText("Logs/" + DateTime.Now.ToString().Replace(':', '-') + ".txt", LogViewer.GetLog());
            } catch { }
        }

        /// <summary>
        /// Open and fill the room settings panel for a given <see cref="Room"/>.
        /// </summary>
        /// <param name="target">The room to configure</param>
        void ShowRoomPanel(Room target) {
            roomName.Text = target.Name;
            roomWidth.Value = target.Width / Room.PixelsPerMeter;
            roomHeight.Value = target.Height / Room.PixelsPerMeter;
            roomSettings.Visible = true;
        }

        /// <summary>
        /// Open and fill the corresponding settings panel for a <see cref="SerializablePanel"/>.
        /// </summary>
        internal void SelectObject(SerializablePanel target) {
            DeselectEverything();
            selection = target;
            target.OnSelect();
            switch (target) {
                case Room room:
                    ShowRoomPanel(room);
                    break;
                case Obstacle obstacle:
                    obstacleName.Text = target.Name;
                    obstacleSettings.Visible = true;
                    break;
                case Sensor sensor:
                    selection = target;
                    ShowRoomPanel((Room)target.Parent);
                    sensorName.Text = sensor.Name;
                    sensorAddress.Text = sensor.Address;
                    sensorSettings.Visible = true;
                    break;
                case Door door:
                    switch (door.DoorType) {
                        case DoorTypes.Door: doorDoor.Checked = true; break;
                        case DoorTypes.Entrance: doorEntrance.Checked = true; break;
                        case DoorTypes.Window: doorWindow.Checked = true; break;
                        default: break;
                    }
                    doorHorizontal.Checked = door.Orientation == Door.Orientations.Horizontal;
                    doorVertical.Checked = door.Orientation == Door.Orientations.Vertical;
                    doorSize.Value = door.Size;
                    doorSettings.Visible = true;
                    bool hasSensor = door.AttachedSensor != null;
                    doorSensorAttached.Checked = hasSensor;
                    doorSensorAddress.Enabled = hasSensor;
                    doorSensorAddress.Text = hasSensor ? door.AttachedSensor.Address : string.Empty;
                    break;
            }
        }

        /// <summary>
        /// Clear the selection of any <see cref="SerializablePanel"/>.
        /// </summary>
        void DeselectEverything() {
            if (selection != null) {
                selection.OnDeselect();
                selection = null;
            }
            roomSettings.Visible = false;
            obstacleSettings.Visible = false;
            sensorSettings.Visible = false;
            doorSettings.Visible = false;
        }

        /// <summary>
        /// Clear the selection when clicking the background of the home editor.
        /// </summary>
        void DrawingPanel_Click(object sender, EventArgs e) => DeselectEverything();

        /// <summary>
        /// Locate the user in the home by selecting the last activated sensor's parent.
        /// </summary>
        void Locate_Click(object sender, EventArgs e) {
            if (Sensor.LastLocation != null)
                SelectObject(Sensor.LastLocation);
        }

        /// <summary>
        /// Open the MQTT Debugger window.
        /// </summary>
        void OpenDebugger_Click(object sender, EventArgs e) => new MQTTDebugger(MQTT).Show();

        /// <summary>
        /// Open the Log Viewer when clicking on the status strip.
        /// </summary>
        void StatusStrip_MouseClick(object sender, MouseEventArgs e) {
            StatusStrip.BackColor = DefaultBackColor;
            new LogViewer().Show();
        }

        /// <summary>
        /// Delete the selected <see cref="SerializablePanel"/>.
        /// </summary>
        void Delete_Click(object sender, EventArgs e) {
            selection.DisconnectFromParent();
            DeselectEverything();
        }

        /// <summary>
        /// Create or load the configuration file.
        /// </summary>
        void LoadConfiguration() {
            if (!File.Exists("config.cfg"))
                File.WriteAllText("config.cfg", defaultConfig);
            if (File.Exists("config.cfg")) {
                string[] config = File.ReadAllLines("config.cfg");
                int splitter;
                for (int line = 0, count = config.Length; line < count; ++line) {
                    if ((splitter = config[line].IndexOf('#')) >= 0)
                        config[line] = config[line].Substring(0, splitter);
                    if ((splitter = config[line].IndexOf('=')) >= 0) {
                        string path = config[line].Substring(0, splitter);
                        string value = config[line].Substring(splitter + 1).Trim();
                        if ((splitter = path.LastIndexOf('.')) >= 0) {
                            string type = path.Substring(0, splitter).Trim();
                            Type t = Type.GetType(type);
                            if (t == null) {
                                MessageBox.Show("Type " + t + " does not exist.");
                                continue;
                            }
                            FieldInfo field = t.GetField(path.Substring(splitter + 1).Trim());
                            if (field.FieldType == typeof(string))
                                field.SetValue(null, value);
                            else if (field.FieldType == typeof(int)) {
                                if (int.TryParse(value, out int intValue))
                                    field.SetValue(null, intValue);
                                else
                                    MessageBox.Show("Failed to parse value:" + Environment.NewLine + config[line]);
                            } else if (field.FieldType == typeof(float)) {
                                if (float.TryParse(value, out float floatValue))
                                    field.SetValue(null, floatValue);
                                else
                                    MessageBox.Show("Failed to parse value:" + Environment.NewLine + config[line]);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Default configuration file contents.
        /// </summary>
        static string defaultConfig = @"MQTT configuration
HomeEditor.Config.MQTTHost = hostname.com
HomeEditor.Config.MQTTPort = 1883
HomeEditor.Config.MQTTUser = username
HomeEditor.Config.MQTTPass = password
Mail configuration
HomeEditor.Alert.SMTPHost = smtp.gmail.com
HomeEditor.Alert.SMTPPort = 587
HomeEditor.Alert.Address = user@gmail.com
HomeEditor.Alert.Password = password ; For Gmail with 2FA, ask for one at https://myaccount.google.com/apppasswords";
    }
}