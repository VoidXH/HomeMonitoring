using System.Collections.Generic;
using System.Windows.Forms;

namespace HomeEditor.Rules {
    public partial class RuleEditor : Form {
        public static List<Rule> rules = new List<Rule>();
        Rule selectedRule;

        public RuleEditor() => InitializeComponent();

        void UpdateRuleList() {
            ruleList.Items.Clear();
            foreach (Rule rule in rules)
                ruleList.Items.Add(rule.name);
        }

        void NewRule_Click(object sender, System.EventArgs e) {
            rules.Add(new Rule() { name = "New rule" });
            UpdateRuleList();
        }

        void RuleList_SelectedIndexChanged(object sender, System.EventArgs e) {

        }
    }
}