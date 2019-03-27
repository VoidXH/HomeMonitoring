using System;
using System.Collections.Generic;
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
        public float minValue;

        /// <summary>
        /// Triggers if <see cref="targetField"/>'s value falls over this.
        /// </summary>
        public float maxValue = 100;

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
        /// Check the history entries of the <see cref="targetRoom"/> for this rule.
        /// </summary>
        public void Tick() {
            List<SensorData> source = new List<SensorData>();
            // TODO: collect from target room or all sensors
            source.Sort((a, b) => a.Timestamp.CompareTo(b.Timestamp));
        }

        #region Serialization
        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader) {
            StringBuilder errorLog = new StringBuilder();
            while (reader.MoveToNextAttribute()) {
                switch (reader.Name) {
                    case "name": name = reader.Value; break;
                    case "targetRoom":
                        targetRoom = Room.GetByName(reader.Value);
                        if (targetRoom == null)
                            errorLog.AppendLine("Room doesn't exist: " + reader.Value);
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
                }
            }
            if (errorLog.Length != 0)
                MessageBox.Show("Rule only imported partially. Errors:" + Environment.NewLine + errorLog.ToString());
        }

        public void WriteXml(XmlWriter writer) {
            writer.WriteAttributeString("name", name);
            if (targetRoom != null)
                writer.WriteAttributeString("targetRoom", targetRoom.Name);
            if (targetProperty != null)
                writer.WriteAttributeString("targetProperty", targetProperty.Name);
            writer.WriteAttributeString("span", span.TotalMinutes.ToString());
            writer.WriteAttributeString("occurence", occurence.ToString());
            writer.WriteAttributeString("minValue", minValue.ToString());
            writer.WriteAttributeString("maxValue", maxValue.ToString());
        }
        #endregion
    }
}