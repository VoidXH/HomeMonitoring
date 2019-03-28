using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using HomeEditor.Events;

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
        /// Event tick timer.
        /// </summary>
        Timer eventTimer;

        /// <summary>
        /// List of parent elements (rooms, doors, and obstacles) in the house.
        /// </summary>
        public IReadOnlyList<SerializablePanel> Elements => drawingPanel.Controls.OfType<SerializablePanel>().ToList();

        /// <summary>
        /// Main window of the application.
        /// </summary>
        public HomeEditor() {
            Form loading = new Loading();
            loading.Show();
            loading.Refresh();
            InitializeComponent();
            defaultTitle = Text;
            LoadRecents();
            if (File.Exists(defaultFileName)) {
                try {
                    DeserializeHome(defaultFileName);
                } catch (Exception exception) {
                    MessageBox.Show("Invalid XML file.\nError: " + exception.Message, "Error");
                }
            }
            LoadConfiguration();
            Event.RegisterEvents();
            eventTimer = new Timer {
                Enabled = true,
                Interval = 1000
            };
            eventTimer.Tick += EventTick;
#if DEBUG
            simulator.Visible = true;
            spoofSensor.Visible = true;
            spoofDoor.Visible = true;
            openDebugger.Visible = true;
#endif
            MQTT = new MQTTHandler();
            loading.Close();
        }

        /// <summary>
        /// Event handler timer function.
        /// </summary>
        private void EventTick(object sender, EventArgs e) => Event.Tick();

        /// <summary>
        /// Auto-save and export logs on close.
        /// </summary>
        private void HomeEditor_FormClosed(object sender, FormClosedEventArgs e) {
            eventTimer.Stop();
            eventTimer.Dispose();
            MQTT.Disconnect();
            SerializeHome(defaultFileName);
            if (!Directory.Exists("Logs"))
                Directory.CreateDirectory("Logs");
            File.WriteAllText("Logs/" + DateTime.Now.ToString().Replace(':', '-') + ".txt", LogViewer.GetLog());
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
                    ShowRoomPanel((Room)target.parent);
                    sensorName.Text = sensor.Name;
                    sensorAddress.Text = sensor.Address;
                    sensorSettings.Visible = true;
                    break;
                case Door door:
                    switch (door.doorType) {
                        case Door.Types.Door: doorDoor.Checked = true; break;
                        case Door.Types.Entrance: doorEntrance.Checked = true; break;
                        case Door.Types.Window: doorWindow.Checked = true; break;
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
            if (Sensor.LastLocation == null)
                return;
            if (Sensor.LastLocation is Room)
                SelectObject(Sensor.LastLocation);
            else {
                SerializablePanel LastRoom = Event.GetLastRoom();
                foreach (SerializablePanel target in drawingPanel.Controls) {
                    if (target is Room && target != LastRoom && Utils.Intersect(Sensor.LastLocation, target)) {
                        SelectObject(target);
                        break;
                    }
                }
            }
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
                    if ((splitter = config[line].IndexOf('#')) != -1)
                        config[line] = config[line].Substring(0, splitter);
                    if ((splitter = config[line].IndexOf('=')) != -1) {
                        string path = config[line].Substring(0, splitter);
                        string value = config[line].Substring(splitter + 1).Trim();
                        if ((splitter = path.LastIndexOf('.')) != -1) {
                            Type t = Type.GetType(path.Substring(0, splitter).Trim());
                            FieldInfo field = t.GetField(path.Substring(splitter + 1).Trim());
                            if (field.FieldType == typeof(string))
                                field.SetValue(null, value);
                            else if (field.FieldType == typeof(int))
                                field.SetValue(null, int.Parse(value));
                            else if (field.FieldType == typeof(float))
                                field.SetValue(null, float.Parse(value));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Default configuration file contents.
        /// </summary>
        static string defaultConfig = @"MQTT configuration
HomeEditor.MQTTHandler.MQTTHost = hostname.com
HomeEditor.MQTTHandler.MQTTUser = username
HomeEditor.MQTTHandler.MQTTPass = password

Events
HomeEditor.Events.ConstantCooling.maximumTemp = 22 # Don't trigger alarms above this temperature
HomeEditor.Events.ConstantCooling.errorCooling = 10 # Degrees to cool in the given interval
HomeEditor.Events.ConstantCooling.errorInterval = 600 # Time span checked in seconds
HomeEditor.Events.DetectTV.noiseThresh = 1 # Minimum light noise required to trigger the alert
HomeEditor.Events.DetectTV.samples = 10 # Samples to check
HomeEditor.Events.IncorrectMovement.interval = 86400 # Interval to check for movement
HomeEditor.Events.IncorrectMovement.maxSilence = 1800 # Maximum time for anything not to happen to disarm the alert
HomeEditor.Events.Leaving.alertTimer = 300 # Alert after the entrance is open for longer than this time (in seconds) and the house is empty
HomeEditor.Events.OscillationError.errorRate = 10 # Amount of open/close events in the checking interval to trigger the alert
HomeEditor.Events.OscillationError.errorInterval = 60 # Time span checked in seconds
HomeEditor.Events.SleepDisorder.lightThreshold = 0,2 # Light value considered darkness";
    }
}