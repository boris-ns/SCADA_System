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

        public DataForm(ServiceReference.DatabaseManagerClient service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void btnAddAlarm_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveAlarm_Click(object sender, EventArgs e)
        {

        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            string tagName = textBoxTagName.Text;
            string description = richTextBoxDescription.Text;
            string driver = comboBoxDriver.Text;
            string ioAddress = textBoxIOAddress.Text;
            float initValue = 0;
            float lowLimit  = 0;
            float highLimit = 0;

            switch (comboBoxTagType.SelectedIndex)
            {
                case 0: // Digital Input
                    service.AddDigitalInput(tagName, description, driver, ioAddress, float.Parse(textBoxScanTime.Text),
                                            checkBoxOnOffScan.Checked,checkBoxAutoManual.Checked);
                    break;

                case 1: // Digital Output
                    service.AddDigitalOutput(tagName, description, driver, ioAddress, float.Parse(textBoxInitValue.Text));
                    break;

                case 2: // Analog Input
                    initValue = float.Parse(textBoxScanTime.Text);
                    lowLimit = float.Parse(textBoxLowLimit.Text);
                    highLimit = float.Parse(textBoxHighLimit.Text);

                    service.AddAnalogInput(tagName, description, driver, ioAddress, initValue, checkBoxOnOffScan.Checked, 
                                            checkBoxAutoManual.Checked, lowLimit, highLimit, textBoxUnits.Text);
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

            Close();
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
    }
}
