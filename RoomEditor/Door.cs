using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace HomeEditor {
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
        /// Possible types of openable entities.
        /// </summary>
        public enum Types {
            Door, Entrance, Window
        }

        /// <summary>
        /// This entity's type.
        /// </summary>
        public Types doorType;

        /// <summary>
        /// Door type as int.
        /// </summary>
        public override int DoorType => (int)doorType;

        /// <summary>
        /// Possible orientations.
        /// </summary>
        public enum Orientations {
            Horizontal, Vertical
        }

        /// <summary>
        /// Cached orientation.
        /// </summary>
        Orientations _Orientation;

        /// <summary>
        /// Orientation, resizes the panel on change.
        /// </summary>
        public Orientations Orientation {
            get => _Orientation;
            set {
                int currentSize = Size;
                _Orientation = value;
                Size = currentSize;
            }
        }

        /// <summary>
        /// Width in pixels, relative to the <see cref="Orientation"/>.
        /// </summary>
        public new int Size {
            get => _Orientation == Orientations.Horizontal ? base.Size.Width : base.Size.Height;
            set => base.Size = _Orientation == Orientations.Horizontal ? new Size(value, Thickness) : new Size(Thickness, value);
        }

        /// <summary>
        /// The sensor on this entity if available.
        /// </summary>
        public Sensor AttachedSensor = null;

        /// <summary>
        /// An openable entity, like a door, entrance, or window.
        /// </summary>
        /// <param name="parent">Containing Control</param>
        public Door(Control parent) : base(parent) {
            color = new ColorStack(BaseDoorColor, SelectionColor, ActivationColor);
            SetDraggable(this);
            BorderStyle = BorderStyle.FixedSingle;
            OnDeselect();
            Size = Room.PixelsPerMeter;
            BringToFront(); // Windows are always above rooms
        }

        /// <summary>
        /// Set color by type when deselected.
        /// </summary>
        public override void OnDeselect() {
            switch (doorType) {
                case Types.Door: color.Base = BaseDoorColor; break;
                case Types.Entrance: color.Base = BaseEntranceColor; break;
                case Types.Window: color.Base = BaseWindowColor; break;
            }
            base.OnDeselect();
        }

        /// <summary>
        /// Snap to the orientation's lines when moved.
        /// </summary>
        protected override void Draggable_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                if (_Orientation == Orientations.Horizontal) {
                    Left += e.X - dragOrigin.X;
                    Top = ((Top + e.Y - dragOrigin.Y) / Room.PixelsPerMeter + 1) * Room.PixelsPerMeter - Thickness / 2
                        - ((Panel)parent).VerticalScroll.Value % Room.PixelsPerMeter;
                } else {
                    Left = ((Left + e.X - dragOrigin.X) / Room.PixelsPerMeter + 1) * Room.PixelsPerMeter - Thickness / 2
                        - ((Panel)parent).HorizontalScroll.Value % Room.PixelsPerMeter;
                    Top += e.Y - dragOrigin.Y;
                }
            }
        }

        #region Serialization
        public override void ReadXml(XmlReader reader) {
            while (reader.MoveToNextAttribute()) {
                switch (reader.Name) {
                    case "type": doorType = (Types)Convert.ToInt32(reader.Value); OnDeselect(); break;
                    case "orientation": Orientation = (Orientations)Convert.ToInt32(reader.Value); break;
                    case "size": Size = Convert.ToInt32(reader.Value); break;
                    case "left": Left = Convert.ToInt32(reader.Value); break;
                    case "top": Top = Convert.ToInt32(reader.Value); break;
                    case "attached": if (Convert.ToBoolean(reader.Value)) AttachedSensor = new Sensor(this) { Visible = false }; break;
                    case "sensor": if (AttachedSensor != null) AttachedSensor.Address = reader.Value; break;
                }
            }
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