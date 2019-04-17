using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace HomeEditor.Rules {
    public partial class RuleEditor : Form {
        const string noParent = "None";

        Color textFieldColor;
        Rule selectedRule;

        public RuleEditor() {
            InitializeComponent();
            textFieldColor = ruleName.BackColor;
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
            ruleList.SelectedIndex = 0;
        }

        void UpdateRuleList() {
            ruleList.Items.Clear();
            parentRule.Items.Clear();
            parentRule.Items.Add(noParent);
            for (int i = 0, c = RuleLibrary.Rules.Count; i < c; ++i) {
                ruleList.Items.Add(RuleLibrary.Rules[i].name);
                if (RuleLibrary.Rules[i] != selectedRule)
                    parentRule.Items.Add(RuleLibrary.Rules[i].name);
                else
                    ruleList.SelectedIndex = i;
            }
        }

        void NewRule_Click(object s, EventArgs e) {
            RuleLibrary.Rules.Add(new Rule("New rule", ((PropertyInfoListItem)targetProperty.Items[0]).item));
            UpdateRuleList();
            ruleList.SelectedIndex = RuleLibrary.Rules.Count - 1;
        }

        void ResetParent() {
            if (RuleLibrary.GetRuleByName(selectedRule.parentRule) == null)
                parentRule.SelectedItem = noParent;
            else
                parentRule.SelectedItem = selectedRule.parentRule;
        }

        void RuleList_SelectedIndexChanged(object s, EventArgs e) {
            selectedRule = RuleLibrary.Rules[ruleList.SelectedIndex];
            ruleName.Text = selectedRule.name;
            ResetParent();
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
            invert.Checked = selectedRule.invert;
            notify.Checked = selectedRule.notify;
            int newFromHour = selectedRule.fromTime / 60, newFromMinute = selectedRule.fromTime % 60,
                newToHour = selectedRule.toTime / 60, newToMinute = selectedRule.toTime % 60;
            fromHour.Value = newFromHour;
            fromMinute.Value = newFromMinute;
            toHour.Value = newToHour;
            toMinute.Value = newToMinute;
        }

        void RuleName_TextChanged(object s, EventArgs e) {
            if (selectedRule != null) {
                // Don't allow naming a rule as the no parent option
                if (ruleName.Text.Equals(noParent)) {
                    ruleName.BackColor = Color.Red;
                    return;
                }
                // Don't allow name collisions
                foreach (Rule rule in RuleLibrary.Rules) {
                    if (rule.name.Equals(ruleName.Text) && rule != selectedRule) {
                        ruleName.BackColor = Color.Red;
                        return;
                    }
                }
                // Keep the parents
                foreach (Rule rule in RuleLibrary.Rules)
                    if (rule.parentRule != null && rule.parentRule.Equals(selectedRule.name))
                        rule.parentRule = ruleName.Text;
                // Finalize
                ruleName.BackColor = textFieldColor;
                selectedRule.name = ruleName.Text;
                UpdateRuleList();
            }
        }

        private void ParentRule_SelectedIndexChanged(object s, EventArgs e) {
            if (selectedRule != null) {
                Rule checkedRule = RuleLibrary.GetRuleByName(parentRule.Text);
                while (checkedRule != null) {
                    checkedRule = RuleLibrary.GetRuleByName(checkedRule.parentRule);
                    if (checkedRule == selectedRule) {
                        MessageBox.Show("Loops are not allowed in the parent rule chain.");
                        ResetParent();
                        return;
                    }
                }
                selectedRule.parentRule = parentRule.Text;
            }
        }

        void TargetRoom_SelectedIndexChanged(object s, EventArgs e) {
            if (selectedRule != null)
                selectedRule.targetRoom = ((RoomListItem)targetRoom.SelectedItem).item;
        }

        void TargetProperty_SelectedIndexChanged(object s, EventArgs e) {
            PropertyInfo property = ((PropertyInfoListItem)targetProperty.SelectedItem).item;
            if (selectedRule != null)
                selectedRule.targetProperty = property;
            bool booleanProperty = property.PropertyType == typeof(bool);
            occurence.Enabled = booleanProperty;
            minValue.Enabled = !booleanProperty;
            maxValue.Enabled = !booleanProperty;
        }

        void Span_ValueChanged(object s, EventArgs e) {
            if (selectedRule != null)
                selectedRule.span = TimeSpan.FromMinutes((int)span.Value);
        }

        void Occurence_ValueChanged(object s, EventArgs e) {
            if (selectedRule != null)
                selectedRule.occurence = (int)occurence.Value;
        }

        void MinValue_ValueChanged(object s, EventArgs e) {
            if (selectedRule != null)
                selectedRule.minValue = (float)minValue.Value;
        }

        void MaxValue_ValueChanged(object s, EventArgs e) {
            if (selectedRule != null)
                selectedRule.maxValue = (float)maxValue.Value;
        }

        void Invert_CheckedChanged(object s, EventArgs e) {
            if (selectedRule != null)
                selectedRule.invert = invert.Checked;
        }

        void Notify_CheckedChanged(object s, EventArgs e) {
            if (selectedRule != null)
                selectedRule.notify = notify.Checked;
        }

        void FromHour_ValueChanged(object s, EventArgs e) => FromMinute_ValueChanged(s, e);

        void FromMinute_ValueChanged(object s, EventArgs e) {
            if (selectedRule != null)
                selectedRule.fromTime = (int)fromHour.Value * 60 + (int)fromMinute.Value;
        }

        void ToHour_ValueChanged(object s, EventArgs e) => ToMinute_ValueChanged(s, e);

        void ToMinute_ValueChanged(object s, EventArgs e) {
            if (selectedRule != null)
                selectedRule.toTime = (int)toHour.Value * 60 + (int)toMinute.Value;
        }

        void DeleteRule_Click(object s, EventArgs e) {
            if (selectedRule != null) {
                bool canRemove = false;
                foreach (Rule rule in RuleLibrary.Rules) {
                    if (rule.parentRule != null && rule.parentRule.Equals(selectedRule.name)) {
                        if (!canRemove) {
                            if (MessageBox.Show("This rule is the parent of other rules. Do you really want to delete it?", "Confirm deletion",
                                MessageBoxButtons.YesNo) == DialogResult.Yes)
                                canRemove = true;
                            else
                                return;
                        }
                        if (canRemove)
                            rule.parentRule = null;
                    }
                }
                RuleLibrary.Rules.Remove(selectedRule);
                UpdateRuleList();
                if (RuleLibrary.Rules.Count > 0)
                    ruleList.SelectedIndex = 0;
            }
        }

        void Close_Click(object s, EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        void RuleEditor_FormClosing(object s, FormClosingEventArgs e) => RuleLibrary.SaveRules();
    }
}