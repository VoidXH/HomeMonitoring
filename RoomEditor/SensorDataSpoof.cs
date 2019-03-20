using System;
using System.Windows.Forms;

namespace HomeEditor {
    public partial class SensorDataSpoof : Form {
        public SensorData Data;

        public SensorDataSpoof() {
            Data = new SensorData();
            InitializeComponent();
        }

        private void Ok_Click(object sender, EventArgs e) {
            Data.Movement = Movement.Checked;
            Data.open = Open.Checked;
            Data.light = Convert.ToSingle(Light.Text);
            Data.temperature = Convert.ToSingle(Temperature.Text);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
