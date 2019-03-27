namespace HomeEditor.Rules {
    partial class RuleEditor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ruleList = new System.Windows.Forms.ListBox();
            this.newRule = new System.Windows.Forms.Button();
            this.targetRoom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.targetProperty = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.occurence = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.span = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.minValue = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.maxValue = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Button();
            this.ruleName = new System.Windows.Forms.TextBox();
            this.deleteRule = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.occurence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.span)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxValue)).BeginInit();
            this.SuspendLayout();
            // 
            // ruleList
            // 
            this.ruleList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ruleList.FormattingEnabled = true;
            this.ruleList.Location = new System.Drawing.Point(12, 12);
            this.ruleList.Name = "ruleList";
            this.ruleList.Size = new System.Drawing.Size(566, 394);
            this.ruleList.TabIndex = 0;
            this.ruleList.SelectedIndexChanged += new System.EventHandler(this.RuleList_SelectedIndexChanged);
            // 
            // newRule
            // 
            this.newRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newRule.Location = new System.Drawing.Point(584, 12);
            this.newRule.Name = "newRule";
            this.newRule.Size = new System.Drawing.Size(188, 23);
            this.newRule.TabIndex = 1;
            this.newRule.Text = "New rule";
            this.newRule.UseVisualStyleBackColor = true;
            this.newRule.Click += new System.EventHandler(this.NewRule_Click);
            // 
            // targetRoom
            // 
            this.targetRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.targetRoom.FormattingEnabled = true;
            this.targetRoom.Location = new System.Drawing.Point(628, 67);
            this.targetRoom.Name = "targetRoom";
            this.targetRoom.Size = new System.Drawing.Size(144, 21);
            this.targetRoom.TabIndex = 3;
            this.targetRoom.Text = "None";
            this.targetRoom.SelectedIndexChanged += new System.EventHandler(this.TargetRoom_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(584, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Room:";
            // 
            // targetProperty
            // 
            this.targetProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.targetProperty.FormattingEnabled = true;
            this.targetProperty.Location = new System.Drawing.Point(639, 94);
            this.targetProperty.Name = "targetProperty";
            this.targetProperty.Size = new System.Drawing.Size(133, 21);
            this.targetProperty.TabIndex = 4;
            this.targetProperty.SelectedIndexChanged += new System.EventHandler(this.TargetProperty_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(584, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Property:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(584, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Span:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(584, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Occurence:";
            // 
            // occurence
            // 
            this.occurence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.occurence.Location = new System.Drawing.Point(653, 147);
            this.occurence.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.occurence.Name = "occurence";
            this.occurence.Size = new System.Drawing.Size(82, 20);
            this.occurence.TabIndex = 9;
            this.occurence.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.occurence.ValueChanged += new System.EventHandler(this.Occurence_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(741, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "times";
            // 
            // span
            // 
            this.span.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.span.Location = new System.Drawing.Point(625, 121);
            this.span.Name = "span";
            this.span.Size = new System.Drawing.Size(98, 20);
            this.span.TabIndex = 6;
            this.span.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.span.ValueChanged += new System.EventHandler(this.Span_ValueChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(729, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "minutes";
            // 
            // minValue
            // 
            this.minValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minValue.DecimalPlaces = 1;
            this.minValue.Location = new System.Drawing.Point(670, 173);
            this.minValue.Name = "minValue";
            this.minValue.Size = new System.Drawing.Size(102, 20);
            this.minValue.TabIndex = 12;
            this.minValue.ValueChanged += new System.EventHandler(this.MinValue_ValueChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(584, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Minimum value:";
            // 
            // maxValue
            // 
            this.maxValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxValue.DecimalPlaces = 1;
            this.maxValue.Location = new System.Drawing.Point(673, 199);
            this.maxValue.Name = "maxValue";
            this.maxValue.Size = new System.Drawing.Size(99, 20);
            this.maxValue.TabIndex = 14;
            this.maxValue.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.maxValue.ValueChanged += new System.EventHandler(this.MaxValue_ValueChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(584, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Maximum value:";
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close.Location = new System.Drawing.Point(584, 391);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(188, 23);
            this.close.TabIndex = 16;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.Close_Click);
            // 
            // ruleName
            // 
            this.ruleName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ruleName.Location = new System.Drawing.Point(584, 41);
            this.ruleName.Name = "ruleName";
            this.ruleName.Size = new System.Drawing.Size(188, 20);
            this.ruleName.TabIndex = 2;
            this.ruleName.Text = "Rule name";
            this.ruleName.TextChanged += new System.EventHandler(this.RuleName_TextChanged);
            // 
            // deleteRule
            // 
            this.deleteRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteRule.Location = new System.Drawing.Point(670, 225);
            this.deleteRule.Name = "deleteRule";
            this.deleteRule.Size = new System.Drawing.Size(102, 23);
            this.deleteRule.TabIndex = 17;
            this.deleteRule.Text = "Delete rule";
            this.deleteRule.UseVisualStyleBackColor = true;
            this.deleteRule.Click += new System.EventHandler(this.DeleteRule_Click);
            // 
            // RuleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 426);
            this.Controls.Add(this.deleteRule);
            this.Controls.Add(this.ruleName);
            this.Controls.Add(this.close);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.maxValue);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.minValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.span);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.occurence);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.targetProperty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.targetRoom);
            this.Controls.Add(this.newRule);
            this.Controls.Add(this.ruleList);
            this.Name = "RuleEditor";
            this.Text = "RuleEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RuleEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.occurence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.span)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ruleList;
        private System.Windows.Forms.Button newRule;
        private System.Windows.Forms.ComboBox targetRoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox targetProperty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown occurence;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown span;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown minValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown maxValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.TextBox ruleName;
        private System.Windows.Forms.Button deleteRule;
    }
}