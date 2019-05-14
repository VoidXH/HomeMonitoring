using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace HomeEditor.Elements {
    /// <summary>
    /// Possible types of openable entities.
    /// </summary>
    public enum DoorTypes {
        Door, Entrance, Window
    }

    /// <summary>
    /// An openable entity in the home, like a door, entrance, or window.
    /// </summary>
    public class Door : SerializablePanel {
        const int Thickness = 8;

        public static Color
            BaseDoorColor = Color.LightBlue,
            BaseEntranceColor = Color.LightSalmon,
            BaseWindowColor = Color.LightYellow,
            SelectionColor = Color.LightGreen,
            ActivationColor = Color.Khaki;

        /// <summary>
        /// Actual value of <see cref="DoorType"/>.
        /// </summary>
        DoorTypes doorType = DoorTypes.Door;

        /// <summary>
        /// This door's type.
        /// </summary>
        public DoorTypes DoorType {
            get => doorType;
            set {
                switch (doorType = value) {
                    case DoorTypes.Door: color.Base = BaseDoorColor; break;
                    case DoorTypes.Entrance: color.Base = BaseEntranceColor; break;
                    case DoorTypes.Window: color.Base = BaseWindowColor; break;
                    default: break;
                }
            }
        }

        /// <summary>
        /// Possible orientations.
        /// </summary>
        public enum Orientations {
            Horizontal, Vertical
        }

        /// <summary>
        /// Actual value of <see cref="Orientation"/>.
        /// </summary>
        Orientations orientation;

        /// <summary>
        /// Orientation, resizes the panel on change.
        /// </summary>
        public Orientations Orientation {
            get => orientation;
            set {
                int currentSize = Size;
                orientation = value;
                Size = currentSize;
            }
        }

        /// <summary>
        /// Width in pixels, relative to the <see cref="Orientation"/>.
        /// </summary>
        public new int Size {
            get => orientation == Orientations.Horizontal ? base.Size.Width : base.Size.Height;
            set => base.Size = orientation == Orientations.Horizontal ? new Size(value, Thickness) : new Size(Thickness, value);
        }

        /// <summary>
        /// The sensor on this entity if available.
        /// </summary>
        public Sensor AttachedSensor = null;

        /// <summary>
        /// An openable entity, like a door, entrance, or window.
        /// </summary>
        /// <param name="parent">Containing panel</param>
        public Door(Panel parent) : base(parent) {
            color = new ColorStack(BaseDoorColor, SelectionColor, ActivationColor);
            SetDraggable(this);
            BorderStyle = BorderStyle.FixedSingle;
            OnDeselect();
            Size = Room.PixelsPerMeter;
            BringToFront(); // Windows are always above rooms
        }

        /// <summary>
        /// Snap to the orientation's lines when moved.
        /// </summary>
        protected override void Draggable_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                if (orientation == Orientations.Horizontal) {
                    Left += e.X - dragOrigin.X;
                    Top = ((Top + e.Y - dragOrigin.Y) / Room.PixelsPerMeter + 1) * Room.PixelsPerMeter - Thickness / 2
                        - ((Panel)Parent).VerticalScroll.Value % Room.PixelsPerMeter;
                } else {
                    Left = ((Left + e.X - dragOrigin.X) / Room.PixelsPerMeter + 1) * Room.PixelsPerMeter - Thickness / 2
                        - ((Panel)Parent).HorizontalScroll.Value % Room.PixelsPerMeter;
                    Top += e.Y - dragOrigin.Y;
                }
            }
        }

        #region Serialization
        public override void ReadXml(XmlReader reader) {
            string sensor = null;
            while (reader.MoveToNextAttribute()) {
                switch (reader.Name) {
                    case "type":
                        if (Utils.ParseProperty(reader.Value, out int type))
                            DoorType = (DoorTypes)type;
                        break;
                    case "orientation":
                        if (Utils.ParseProperty(reader.Value, out int orientation))
                            Orientation = (Orientations)orientation;
                        break;
                    case "size":
                        if (Utils.ParseProperty(reader.Value, out int size))
                            Size = size;
                        break;
                    case "left":
                        if (Utils.ParseProperty(reader.Value, out int left))
                            Left = left;
                        break;
                    case "top":
                        if (Utils.ParseProperty(reader.Value, out int top))
                            Top = top;
                        break;
                    case "attached":
                        if (Utils.ParseProperty(reader.Value, out bool attached) && attached)
                            AttachedSensor = new Sensor(this) { Visible = false };
                        break;
                    case "sensor":
                        sensor = reader.Value;
                        break;
                }
            }
            if (AttachedSensor != null && !string.IsNullOrEmpty(sensor))
                AttachedSensor.Address = sensor;
        }

        public override void WriteXml(XmlWriter writer) {
            writer.WriteAttributeString("type", ((int)doorType).ToString());
            writer.WriteAttributeString("orientation", ((int)Orientation).ToString());
            writer.WriteAttributeString("size", Size.ToString());
            writer.WriteAttributeString("left", Left.ToString());
            writer.WriteAttributeString("top", Top.ToString());
            writer.WriteAttributeString("attached", (AttachedSensor != null).ToString());
            writer.WriteAttributeString("sensor", AttachedSensor != null ? AttachedSensor.Address : string.Empty);
        }
        #endregion
    }
}