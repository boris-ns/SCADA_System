using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseManager
{
    public partial class DataForm : Form
    {
        private ServiceReference.DatabaseManagerClient service;
        private List<ServiceReference.Alarm> alarms;

        private bool editingEnabled;

        private ServiceReference.DigitalInput diToEdit;
        private ServiceReference.DigitalOutput doToEdit;
        private ServiceReference.AnalogInput aiToEdit;
        private ServiceReference.AnalogOutput aoToEdit;

        // Constructor for adding new tag
        public DataForm(ServiceReference.DatabaseManagerClient service)
        {
            InitializeComponent();
            this.service = service;
            alarms = new List<ServiceReference.Alarm>();
            editingEnabled = false;
        }

        // All other c-tors are for editing tags
        public DataForm(ServiceReference.DatabaseManagerClient service, ServiceReference.DigitalInput tagToEdit)
        {
            InitializeComponent();
            this.service = service;
            diToEdit = tagToEdit;
            editingEnabled = true;
            alarms = tagToEdit.alarms.ToList();
            DisableComponentsForEditing();
            EnableComponentsForDigitalInput();
            FillInComponentsDigitalInput();
        }

        public DataForm(ServiceReference.DatabaseManagerClient service, ServiceReference.DigitalOutput tagToEdit)
        {
            InitializeComponent();
            this.service = service;
            doToEdit = tagToEdit;
            editingEnabled = true;
            DisableComponentsForEditing();
            EnableComponentsForDigitalOutput();
            FillInComponentsDigitalOutput();
        }

        public DataForm(ServiceReference.DatabaseManagerClient service, ServiceReference.AnalogInput tagToEdit)
        {
            InitializeComponent();
            this.service = service;
            aiToEdit = tagToEdit;
            editingEnabled = true;
            alarms = tagToEdit.alarms.ToList();
            DisableComponentsForEditing();
            EnableComponentsForAnalogInput();
            FillInComponentsAnalogInput();
        }

        public DataForm(ServiceReference.DatabaseManagerClient service, ServiceReference.AnalogOutput tagToEdit)
        {
            InitializeComponent();
            this.service = service;
            aoToEdit = tagToEdit;
            editingEnabled = true;
            DisableComponentsForEditing();
            EnableComponentsForAnalogOutput();
            FillInComponentsAnalogOutput();
        }


        private void btnAddAlarm_Click(object sender, EventArgs e)
        {
            string tagName = textBoxTagName.Text;
            string alarmType = comboBoxAlarmType.Text;
            string alarmName = textBoxAlarmName.Text;

            alarms.Add(new ServiceReference.Alarm {
                alarmName = alarmName,
                alarmDateTime = DateTime.Now,
                alarmType = alarmType,
                lowLimit = (float)numericUpDownLowLimit.Value,
                highLimit = (float)numericUpDownHighLimit.Value
            });

            listBoxAlarms.Items.Add(alarmName);
        }

        private void btnRemoveAlarm_Click(object sender, EventArgs e)
        {
            string alarmName = listBoxAlarms.SelectedItem.ToString();
            alarms.RemoveAll(alarm => alarm.alarmName == alarmName);
        }

        private void AddNewTag()
        {
            string tagName = textBoxTagName.Text;
            string description = richTextBoxDescription.Text;
            string driver = comboBoxDriver.Text;
            int ioAddress = int.Parse(textBoxIOAddress.Text);
            float initValue = 0;
            float lowLimit = 0;
            float highLimit = 0;

            switch (comboBoxTagType.SelectedIndex)
            {
                case 0: // Digital Input
                    service.AddDigitalInput(tagName, description, driver, ioAddress, int.Parse(textBoxScanTime.Text),
                                            checkBoxOnOffScan.Checked, checkBoxAutoManual.Checked, alarms.ToArray(),
                                            float.Parse(textBoxManualModeValue.Text));
                    break;

                case 1: // Digital Output
                    service.AddDigitalOutput(tagName, description, driver, ioAddress, float.Parse(textBoxInitValue.Text));
                    break;

                case 2: // Analog Input
                    initValue = float.Parse(textBoxScanTime.Text);
                    lowLimit = float.Parse(textBoxLowLimit.Text);
                    highLimit = float.Parse(textBoxHighLimit.Text);

                    service.AddAnalogInput(tagName, description, driver, ioAddress, int.Parse(textBoxScanTime.Text), checkBoxOnOffScan.Checked,
                                            checkBoxAutoManual.Checked, lowLimit, highLimit, textBoxUnits.Text, alarms.ToArray(),
                                            float.Parse(textBoxManualModeValue.Text));
                    break;

                case 3: // Analog Output
                    initValue = float.Parse(textBoxInitValue.Text);
                    lowLimit = float.Parse(textBoxLowLimit.Text);
                    highLimit = float.Parse(textBoxHighLimit.Text);

                    service.AddAnalogOutput(tagName, description, driver, ioAddress, initValue, lowLimit,
                                            highLimit, textBoxUnits.Text);
                    break;

                default:
                    break;
            }
        }

        private void EditTag()
        {
            string description = richTextBoxDescription.Text;
            string driver = comboBoxDriver.Text;
            int ioAddress = int.Parse(textBoxIOAddress.Text);

            switch (comboBoxTagType.SelectedIndex)
            {
                case 0: // Digital Input
                    diToEdit.description = description;
                    diToEdit.driver = driver;
                    diToEdit.ioAddress = ioAddress;
                    diToEdit.scanTime = int.Parse(textBoxScanTime.Text);
                    diToEdit.enableScan = checkBoxOnOffScan.Checked;
                    diToEdit.manualMode = checkBoxAutoManual.Checked;
                    diToEdit.alarms = alarms.ToArray();
                    service.EditDigitalInputTag(diToEdit);
                    break;

                case 1: // Digital Output
                    doToEdit.description = description;
                    doToEdit.driver = driver;
                    doToEdit.ioAddress = ioAddress;
                    doToEdit.initValue = float.Parse(textBoxInitValue.Text);
                    service.EditDigitalOutputTag(doToEdit);
                    break;

                case 2: // Analog Input
                    aiToEdit.description = description;
                    aiToEdit.driver = driver;
                    aiToEdit.ioAddress = ioAddress;
                    aiToEdit.scanTime = int.Parse(textBoxScanTime.Text);
                    aiToEdit.enableScan = checkBoxOnOffScan.Checked;
                    aiToEdit.manualMode = checkBoxAutoManual.Checked;
                    aiToEdit.lowLimit = float.Parse(textBoxLowLimit.Text);
                    aiToEdit.highLimit = float.Parse(textBoxHighLimit.Text);
                    aiToEdit.units = textBoxUnits.Text;
                    aiToEdit.alarms = alarms.ToArray();
                    service.EditAnalogInputTag(aiToEdit);
                    break;

                case 3: // Analog Output
                    aoToEdit.description = description;
                    aoToEdit.driver = driver;
                    aoToEdit.ioAddress = ioAddress;
                    aoToEdit.initValue = float.Parse(textBoxInitValue.Text);
                    aoToEdit.lowLimit = float.Parse(textBoxLowLimit.Text);
                    aoToEdit.highLimit = float.Parse(textBoxHighLimit.Text);
                    aoToEdit.units = textBoxUnits.Text;
                    service.EditAnalogOutputTag(aoToEdit);
                    break;

                default:
                    break;
            }
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            if (editingEnabled)
                EditTag();
            else
                AddNewTag();

            Close();
        }

        private void DisableComponentsForEditing()
        {
            textBoxTagName.Enabled = false;
            comboBoxTagType.Enabled = false;
        }

        private void FillInComponentsDigitalInput()
        {
            textBoxTagName.Text = diToEdit.tagName;
            comboBoxTagType.SelectedItem = "Digital Input";
            richTextBoxDescription.Text = diToEdit.description;
            comboBoxDriver.SelectedItem = diToEdit.driver;
            textBoxIOAddress.Text = diToEdit.ioAddress.ToString();

            foreach (var alarm in diToEdit.alarms)
                listBoxAlarms.Items.Add(alarm.alarmName);

            textBoxScanTime.Text = diToEdit.scanTime.ToString();
            checkBoxOnOffScan.Checked = diToEdit.enableScan;
            checkBoxAutoManual.Checked = diToEdit.manualMode;
        }

        private void FillInComponentsDigitalOutput()
        {
            textBoxTagName.Text = doToEdit.tagName;
            comboBoxTagType.SelectedItem = "Digital Output";
            richTextBoxDescription.Text = doToEdit.description;
            comboBoxDriver.SelectedItem = doToEdit.driver;
            textBoxIOAddress.Text = doToEdit.ioAddress.ToString();

            textBoxInitValue.Text = doToEdit.initValue.ToString();
        }

        private void FillInComponentsAnalogInput()
        {
            textBoxTagName.Text = aiToEdit.tagName;
            comboBoxTagType.SelectedItem = "Analog Input";
            richTextBoxDescription.Text = aiToEdit.description;
            comboBoxDriver.SelectedItem = aiToEdit.driver;
            textBoxIOAddress.Text = aiToEdit.ioAddress.ToString();

            foreach (var alarm in aiToEdit.alarms)
                listBoxAlarms.Items.Add(alarm.alarmName);

            textBoxScanTime.Text = aiToEdit.scanTime.ToString();
            checkBoxOnOffScan.Checked = aiToEdit.enableScan;
            checkBoxAutoManual.Checked = aiToEdit.manualMode;
            textBoxLowLimit.Text = aiToEdit.lowLimit.ToString();
            textBoxHighLimit.Text = aiToEdit.highLimit.ToString();
            textBoxUnits.Text = aiToEdit.units;
        }

        private void FillInComponentsAnalogOutput()
        {
            textBoxTagName.Text = aoToEdit.tagName;
            comboBoxTagType.SelectedItem = "Analog Output";
            richTextBoxDescription.Text = aoToEdit.description;
            comboBoxDriver.SelectedItem = aoToEdit.driver;
            textBoxIOAddress.Text = aoToEdit.ioAddress.ToString();

            textBoxInitValue.Text = aoToEdit.initValue.ToString();
            textBoxLowLimit.Text = aoToEdit.lowLimit.ToString();
            textBoxHighLimit.Text = aoToEdit.highLimit.ToString();
            textBoxUnits.Text = aoToEdit.units;
        }

        private void EnableComponentsForDigitalInput()
        {
            btnAddAlarm.Enabled = true;
            btnRemoveAlarm.Enabled = true;
            listBoxAlarms.Enabled = true;
            textBoxScanTime.Enabled = true;
            textBoxInitValue.Enabled = false;
            textBoxLowLimit.Enabled = false;
            textBoxHighLimit.Enabled = false;
            textBoxUnits.Enabled = false;
            checkBoxOnOffScan.Enabled = true;
            checkBoxAutoManual.Enabled = true;
            textBoxManualModeValue.Enabled = true;
        }

        private void EnableComponentsForDigitalOutput()
        {
            btnAddAlarm.Enabled = false;
            btnRemoveAlarm.Enabled = false;
            listBoxAlarms.Enabled = false;
            textBoxScanTime.Enabled = false;
            textBoxInitValue.Enabled = true;
            textBoxLowLimit.Enabled = false;
            textBoxHighLimit.Enabled = false;
            textBoxUnits.Enabled = false;
            checkBoxOnOffScan.Enabled = false;
            checkBoxAutoManual.Enabled = false;
            textBoxManualModeValue.Enabled = false;
        }

        private void EnableComponentsForAnalogInput()
        {
            btnAddAlarm.Enabled = true;
            btnRemoveAlarm.Enabled = true;
            listBoxAlarms.Enabled = true;
            textBoxScanTime.Enabled = true;
            textBoxInitValue.Enabled = false;
            textBoxLowLimit.Enabled = true;
            textBoxHighLimit.Enabled = true;
            textBoxUnits.Enabled = true;
            checkBoxOnOffScan.Enabled = true;
            checkBoxAutoManual.Enabled = true;
            textBoxManualModeValue.Enabled = true;
        }

        private void EnableComponentsForAnalogOutput()
        {
            btnAddAlarm.Enabled = false;
            btnRemoveAlarm.Enabled = false;
            listBoxAlarms.Enabled = false;
            textBoxScanTime.Enabled = false;
            textBoxInitValue.Enabled = true;
            textBoxLowLimit.Enabled = true;
            textBoxHighLimit.Enabled = true;
            textBoxUnits.Enabled = true;
            checkBoxOnOffScan.Enabled = false;
            checkBoxAutoManual.Enabled = false;
            textBoxManualModeValue.Enabled = false;
        }

        private void comboBoxTagType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxTagType.SelectedIndex)
            {
                case 0: // Digital Input
                    EnableComponentsForDigitalInput();
                    break;

                case 1: // Digital Output
                    EnableComponentsForDigitalOutput();
                    break;

                case 2: // Analog Input
                    EnableComponentsForAnalogInput();
                    break;

                case 3: // Analog Output
                    EnableComponentsForAnalogOutput();
                    break;

                default:
                    break;
            }
        }

        private void listBoxAlarms_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveAlarm.Enabled = true;
        }

        private void comboBoxDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)comboBoxDriver.SelectedItem == "Real time driver")
            {
                checkBoxAutoManual.Checked = false;
                checkBoxAutoManual.Enabled = false;
                textBoxInitValue.Enabled = false;
                textBoxInitValue.Text = "0";
                textBoxManualModeValue.Enabled = false;
            }
            else
            {
                checkBoxAutoManual.Enabled = true;
                textBoxInitValue.Enabled = true;
                textBoxManualModeValue.Enabled = true;
            }
        }
    }
}
