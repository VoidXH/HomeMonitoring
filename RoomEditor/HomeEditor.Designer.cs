namespace HomeEditor {
    partial class HomeEditor {
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
            this.components = new System.ComponentModel.Container();
            this.addRoom = new System.Windows.Forms.Button();
            this.roomSettings = new System.Windows.Forms.GroupBox();
            this.sensorSettings = new System.Windows.Forms.GroupBox();
            this.sensorName = new System.Windows.Forms.TextBox();
            this.sensorNameLabel = new System.Windows.Forms.Label();
            this.spoofSensor = new System.Windows.Forms.Button();
            this.sensorAddress = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.deleteSensor = new System.Windows.Forms.Button();
            this.addSensor = new System.Windows.Forms.Button();
            this.deleteRoom = new System.Windows.Forms.Button();
            this.roomHeightDisplay = new System.Windows.Forms.Label();
            this.roomHeightLabel = new System.Windows.Forms.Label();
            this.roomHeight = new System.Windows.Forms.TrackBar();
            this.roomWidthDisplay = new System.Windows.Forms.Label();
            this.roomWidthLabel = new System.Windows.Forms.Label();
            this.roomWidth = new System.Windows.Forms.TrackBar();
            this.roomName = new System.Windows.Forms.TextBox();
            this.roomNameLabel = new System.Windows.Forms.Label();
            this.obstacleSettings = new System.Windows.Forms.GroupBox();
            this.deleteObstacle = new System.Windows.Forms.Button();
            this.obstacleName = new System.Windows.Forms.TextBox();
            this.obstacleNameLabel = new System.Windows.Forms.Label();
            this.addObstacle = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundSplit = new System.Windows.Forms.SplitContainer();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.openDebugger = new System.Windows.Forms.Button();
            this.activityLabel = new System.Windows.Forms.Label();
            this.locate = new System.Windows.Forms.Button();
            this.simulator = new System.Windows.Forms.CheckBox();
            this.addDoor = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.doorSettings = new System.Windows.Forms.GroupBox();
            this.doorSensorSettings = new System.Windows.Forms.GroupBox();
            this.doorSensorName = new System.Windows.Forms.TextBox();
            this.doorNameLabel = new System.Windows.Forms.Label();
            this.spoofDoor = new System.Windows.Forms.Button();
            this.doorSensorAddress = new System.Windows.Forms.TextBox();
            this.doorAddressLabel = new System.Windows.Forms.Label();
            this.doorSensorAttached = new System.Windows.Forms.CheckBox();
            this.doorType = new System.Windows.Forms.GroupBox();
            this.doorWindow = new System.Windows.Forms.RadioButton();
            this.doorEntrance = new System.Windows.Forms.RadioButton();
            this.doorDoor = new System.Windows.Forms.RadioButton();
            this.doorOrientation = new System.Windows.Forms.GroupBox();
            this.doorHorizontal = new System.Windows.Forms.RadioButton();
            this.doorVertical = new System.Windows.Forms.RadioButton();
            this.deleteDoor = new System.Windows.Forms.Button();
            this.doorSizeDisplay = new System.Windows.Forms.Label();
            this.doorSizeLabel = new System.Windows.Forms.Label();
            this.doorSize = new System.Windows.Forms.TrackBar();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.LastAlert = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.roomSettings.SuspendLayout();
            this.sensorSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomWidth)).BeginInit();
            this.obstacleSettings.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundSplit)).BeginInit();
            this.backgroundSplit.Panel1.SuspendLayout();
            this.backgroundSplit.Panel2.SuspendLayout();
            this.backgroundSplit.SuspendLayout();
            this.doorSettings.SuspendLayout();
            this.doorSensorSettings.SuspendLayout();
            this.doorType.SuspendLayout();
            this.doorOrientation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doorSize)).BeginInit();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // addRoom
            // 
            this.addRoom.Location = new System.Drawing.Point(3, 3);
            this.addRoom.Name = "addRoom";
            this.addRoom.Size = new System.Drawing.Size(125, 23);
            this.addRoom.TabIndex = 3;
            this.addRoom.Text = "Add room";
            this.addRoom.UseVisualStyleBackColor = true;
            this.addRoom.Click += new System.EventHandler(this.AddRoom_Click);
            // 
            // roomSettings
            // 
            this.roomSettings.Controls.Add(this.sensorSettings);
            this.roomSettings.Controls.Add(this.addSensor);
            this.roomSettings.Controls.Add(this.deleteRoom);
            this.roomSettings.Controls.Add(this.roomHeightDisplay);
            this.roomSettings.Controls.Add(this.roomHeightLabel);
            this.roomSettings.Controls.Add(this.roomHeight);
            this.roomSettings.Controls.Add(this.roomWidthDisplay);
            this.roomSettings.Controls.Add(this.roomWidthLabel);
            this.roomSettings.Controls.Add(this.roomWidth);
            this.roomSettings.Controls.Add(this.roomName);
            this.roomSettings.Controls.Add(this.roomNameLabel);
            this.roomSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.roomSettings.Location = new System.Drawing.Point(624, 24);
            this.roomSettings.Name = "roomSettings";
            this.roomSettings.Size = new System.Drawing.Size(200, 425);
            this.roomSettings.TabIndex = 2;
            this.roomSettings.TabStop = false;
            this.roomSettings.Text = "Room settings";
            this.roomSettings.Visible = false;
            // 
            // sensorSettings
            // 
            this.sensorSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sensorSettings.Controls.Add(this.sensorName);
            this.sensorSettings.Controls.Add(this.sensorNameLabel);
            this.sensorSettings.Controls.Add(this.spoofSensor);
            this.sensorSettings.Controls.Add(this.sensorAddress);
            this.sensorSettings.Controls.Add(this.addressLabel);
            this.sensorSettings.Controls.Add(this.deleteSensor);
            this.sensorSettings.Location = new System.Drawing.Point(6, 188);
            this.sensorSettings.Name = "sensorSettings";
            this.sensorSettings.Size = new System.Drawing.Size(188, 103);
            this.sensorSettings.TabIndex = 9;
            this.sensorSettings.TabStop = false;
            this.sensorSettings.Text = "Sensor settings";
            this.sensorSettings.Visible = false;
            // 
            // sensorName
            // 
            this.sensorName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sensorName.Location = new System.Drawing.Point(50, 19);
            this.sensorName.Name = "sensorName";
            this.sensorName.Size = new System.Drawing.Size(132, 20);
            this.sensorName.TabIndex = 14;
            this.sensorName.TextChanged += new System.EventHandler(this.SensorName_TextChanged);
            // 
            // sensorNameLabel
            // 
            this.sensorNameLabel.AutoSize = true;
            this.sensorNameLabel.Location = new System.Drawing.Point(6, 22);
            this.sensorNameLabel.Name = "sensorNameLabel";
            this.sensorNameLabel.Size = new System.Drawing.Size(38, 13);
            this.sensorNameLabel.TabIndex = 17;
            this.sensorNameLabel.Text = "Name:";
            // 
            // spoofSensor
            // 
            this.spoofSensor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spoofSensor.Location = new System.Drawing.Point(6, 74);
            this.spoofSensor.Name = "spoofSensor";
            this.spoofSensor.Size = new System.Drawing.Size(75, 23);
            this.spoofSensor.TabIndex = 16;
            this.spoofSensor.Text = "Spoof";
            this.spoofSensor.UseVisualStyleBackColor = true;
            this.spoofSensor.Visible = false;
            this.spoofSensor.Click += new System.EventHandler(this.SpoofSensor_Click);
            // 
            // sensorAddress
            // 
            this.sensorAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sensorAddress.Location = new System.Drawing.Point(61, 45);
            this.sensorAddress.Name = "sensorAddress";
            this.sensorAddress.Size = new System.Drawing.Size(121, 20);
            this.sensorAddress.TabIndex = 15;
            this.sensorAddress.TextChanged += new System.EventHandler(this.SensorAddress_TextChanged);
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(6, 48);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(48, 13);
            this.addressLabel.TabIndex = 3;
            this.addressLabel.Text = "Address:";
            // 
            // deleteSensor
            // 
            this.deleteSensor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteSensor.Location = new System.Drawing.Point(107, 74);
            this.deleteSensor.Name = "deleteSensor";
            this.deleteSensor.Size = new System.Drawing.Size(75, 23);
            this.deleteSensor.TabIndex = 17;
            this.deleteSensor.Text = "Delete";
            this.deleteSensor.UseVisualStyleBackColor = true;
            this.deleteSensor.Click += new System.EventHandler(this.DeleteSensor_Click);
            // 
            // addSensor
            // 
            this.addSensor.Location = new System.Drawing.Point(6, 159);
            this.addSensor.Name = "addSensor";
            this.addSensor.Size = new System.Drawing.Size(100, 23);
            this.addSensor.TabIndex = 13;
            this.addSensor.Text = "Add sensor";
            this.addSensor.UseVisualStyleBackColor = true;
            this.addSensor.Click += new System.EventHandler(this.AddSensor_Click);
            // 
            // deleteRoom
            // 
            this.deleteRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteRoom.Location = new System.Drawing.Point(119, 396);
            this.deleteRoom.Name = "deleteRoom";
            this.deleteRoom.Size = new System.Drawing.Size(75, 23);
            this.deleteRoom.TabIndex = 19;
            this.deleteRoom.Text = "Delete";
            this.deleteRoom.UseVisualStyleBackColor = true;
            this.deleteRoom.Click += new System.EventHandler(this.Delete_Click);
            // 
            // roomHeightDisplay
            // 
            this.roomHeightDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.roomHeightDisplay.Location = new System.Drawing.Point(144, 130);
            this.roomHeightDisplay.Name = "roomHeightDisplay";
            this.roomHeightDisplay.Size = new System.Drawing.Size(50, 13);
            this.roomHeightDisplay.TabIndex = 7;
            this.roomHeightDisplay.Text = "5 m";
            this.roomHeightDisplay.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // roomHeightLabel
            // 
            this.roomHeightLabel.AutoSize = true;
            this.roomHeightLabel.Location = new System.Drawing.Point(6, 130);
            this.roomHeightLabel.Name = "roomHeightLabel";
            this.roomHeightLabel.Size = new System.Drawing.Size(38, 13);
            this.roomHeightLabel.TabIndex = 6;
            this.roomHeightLabel.Text = "Height";
            // 
            // roomHeight
            // 
            this.roomHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roomHeight.Location = new System.Drawing.Point(9, 98);
            this.roomHeight.Maximum = 50;
            this.roomHeight.Minimum = 1;
            this.roomHeight.Name = "roomHeight";
            this.roomHeight.Size = new System.Drawing.Size(185, 45);
            this.roomHeight.TabIndex = 12;
            this.roomHeight.TickStyle = System.Windows.Forms.TickStyle.None;
            this.roomHeight.Value = 5;
            this.roomHeight.ValueChanged += new System.EventHandler(this.RoomHeight_ValueChanged);
            // 
            // roomWidthDisplay
            // 
            this.roomWidthDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.roomWidthDisplay.Location = new System.Drawing.Point(144, 78);
            this.roomWidthDisplay.Name = "roomWidthDisplay";
            this.roomWidthDisplay.Size = new System.Drawing.Size(50, 13);
            this.roomWidthDisplay.TabIndex = 4;
            this.roomWidthDisplay.Text = "5 m";
            this.roomWidthDisplay.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // roomWidthLabel
            // 
            this.roomWidthLabel.AutoSize = true;
            this.roomWidthLabel.Location = new System.Drawing.Point(6, 78);
            this.roomWidthLabel.Name = "roomWidthLabel";
            this.roomWidthLabel.Size = new System.Drawing.Size(35, 13);
            this.roomWidthLabel.TabIndex = 3;
            this.roomWidthLabel.Text = "Width";
            // 
            // roomWidth
            // 
            this.roomWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roomWidth.Location = new System.Drawing.Point(9, 46);
            this.roomWidth.Maximum = 50;
            this.roomWidth.Minimum = 1;
            this.roomWidth.Name = "roomWidth";
            this.roomWidth.Size = new System.Drawing.Size(185, 45);
            this.roomWidth.TabIndex = 11;
            this.roomWidth.TickStyle = System.Windows.Forms.TickStyle.None;
            this.roomWidth.Value = 5;
            this.roomWidth.ValueChanged += new System.EventHandler(this.RoomWidth_ValueChanged);
            // 
            // roomName
            // 
            this.roomName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roomName.Location = new System.Drawing.Point(50, 20);
            this.roomName.Name = "roomName";
            this.roomName.Size = new System.Drawing.Size(144, 20);
            this.roomName.TabIndex = 10;
            this.roomName.TextChanged += new System.EventHandler(this.RoomName_TextChanged);
            // 
            // roomNameLabel
            // 
            this.roomNameLabel.AutoSize = true;
            this.roomNameLabel.Location = new System.Drawing.Point(6, 23);
            this.roomNameLabel.Name = "roomNameLabel";
            this.roomNameLabel.Size = new System.Drawing.Size(38, 13);
            this.roomNameLabel.TabIndex = 0;
            this.roomNameLabel.Text = "Name:";
            // 
            // obstacleSettings
            // 
            this.obstacleSettings.Controls.Add(this.deleteObstacle);
            this.obstacleSettings.Controls.Add(this.obstacleName);
            this.obstacleSettings.Controls.Add(this.obstacleNameLabel);
            this.obstacleSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.obstacleSettings.Location = new System.Drawing.Point(424, 24);
            this.obstacleSettings.Name = "obstacleSettings";
            this.obstacleSettings.Size = new System.Drawing.Size(200, 425);
            this.obstacleSettings.TabIndex = 3;
            this.obstacleSettings.TabStop = false;
            this.obstacleSettings.Text = "Obstacle settings";
            this.obstacleSettings.Visible = false;
            // 
            // deleteObstacle
            // 
            this.deleteObstacle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteObstacle.Location = new System.Drawing.Point(119, 396);
            this.deleteObstacle.Name = "deleteObstacle";
            this.deleteObstacle.Size = new System.Drawing.Size(75, 23);
            this.deleteObstacle.TabIndex = 29;
            this.deleteObstacle.Text = "Delete";
            this.deleteObstacle.UseVisualStyleBackColor = true;
            this.deleteObstacle.Click += new System.EventHandler(this.Delete_Click);
            // 
            // obstacleName
            // 
            this.obstacleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.obstacleName.Location = new System.Drawing.Point(50, 20);
            this.obstacleName.Name = "obstacleName";
            this.obstacleName.Size = new System.Drawing.Size(144, 20);
            this.obstacleName.TabIndex = 20;
            this.obstacleName.TextChanged += new System.EventHandler(this.ObstacleName_TextChanged);
            // 
            // obstacleNameLabel
            // 
            this.obstacleNameLabel.AutoSize = true;
            this.obstacleNameLabel.Location = new System.Drawing.Point(6, 23);
            this.obstacleNameLabel.Name = "obstacleNameLabel";
            this.obstacleNameLabel.Size = new System.Drawing.Size(38, 13);
            this.obstacleNameLabel.TabIndex = 0;
            this.obstacleNameLabel.Text = "Name:";
            // 
            // addObstacle
            // 
            this.addObstacle.Location = new System.Drawing.Point(3, 32);
            this.addObstacle.Name = "addObstacle";
            this.addObstacle.Size = new System.Drawing.Size(125, 23);
            this.addObstacle.TabIndex = 4;
            this.addObstacle.Text = "Add obstacle";
            this.addObstacle.UseVisualStyleBackColor = true;
            this.addObstacle.Click += new System.EventHandler(this.AddObstacle_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(824, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.loadRecentToolStripMenuItem,
            this.saveToolStripMenuItem1,
            this.saveToolStripMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.ShortcutKeyDisplayString = "";
            this.fileMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.loadToolStripMenuItem.Text = "Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // loadRecentToolStripMenuItem
            // 
            this.loadRecentToolStripMenuItem.Name = "loadRecentToolStripMenuItem";
            this.loadRecentToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.loadRecentToolStripMenuItem.Text = "Load recent";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.SaveToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.saveToolStripMenuItem.Text = "Save as...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.ShortcutKeyDisplayString = "";
            this.helpMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.helpMenu.Size = new System.Drawing.Size(44, 20);
            this.helpMenu.Text = "&Help";
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.colorsToolStripMenuItem.Text = "Colors";
            this.colorsToolStripMenuItem.Click += new System.EventHandler(this.ColorsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // backgroundSplit
            // 
            this.backgroundSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.backgroundSplit.IsSplitterFixed = true;
            this.backgroundSplit.Location = new System.Drawing.Point(0, 24);
            this.backgroundSplit.Name = "backgroundSplit";
            // 
            // backgroundSplit.Panel1
            // 
            this.backgroundSplit.Panel1.Controls.Add(this.drawingPanel);
            // 
            // backgroundSplit.Panel2
            // 
            this.backgroundSplit.Panel2.AutoScroll = true;
            this.backgroundSplit.Panel2.Controls.Add(this.openDebugger);
            this.backgroundSplit.Panel2.Controls.Add(this.activityLabel);
            this.backgroundSplit.Panel2.Controls.Add(this.locate);
            this.backgroundSplit.Panel2.Controls.Add(this.simulator);
            this.backgroundSplit.Panel2.Controls.Add(this.addDoor);
            this.backgroundSplit.Panel2.Controls.Add(this.addObstacle);
            this.backgroundSplit.Panel2.Controls.Add(this.addRoom);
            this.backgroundSplit.Size = new System.Drawing.Size(224, 425);
            this.backgroundSplit.SplitterDistance = 89;
            this.backgroundSplit.TabIndex = 2;
            this.backgroundSplit.TabStop = false;
            // 
            // drawingPanel
            // 
            this.drawingPanel.AutoScroll = true;
            this.drawingPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel.Location = new System.Drawing.Point(0, 0);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(89, 425);
            this.drawingPanel.TabIndex = 0;
            this.drawingPanel.Click += new System.EventHandler(this.DrawingPanel_Click);
            // 
            // openDebugger
            // 
            this.openDebugger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openDebugger.Location = new System.Drawing.Point(3, 377);
            this.openDebugger.Name = "openDebugger";
            this.openDebugger.Size = new System.Drawing.Size(125, 23);
            this.openDebugger.TabIndex = 8;
            this.openDebugger.Text = "MQTT debugger";
            this.openDebugger.UseVisualStyleBackColor = true;
            this.openDebugger.Visible = false;
            this.openDebugger.Click += new System.EventHandler(this.OpenDebugger_Click);
            // 
            // activityLabel
            // 
            this.activityLabel.AutoSize = true;
            this.activityLabel.Location = new System.Drawing.Point(3, 188);
            this.activityLabel.Name = "activityLabel";
            this.activityLabel.Size = new System.Drawing.Size(118, 13);
            this.activityLabel.TabIndex = 8;
            this.activityLabel.Text = "Activity: None detected";
            // 
            // locate
            // 
            this.locate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.locate.Location = new System.Drawing.Point(3, 159);
            this.locate.Name = "locate";
            this.locate.Size = new System.Drawing.Size(125, 23);
            this.locate.TabIndex = 7;
            this.locate.Text = "Locate user";
            this.locate.UseVisualStyleBackColor = true;
            this.locate.Click += new System.EventHandler(this.Locate_Click);
            // 
            // simulator
            // 
            this.simulator.AutoSize = true;
            this.simulator.Location = new System.Drawing.Point(3, 136);
            this.simulator.Name = "simulator";
            this.simulator.Size = new System.Drawing.Size(105, 17);
            this.simulator.TabIndex = 6;
            this.simulator.Text = "Simulate sensors";
            this.simulator.UseVisualStyleBackColor = true;
            this.simulator.Visible = false;
            this.simulator.CheckedChanged += new System.EventHandler(this.Simulator_CheckedChanged);
            // 
            // addDoor
            // 
            this.addDoor.Location = new System.Drawing.Point(3, 61);
            this.addDoor.Name = "addDoor";
            this.addDoor.Size = new System.Drawing.Size(125, 23);
            this.addDoor.TabIndex = 5;
            this.addDoor.Text = "Add door";
            this.addDoor.UseVisualStyleBackColor = true;
            this.addDoor.Click += new System.EventHandler(this.AddDoor_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "xml";
            this.openFileDialog.Filter = "XML files|*.xml";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xml";
            this.saveFileDialog.Filter = "XML files|*.xml";
            // 
            // doorSettings
            // 
            this.doorSettings.Controls.Add(this.doorSensorSettings);
            this.doorSettings.Controls.Add(this.doorType);
            this.doorSettings.Controls.Add(this.doorOrientation);
            this.doorSettings.Controls.Add(this.deleteDoor);
            this.doorSettings.Controls.Add(this.doorSizeDisplay);
            this.doorSettings.Controls.Add(this.doorSizeLabel);
            this.doorSettings.Controls.Add(this.doorSize);
            this.doorSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.doorSettings.Location = new System.Drawing.Point(224, 24);
            this.doorSettings.Name = "doorSettings";
            this.doorSettings.Size = new System.Drawing.Size(200, 425);
            this.doorSettings.TabIndex = 4;
            this.doorSettings.TabStop = false;
            this.doorSettings.Text = "Door settings";
            this.doorSettings.Visible = false;
            // 
            // doorSensorSettings
            // 
            this.doorSensorSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doorSensorSettings.Controls.Add(this.doorSensorName);
            this.doorSensorSettings.Controls.Add(this.doorNameLabel);
            this.doorSensorSettings.Controls.Add(this.spoofDoor);
            this.doorSensorSettings.Controls.Add(this.doorSensorAddress);
            this.doorSensorSettings.Controls.Add(this.doorAddressLabel);
            this.doorSensorSettings.Controls.Add(this.doorSensorAttached);
            this.doorSensorSettings.Location = new System.Drawing.Point(6, 222);
            this.doorSensorSettings.Name = "doorSensorSettings";
            this.doorSensorSettings.Size = new System.Drawing.Size(188, 125);
            this.doorSensorSettings.TabIndex = 33;
            this.doorSensorSettings.TabStop = false;
            this.doorSensorSettings.Text = "Sensor settings";
            // 
            // doorSensorName
            // 
            this.doorSensorName.Location = new System.Drawing.Point(50, 43);
            this.doorSensorName.Name = "doorSensorName";
            this.doorSensorName.Size = new System.Drawing.Size(132, 20);
            this.doorSensorName.TabIndex = 34;
            this.doorSensorName.TextChanged += new System.EventHandler(this.DoorSensorName_TextChanged);
            // 
            // doorNameLabel
            // 
            this.doorNameLabel.AutoSize = true;
            this.doorNameLabel.Location = new System.Drawing.Point(6, 46);
            this.doorNameLabel.Name = "doorNameLabel";
            this.doorNameLabel.Size = new System.Drawing.Size(38, 13);
            this.doorNameLabel.TabIndex = 4;
            this.doorNameLabel.Text = "Name:";
            // 
            // spoofDoor
            // 
            this.spoofDoor.Location = new System.Drawing.Point(6, 95);
            this.spoofDoor.Name = "spoofDoor";
            this.spoofDoor.Size = new System.Drawing.Size(75, 23);
            this.spoofDoor.TabIndex = 36;
            this.spoofDoor.Text = "Spoof";
            this.spoofDoor.UseVisualStyleBackColor = true;
            this.spoofDoor.Visible = false;
            this.spoofDoor.Click += new System.EventHandler(this.SpoofDoor_Click);
            // 
            // doorSensorAddress
            // 
            this.doorSensorAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doorSensorAddress.Enabled = false;
            this.doorSensorAddress.Location = new System.Drawing.Point(60, 69);
            this.doorSensorAddress.Name = "doorSensorAddress";
            this.doorSensorAddress.Size = new System.Drawing.Size(122, 20);
            this.doorSensorAddress.TabIndex = 35;
            this.doorSensorAddress.TextChanged += new System.EventHandler(this.DoorSensorAddress_TextChanged);
            // 
            // doorAddressLabel
            // 
            this.doorAddressLabel.AutoSize = true;
            this.doorAddressLabel.Location = new System.Drawing.Point(6, 72);
            this.doorAddressLabel.Name = "doorAddressLabel";
            this.doorAddressLabel.Size = new System.Drawing.Size(48, 13);
            this.doorAddressLabel.TabIndex = 1;
            this.doorAddressLabel.Text = "Address:";
            // 
            // doorSensorAttached
            // 
            this.doorSensorAttached.AutoSize = true;
            this.doorSensorAttached.Location = new System.Drawing.Point(7, 20);
            this.doorSensorAttached.Name = "doorSensorAttached";
            this.doorSensorAttached.Size = new System.Drawing.Size(69, 17);
            this.doorSensorAttached.TabIndex = 33;
            this.doorSensorAttached.Text = "Attached";
            this.doorSensorAttached.UseVisualStyleBackColor = true;
            this.doorSensorAttached.CheckedChanged += new System.EventHandler(this.DoorSensorAttached_CheckedChanged);
            // 
            // doorType
            // 
            this.doorType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doorType.Controls.Add(this.doorWindow);
            this.doorType.Controls.Add(this.doorEntrance);
            this.doorType.Controls.Add(this.doorDoor);
            this.doorType.Location = new System.Drawing.Point(6, 20);
            this.doorType.Name = "doorType";
            this.doorType.Size = new System.Drawing.Size(188, 91);
            this.doorType.TabIndex = 30;
            this.doorType.TabStop = false;
            this.doorType.Text = "Type";
            // 
            // doorWindow
            // 
            this.doorWindow.AutoSize = true;
            this.doorWindow.Location = new System.Drawing.Point(6, 65);
            this.doorWindow.Name = "doorWindow";
            this.doorWindow.Size = new System.Drawing.Size(64, 17);
            this.doorWindow.TabIndex = 3;
            this.doorWindow.Text = "Window";
            this.doorWindow.UseVisualStyleBackColor = true;
            this.doorWindow.CheckedChanged += new System.EventHandler(this.DoorWindow_CheckedChanged);
            // 
            // doorEntrance
            // 
            this.doorEntrance.AutoSize = true;
            this.doorEntrance.Location = new System.Drawing.Point(6, 42);
            this.doorEntrance.Name = "doorEntrance";
            this.doorEntrance.Size = new System.Drawing.Size(68, 17);
            this.doorEntrance.TabIndex = 2;
            this.doorEntrance.Text = "Entrance";
            this.doorEntrance.UseVisualStyleBackColor = true;
            this.doorEntrance.CheckedChanged += new System.EventHandler(this.DoorEntrance_CheckedChanged);
            // 
            // doorDoor
            // 
            this.doorDoor.AutoSize = true;
            this.doorDoor.Checked = true;
            this.doorDoor.Location = new System.Drawing.Point(6, 19);
            this.doorDoor.Name = "doorDoor";
            this.doorDoor.Size = new System.Drawing.Size(48, 17);
            this.doorDoor.TabIndex = 1;
            this.doorDoor.TabStop = true;
            this.doorDoor.Text = "Door";
            this.doorDoor.UseVisualStyleBackColor = true;
            this.doorDoor.CheckedChanged += new System.EventHandler(this.DoorDoor_CheckedChanged);
            // 
            // doorOrientation
            // 
            this.doorOrientation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doorOrientation.Controls.Add(this.doorHorizontal);
            this.doorOrientation.Controls.Add(this.doorVertical);
            this.doorOrientation.Location = new System.Drawing.Point(6, 117);
            this.doorOrientation.Name = "doorOrientation";
            this.doorOrientation.Size = new System.Drawing.Size(188, 47);
            this.doorOrientation.TabIndex = 31;
            this.doorOrientation.TabStop = false;
            this.doorOrientation.Text = "Orientation";
            // 
            // doorHorizontal
            // 
            this.doorHorizontal.AutoSize = true;
            this.doorHorizontal.Checked = true;
            this.doorHorizontal.Location = new System.Drawing.Point(6, 19);
            this.doorHorizontal.Name = "doorHorizontal";
            this.doorHorizontal.Size = new System.Drawing.Size(72, 17);
            this.doorHorizontal.TabIndex = 1;
            this.doorHorizontal.TabStop = true;
            this.doorHorizontal.Text = "Horizontal";
            this.doorHorizontal.UseVisualStyleBackColor = true;
            this.doorHorizontal.CheckedChanged += new System.EventHandler(this.DoorHorizontal_CheckedChanged);
            // 
            // doorVertical
            // 
            this.doorVertical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doorVertical.AutoSize = true;
            this.doorVertical.Location = new System.Drawing.Point(108, 19);
            this.doorVertical.Name = "doorVertical";
            this.doorVertical.Size = new System.Drawing.Size(60, 17);
            this.doorVertical.TabIndex = 2;
            this.doorVertical.TabStop = true;
            this.doorVertical.Text = "Vertical";
            this.doorVertical.UseVisualStyleBackColor = true;
            // 
            // deleteDoor
            // 
            this.deleteDoor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteDoor.Location = new System.Drawing.Point(119, 396);
            this.deleteDoor.Name = "deleteDoor";
            this.deleteDoor.Size = new System.Drawing.Size(75, 23);
            this.deleteDoor.TabIndex = 39;
            this.deleteDoor.Text = "Delete";
            this.deleteDoor.UseVisualStyleBackColor = true;
            this.deleteDoor.Click += new System.EventHandler(this.Delete_Click);
            // 
            // doorSizeDisplay
            // 
            this.doorSizeDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doorSizeDisplay.Location = new System.Drawing.Point(144, 194);
            this.doorSizeDisplay.Name = "doorSizeDisplay";
            this.doorSizeDisplay.Size = new System.Drawing.Size(50, 13);
            this.doorSizeDisplay.TabIndex = 34;
            this.doorSizeDisplay.Text = "200 cm";
            this.doorSizeDisplay.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // doorSizeLabel
            // 
            this.doorSizeLabel.AutoSize = true;
            this.doorSizeLabel.Location = new System.Drawing.Point(6, 194);
            this.doorSizeLabel.Name = "doorSizeLabel";
            this.doorSizeLabel.Size = new System.Drawing.Size(27, 13);
            this.doorSizeLabel.TabIndex = 33;
            this.doorSizeLabel.Text = "Size";
            // 
            // doorSize
            // 
            this.doorSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doorSize.LargeChange = 25;
            this.doorSize.Location = new System.Drawing.Point(6, 170);
            this.doorSize.Maximum = 100;
            this.doorSize.Minimum = 10;
            this.doorSize.Name = "doorSize";
            this.doorSize.Size = new System.Drawing.Size(188, 45);
            this.doorSize.SmallChange = 5;
            this.doorSize.TabIndex = 32;
            this.doorSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.doorSize.Value = 50;
            this.doorSize.ValueChanged += new System.EventHandler(this.DoorSize_ValueChanged);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LastAlert});
            this.StatusStrip.Location = new System.Drawing.Point(0, 427);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(224, 22);
            this.StatusStrip.TabIndex = 5;
            this.StatusStrip.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StatusStrip_MouseClick);
            // 
            // LastAlert
            // 
            this.LastAlert.BackColor = System.Drawing.Color.Transparent;
            this.LastAlert.Name = "LastAlert";
            this.LastAlert.Size = new System.Drawing.Size(0, 17);
            // 
            // HomeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 449);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.backgroundSplit);
            this.Controls.Add(this.doorSettings);
            this.Controls.Add(this.obstacleSettings);
            this.Controls.Add(this.roomSettings);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "HomeEditor";
            this.Text = "Home Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HomeEditor_FormClosed);
            this.roomSettings.ResumeLayout(false);
            this.roomSettings.PerformLayout();
            this.sensorSettings.ResumeLayout(false);
            this.sensorSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomWidth)).EndInit();
            this.obstacleSettings.ResumeLayout(false);
            this.obstacleSettings.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.backgroundSplit.Panel1.ResumeLayout(false);
            this.backgroundSplit.Panel2.ResumeLayout(false);
            this.backgroundSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundSplit)).EndInit();
            this.backgroundSplit.ResumeLayout(false);
            this.doorSettings.ResumeLayout(false);
            this.doorSettings.PerformLayout();
            this.doorSensorSettings.ResumeLayout(false);
            this.doorSensorSettings.PerformLayout();
            this.doorType.ResumeLayout(false);
            this.doorType.PerformLayout();
            this.doorOrientation.ResumeLayout(false);
            this.doorOrientation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doorSize)).EndInit();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addRoom;
        private System.Windows.Forms.GroupBox roomSettings;
        private System.Windows.Forms.Label roomNameLabel;
        private System.Windows.Forms.TextBox roomName;
        private System.Windows.Forms.TrackBar roomWidth;
        private System.Windows.Forms.Label roomWidthDisplay;
        private System.Windows.Forms.Label roomWidthLabel;
        private System.Windows.Forms.TrackBar roomHeight;
        private System.Windows.Forms.Label roomHeightLabel;
        private System.Windows.Forms.Label roomHeightDisplay;
        private System.Windows.Forms.Button deleteRoom;
        private System.Windows.Forms.Button addObstacle;
        private System.Windows.Forms.GroupBox obstacleSettings;
        private System.Windows.Forms.Label obstacleNameLabel;
        private System.Windows.Forms.TextBox obstacleName;
        private System.Windows.Forms.Button deleteObstacle;
        private System.Windows.Forms.Button addSensor;
        private System.Windows.Forms.GroupBox sensorSettings;
        private System.Windows.Forms.Button deleteSensor;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SplitContainer backgroundSplit;
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem loadRecentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.TextBox sensorAddress;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Button addDoor;
        private System.Windows.Forms.GroupBox doorSettings;
        private System.Windows.Forms.TrackBar doorSize;
        private System.Windows.Forms.Label doorSizeDisplay;
        private System.Windows.Forms.Label doorSizeLabel;
        private System.Windows.Forms.Button deleteDoor;
        private System.Windows.Forms.RadioButton doorVertical;
        private System.Windows.Forms.RadioButton doorHorizontal;
        private System.Windows.Forms.GroupBox doorOrientation;
        private System.Windows.Forms.GroupBox doorType;
        private System.Windows.Forms.RadioButton doorWindow;
        private System.Windows.Forms.RadioButton doorEntrance;
        private System.Windows.Forms.RadioButton doorDoor;
        private System.Windows.Forms.GroupBox doorSensorSettings;
        private System.Windows.Forms.TextBox doorSensorAddress;
        private System.Windows.Forms.Label doorAddressLabel;
        private System.Windows.Forms.CheckBox doorSensorAttached;
        private System.Windows.Forms.CheckBox simulator;
        private System.Windows.Forms.Button locate;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.Button spoofSensor;
        internal System.Windows.Forms.ToolStripStatusLabel LastAlert;
        private System.Windows.Forms.Button spoofDoor;
        private System.Windows.Forms.TextBox doorSensorName;
        private System.Windows.Forms.Label doorNameLabel;
        private System.Windows.Forms.TextBox sensorName;
        private System.Windows.Forms.Label sensorNameLabel;
        public System.Windows.Forms.Label activityLabel;
        private System.Windows.Forms.Button openDebugger;
        public System.Windows.Forms.ToolTip toolTip;
        public System.Windows.Forms.StatusStrip StatusStrip;
    }
}

