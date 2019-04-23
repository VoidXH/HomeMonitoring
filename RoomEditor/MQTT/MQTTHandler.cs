using HomeEditor.Elements;
using OpenNETCF.MQTT;
using System;
using System.Collections.Generic;

namespace HomeEditor.MQTT {
    /// <summary>
    /// MQTT message interpreter and setup object.
    /// </summary>
    public class MQTTHandler {
        public static string MQTTHost;
        public static string MQTTUser;
        public static string MQTTPass;

        /// <summary>
        /// MQTT connection handler object.
        /// </summary>
        MQTTClient client;

        /// <summary>
        /// Last messages sent by each sensor.
        /// </summary>
        readonly Dictionary<string, string> lastMessages = new Dictionary<string, string>();

        /// <summary>
        /// Last message received at.
        /// </summary>
        public DateTime LastMessage { get; private set; } = DateTime.Now;

        /// <summary>
        /// Last messages sent by each sensor.
        /// </summary>
        public IReadOnlyDictionary<string, string> LastMessages => lastMessages;

        public MQTTHandler() {
            client = new MQTTClient(MQTTHost, 1883);
            client.MessageReceived += MessageReceived;
            client.Connect(MQTTHost, MQTTUser, MQTTPass);
            int i = 0;
            while (!client.IsConnected) {
                System.Threading.Thread.Sleep(500);
                if (i++ > 10) {
                    Program.Alert(null, "MQTT connection failed to " + MQTTHost + " as " + MQTTUser + '.');
                    break;
                }
            }
            client.Subscriptions.Add(new Subscription("#"));
        }

        void MessageReceived(string topic, QoS qos, byte[] payload) {
            string message = System.Text.Encoding.Default.GetString(payload);
            string[] topicParts = topic.Split('/');
            if (topicParts[1].Equals("aged")) {
                string mac = topicParts[2];
                string type = null;
                if (topicParts.Length == 5) {
                    mac += '/' + topicParts[3].Trim();
                    type = topicParts[4].Trim();
                } else {
                    if (topicParts.Length != 4)
                        return;
                    type = topicParts[3].Trim();
                }
                LastMessage = DateTime.Now;
                lastMessages[mac] = type + ": " + message;
                if (type.Equals("status")) {
                    string[] dataParts = message.Split(';');
                    float temp = Convert.ToSingle(dataParts[0].Replace('.', ',').Trim());
                    float light = Convert.ToSingle(dataParts[1].Replace('.', ',').Trim());
                    float battery = -1;
                    bool led = false, buzzer = false;
                    if (dataParts.Length == 3)
                        battery = Convert.ToSingle(dataParts[2].Replace('.', ',').Trim());
                    if (dataParts.Length == 4) {
                        led = dataParts[2].Trim().Equals("1");
                        buzzer = dataParts[3].Trim().Equals("1");
                    }
                    Sensor.ForwardData(mac, new SensorData(temp, light, battery, led, buzzer));
                } else if (type.Equals("extstatus")) {
                    string[] dataParts = message.Split(';');
                    float temp = Convert.ToSingle(dataParts[0].Replace('.', ',').Trim());
                    float hum = Convert.ToSingle(dataParts[1].Replace('.', ',').Trim());
                    float pres = Convert.ToSingle(dataParts[2].Replace('.', ',').Trim());
                    Sensor.ForwardData(mac, new SensorData(temp, hum, pres));
                } else if (type.Equals("motion"))
                    Sensor.ForwardData(mac, new SensorData(message != "0", false));
                else if (type.Equals("contact"))
                    Sensor.ForwardData(mac, new SensorData(false, message != "0"));
                else if (type.Equals("btn")) {
                    Sensor.ForwardButton(mac);
                    /* this.mdb.logButton(mac, subMac, Integer.parseInt(message.trim()));
                    string lastCmd = this.mdb.getLastSentCommand(mac);
                    if (lastCmd != null && lastCmd.equals("led")) {
                        this.mqc.sendCommand("/aged/" + mac + "/LED", "000000 0000 00");
                        this.mdb.putLedCommand(mac, "000000", 0, 0, true);
                    }
                    if (lastCmd != null && lastCmd.equals("buzzer")) {
                        this.mqc.sendCommand("/aged/" + mac + "/BUZ", "0 0000 00");
                        this.mdb.putBuzzerCommand(mac, false, 0, 0, true);
                    }*/
                }
            }
        }

        public void Disconnect() {
            if (!client.IsConnected)
                client.Disconnect();
        }
    }
}
