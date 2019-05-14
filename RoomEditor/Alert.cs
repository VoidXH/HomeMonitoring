using HomeEditor.Elements;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace HomeEditor {
    public static class Alert {
        public static string SMTPHost;
        public static int SMTPPort = 25;
        public static string Address;
        public static string Password;

        static void SendEmail(string subject, string body) {
            SmtpClient client = new SmtpClient {
                Host = SMTPHost,
                Port = SMTPPort,
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Address, Password)
            };
            using (MailMessage mail = new MailMessage(Address, Address, subject, body) {
                BodyEncoding = Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            })
                client.Send(mail);
        }

        public static void SendAlert(Sensor sensor, string message) {
            if (sensor != null)
                sensor.Parent.BackColor = Color.Red;
            if (Program.window != null) {
                SendEmail("Remote Monitoring Alert", message);
                LogViewer.Log(message);
                Program.window.StatusStrip.BackColor = Color.Red;
                Program.window.LastAlert.Text = LogViewer.GetLog(1);
            } else
                MessageBox.Show(message);
        }
    }
}