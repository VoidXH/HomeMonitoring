using System.Drawing;
using System.Windows.Forms;

namespace HomeEditor.Events {
    /// <summary>
    /// Detectable event handler.
    /// </summary>
    public static class Event {
        public delegate void EventCall();
        public static event EventCall EventCalls;

        static string _Activity = string.Empty;
        public static string Activity {
            get => _Activity;
            internal set {
                _Activity = value;
                Program.window.activityLabel.Text = "Activity: " + value;
            }
        }

        public static void RegisterEvents() {
            EventCalls += Leaving.Check;
            EventCalls += SleepDisorder.Check;
            EventCalls += DetectTV.Check;
        }

        public static void Tick() => EventCalls?.Invoke();

        public static void Alert(Sensor sensor, string message) {
            if (sensor != null)
                sensor.parent.BackColor = Color.Red;
            if (Program.window != null) {
                LogViewer.Log(message);
                Program.window.StatusStrip.BackColor = Color.Red;
                Program.window.LastAlert.Text = LogViewer.GetLog(1);
            } else
                MessageBox.Show(message);
        }

        /// <summary>
        /// Get the room the user last visited.
        /// </summary>
        public static Room GetLastRoom() {
            for (int i = Sensor.History.Count - 1; i >= 0; --i)
                if (((SerializablePanel)Sensor.History[i].parent) is Room)
                    return (Room)Sensor.History[i].parent;
            return null;
        }
    }
}