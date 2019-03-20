using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace HomeEditor {
    public partial class LogViewer : Form {
        static List<LogEntry> logs = new List<LogEntry>();

        public static void Log(string message) {
            bool add = logs.Count == 0 || !logs[logs.Count - 1].Message.Equals(message);
            if (add)
                logs.Add(new LogEntry(message));
            else
                logs[logs.Count - 1].OnRepeat();
        }

        public static string GetLog(int EntriesBack = -1) {
            StringBuilder sb = new StringBuilder();
            for (int logCount = logs.Count, i = logCount - 1; i >= 0 && (EntriesBack == -1 || i >= logCount - EntriesBack); --i) {
                sb.Append(logs[i].Message);
                if (logs[i].Repeated != 0)
                    sb.Append("( Repeated ").Append(logs[i].Repeated).Append(" times)");
                sb.AppendLine();
            }
            return sb.Length < 2 ? string.Empty : sb.Remove(sb.Length - 2, 2).ToString();
        }

        public LogViewer() {
            InitializeComponent();
            display.Text = GetLog(10);
        }
    }

    public class LogEntry {
        public string Message;
        public int Repeated { get; private set; }

        public LogEntry(string message) => Message = message;

        public void OnRepeat() => ++Repeated;
    }
}
