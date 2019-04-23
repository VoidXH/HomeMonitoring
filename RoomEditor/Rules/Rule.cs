using HomeEditor.Elements;
using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace HomeEditor.Rules {
    public class Rule : IXmlSerializable {
        /// <summary>
        /// Name of this rule.
        /// </summary>
        public string name = string.Empty;

        /// <summary>
        /// A rule that also has to trigger in order for this one to trigger.
        /// </summary>
        public string parentRule = null;

        // TODO: virtual "Lobby" room, which represents sensor data from the entrance door, use that as target for the leaving event
        /// <summary>
        /// Room to check. If null, all sensors will be checked independently.
        /// </summary>
        public Room targetRoom;

        /// <summary>
        /// Property in <see cref="SensorData"/> to check.
        /// </summary>
        public PropertyInfo targetProperty;

        /// <summary>
        /// Maximum detection interval. Zero span means instant notification when the value range is out of bounds.
        /// </summary>
        public TimeSpan span = TimeSpan.FromMinutes(5);

        /// <summary>
        /// Triggers if the rule happend more than this times in the interval set in <see cref="span"/>.
        /// </summary>
        public int occurence = 1;

        /// <summary>
        /// Triggers if <see cref="targetField"/>'s value falls below this.
        /// </summary>
        public float minValue = 0;

        /// <summary>
        /// Triggers if <see cref="targetField"/>'s value falls over this.
        /// </summary>
        public float maxValue = 100;

        /// <summary>
        /// Detect false for boolean values and trigger for in range for float values.
        /// </summary>
        public bool invert = false;

        /// <summary>
        /// Notify the user if this rule triggers. The trigger will be logged anyway.
        /// </summary>
        public bool notify = true;

        /// <summary>
        /// First time of the day (in total minutes) to handle this rule.
        /// </summary>
        public int fromTime = 0;

        /// <summary>
        /// Last time of the day (in total minutes) to handle this rule.
        /// </summary>
        public int toTime = 23 * 60 + 59;

        /// <summary>
        /// Rule trigger function.
        /// </summary>
        public delegate void Notification(Rule rule);

        /// <summary>
        /// Called when a rule triggers.
        /// </summary>
        public static event Notification OnNotification;

        public Rule() { }

        public Rule(string name, PropertyInfo targetProperty) {
            this.name = name;
            this.targetProperty = targetProperty;
        }

        public Rule(string name, string targetProperty) {
            this.name = name;
            SetTargetProperty(targetProperty);
        }

        /// <summary>
        /// Set <see cref="targetProperty"/> from a given name.
        /// </summary>
        void SetTargetProperty(string name) {
            PropertyInfo[] properties = typeof(SensorData).GetProperties();
            foreach (PropertyInfo property in properties)
                if (property.Name.Equals(name))
                    targetProperty = property;
        }

        /// <summary>
        /// Check the history entries of the <see cref="targetRoom"/> for this rule. Returns true and notifies if the rule has triggered.
        /// </summary>
        public bool Tick() {
            DateTime now = DateTime.Now;
            if (now.Hour < fromTime / 60 || (now.Hour == fromTime / 60 && now.Minute < fromTime % 60)) // Handle fromTime
                return false;
            if (now.Hour > toTime / 60 || (now.Hour == toTime / 60 && now.Minute > toTime % 60)) // Handle toTime
                return false;
            DateTime lastChecked = now - span;
            Room.ForEach(room => {
                if (targetRoom == null || targetRoom == room) { // Handle room
                    int lastEntry = room.DataHistory.Count - 1;
                    for (int i = lastEntry; i >= 0; --i) {
                        SensorData entry = room.DataHistory[i];
                        if (entry.Timestamp > lastChecked || (i == lastEntry)) { // Handle span
                            if (targetProperty.PropertyType == typeof(bool)) {
                                // TODO
                            } else if (targetProperty.PropertyType == typeof(float)) {
                                // TODO
                            }
                        }
                    }
                }
            });
            return false;
        }

        #region Serialization
        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader) {
            StringBuilder errorLog = new StringBuilder();
            while (reader.MoveToNextAttribute()) {
                switch (reader.Name) {
                    case "name": name = reader.Value; break;
                    case "parentRule": parentRule = reader.Value; break;
                    case "targetRoom":
                        targetRoom = Room.GetByName(reader.Value);
                        if (targetRoom == null) {
                            if (reader.Value.Equals(AllLobbies.Instance.Name))
                                targetRoom = AllLobbies.Instance;
                            else
                                errorLog.AppendLine("Room doesn't exist: " + reader.Value);
                        }
                        break;
                    case "targetProperty":
                        SetTargetProperty(reader.Value);
                        if (targetProperty == null)
                            errorLog.AppendLine("Invalid target property: " + reader.Value);
                        break;
                    case "span":
                        if (Utils.ParseProperty(reader.Value, out float span, errorLog, "span"))
                            this.span = TimeSpan.FromMinutes(span);
                        break;
                    case "occurence": Utils.ParseProperty(reader.Value, out occurence, errorLog, "occurence"); break;
                    case "minValue": Utils.ParseProperty(reader.Value, out minValue, errorLog, "minValue"); break;
                    case "maxValue": Utils.ParseProperty(reader.Value, out maxValue, errorLog, "maxValue"); break;
                    case "invert": Utils.ParseProperty(reader.Value, out invert, errorLog, "invert"); break;
                    case "notify": Utils.ParseProperty(reader.Value, out notify, errorLog, "notify"); break;
                    case "fromTime": Utils.ParseProperty(reader.Value, out fromTime, errorLog, "fromTime"); break;
                    case "toTime": Utils.ParseProperty(reader.Value, out toTime, errorLog, "toTime"); break;
                }
            }
            if (errorLog.Length != 0)
                MessageBox.Show("Rule only imported partially. Errors:" + Environment.NewLine + errorLog.ToString());
        }

        public void WriteXml(XmlWriter writer) {
            writer.WriteAttributeString("name", name);
            if (parentRule != null)
                writer.WriteAttributeString("parentRule", parentRule);
            if (targetRoom != null)
                writer.WriteAttributeString("targetRoom", targetRoom.Name);
            if (targetProperty != null)
                writer.WriteAttributeString("targetProperty", targetProperty.Name);
            writer.WriteAttributeString("span", span.TotalMinutes.ToString());
            writer.WriteAttributeString("occurence", occurence.ToString());
            writer.WriteAttributeString("minValue", minValue.ToString());
            writer.WriteAttributeString("maxValue", maxValue.ToString());
            writer.WriteAttributeString("invert", invert.ToString());
            writer.WriteAttributeString("notify", notify.ToString());
            writer.WriteAttributeString("fromTime", fromTime.ToString());
            writer.WriteAttributeString("toTime", toTime.ToString());
        }
        #endregion
    }
}