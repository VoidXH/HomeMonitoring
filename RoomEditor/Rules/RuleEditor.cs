using System.Collections.Generic;
using System.Windows.Forms;

namespace HomeEditor.Rules {
    public partial class RuleEditor : Form {
        public static List<Rule> rules = new List<Rule>();
        Rule selectedRule;

        public RuleEditor() {
            InitializeComponent();
            targetRoom.Items.Add("None");
            targetRoom.SelectedIndex = 0;
            Room.ForEach(room => targetRoom.Items.Add(room.Name));
            // TODO: fill properties
        }

        void UpdateRuleList() {
            ruleList.Items.Clear();
            foreach (Rule rule in rules)
                ruleList.Items.Add(rule.name);
        }

        void NewRule_Click(object sender, System.EventArgs e) {
            rules.Add(new Rule() { name = "New rule" });
            UpdateRuleList();
            ruleList.SelectedIndex = rules.Count - 1;
        }

        void RuleList_SelectedIndexChanged(object sender, System.EventArgs e) {
            selectedRule = rules[ruleList.SelectedIndex];
            ruleName.Text = selectedRule.name;
            targetRoom.Text = selectedRule.targetRoom != null ? selectedRule.targetRoom.Name : "None";
            targetProperty.Text = selectedRule.targetProperty;
            span.Value = (decimal)selectedRule.span.TotalMinutes;
        }
    }
}