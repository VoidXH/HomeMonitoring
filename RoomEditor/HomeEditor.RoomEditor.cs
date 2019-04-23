using System;
using System.Drawing;
using System.Windows.Forms;

namespace HomeEditor {
    /// <summary>
    /// Room editor behaviour.
    /// </summary>
    public partial class HomeEditor : Form {
        /// <summary>
        /// Add a new room.
        /// </summary>
        void AddRoom_Click(object sender, EventArgs e) => SelectObject(new Room(drawingPanel));

        /// <summary>
        /// Get the selected room or the selected sensor's containing room.
        /// </summary>
        Room GetSelectedRoom() => selection is Room ? (Room)selection : (Room)selection.Parent;

        /// <summary>
        /// Change the selected room's name.
        /// </summary>
        void RoomName_TextChanged(object sender, EventArgs e) {
            TextBox target = (TextBox)sender;
            string newName = target.Text;
            if (newName.Equals(AllLobbies.Instance.Name)) {
                target.BackColor = Color.Red;
                return;
            }
            target.BackColor = roomNameBackground;
            GetSelectedRoom().SetName(newName);
        }

        /// <summary>
        /// Change the selected room's width.
        /// </summary>
        void RoomWidth_ValueChanged(object sender, EventArgs e) {
            GetSelectedRoom().Width = ((TrackBar)sender).Value * Room.PixelsPerMeter;
            roomWidthDisplay.Text = ((TrackBar)sender).Value + " m";
        }

        /// <summary>
        /// Change the selected room's height.
        /// </summary>
        void RoomHeight_ValueChanged(object sender, EventArgs e) {
            GetSelectedRoom().Height = ((TrackBar)sender).Value * Room.PixelsPerMeter;
            roomHeightDisplay.Text = ((TrackBar)sender).Value + " m";
        }

        /// <summary>
        /// Add a sensor to the selected room.
        /// </summary>
        void AddSensor_Click(object sender, EventArgs e) {
            Sensor newSensor = new Sensor(GetSelectedRoom());
            SelectObject(newSensor);
        }

        #region Sensor editor
        void SensorName_TextChanged(object sender, EventArgs e) => ((Sensor)selection).Name = sensorName.Text;

        /// <summary>
        /// Change the selected sensor's address.
        /// </summary>
        void SensorAddress_TextChanged(object sender, EventArgs e) => ((Sensor)selection).Address = sensorAddress.Text;

        /// <summary>
        /// Open the data spoofer for the selected sensor.
        /// </summary>
        void SpoofSensor_Click(object sender, EventArgs e) {
            SensorDataSpoof spoofer = new SensorDataSpoof();
            if (spoofer.ShowDialog() == DialogResult.OK)
                ((Sensor)selection).DataReceived(spoofer.Data);
        }

        /// <summary>
        /// Delete the selected sensor.
        /// </summary>
        void DeleteSensor_Click(object sender, EventArgs e) {
            sensorSettings.Visible = false;
            selection.DisconnectFromParent();
            selection = (SerializablePanel)selection.parent;
        }
        #endregion
    }
}