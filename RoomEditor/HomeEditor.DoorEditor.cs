using HomeEditor.Elements;
using System;
using System.Windows.Forms;

namespace HomeEditor {
    /// <summary>
    /// Obstacle editor behaviour.
    /// </summary>
    public partial class HomeEditor : Form {
        /// <summary>
        /// Add a new openable entity.
        /// </summary>
        void AddDoor_Click(object sender, EventArgs e) => SelectObject(new Door(drawingPanel));

        /// <summary>
        /// Set the selected openable entity's type to door.
        /// </summary>
        void DoorDoor_CheckedChanged(object sender, EventArgs e) {
            if (((RadioButton)sender).Checked)
                ((Door)selection).DoorType = Door.Types.Door;
        }

        /// <summary>
        /// Set the selected openable entity's type to entrance.
        /// </summary>
        void DoorEntrance_CheckedChanged(object sender, EventArgs e) {
            if (((RadioButton)sender).Checked)
                ((Door)selection).DoorType = Door.Types.Entrance;
        }

        /// <summary>
        /// Set the selected openable entity's type to window.
        /// </summary>
        void DoorWindow_CheckedChanged(object sender, EventArgs e) {
            if (((RadioButton)sender).Checked)
                ((Door)selection).DoorType = Door.Types.Window;
        }

        /// <summary>
        /// Set the selected openable entity's orientation by checking the selection state of the horizontal check.
        /// </summary>
        void DoorHorizontal_CheckedChanged(object sender, EventArgs e) {
            ((Door)selection).Orientation = doorHorizontal.Checked ? Door.Orientations.Horizontal : Door.Orientations.Vertical;
            int oldLeft = selection.Left, oldTop = selection.Top;
            selection.Left = oldLeft / Room.PixelsPerMeter * Room.PixelsPerMeter + oldTop % Room.PixelsPerMeter;
            selection.Top = oldTop / Room.PixelsPerMeter * Room.PixelsPerMeter + oldLeft % Room.PixelsPerMeter;
        }

        /// <summary>
        /// Set the selected openable entity's width.
        /// </summary>
        void DoorSize_ValueChanged(object sender, EventArgs e) {
            ((Door)selection).Size = ((TrackBar)sender).Value;
            doorSizeDisplay.Text = ((TrackBar)sender).Value * 100 / Room.PixelsPerMeter + " cm";
        }

        /// <summary>
        /// Set the selected openable entity's sensor state.
        /// </summary>
        void DoorSensorAttached_CheckedChanged(object sender, EventArgs e) {
            Door SelectedDoor = ((Door)selection);
            if (((CheckBox)sender).Checked) {
                if (SelectedDoor.AttachedSensor == null)
                    SelectedDoor.AttachedSensor = new Sensor(selection) { Visible = false };
                doorSensorName.Enabled = doorSensorAddress.Enabled = spoofDoor.Enabled = true;
                doorSensorAddress.Text = string.Empty;
            } else {
                if (SelectedDoor.AttachedSensor != null) {
                    SelectedDoor.AttachedSensor.DisconnectFromParent();
                    SelectedDoor.AttachedSensor = null;
                }
                doorSensorName.Enabled = doorSensorAddress.Enabled = spoofDoor.Enabled = false;
                doorSensorAddress.Text = string.Empty;
            }
        }

        /// <summary>
        /// Set the selected openable entity's sensor name.
        /// </summary>
        private void DoorSensorName_TextChanged(object sender, EventArgs e) {
            Sensor target = ((Door)selection).AttachedSensor;
            if (target != null)
                target.Name = ((TextBox)sender).Text;
        }

        /// <summary>
        /// Set the selected openable entity's sensor address.
        /// </summary>
        void DoorSensorAddress_TextChanged(object sender, EventArgs e) {
            Sensor target = ((Door)selection).AttachedSensor;
            if (target != null)
                target.Address = ((TextBox)sender).Text;
        }

        /// <summary>
        /// Open the data spoofer for the selected door's sensor.
        /// </summary>
        private void SpoofDoor_Click(object sender, EventArgs e) {
            SensorDataSpoof spoofer = new SensorDataSpoof();
            if (spoofer.ShowDialog() == DialogResult.OK)
                ((Door)selection).AttachedSensor.DataReceived(spoofer.Data);
        }
    }
}