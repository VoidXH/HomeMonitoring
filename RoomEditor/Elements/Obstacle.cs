using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace HomeEditor.Elements {
    /// <summary>
    /// Renamable obstacle in the home.
    /// </summary>
    [Serializable]
    public class Obstacle : SerializablePanel {
        public static Color
            BaseColor = Color.Blue,
            SelectionColor = Color.Green;

        /// <summary>
        /// Name of the obstacle.
        /// </summary>
        Label name;

        /// <summary>
        /// An X marking the obstacle's position.
        /// </summary>
        Label marker;

        /// <summary>
        /// Renamable obstacle in the home.
        /// </summary>
        /// <param name="parent">Containing panel</param>
        public Obstacle(Panel parent) : base(parent) {
            color = new ColorStack(BaseColor, SelectionColor, Color.Red);
            // Add name label
            name = new Label {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            SetName("New obstacle");
            Controls.Add(name);
            // Marker label
            marker = new Label {
                AutoSize = false,
                Dock = DockStyle.Left,
                Size = new Size(Room.PixelsPerMeter, Room.PixelsPerMeter),
                Text = "×",
                TextAlign = ContentAlignment.MiddleCenter
            };
            marker.Font = new Font(marker.Font.FontFamily, 16);
            Controls.Add(marker);
            // Set mouse behaviour (on both labels, because they're on top)
            SetDraggable(name);
            SetDraggable(marker);
            // Design
            ForeColor = BaseColor;
            Size = new Size(125, 25);
            BringToFront(); // Obstacles are always above rooms
        }

        /// <summary>
        /// Rename the obstacle.
        /// </summary>
        public void SetName(string newName) => Name = name.Text = newName;

        /// <summary>
        /// Apply a new color or a new state's color.
        /// </summary>
        protected override void Repaint() => ForeColor = color.GetColor();

        #region Serialization
        public override void ReadXml(XmlReader reader) {
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
                }
            }
        }

        public override void WriteXml(XmlWriter writer) {
            writer.WriteAttributeString("name", Name);
            writer.WriteAttributeString("left", Left.ToString());
            writer.WriteAttributeString("top", Top.ToString());
        }
        #endregion
    }
}