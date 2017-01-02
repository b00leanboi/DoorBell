namespace DoorBell
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.statLbl = new System.Windows.Forms.Label();
            this.statusPicture = new System.Windows.Forms.PictureBox();
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.saveSettingsBtn = new System.Windows.Forms.Button();
            this.portNUD = new System.Windows.Forms.NumericUpDown();
            this.portLabel = new System.Windows.Forms.Label();
            this.playErrorCheckBox = new System.Windows.Forms.CheckBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.errorSoundButton = new System.Windows.Forms.Button();
            this.ringLabel = new System.Windows.Forms.Label();
            this.ringSoundButton = new System.Windows.Forms.Button();
            this.conntestLabel = new System.Windows.Forms.Label();
            this.showConntestCheckBox = new System.Windows.Forms.CheckBox();
            this.triesLabel = new System.Windows.Forms.Label();
            this.triesInputNUD = new System.Windows.Forms.NumericUpDown();
            this.deadConnLabelA = new System.Windows.Forms.Label();
            this.checkConnLabelB = new System.Windows.Forms.Label();
            this.checkConnectionNUD = new System.Windows.Forms.NumericUpDown();
            this.checkConnLabelA = new System.Windows.Forms.Label();
            this.logGroupBox = new System.Windows.Forms.GroupBox();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.statusPicture)).BeginInit();
            this.optionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.triesInputNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkConnectionNUD)).BeginInit();
            this.logGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // statLbl
            // 
            this.statLbl.AutoSize = true;
            this.statLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statLbl.Location = new System.Drawing.Point(12, 9);
            this.statLbl.Name = "statLbl";
            this.statLbl.Size = new System.Drawing.Size(127, 29);
            this.statLbl.TabIndex = 0;
            this.statLbl.Text = "{STATUS}";
            // 
            // statusPicture
            // 
            this.statusPicture.Image = global::DoorBell.Properties.Resources.notifyRed;
            this.statusPicture.Location = new System.Drawing.Point(145, 9);
            this.statusPicture.Name = "statusPicture";
            this.statusPicture.Size = new System.Drawing.Size(36, 29);
            this.statusPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.statusPicture.TabIndex = 1;
            this.statusPicture.TabStop = false;
            // 
            // optionsGroupBox
            // 
            this.optionsGroupBox.Controls.Add(this.saveSettingsBtn);
            this.optionsGroupBox.Controls.Add(this.portNUD);
            this.optionsGroupBox.Controls.Add(this.portLabel);
            this.optionsGroupBox.Controls.Add(this.playErrorCheckBox);
            this.optionsGroupBox.Controls.Add(this.errorLabel);
            this.optionsGroupBox.Controls.Add(this.errorSoundButton);
            this.optionsGroupBox.Controls.Add(this.ringLabel);
            this.optionsGroupBox.Controls.Add(this.ringSoundButton);
            this.optionsGroupBox.Controls.Add(this.conntestLabel);
            this.optionsGroupBox.Controls.Add(this.showConntestCheckBox);
            this.optionsGroupBox.Controls.Add(this.triesLabel);
            this.optionsGroupBox.Controls.Add(this.triesInputNUD);
            this.optionsGroupBox.Controls.Add(this.deadConnLabelA);
            this.optionsGroupBox.Controls.Add(this.checkConnLabelB);
            this.optionsGroupBox.Controls.Add(this.checkConnectionNUD);
            this.optionsGroupBox.Controls.Add(this.checkConnLabelA);
            this.optionsGroupBox.Location = new System.Drawing.Point(17, 44);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(371, 245);
            this.optionsGroupBox.TabIndex = 2;
            this.optionsGroupBox.TabStop = false;
            this.optionsGroupBox.Text = "OPTIONS";
            // 
            // saveSettingsBtn
            // 
            this.saveSettingsBtn.Location = new System.Drawing.Point(275, 216);
            this.saveSettingsBtn.Name = "saveSettingsBtn";
            this.saveSettingsBtn.Size = new System.Drawing.Size(90, 23);
            this.saveSettingsBtn.TabIndex = 15;
            this.saveSettingsBtn.Text = "Save Settings";
            this.saveSettingsBtn.UseVisualStyleBackColor = true;
            this.saveSettingsBtn.Click += new System.EventHandler(this.saveSettingsBtn_Click);
            // 
            // portNUD
            // 
            this.portNUD.Location = new System.Drawing.Point(190, 156);
            this.portNUD.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.portNUD.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.portNUD.Name = "portNUD";
            this.portNUD.Size = new System.Drawing.Size(72, 20);
            this.portNUD.TabIndex = 14;
            this.portNUD.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.portNUD.ValueChanged += new System.EventHandler(this.portNUD_ValueChanged);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(111, 158);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 13);
            this.portLabel.TabIndex = 13;
            this.portLabel.Text = "Port:";
            // 
            // playErrorCheckBox
            // 
            this.playErrorCheckBox.AutoSize = true;
            this.playErrorCheckBox.Location = new System.Drawing.Point(275, 131);
            this.playErrorCheckBox.Name = "playErrorCheckBox";
            this.playErrorCheckBox.Size = new System.Drawing.Size(46, 17);
            this.playErrorCheckBox.TabIndex = 12;
            this.playErrorCheckBox.Text = "Play";
            this.playErrorCheckBox.UseVisualStyleBackColor = true;
            this.playErrorCheckBox.CheckedChanged += new System.EventHandler(this.playErrorCheckBox_CheckedChanged);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(76, 132);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(64, 13);
            this.errorLabel.TabIndex = 11;
            this.errorLabel.Text = "Error sound:";
            // 
            // errorSoundButton
            // 
            this.errorSoundButton.Location = new System.Drawing.Point(190, 127);
            this.errorSoundButton.Name = "errorSoundButton";
            this.errorSoundButton.Size = new System.Drawing.Size(75, 23);
            this.errorSoundButton.TabIndex = 10;
            this.errorSoundButton.Text = "Choose";
            this.errorSoundButton.UseVisualStyleBackColor = true;
            this.errorSoundButton.Click += new System.EventHandler(this.errorSoundButton_Click);
            // 
            // ringLabel
            // 
            this.ringLabel.AutoSize = true;
            this.ringLabel.Location = new System.Drawing.Point(76, 103);
            this.ringLabel.Name = "ringLabel";
            this.ringLabel.Size = new System.Drawing.Size(64, 13);
            this.ringLabel.TabIndex = 9;
            this.ringLabel.Text = "Ring sound:";
            // 
            // ringSoundButton
            // 
            this.ringSoundButton.Location = new System.Drawing.Point(190, 98);
            this.ringSoundButton.Name = "ringSoundButton";
            this.ringSoundButton.Size = new System.Drawing.Size(75, 23);
            this.ringSoundButton.TabIndex = 8;
            this.ringSoundButton.Text = "Change";
            this.ringSoundButton.UseVisualStyleBackColor = true;
            this.ringSoundButton.Click += new System.EventHandler(this.ringSoundButton_Click);
            // 
            // conntestLabel
            // 
            this.conntestLabel.AutoSize = true;
            this.conntestLabel.Location = new System.Drawing.Point(9, 76);
            this.conntestLabel.Name = "conntestLabel";
            this.conntestLabel.Size = new System.Drawing.Size(131, 13);
            this.conntestLabel.TabIndex = 7;
            this.conntestLabel.Text = "Show conntest messages:";
            // 
            // showConntestCheckBox
            // 
            this.showConntestCheckBox.AutoSize = true;
            this.showConntestCheckBox.Location = new System.Drawing.Point(190, 75);
            this.showConntestCheckBox.Name = "showConntestCheckBox";
            this.showConntestCheckBox.Size = new System.Drawing.Size(53, 17);
            this.showConntestCheckBox.TabIndex = 6;
            this.showConntestCheckBox.Text = "Show";
            this.showConntestCheckBox.UseVisualStyleBackColor = true;
            this.showConntestCheckBox.CheckedChanged += new System.EventHandler(this.showConntestCheckBox_CheckedChanged);
            // 
            // triesLabel
            // 
            this.triesLabel.AutoSize = true;
            this.triesLabel.Location = new System.Drawing.Point(268, 51);
            this.triesLabel.Name = "triesLabel";
            this.triesLabel.Size = new System.Drawing.Size(87, 13);
            this.triesLabel.TabIndex = 5;
            this.triesLabel.Text = "tries ({x} minutes)";
            // 
            // triesInputNUD
            // 
            this.triesInputNUD.Location = new System.Drawing.Point(190, 49);
            this.triesInputNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.triesInputNUD.Name = "triesInputNUD";
            this.triesInputNUD.Size = new System.Drawing.Size(72, 20);
            this.triesInputNUD.TabIndex = 4;
            this.triesInputNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.triesInputNUD.ValueChanged += new System.EventHandler(this.triesInputNUD_ValueChanged);
            // 
            // deadConnLabelA
            // 
            this.deadConnLabelA.AutoSize = true;
            this.deadConnLabelA.Location = new System.Drawing.Point(24, 51);
            this.deadConnLabelA.Name = "deadConnLabelA";
            this.deadConnLabelA.Size = new System.Drawing.Size(116, 13);
            this.deadConnLabelA.TabIndex = 3;
            this.deadConnLabelA.Text = "Dead connection after:";
            // 
            // checkConnLabelB
            // 
            this.checkConnLabelB.AutoSize = true;
            this.checkConnLabelB.Location = new System.Drawing.Point(268, 25);
            this.checkConnLabelB.Name = "checkConnLabelB";
            this.checkConnLabelB.Size = new System.Drawing.Size(43, 13);
            this.checkConnLabelB.TabIndex = 2;
            this.checkConnLabelB.Text = "minutes";
            // 
            // checkConnectionNUD
            // 
            this.checkConnectionNUD.Location = new System.Drawing.Point(190, 23);
            this.checkConnectionNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.checkConnectionNUD.Name = "checkConnectionNUD";
            this.checkConnectionNUD.Size = new System.Drawing.Size(72, 20);
            this.checkConnectionNUD.TabIndex = 1;
            this.checkConnectionNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.checkConnectionNUD.ValueChanged += new System.EventHandler(this.checkConnectionNUD_ValueChanged);
            // 
            // checkConnLabelA
            // 
            this.checkConnLabelA.AutoSize = true;
            this.checkConnLabelA.Location = new System.Drawing.Point(16, 27);
            this.checkConnLabelA.Name = "checkConnLabelA";
            this.checkConnLabelA.Size = new System.Drawing.Size(124, 13);
            this.checkConnLabelA.TabIndex = 0;
            this.checkConnLabelA.Text = "Check connection each:";
            // 
            // logGroupBox
            // 
            this.logGroupBox.Controls.Add(this.logTextBox);
            this.logGroupBox.Location = new System.Drawing.Point(17, 295);
            this.logGroupBox.Name = "logGroupBox";
            this.logGroupBox.Size = new System.Drawing.Size(371, 223);
            this.logGroupBox.TabIndex = 3;
            this.logGroupBox.TabStop = false;
            this.logGroupBox.Text = "DATA RECEIVED";
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(6, 19);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(359, 198);
            this.logTextBox.TabIndex = 0;
            this.logTextBox.Text = "";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "The application will continue running minimised.\r\nIt will also start minimised ne" +
    "xt time";
            this.notifyIcon.BalloonTipTitle = "Information";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "DoorBell";
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 530);
            this.Controls.Add(this.logGroupBox);
            this.Controls.Add(this.optionsGroupBox);
            this.Controls.Add(this.statusPicture);
            this.Controls.Add(this.statLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "DoorBell";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.statusPicture)).EndInit();
            this.optionsGroupBox.ResumeLayout(false);
            this.optionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.triesInputNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkConnectionNUD)).EndInit();
            this.logGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statLbl;
        private System.Windows.Forms.PictureBox statusPicture;
        private System.Windows.Forms.GroupBox optionsGroupBox;
        private System.Windows.Forms.NumericUpDown portNUD;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.CheckBox playErrorCheckBox;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button errorSoundButton;
        private System.Windows.Forms.Label ringLabel;
        private System.Windows.Forms.Button ringSoundButton;
        private System.Windows.Forms.Label conntestLabel;
        private System.Windows.Forms.CheckBox showConntestCheckBox;
        private System.Windows.Forms.Label triesLabel;
        private System.Windows.Forms.NumericUpDown triesInputNUD;
        private System.Windows.Forms.Label deadConnLabelA;
        private System.Windows.Forms.Label checkConnLabelB;
        private System.Windows.Forms.NumericUpDown checkConnectionNUD;
        private System.Windows.Forms.Label checkConnLabelA;
        private System.Windows.Forms.GroupBox logGroupBox;
        private System.Windows.Forms.Button saveSettingsBtn;
        private System.Windows.Forms.RichTextBox logTextBox;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

