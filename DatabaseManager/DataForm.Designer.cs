namespace DatabaseManager
{
    partial class DataForm
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
            this.labelTagType = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelDriver = new System.Windows.Forms.Label();
            this.labelIOAddress = new System.Windows.Forms.Label();
            this.labelScanTime = new System.Windows.Forms.Label();
            this.labelInitValue = new System.Windows.Forms.Label();
            this.labelOnOffScan = new System.Windows.Forms.Label();
            this.labelAutoManual = new System.Windows.Forms.Label();
            this.labelLowLimit = new System.Windows.Forms.Label();
            this.labelHighLimit = new System.Windows.Forms.Label();
            this.labelUnits = new System.Windows.Forms.Label();
            this.comboBoxTagType = new System.Windows.Forms.ComboBox();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.textBoxIOAddress = new System.Windows.Forms.TextBox();
            this.textBoxScanTime = new System.Windows.Forms.TextBox();
            this.textBoxInitValue = new System.Windows.Forms.TextBox();
            this.checkBoxOnOffScan = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoManual = new System.Windows.Forms.CheckBox();
            this.textBoxLowLimit = new System.Windows.Forms.TextBox();
            this.textBoxHighLimit = new System.Windows.Forms.TextBox();
            this.textBoxUnits = new System.Windows.Forms.TextBox();
            this.comboBoxDriver = new System.Windows.Forms.ComboBox();
            this.labelAlarms = new System.Windows.Forms.Label();
            this.listBoxAlarms = new System.Windows.Forms.ListBox();
            this.btnAddAlarm = new System.Windows.Forms.Button();
            this.btnRemoveAlarm = new System.Windows.Forms.Button();
            this.buttonFinish = new System.Windows.Forms.Button();
            this.labelTagName = new System.Windows.Forms.Label();
            this.textBoxTagName = new System.Windows.Forms.TextBox();
            this.comboBoxAlarmType = new System.Windows.Forms.ComboBox();
            this.labelAlarmType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTagType
            // 
            this.labelTagType.AutoSize = true;
            this.labelTagType.Location = new System.Drawing.Point(12, 38);
            this.labelTagType.Name = "labelTagType";
            this.labelTagType.Size = new System.Drawing.Size(52, 13);
            this.labelTagType.TabIndex = 0;
            this.labelTagType.Text = "Tag type:";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(12, 74);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(63, 13);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Description:";
            // 
            // labelDriver
            // 
            this.labelDriver.AutoSize = true;
            this.labelDriver.Location = new System.Drawing.Point(12, 153);
            this.labelDriver.Name = "labelDriver";
            this.labelDriver.Size = new System.Drawing.Size(38, 13);
            this.labelDriver.TabIndex = 2;
            this.labelDriver.Text = "Driver:";
            // 
            // labelIOAddress
            // 
            this.labelIOAddress.AutoSize = true;
            this.labelIOAddress.Location = new System.Drawing.Point(12, 189);
            this.labelIOAddress.Name = "labelIOAddress";
            this.labelIOAddress.Size = new System.Drawing.Size(66, 13);
            this.labelIOAddress.TabIndex = 3;
            this.labelIOAddress.Text = "I/O address:";
            // 
            // labelScanTime
            // 
            this.labelScanTime.AutoSize = true;
            this.labelScanTime.Location = new System.Drawing.Point(12, 225);
            this.labelScanTime.Name = "labelScanTime";
            this.labelScanTime.Size = new System.Drawing.Size(57, 13);
            this.labelScanTime.TabIndex = 4;
            this.labelScanTime.Text = "Scan time:";
            // 
            // labelInitValue
            // 
            this.labelInitValue.AutoSize = true;
            this.labelInitValue.Location = new System.Drawing.Point(12, 262);
            this.labelInitValue.Name = "labelInitValue";
            this.labelInitValue.Size = new System.Drawing.Size(63, 13);
            this.labelInitValue.TabIndex = 5;
            this.labelInitValue.Text = "Initial value:";
            // 
            // labelOnOffScan
            // 
            this.labelOnOffScan.AutoSize = true;
            this.labelOnOffScan.Location = new System.Drawing.Point(12, 403);
            this.labelOnOffScan.Name = "labelOnOffScan";
            this.labelOnOffScan.Size = new System.Drawing.Size(75, 13);
            this.labelOnOffScan.TabIndex = 6;
            this.labelOnOffScan.Text = "On / Off scan:";
            // 
            // labelAutoManual
            // 
            this.labelAutoManual.AutoSize = true;
            this.labelAutoManual.Location = new System.Drawing.Point(12, 439);
            this.labelAutoManual.Name = "labelAutoManual";
            this.labelAutoManual.Size = new System.Drawing.Size(78, 13);
            this.labelAutoManual.TabIndex = 7;
            this.labelAutoManual.Text = "Auto / Manual:";
            // 
            // labelLowLimit
            // 
            this.labelLowLimit.AutoSize = true;
            this.labelLowLimit.Location = new System.Drawing.Point(12, 297);
            this.labelLowLimit.Name = "labelLowLimit";
            this.labelLowLimit.Size = new System.Drawing.Size(50, 13);
            this.labelLowLimit.TabIndex = 8;
            this.labelLowLimit.Text = "Low limit:";
            // 
            // labelHighLimit
            // 
            this.labelHighLimit.AutoSize = true;
            this.labelHighLimit.Location = new System.Drawing.Point(12, 336);
            this.labelHighLimit.Name = "labelHighLimit";
            this.labelHighLimit.Size = new System.Drawing.Size(53, 13);
            this.labelHighLimit.TabIndex = 9;
            this.labelHighLimit.Text = "HighLimit:";
            // 
            // labelUnits
            // 
            this.labelUnits.AutoSize = true;
            this.labelUnits.Location = new System.Drawing.Point(12, 370);
            this.labelUnits.Name = "labelUnits";
            this.labelUnits.Size = new System.Drawing.Size(34, 13);
            this.labelUnits.TabIndex = 10;
            this.labelUnits.Text = "Units:";
            // 
            // comboBoxTagType
            // 
            this.comboBoxTagType.FormattingEnabled = true;
            this.comboBoxTagType.Items.AddRange(new object[] {
            "Digital Input",
            "Digital Output",
            "Analog Input",
            "Analog Output"});
            this.comboBoxTagType.Location = new System.Drawing.Point(87, 35);
            this.comboBoxTagType.Name = "comboBoxTagType";
            this.comboBoxTagType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTagType.TabIndex = 11;
            this.comboBoxTagType.SelectedIndexChanged += new System.EventHandler(this.comboBoxTagType_SelectedIndexChanged);
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Location = new System.Drawing.Point(87, 74);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(183, 70);
            this.richTextBoxDescription.TabIndex = 12;
            this.richTextBoxDescription.Text = "";
            // 
            // textBoxIOAddress
            // 
            this.textBoxIOAddress.Location = new System.Drawing.Point(87, 186);
            this.textBoxIOAddress.Name = "textBoxIOAddress";
            this.textBoxIOAddress.Size = new System.Drawing.Size(121, 20);
            this.textBoxIOAddress.TabIndex = 13;
            // 
            // textBoxScanTime
            // 
            this.textBoxScanTime.Location = new System.Drawing.Point(87, 222);
            this.textBoxScanTime.Name = "textBoxScanTime";
            this.textBoxScanTime.Size = new System.Drawing.Size(121, 20);
            this.textBoxScanTime.TabIndex = 14;
            // 
            // textBoxInitValue
            // 
            this.textBoxInitValue.Location = new System.Drawing.Point(88, 259);
            this.textBoxInitValue.Name = "textBoxInitValue";
            this.textBoxInitValue.Size = new System.Drawing.Size(120, 20);
            this.textBoxInitValue.TabIndex = 15;
            // 
            // checkBoxOnOffScan
            // 
            this.checkBoxOnOffScan.AutoSize = true;
            this.checkBoxOnOffScan.Location = new System.Drawing.Point(108, 402);
            this.checkBoxOnOffScan.Name = "checkBoxOnOffScan";
            this.checkBoxOnOffScan.Size = new System.Drawing.Size(15, 14);
            this.checkBoxOnOffScan.TabIndex = 16;
            this.checkBoxOnOffScan.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoManual
            // 
            this.checkBoxAutoManual.AutoSize = true;
            this.checkBoxAutoManual.Location = new System.Drawing.Point(108, 438);
            this.checkBoxAutoManual.Name = "checkBoxAutoManual";
            this.checkBoxAutoManual.Size = new System.Drawing.Size(15, 14);
            this.checkBoxAutoManual.TabIndex = 17;
            this.checkBoxAutoManual.UseVisualStyleBackColor = true;
            // 
            // textBoxLowLimit
            // 
            this.textBoxLowLimit.Location = new System.Drawing.Point(88, 294);
            this.textBoxLowLimit.Name = "textBoxLowLimit";
            this.textBoxLowLimit.Size = new System.Drawing.Size(120, 20);
            this.textBoxLowLimit.TabIndex = 18;
            // 
            // textBoxHighLimit
            // 
            this.textBoxHighLimit.Location = new System.Drawing.Point(87, 333);
            this.textBoxHighLimit.Name = "textBoxHighLimit";
            this.textBoxHighLimit.Size = new System.Drawing.Size(121, 20);
            this.textBoxHighLimit.TabIndex = 19;
            // 
            // textBoxUnits
            // 
            this.textBoxUnits.Location = new System.Drawing.Point(87, 367);
            this.textBoxUnits.Name = "textBoxUnits";
            this.textBoxUnits.Size = new System.Drawing.Size(121, 20);
            this.textBoxUnits.TabIndex = 20;
            // 
            // comboBoxDriver
            // 
            this.comboBoxDriver.FormattingEnabled = true;
            this.comboBoxDriver.Items.AddRange(new object[] {
            "Simulation driver",
            "Real time driver"});
            this.comboBoxDriver.Location = new System.Drawing.Point(87, 153);
            this.comboBoxDriver.Name = "comboBoxDriver";
            this.comboBoxDriver.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDriver.TabIndex = 21;
            // 
            // labelAlarms
            // 
            this.labelAlarms.AutoSize = true;
            this.labelAlarms.Location = new System.Drawing.Point(342, 30);
            this.labelAlarms.Name = "labelAlarms";
            this.labelAlarms.Size = new System.Drawing.Size(38, 13);
            this.labelAlarms.TabIndex = 22;
            this.labelAlarms.Text = "Alarms";
            // 
            // listBoxAlarms
            // 
            this.listBoxAlarms.FormattingEnabled = true;
            this.listBoxAlarms.Location = new System.Drawing.Point(345, 102);
            this.listBoxAlarms.Name = "listBoxAlarms";
            this.listBoxAlarms.Size = new System.Drawing.Size(303, 251);
            this.listBoxAlarms.TabIndex = 23;
            // 
            // btnAddAlarm
            // 
            this.btnAddAlarm.Location = new System.Drawing.Point(553, 63);
            this.btnAddAlarm.Name = "btnAddAlarm";
            this.btnAddAlarm.Size = new System.Drawing.Size(95, 23);
            this.btnAddAlarm.TabIndex = 24;
            this.btnAddAlarm.Text = "Add alarm";
            this.btnAddAlarm.UseVisualStyleBackColor = true;
            this.btnAddAlarm.Click += new System.EventHandler(this.btnAddAlarm_Click);
            // 
            // btnRemoveAlarm
            // 
            this.btnRemoveAlarm.Location = new System.Drawing.Point(345, 367);
            this.btnRemoveAlarm.Name = "btnRemoveAlarm";
            this.btnRemoveAlarm.Size = new System.Drawing.Size(95, 23);
            this.btnRemoveAlarm.TabIndex = 25;
            this.btnRemoveAlarm.Text = "Remove alarm";
            this.btnRemoveAlarm.UseVisualStyleBackColor = true;
            this.btnRemoveAlarm.Click += new System.EventHandler(this.btnRemoveAlarm_Click);
            // 
            // buttonFinish
            // 
            this.buttonFinish.Location = new System.Drawing.Point(274, 458);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(106, 23);
            this.buttonFinish.TabIndex = 26;
            this.buttonFinish.Text = "Finish";
            this.buttonFinish.UseVisualStyleBackColor = true;
            this.buttonFinish.Click += new System.EventHandler(this.buttonFinish_Click);
            // 
            // labelTagName
            // 
            this.labelTagName.AutoSize = true;
            this.labelTagName.Location = new System.Drawing.Point(12, 9);
            this.labelTagName.Name = "labelTagName";
            this.labelTagName.Size = new System.Drawing.Size(58, 13);
            this.labelTagName.TabIndex = 27;
            this.labelTagName.Text = "Tag name:";
            // 
            // textBoxTagName
            // 
            this.textBoxTagName.Location = new System.Drawing.Point(87, 6);
            this.textBoxTagName.Name = "textBoxTagName";
            this.textBoxTagName.Size = new System.Drawing.Size(121, 20);
            this.textBoxTagName.TabIndex = 28;
            // 
            // comboBoxAlarmType
            // 
            this.comboBoxAlarmType.FormattingEnabled = true;
            this.comboBoxAlarmType.Items.AddRange(new object[] {
            "Level 1",
            "Level 2",
            "Level 3"});
            this.comboBoxAlarmType.Location = new System.Drawing.Point(419, 63);
            this.comboBoxAlarmType.Name = "comboBoxAlarmType";
            this.comboBoxAlarmType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAlarmType.TabIndex = 29;
            // 
            // labelAlarmType
            // 
            this.labelAlarmType.AutoSize = true;
            this.labelAlarmType.Location = new System.Drawing.Point(345, 66);
            this.labelAlarmType.Name = "labelAlarmType";
            this.labelAlarmType.Size = new System.Drawing.Size(59, 13);
            this.labelAlarmType.TabIndex = 30;
            this.labelAlarmType.Text = "Alarm type:";
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 493);
            this.Controls.Add(this.labelAlarmType);
            this.Controls.Add(this.comboBoxAlarmType);
            this.Controls.Add(this.textBoxTagName);
            this.Controls.Add(this.labelTagName);
            this.Controls.Add(this.buttonFinish);
            this.Controls.Add(this.btnRemoveAlarm);
            this.Controls.Add(this.btnAddAlarm);
            this.Controls.Add(this.listBoxAlarms);
            this.Controls.Add(this.labelAlarms);
            this.Controls.Add(this.comboBoxDriver);
            this.Controls.Add(this.textBoxUnits);
            this.Controls.Add(this.textBoxHighLimit);
            this.Controls.Add(this.textBoxLowLimit);
            this.Controls.Add(this.checkBoxAutoManual);
            this.Controls.Add(this.checkBoxOnOffScan);
            this.Controls.Add(this.textBoxInitValue);
            this.Controls.Add(this.textBoxScanTime);
            this.Controls.Add(this.textBoxIOAddress);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.comboBoxTagType);
            this.Controls.Add(this.labelUnits);
            this.Controls.Add(this.labelHighLimit);
            this.Controls.Add(this.labelLowLimit);
            this.Controls.Add(this.labelAutoManual);
            this.Controls.Add(this.labelOnOffScan);
            this.Controls.Add(this.labelInitValue);
            this.Controls.Add(this.labelScanTime);
            this.Controls.Add(this.labelIOAddress);
            this.Controls.Add(this.labelDriver);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelTagType);
            this.Name = "DataForm";
            this.Text = "DataForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTagType;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelDriver;
        private System.Windows.Forms.Label labelIOAddress;
        private System.Windows.Forms.Label labelScanTime;
        private System.Windows.Forms.Label labelInitValue;
        private System.Windows.Forms.Label labelOnOffScan;
        private System.Windows.Forms.Label labelAutoManual;
        private System.Windows.Forms.Label labelLowLimit;
        private System.Windows.Forms.Label labelHighLimit;
        private System.Windows.Forms.Label labelUnits;
        private System.Windows.Forms.ComboBox comboBoxTagType;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.TextBox textBoxIOAddress;
        private System.Windows.Forms.TextBox textBoxScanTime;
        private System.Windows.Forms.TextBox textBoxInitValue;
        private System.Windows.Forms.CheckBox checkBoxOnOffScan;
        private System.Windows.Forms.CheckBox checkBoxAutoManual;
        private System.Windows.Forms.TextBox textBoxLowLimit;
        private System.Windows.Forms.TextBox textBoxHighLimit;
        private System.Windows.Forms.TextBox textBoxUnits;
        private System.Windows.Forms.ComboBox comboBoxDriver;
        private System.Windows.Forms.Label labelAlarms;
        private System.Windows.Forms.ListBox listBoxAlarms;
        private System.Windows.Forms.Button btnAddAlarm;
        private System.Windows.Forms.Button btnRemoveAlarm;
        private System.Windows.Forms.Button buttonFinish;
        private System.Windows.Forms.Label labelTagName;
        private System.Windows.Forms.TextBox textBoxTagName;
        private System.Windows.Forms.ComboBox comboBoxAlarmType;
        private System.Windows.Forms.Label labelAlarmType;
    }
}