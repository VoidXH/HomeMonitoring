using HomeEditor.Elements;
using System.Drawing;
using System.Windows.Forms;

namespace HomeEditor {
    public static class Alert {
        public static void SendAlert(Sensor sensor, string message) {
            if (sensor != null)
                sensor.Parent.BackColor = Color.Red;
            if (Program.window != null) {
                LogViewer.Log(message);
                Program.window.StatusStrip.BackColor = Color.Red;
                Program.window.LastAlert.Text = LogViewer.GetLog(1);
            } else
                MessageBox.Show(message);
        }
    }
}