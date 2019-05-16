using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace HomeEditor.Elements {
    /// <summary>
    /// A room in the home.
    /// </summary>
    [Serializable]
    public class Room : SerializablePanel {
        public static Color
            BaseColor = DefaultBackColor,
            SelectionColor = Color.LightGreen,
            ActivationColor = Color.Khaki;

        /// <summary>
        /// How many pixels are representing a meter.
        /// </summary>
        public const int PixelsPerMeter = 25;

        /// <summary>
        /// <see cref="RoomStatus"/> history.
        /// </summary>
        readonly List<SensorData> history = new List<SensorData>();

        /// <summary>
        /// Read-only list of <see cref="RoomStatus"/> history.
        /// </summary>
        public virtual IReadOnlyList<SensorData> DataHistory => history;

        /// <summary>
        /// Name of the room.
        /// </summary>
        Label name;

        /// <summary>
        /// A room in the home.
        /// </summary>
        /// <param name="parent">Containing panel</param>
        public Room(Panel parent) : base(parent) {
            color = new ColorStack(BaseColor, SelectionColor, ActivationColor);
            // Add name label
            name = new Label {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            SetName("New room");
            Controls.Add(name);
            // Set mouse behaviour (on the filling label, because that's on top)
            SetDraggable(name);
            // Design
            BorderStyle = BorderStyle.FixedSingle;
            Size = new Size(5 * PixelsPerMeter, 5 * PixelsPerMeter);
            SendToBack(); // Rooms are always behind every other object
        }

        /// <summary>
        /// This room is a lobby if an entrance intersects with it.
        /// </summary>
        public virtual bool IsLobby {
            get {
                if (Parent != null) // Virtual rooms don't intersect with anything, but their virtual boundaries could
                    foreach (SerializablePanel panel in Program.window.Elements)
                        if (panel is Door && ((Door)panel).DoorType == DoorTypes.Entrance && Utils.Intersect(panel, this))
                            return true;
                return false;
            }
        }

        /// <summary>
        /// Rename the room.
        /// </summary>
        public void SetName(string newName) {
            Name = newName;
            name.Text = newName;
        }

        /// <summary>
        /// Snap to a grid with 1 meter gaps when moved.
        /// </summary>
        protected override void Draggable_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) { // TODO: don't jump on click
                Left = (Left + e.X - dragOrigin.X) / PixelsPerMeter * PixelsPerMeter - ((Panel)Parent).HorizontalScroll.Value % PixelsPerMeter;
                Top = (Top + e.Y - dragOrigin.Y) / PixelsPerMeter * PixelsPerMeter - ((Panel)Parent).VerticalScroll.Value % PixelsPerMeter;
            }
        }

        /// <summary>
        /// Calculates the sum of float type sensor data.
        /// </summary>
        void SumFloat(ref int count, ref float sum, float value) {
            if (value != SensorData.Unmeasured) {
                ++count;
                sum += value;
            }
        }

        /// <summary>
        /// Keep the latest date of the two values in <paramref name="value"/>.
        /// </summary>
        void MaxDate(ref DateTime value, DateTime newValue) {
            if (value < newValue)
                value = newValue;
        }

        /// <summary>
        /// Keep the lowest of the two values in <paramref name="min"/>.
        /// </summary>
        void MinFloat(ref float min, float value) {
            if (min > value)
                min = value;
        }

        /// <summary>
        /// Merges data from all sensors in the room, averaging available float values and or-ing bool values.
        /// Data older than 5 minutes won't count, as the sensor's battery has probably died.
        /// </summary>
        SensorData RoomStatus() {
            TimeSpan maxDiff = TimeSpan.FromMinutes(5);
            DateTime lastResult = DateTime.MinValue + maxDiff;
            Sensor.ForEachWithHistory(this, lastResult, sensor => MaxDate(ref lastResult, sensor.LastEntry.Timestamp));
            Sensor.ForEachDoorWithHistory(this, lastResult, sensor => MaxDate(ref lastResult, sensor.LastEntry.Timestamp));
            lastResult -= maxDiff;
            SensorData result = new SensorData(lastResult);
            foreach (PropertyInfo property in typeof(SensorData).GetProperties()) {
                if (property.Name.Equals("Battery")) {
                    float min = 100;
                    Sensor.ForEachWithHistory(this, lastResult, sensor => MinFloat(ref min, (float)property.GetValue(sensor.LastEntry)));
                    Sensor.ForEachDoorWithHistory(this, lastResult, sensor => MinFloat(ref min, (float)property.GetValue(sensor.LastEntry)));
                    property.SetValue(result, min);
                } else if (property.PropertyType == typeof(bool)) {
                    bool value = false;
                    Sensor.ForEachWithHistory(this, lastResult, sensor => value |= (bool)property.GetValue(sensor.LastEntry));
                    Sensor.ForEachDoorWithHistory(this, lastResult, sensor => value |= (bool)property.GetValue(sensor.LastEntry));
                    property.SetValue(result, value);
                } else if (property.PropertyType == typeof(float)) {
                    float sum = 0;
                    int measurements = 0;
                    Sensor.ForEachWithHistory(this, lastResult, sensor => SumFloat(ref measurements, ref sum,
                        (float)property.GetValue(sensor.LastEntry)));
                    Sensor.ForEachDoorWithHistory(this, lastResult, sensor => SumFloat(ref measurements, ref sum,
                        (float)property.GetValue(sensor.LastEntry)));
                    property.SetValue(result, measurements != 0 ? sum / measurements : SensorData.Unmeasured);
                }
            }
            return result;
        }

        public void DataReceived() {
            DateTime lastKeptEntry = DateTime.Now - TimeSpan.FromDays(2);
            int removeUntil = 0;
            while (removeUntil != history.Count && history[removeUntil].Timestamp < lastKeptEntry)
                ++removeUntil;
            history.RemoveRange(0, removeUntil);
            history.Add(RoomStatus());
        }

        public static void ForEach(Action<Room> action) {
            foreach (SerializablePanel panel in Program.window.Elements)
                if (panel is Room)
                    action((Room)panel);
        }

        public static void ForEachWithHistory(Action<Room> action) {
            foreach (SerializablePanel panel in Program.window.Elements)
                if (panel is Room && ((Room)panel).history.Count != 0)
                    action((Room)panel);
        }

        public static Room GetByName(string name) {
            foreach (SerializablePanel panel in Program.window.Elements)
                if (panel is Room && panel.Name.Equals(name))
                    return (Room)panel;
            return null;
        }

        #region Serialization
        public override void ReadXml(XmlReader reader) {
            reader = reader.ReadSubtree();
            while (reader.NodeType != XmlNodeType.Element)
                reader.Read(); // ReadSubtree does not always return the beginning of the subtree
            while (reader.MoveToNextAttribute()) {
                switch (reader.Name) {
                    case "name": SetName(reader.Value); break;
                    case "left":
                        if (Utils.ParseProperty(reader.Value, out int left))
                            Left = left;
                        break;
                    case "top":
                        if (Utils.ParseProperty(reader.Value, out int top))
                            Top = top;
                        break;
                    case "size_x":
                        if (Utils.ParseProperty(reader.Value, out int size_x))
                            Width = size_x;
                        break;
                    case "size_y":
                        if (Utils.ParseProperty(reader.Value, out int size_y))
                            Height = size_y;
                        break;
                }
            }
            while (reader.Read()) {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Sensor") {
                    Sensor newSensor = new Sensor(this);
                    newSensor.ReadXml(reader);
                }
            }
            reader.Close();
        }

        public override void WriteXml(XmlWriter writer) {
            writer.WriteAttributeString("name", Name);
            writer.WriteAttributeString("left", Left.ToString());
            writer.WriteAttributeString("top", Top.ToString());
            writer.WriteAttributeString("size_x", Width.ToString());
            writer.WriteAttributeString("size_y", Height.ToString());
            Sensor.ForEach(this, sensor => Utils.SerializeObject(writer, sensor));
        }
        #endregion
    }
}