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
        public static ServiceReference.ListOfTags listOfTags;

        public MainForm()
        {
            InitializeComponent();
            dbManagerService = new ServiceReference.DatabaseManagerClient();
            LoadTags();
        }

        /* Loads tags from service and imports them into list box */
        private void LoadTags()
        {
            listOfTags = dbManagerService.GetTags();

            foreach (var tag in listOfTags.digitalInputTags)
                listBoxTags.Items.Add(tag.tagName + " " + tag.ioAddress);

            foreach (var tag in listOfTags.digitalOutputTags)
                listBoxTags.Items.Add(tag.tagName + " " + tag.ioAddress);

            foreach (var tag in listOfTags.analogInputTags)
                listBoxTags.Items.Add(tag.tagName + " " + tag.ioAddress);

            foreach (var tag in listOfTags.analogOutputTags)
                listBoxTags.Items.Add(tag.tagName + " " + tag.ioAddress);
        }

        private void UpdateTagsList()
        {
            listBoxTags.Items.Clear();
            LoadTags();
        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            DataForm addTagForm = new DataForm(dbManagerService);
            addTagForm.Show();
        }

        private void btnRemoveTag_Click(object sender, EventArgs e)
        {

        }

        private void btnEditTag_Click(object sender, EventArgs e)
        {

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            UpdateTagsList();
        }
    }
}
