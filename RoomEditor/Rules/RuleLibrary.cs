using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace HomeEditor.Rules {
    public static class RuleLibrary {
        static List<Rule> rules;

        public static List<Rule> Rules {
            get {
                if (rules == null) {
                    rules = new List<Rule>();
                    LoadRules();
                }
                return rules;
            }
        }

        public static string RuleFileName { get; set; } = "./_rules.xml";

        public static Rule GetRuleByName(string name) {
            foreach (Rule rule in Rules)
                if (rule.name.Equals(name))
                    return rule;
            return null;
        }

        /// <summary>
        /// Check the sensor histories if they match rules with a given parent.
        /// </summary>
        static void Tick(string Parent = null) {
            foreach (Rule rule in Rules) {
                if (rule.parentRule == Parent) {
                    rule.Tick();
                    if (rule.Triggered)
                        Tick(rule.name);
                }
            }
        }

        /// <summary>
        /// Check the sensor histories if they match rules.
        /// </summary>
        public static void Tick() => Tick(null);

        public static void LoadRules() {
            Rules.Clear();
            if (!File.Exists(RuleFileName)) {
                rules.Add(new Rule("Sleeping", "Movement") { invert = true, span = TimeSpan.FromHours(2), notify = false });
                rules.Add(new Rule("Watching TV", "LightNoise") { span = TimeSpan.FromMinutes(30), maxValue = 5, notify = false });
                rules.Add(new Rule("Empty house for a day", "Movement") { invert = true, span = TimeSpan.FromHours(24) });
                rules.Add(new Rule("Sleep disorder", "Movement") { span = TimeSpan.FromMinutes(15), occurence = 3, toTime = 300 });
                rules.Add(new Rule("Entrance opened", "Open")
                    { targetRoom = AllLobbies.Instance, span = TimeSpan.FromMinutes(0), notify = false });
                rules.Add(new Rule("Left home with entrance opened", "Movement") { parentRule = "Entrance opened", invert = true });
                rules.Add(new Rule("Unoptimal temperature", "Temperature") { minValue = 18, maxValue = 32 });
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