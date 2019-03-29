using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace HomeEditor.Rules {
    public static class RuleLibrary {
        static List<Rule> rules;

        public static List<Rule> Rules {
            get {
                if (rules == null)
                    rules = new List<Rule>();
                return rules;
            }
        }

        public static string RuleFileName { get; set; } = "./_rules.xml";

        public static void LoadRules() {
            Rules.Clear();
            if (!File.Exists(RuleFileName)) {
                rules.Add(new Rule("Unoptimal temperature", "Temperature") { minValue = 18, maxValue = 32 });
                rules.Add(new Rule("Sleep", "Movement") { invert = true, span = TimeSpan.FromHours(2), notify = false });
                rules.Add(new Rule("Empty house for a day", "Movement") { invert = true, span = TimeSpan.FromHours(24) });
                rules.Add(new Rule("Sleep disorder", "Movement") { span = TimeSpan.FromMinutes(15), occurence = 3, toTime = 300 });
                rules.Add(new Rule("Incorrect temperature (possible sensor failure)", "Temperature")
                    { minValue = 10, maxValue = 50, span = TimeSpan.FromMinutes(0) });
                rules.Add(new Rule("Too much movement (possible sensor failure)", "Movement") { span = TimeSpan.FromHours(12) });
                rules.Add(new Rule("Too many door openings (possible sensor failure)", "Open")
                    { span = TimeSpan.FromMinutes(1), occurence = 5 });
                return;
            }
            using (XmlReader reader = XmlReader.Create(RuleFileName)) {
                while (reader.Read()) {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals(typeof(Rule).Name)) {
                        Rule newRule = new Rule();
                        newRule.ReadXml(reader);
                        rules.Add(newRule);
                    }
                }
            }
        }

        public static void SaveRules() {
            XmlWriter writer = XmlWriter.Create(RuleFileName, Utils.xmlSettings);
            writer.WriteStartElement("ruleset");
            foreach (Rule rule in Rules)
                Utils.SerializeObject(writer, rule);
            writer.WriteEndElement();
            writer.Close();
        }
    }
}