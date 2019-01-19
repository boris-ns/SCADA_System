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
            ServiceReference.ListOfTags tags = dbManagerService.GetTags();
            
            foreach (var tag in tags.digitalInputTags)
                listBoxTags.Items.Add(tag.tagName);

            foreach (var tag in tags.digitalOutputTags)
                listBoxTags.Items.Add(tag.tagName);

            foreach (var tag in tags.analogInputTags)
                listBoxTags.Items.Add(tag.tagName);

            foreach (var tag in tags.analogOutputTags)
                listBoxTags.Items.Add(tag.tagName);
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
            string selectedTag = (string)listBoxTags.SelectedItem;
            dbManagerService.RemoveTag(selectedTag);
            UpdateTagsList();
            btnRemoveTag.Enabled = false;
        }

        private void btnEditTag_Click(object sender, EventArgs e)
        {
            string selectedTag = (string)listBoxTags.SelectedItem;
            ServiceReference.ListOfTags tags = dbManagerService.GetTags();

            DataForm form = null;

            if (tags.digitalInputTags.Any(tag => tag.tagName == selectedTag))
                form = new DataForm(dbManagerService, tags.digitalInputTags.Where(tag => tag.tagName == selectedTag).Single());
            else if (tags.digitalOutputTags.Any(tag => tag.tagName == selectedTag))
                form = new DataForm(dbManagerService, tags.digitalOutputTags.Where(tag => tag.tagName == selectedTag).Single());
            else if (tags.analogInputTags.Any(tag => tag.tagName == selectedTag))
                form = new DataForm(dbManagerService, tags.analogInputTags.Where(tag => tag.tagName == selectedTag).Single());
            else if (tags.analogOutputTags.Any(tag => tag.tagName == selectedTag))
                form = new DataForm(dbManagerService, tags.analogOutputTags.Where(tag => tag.tagName == selectedTag).Single());

            if (form != null)
                form.Show();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            UpdateTagsList();
        }

        private void listBoxTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveTag.Enabled = true;
            btnEditTag.Enabled = true;
        }
    }
}
