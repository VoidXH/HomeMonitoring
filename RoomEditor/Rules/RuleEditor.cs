using System;
using System.Reflection;
using System.Windows.Forms;

namespace HomeEditor.Rules {
    public partial class RuleEditor : Form {
        Rule selectedRule;

        public RuleEditor() {
            InitializeComponent();
            targetRoom.Items.Add(new RoomListItem(null));
            Room.ForEach(room => targetRoom.Items.Add(new RoomListItem(room)));
            targetRoom.SelectedIndex = 0;
            PropertyInfo[] properties = typeof(SensorData).GetProperties();
            foreach (PropertyInfo property in properties)
                if (property.PropertyType == typeof(bool) || property.PropertyType == typeof(float))
                    targetProperty.Items.Add(new PropertyInfoListItem(property));
            targetProperty.SelectedIndex = 0;
            RuleLibrary.LoadRules();
            UpdateRuleList();
        }

        void UpdateRuleList() {
            ruleList.Items.Clear();
            for (int i = 0, c = RuleLibrary.Rules.Count; i < c; ++i) {
                ruleList.Items.Add(RuleLibrary.Rules[i].name);
                if (RuleLibrary.Rules[i] == selectedRule)
                    ruleList.SelectedIndex = i;
            }
        }

        void NewRule_Click(object s, EventArgs e) {
            RuleLibrary.Rules.Add(new Rule("New rule", ((PropertyInfoListItem)targetProperty.Items[0]).item));
            UpdateRuleList();
            ruleList.SelectedIndex = RuleLibrary.Rules.Count - 1;
        }

        void RuleList_SelectedIndexChanged(object s, EventArgs e) {
            selectedRule = RuleLibrary.Rules[ruleList.SelectedIndex];
            ruleName.Text = selectedRule.name;
            for (int i = 0, c = targetRoom.Items.Count; i < c; ++i)
                if (((RoomListItem)targetRoom.Items[i]).item == selectedRule.targetRoom)
                    targetRoom.SelectedIndex = i;
            for (int i = 0, c = targetProperty.Items.Count; i < c; ++i)
                if (((PropertyInfoListItem)targetProperty.Items[i]).item == selectedRule.targetProperty)
                    targetProperty.SelectedIndex = i;
            span.Value = (decimal)selectedRule.span.TotalMinutes;
            occurence.Value = selectedRule.occurence;
            minValue.Value = (decimal)selectedRule.minValue;
            maxValue.Value = (decimal)selectedRule.maxValue;
        }

        private void RuleName_TextChanged(object s, EventArgs e) {
            if (selectedRule != null) {
                selectedRule.name = ruleName.Text;
                UpdateRuleList();
            }
        }

        private void TargetRoom_SelectedIndexChanged(object s, EventArgs e) {
            if (selectedRule != null)
                selectedRule.targetRoom = ((RoomListItem)targetRoom.SelectedItem).item;
        }

        private void TargetProperty_SelectedIndexChanged(object s, EventArgs e) {
            if (selectedRule != null)
                selectedRule.targetProperty = ((PropertyInfoListItem)targetProperty.SelectedItem).item;
        }

        private void Span_ValueChanged(object s, EventArgs e) {
            if (selectedRule != null)
                selectedRule.span = TimeSpan.FromMinutes((int)span.Value);
        }

        private void Occurence_ValueChanged(object s, EventArgs e) {
            if (selectedRule != null)
                selectedRule.occurence = (int)occurence.Value;
        }

        private void MinValue_ValueChanged(object s, EventArgs e) {
            if (selectedRule != null)
                selectedRule.minValue = (float)minValue.Value;
        }

        private void MaxValue_ValueChanged(object s, EventArgs e) {
            if (selectedRule != null)
                selectedRule.maxValue = (float)maxValue.Value;
        }

        private void DeleteRule_Click(object sender, EventArgs e) {
            if (selectedRule != null) {
                RuleLibrary.Rules.Remove(selectedRule);
                selectedRule = RuleLibrary.Rules.Count > 0 ? RuleLibrary.Rules[0] : null;
                UpdateRuleList();
            }
        }

        private void Close_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void RuleEditor_FormClosing(object sender, FormClosingEventArgs e) => RuleLibrary.SaveRules();
    }
}