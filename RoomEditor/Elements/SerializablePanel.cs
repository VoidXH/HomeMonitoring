using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace HomeEditor.Elements {
    /// <summary>
    /// An object in the home which could be imported and exported.
    /// </summary>
    [Serializable]
    public abstract class SerializablePanel : Panel, IXmlSerializable {
        /// <summary>
        /// The Control containing this Panel.
        /// </summary>
        public Control parent { get; private set; }

        /// <summary>
        /// Colors of this Panel by state.
        /// </summary>
        protected ColorStack color;

        /// <summary>
        /// Apply a new color or a new state's color.
        /// </summary>
        protected virtual void Repaint() => BackColor = color.GetColor();

        /// <summary>
        /// An object in the home which could be imported and exported.
        /// </summary>
        /// <param name="parent">Containing Control</param>
        public SerializablePanel(Control parent) : base() {
            if (parent != null) {
                parent.Controls.Add(this);
                this.parent = parent;
            }
        }

        /// <summary>
        /// Remove this object from the home.
        /// </summary>
        public virtual void DisconnectFromParent() => parent.Controls.Remove(this);

        #region Selection
        /// <summary>
        /// Called when the panel is selected.
        /// </summary>
        public virtual void OnSelect() {
            color.Selection = true;
            Repaint();
        }

        /// <summary>
        /// Called when the panel is not selected anymore.
        /// </summary>
        public virtual void OnDeselect() {
            color.Selection = false;
            Repaint();
        }

        /// <summary>
        /// Called when the panel is activated by a sensor.
        /// </summary>
        public virtual void OnActivate() {
            color.Activation = true;
            Repaint();
        }

        /// <summary>
        /// Called when the panel is deactivated by a sensor.
        /// </summary>
        public virtual void OnDeactivate() {
            color.Activation = false;
            Repaint();
        }
        #endregion

        #region Serialization
        public XmlSchema GetSchema() => null;

        /// <summary>
        /// Import the Panel from an XML file.
        /// </summary>
        public abstract void ReadXml(XmlReader reader);

        /// <summary>
        /// Export the Panel to an XML file.
        /// </summary>
        public abstract void WriteXml(XmlWriter writer);
        #endregion

        #region Dragging with mouse
        /// <summary>
        /// The position where the dragging started.
        /// </summary>
        protected Point dragOrigin;

        /// <summary>
        /// Cache the start position of the dragging.
        /// </summary>
        protected void Draggable_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                dragOrigin = e.Location;
                Program.window.SelectObject(this);
            }
        }

        /// <summary>
        /// Move the object when dragged by the mouse.
        /// </summary>
        protected virtual void Draggable_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                Left += e.X - dragOrigin.X;
                Top += e.Y - dragOrigin.Y;
            }
        }

        /// <summary>
        /// Make the target Panel draggable.
        /// </summary>
        protected void SetDraggable(Control target) {
            target.MouseDown += Draggable_MouseDown;
            target.MouseMove += Draggable_MouseMove;
        }
        #endregion

        #region Checks
        /// <summary>
        /// This entity's door type.
        /// </summary>
        public virtual Door.Types DoorType {
            get => Door.Types.NotDoor;
            set { }
        }
        #endregion
    }
}