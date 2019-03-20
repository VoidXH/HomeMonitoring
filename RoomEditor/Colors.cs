using System.Windows.Forms;

namespace HomeEditor {
    public partial class Colors : Form {
        public Colors() {
            InitializeComponent();
            roomBase.BackColor = Room.BaseColor;
            roomSelection.BackColor = Room.SelectionColor;
            roomActivation.BackColor = Room.ActivationColor;
            obstacleBase.BackColor = Obstacle.BaseColor;
            obstacleSelection.BackColor = Obstacle.SelectionColor;
            doorBase.BackColor = Door.BaseDoorColor;
            entranceBase.BackColor = Door.BaseEntranceColor;
            windowBase.BackColor = Door.BaseWindowColor;
            doorSelection.BackColor = Door.SelectionColor;
            doorActivation.BackColor = Door.ActivationColor;
            sensorBase.BackColor = Sensor.BaseColor;
            sensorSelection.BackColor = Sensor.SelectionColor;
            sensorActivation.BackColor = Sensor.ActivationColor;
        }
    }
}