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
    public partial class MainForm : Form
    {
        public static ServiceReference.DatabaseManagerClient dbManagerService;

        public MainForm()
        {
            InitializeComponent();
            dbManagerService = new ServiceReference.DatabaseManagerClient();
            LoadTags();
        }

        /* Loads tags from service and imports them into list box */
        private void LoadTags()
        {
            ServiceReference.DigitalInput[] tags = dbManagerService.GetAllDigitalInputs();

            foreach (var tag in tags)
            {
                listBoxTags.Items.Add(tag.tagName + " " + tag.ioAddress);
            }
        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            DataForm addTagForm = new DataForm();
            addTagForm.Show();
        }

        private void btnRemoveTag_Click(object sender, EventArgs e)
        {

        }

        private void btnEditTag_Click(object sender, EventArgs e)
        {

        }
    }
}
