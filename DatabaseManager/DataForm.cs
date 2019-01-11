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
        public DataForm()
        {
            InitializeComponent();
        }

        private void btnAddAlarm_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveAlarm_Click(object sender, EventArgs e)
        {

        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {

        }

        private void EnableComponentsForDigitalOutput()
        {
            btnAddAlarm.Enabled = false;
            btnRemoveAlarm.Enabled = false;
            listBoxAlarms.Enabled = false;
            textBoxScanTime.Enabled = false;
            textBoxLowLimit.Enabled = false;
            labelHighLimit.Enabled = false;
            textBoxUnits.Enabled = false;
            checkBoxOnOffScan.Enabled = false;
            checkBoxAutoManual.Enabled = false;
        }

        private void comboBoxTagType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxTagType.SelectedIndex)
            {
                case 0:

                    break;

                case 1:
                    EnableComponentsForDigitalOutput();
                    break;

                case 2:

                    break;

                case 3:

                    break;

                default:
                    break;
            }
        }
    }
}
