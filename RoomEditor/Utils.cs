using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace HomeEditor {
    /// <summary>
    /// Random functions without a specific location.
    /// </summary>
    public static class Utils {
        /// <summary>
        /// Global indention settings for XML writing.
        /// </summary>
        public static XmlWriterSettings xmlSettings = new XmlWriterSettings() { Indent = true, IndentChars = "  " };

        /// <summary>
        /// Clamp <paramref name="x"/> between <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        public static int Clamp(int x, int min, int max) => x > 0 ? (x < max ? x : max) : min;

        /// <summary>
        /// Check if two elements have an intersection.
        /// </summary>
        /// <param name="Container">First element</param>
        /// <param name="Content">Second element</param>
        /// <remarks>They intersect, if the second rectangle is not entirely left/right/up/down from the first</remarks>
        public static bool Intersect(SerializablePanel Container, SerializablePanel Content) =>
            !(Container.Left >= Content.Right || Container.Top >= Content.Bottom ||
                Container.Right <= Content.Left || Container.Bottom <= Content.Top);

        /// <summary>
        /// Safely parse a property from user input.
        /// </summary>
        /// <typeparam name="T">Target property type</typeparam>        
        /// <param name="value">Input value</param>
        /// <param name="parsedValue">Parsed value if <typeparamref name="T"/> is supported and <paramref name="value"/> is valid</param>
        /// <param name="errorLog">If the parsing failed, a line will be logged in this <see cref="StringBuilder"/></param>
        /// <param name="propertyName">Name of the property to be logged in case of an error</param>
        /// <returns>True if parsing was successful</returns>
        public static bool ParseProperty<T>(string value, out T parsedValue, StringBuilder errorLog = null, string propertyName = null) {
            bool result = false;
            parsedValue = default(T);
            if (typeof(T) == typeof(float)) {
                if (result = float.TryParse(value, out float temp))
                    parsedValue = (T)Convert.ChangeType(temp, typeof(T));
            } else if (typeof(T) == typeof(int)) {
                if (result = int.TryParse(value, out int temp))
                    parsedValue = (T)Convert.ChangeType(temp, typeof(T));
            } else if (typeof(T) == typeof(bool)) {
                if (result = bool.TryParse(value, out bool temp))
                    parsedValue = (T)Convert.ChangeType(temp, typeof(T));
            }
            if (!result && errorLog != null)
                if (!string.IsNullOrEmpty(propertyName))
                    errorLog.Append("Invalid ").Append(propertyName).Append(" value: ").AppendLine(value);
                else
                    errorLog.Append("Invalid value: ").AppendLine(value);
            return result;
        }

        /// <summary>
        /// Attach an <see cref="IXmlSerializable"/> to an XML file.
        /// </summary>
        public static void SerializeObject(XmlWriter writer, IXmlSerializable target) {
            writer.WriteStartElement(target.GetType().Name);
            target.WriteXml(writer);
            writer.WriteEndElement();
        }
    }
}