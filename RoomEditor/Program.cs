using HomeEditor.Elements;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HomeEditor {
    static class Program {
        public static HomeEditor window;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            window = new HomeEditor();
            Application.Run(window);
        }

        public static void Alert(Sensor sensor, string message) {
            if (sensor != null)
                sensor.parent.BackColor = Color.Red;
            if (window != null) {
                LogViewer.Log(message);
                window.StatusStrip.BackColor = Color.Red;
                window.LastAlert.Text = LogViewer.GetLog(1);
            } else
                MessageBox.Show(message);
        }
    }
}