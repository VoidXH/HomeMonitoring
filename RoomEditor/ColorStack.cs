using System;
using System.Drawing;

namespace HomeEditor {
    /// <summary>
    /// Collects a Control's possible colors and selects one by its state.
    /// </summary>
    public struct ColorStack {
        /// <summary>
        /// Color when not selected nor activated.
        /// </summary>
        public Color Base;
        /// <summary>
        /// Color when selected.
        /// </summary>
        public Color Selected;
        /// <summary>
        /// Color when a sensor is activated.
        /// </summary>
        public Color Activated;

        /// <summary>
        /// The Control is selected by the user.
        /// </summary>
        public bool Selection;
        /// <summary>
        /// The Control is activated by a sensor.
        /// </summary>
        public bool Activation;

        /// <summary>
        /// Collects a Control's possible colors and selects one by its state.
        /// </summary>
        /// <param name="Base">Color when not selected nor activated</param>
        /// <param name="Selected">Color when selected</param>
        /// <param name="Activated">Color when a sensor is activated</param>
        public ColorStack(Color Base, Color Selected, Color Activated) {
            this.Base = Base;
            this.Selected = Selected;
            this.Activated = Activated;
            Selection = false;
            Activation = false;
        }

        /// <summary>
        /// Root mean square of two bytes.
        /// </summary>
        byte RMS(byte L, byte R) => (byte)Math.Sqrt((L * L + R * R) / 2);

        /// <summary>
        /// Current color of the Control.
        /// </summary>
        public Color GetColor() {
#if DEBUG
            if (Selection && Activation)
                return Color.FromArgb(RMS(Selected.R, Activated.R), RMS(Selected.G, Activated.G), RMS(Selected.B, Activated.B));
#endif
            return Selection ? Selected : Activation ? Activated : Base;
        }
    }
}