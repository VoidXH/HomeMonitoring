using HomeEditor.Elements;
using System.Windows.Forms;
using System.Xml;

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
        string lastFileName;

        /// <summary>
        /// Last opened file's path, changes the window's title when set.
        /// </summary>
        string LastFileName {
            get => lastFileName;
            set {
                lastFileName = value;
                Text = value.Equals(defaultFileName) ? defaultTitle : defaultTitle + " - " + value;
            }
        }

        /// <summary>
        /// Save the last created home.
        /// </summary>
        /// <param name="fileName">Target file name</param>
        void SerializeHome(string fileName) {
            drawingPanel.HorizontalScroll.Value = drawingPanel.VerticalScroll.Value = 0; // Top/Left positions are relative to this
            drawingPanel.AutoScroll = true; // Reset scrollbar position
            XmlWriter writer = XmlWriter.Create(fileName, Utils.xmlSettings);
            writer.WriteStartElement("home");
            foreach (SerializablePanel target in drawingPanel.Controls)
                Utils.SerializeObject(writer, target);
            writer.WriteEndElement();
            writer.Close();
        }

        /// <summary>
        /// Empties the home.
        /// </summary>
        void HardReset() {
            DisableSimulator();
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
            LastFileName = fileName;
        }
    }
}
