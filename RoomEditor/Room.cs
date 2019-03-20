using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace HomeEditor {
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
        /// Name of the room.
        /// </summary>
        Label name;

        /// <summary>
        /// A room in the home.
        /// </summary>
        /// <param name="parent">Containing Control</param>
        public Room(Control parent) : base(parent) {
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
        public bool IsLobby {
            get {
                foreach (SerializablePanel panel in Program.window.Elements)
                    if (panel.DoorType == (int)Door.Types.Entrance && Utils.Intersect(panel, this))
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
                Left = (Left + e.X - dragOrigin.X) / PixelsPerMeter * PixelsPerMeter - ((Panel)parent).HorizontalScroll.Value % PixelsPerMeter;
                Top = (Top + e.Y - dragOrigin.Y) / PixelsPerMeter * PixelsPerMeter - ((Panel)parent).VerticalScroll.Value % PixelsPerMeter;
            }
        }

        /// <summary>
        /// Call an action for all sensors in this room.
        /// </summary>
        void ForEachSensor(Action<Sensor> action) {
            foreach (Control child in Controls)
                if (child is Sensor)
                    action.Invoke((Sensor)child);
        }

        /// <summary>
        /// Merges data from all sensors in the room, averaging available float values and or-ing bool values.
        /// Data older than 5 minutes won't count, as the sensor's battery has probably died.
        /// </summary>
        public SensorData RoomStatus() {
            TimeSpan maxDiff = TimeSpan.FromMinutes(5);
            DateTime lastResult = DateTime.Now - maxDiff;
            ForEachSensor((sensor) => {
                if (lastResult < sensor.lastActivation)
                    lastResult = sensor.lastActivation;
            });
            SensorData result = new SensorData(lastResult);
            lastResult -= maxDiff;
            ForEachSensor((sensor) => {
                if (lastResult < sensor.lastActivation) {
                    SensorData lastEntry = sensor.DataHistory[sensor.DataHistory.Count - 1];
                    result.Movement |= lastEntry.Movement;
                }
            });
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
                    case "left": Left = Convert.ToInt32(reader.Value); break;
                    case "top": Top = Convert.ToInt32(reader.Value); break;
                    case "size_x": Width = Convert.ToInt32(reader.Value); break;
                    case "size_y": Height = Convert.ToInt32(reader.Value); break;
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
            ForEachSensor((sensor) => {
                writer.WriteStartElement("Sensor");
                sensor.WriteXml(writer);
                writer.WriteEndElement();
            });
        }
        #endregion
    }
}