using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace HomeEditor.Elements {
    /// <summary>
    /// A sensor in a room.
    /// </summary>
    public class Sensor : SerializablePanel {
        public static int ActivationHistoryLength = 10;
        public static Color
            BaseColor = Color.Blue,
            SelectionColor = Color.Green,
            ActivationColor = Color.OrangeRed;

        /// <summary>
        /// Default sensor width and height.
        /// </summary>
        const int SensorSize = Room.PixelsPerMeter;

        /// <summary>
        /// List of all sensors in the home.
        /// </summary>
        static List<Sensor> sensors = new List<Sensor>();

        /// <summary>
        /// History of the last sensor activations.
        /// </summary>
        static List<Sensor> activations = new List<Sensor>();

        /// <summary>
        /// History of the last sensor activations.
        /// </summary>
        public static IReadOnlyList<Sensor> History => activations;

        /// <summary>
        /// Last activated sensor.
        /// </summary>
        public static SerializablePanel LastLocation { get; private set; }

        /// <summary>
        /// Address of the sensor.
        /// </summary>
        public string Address = string.Empty;

        /// <summary>
        /// Last activation time.
        /// </summary>
        public DateTime lastActivation = DateTime.Now;

        /// <summary>
        /// Measured sensor data.
        /// </summary>
        readonly List<SensorData> history = new List<SensorData>();

        /// <summary>
        /// Read-only list of measured sensor data.
        /// </summary>
        public IReadOnlyList<SensorData> DataHistory => history;

        /// <summary>
        /// An "O" marking the sensor.
        /// </summary>
        Label marker;

        /// <summary>
        /// Sensor name that appears in the log.
        /// </summary>
        public string LogName => Name.Equals(string.Empty) ? Address : Name + " (" + Address + ')';

        /// <summary>
        /// Should only be called on reset, clears the list of sensors in the home.
        /// </summary>
        public static void ClearSensorList() => sensors.Clear();

        /// <summary>
        /// Apply a new color or a new state's color.
        /// </summary>
        protected override void Repaint() => marker.ForeColor = color.GetColor();

        /// <summary>
        /// A sensor in a room.
        /// </summary>
        /// <param name="parent">Containing element</param>
        public Sensor(SerializablePanel parent) : base(parent) {
            color = new ColorStack(BaseColor, SelectionColor, ActivationColor);
            // Marker label
            marker = new Label {
                AutoSize = false,
                ForeColor = Color.Gray,
                Dock = DockStyle.Fill,
                Size = new Size(SensorSize, SensorSize),
                Text = "O",
                TextAlign = ContentAlignment.MiddleCenter
            };
            marker.Font = new Font(marker.Font.FontFamily, SensorSize / 2);
            Controls.Add(marker);
            // Set mouse behaviour (on the filling label, because that's on top)
            SetDraggable(marker);
            // Design
            Repaint();
            Size = new Size(25, 25);
            BringToFront(); // Sensors are always above every other object
            sensors.Add(this);
        }

        /// <summary>
        /// New sensor data received.
        /// </summary>
        public void DataReceived(SensorData data) {
            if (history.Count > 0) {
                data.FillFrom(history[history.Count - 1]);
                DateTime yesterday = DateTime.Now - TimeSpan.FromDays(1);
                int removeUntil = 0;
                while (removeUntil != history.Count && history[removeUntil].Timestamp < yesterday)
                    ++removeUntil;
                history.RemoveRange(0, removeUntil);
            }
            if (Parent is Room)
                ((Room)Parent).DataReceived();
            Program.window.Invoke(new Action(() => { Program.window.toolTip.SetToolTip(marker, data.ToString()); }));
            history.Add(data);
            bool activate = data.Open || data.Movement;
            if (activate && !color.Activation)
                OnActivate();
            else if (!activate && color.Activation)
                OnDeactivate();
            Repaint();
        }

        /// <summary>
        /// Send incoming data to the corresponding sensor.
        /// </summary>
        public static void ForwardData(string address, SensorData data) => ForEach((sensor) => {
            if (sensor.Address.Equals(address))
                sensor.DataReceived(data);
        });

        /// <summary>
        /// Send an alert from the sensor where the button was pressed.
        /// </summary>
        public static void ForwardButton(string address) => ForEach((sensor) => {
            if (sensor.Address.Equals(address))
                Alert.SendAlert(sensor, "Button pressed.");
        });

        /// <summary>
        /// Set color when activated.
        /// </summary>
        public override void OnActivate() {
            base.OnActivate();
            lastActivation = DateTime.Now;
            LastLocation = (SerializablePanel)Parent;
            LastLocation.OnActivate();
            if (activations.Count == 0 || activations[activations.Count - 1] != this) {
                activations.Add(this);
                if (activations.Count >= ActivationHistoryLength)
                    activations = activations.GetRange(activations.Count - ActivationHistoryLength, ActivationHistoryLength);
            }
        }

        /// <summary>
        /// Set color when deactivated.
        /// </summary>
        public override void OnDeactivate() {
            base.OnDeactivate();
            ((SerializablePanel)Parent).OnDeactivate();
        }

        /// <summary>
        /// Remove the sensor from the home.
        /// </summary>
        public override void DisconnectFromParent() {
            sensors.Remove(this);
            base.DisconnectFromParent();
        }

        /// <summary>
        /// Select both the sensor and the containing room when selected.
        /// </summary>
        public override void OnSelect() {
            ((SerializablePanel)Parent).OnSelect();
            base.OnSelect();
        }

        /// <summary>
        /// Deselect both the sensor and the containing room when deselected.
        /// </summary>
        public override void OnDeselect() {
            ((SerializablePanel)Parent).OnDeselect();
            base.OnDeselect();
        }

        /// <summary>
        /// Limit the sensor's location in the room's boundaries.
        /// </summary>
        protected override void Draggable_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                Left = Utils.Clamp(Left + e.X - dragOrigin.X, 0, Parent.Width - SensorSize);
                Top = Utils.Clamp(Top + e.Y - dragOrigin.Y, 0, Parent.Height - SensorSize);
            }
        }

        #region List handling
        public static Sensor Random => sensors[new Random().Next(sensors.Count)];

        public static void ForEach(Action<Sensor> action) {
            foreach (Sensor sensor in sensors)
                action.Invoke(sensor);
        }

        public static void ForEach(Room room, Action<Sensor> action) {
            foreach (Control child in room.Controls)
                if (child is Sensor)
                    action.Invoke((Sensor)child);
        }

        public static void ForEachDoor(Room room, Action<Door, Sensor> action) {
            foreach (SerializablePanel panel in Program.window.Elements) {
                if (Utils.Intersect(room, panel) && panel.DoorType != DoorTypes.NotDoor) {
                    Sensor sensor = ((Door)panel).AttachedSensor;
                    if (sensor != null)
                        action.Invoke((Door)panel, sensor);
                }
            }
        }

        public static void ForEachWithHistory(Action<Sensor> action) {
            foreach (Sensor sensor in sensors)
                if (sensor.DataHistory.Count != 0)
                    action.Invoke(sensor);
        }

        public static void ForEachWithHistory(Room room, DateTime after, Action<Sensor> action) {
            foreach (Control child in room.Controls)
                if (child is Sensor && ((Sensor)child).DataHistory.Count != 0 && after < ((Sensor)child).lastActivation)
                    action.Invoke((Sensor)child);
        }

        public static void ForEachDoorWithHistory(Room room, DateTime after, Action<Sensor> action) {
            foreach (SerializablePanel panel in Program.window.Elements) {
                if (panel.DoorType != DoorTypes.NotDoor && Utils.Intersect(room, panel)) {
                    Sensor sensor = ((Door)panel).AttachedSensor;
                    if (sensor != null && sensor.DataHistory.Count != 0 && after < sensor.lastActivation)
                        action.Invoke(sensor);
                }
            }
        }
        #endregion

        #region Serialization
        public override void ReadXml(XmlReader reader) {
            while (reader.MoveToNextAttribute()) {
                switch (reader.Name) {
                    case "name": Name = reader.Value; break;
                    case "address": Address = reader.Value; break;
                    case "left":
                        if (Utils.ParseProperty(reader.Value, out int left))
                            Left = left;
                        break;
                    case "top":
                        if (Utils.ParseProperty(reader.Value, out int top))
                            Top = top;
                        break;
                }
            }
        }

        public override void WriteXml(XmlWriter writer) {
            writer.WriteAttributeString("name", Name);
            writer.WriteAttributeString("address", Address);
            writer.WriteAttributeString("left", Left.ToString());
            writer.WriteAttributeString("top", Top.ToString());
        }
        #endregion
    }
}