namespace HomeEditor {
    partial class SensorDataSpoof {
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
            this.Movement = new System.Windows.Forms.CheckBox();
            this.Open = new System.Windows.Forms.CheckBox();
            this.Light = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Temperature = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Movement
            // 
            this.Movement.AutoSize = true;
            this.Movement.Location = new System.Drawing.Point(13, 13);
            this.Movement.Name = "Movement";
            this.Movement.Size = new System.Drawing.Size(121, 17);
            this.Movement.TabIndex = 0;
            this.Movement.Text = "Movement detected";
            this.Movement.UseVisualStyleBackColor = true;
            // 
            // Open
            // 
            this.Open.AutoSize = true;
            this.Open.Location = new System.Drawing.Point(13, 36);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(139, 17);
            this.Open.TabIndex = 1;
            this.Open.Text = "Door or window opened";
            this.Open.UseVisualStyleBackColor = true;
            // 
            // Light
            // 
            this.Light.Location = new System.Drawing.Point(80, 59);
            this.Light.Name = "Light";
            this.Light.Size = new System.Drawing.Size(100, 20);
            this.Light.TabIndex = 2;
            this.Light.Text = "66,101116116105";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Light value:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Temperature:";
            // 
            // Temperature
            // 
            this.Temperature.Location = new System.Drawing.Point(88, 85);
            this.Temperature.Name = "Temperature";
            this.Temperature.Size = new System.Drawing.Size(92, 20);
            this.Temperature.TabIndex = 5;
            this.Temperature.Text = "25,4";
            // 
            // ok
            // 
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.Location = new System.Drawing.Point(106, 111);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 6;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // SensorDataSpoof
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 143);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.Temperature);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Light);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.Movement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SensorDataSpoof";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Sensor data spoofing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Movement;
        private System.Windows.Forms.CheckBox Open;
        private System.Windows.Forms.TextBox Light;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Temperature;
        private System.Windows.Forms.Button ok;
    }
}