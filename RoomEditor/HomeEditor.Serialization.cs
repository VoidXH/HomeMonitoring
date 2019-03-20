using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace HomeEditor {
    /// <summary>
    /// Export and import handling.
    /// </summary>
    public partial class HomeEditor : Form {
        /// <summary>
        /// Auto-save location.
        /// </summary>
        const string defaultFileName = "./_active.xml";

        /// <summary>
        /// Cached last opened file's path.
        /// </summary>
        string _lastFileName;

        /// <summary>
        /// Last opened file's path, changes the window's title when set.
        /// </summary>
        string lastFileName {
            get => _lastFileName;
            set {
                _lastFileName = value;
                Text = value.Equals(defaultFileName) ? defaultTitle : defaultTitle + " - " + value;
            }
        }

        /// <summary>
        /// Attach an <see cref="IXmlSerializable"/> to an XML file.
        /// </summary>
        void SerializeObject(XmlWriter writer, IXmlSerializable target) {
            writer.WriteStartElement(target.GetType().Name);
            target.WriteXml(writer);
            writer.WriteEndElement();
        }

        /// <summary>
        /// Save the last created home.
        /// </summary>
        /// <param name="fileName">Target file name</param>
        void SerializeHome(string fileName) {
            drawingPanel.HorizontalScroll.Value = drawingPanel.VerticalScroll.Value = 0; // Top/Left positions are relative to this
            drawingPanel.AutoScroll = true; // Reset scrollbar position
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true, IndentChars = "  " };
            XmlWriter writer = XmlWriter.Create(fileName, settings);
            writer.WriteStartElement("home");
            foreach (SerializablePanel target in drawingPanel.Controls)
                SerializeObject(writer, target);
            writer.WriteEndElement();
            writer.Close();
        }

        /// <summary>
        /// Empties the home.
        /// </summary>
        void HardReset() {
            simulator.Checked = false;
            DeselectEverything();
            selection = null;
            Sensor.ClearSensorList();
            drawingPanel.Controls.Clear();
        }

        /// <summary>
        /// Load a home from a file.
        /// </summary>
        /// <param name="fileName">Target file name</param>
        void DeserializeHome(string fileName) {
            HardReset();
            using (XmlReader reader = XmlReader.Create(fileName)) {
                while (reader.Read()) {
                    if (reader.NodeType == XmlNodeType.Element) {
                        SerializablePanel newObject = null;
                        switch (reader.Name) {
                            case "Room": newObject = new Room(drawingPanel); break;
                            case "Obstacle": newObject = new Obstacle(drawingPanel); break;
                            case "Door": newObject = new Door(drawingPanel); break;
                            default: break;
                        }
                        if (newObject != null)
                            newObject.ReadXml(reader);
                    }
                }
            }
            lastFileName = fileName;
        }
    }
}
