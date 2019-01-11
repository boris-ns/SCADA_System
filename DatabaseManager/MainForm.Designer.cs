using System;

namespace DatabaseManager
{
    partial class MainForm
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
            this.btnAddTag = new System.Windows.Forms.Button();
            this.btnRemoveTag = new System.Windows.Forms.Button();
            this.btnEditTag = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxTags = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnAddTag
            // 
            this.btnAddTag.Location = new System.Drawing.Point(12, 23);
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.Size = new System.Drawing.Size(75, 23);
            this.btnAddTag.TabIndex = 0;
            this.btnAddTag.Text = "Add tag";
            this.btnAddTag.UseVisualStyleBackColor = true;
            this.btnAddTag.Click += new System.EventHandler(this.btnAddTag_Click);
            // 
            // btnRemoveTag
            // 
            this.btnRemoveTag.Location = new System.Drawing.Point(108, 23);
            this.btnRemoveTag.Name = "btnRemoveTag";
            this.btnRemoveTag.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveTag.TabIndex = 1;
            this.btnRemoveTag.Text = "Remove tag";
            this.btnRemoveTag.UseVisualStyleBackColor = true;
            this.btnRemoveTag.Click += new System.EventHandler(this.btnRemoveTag_Click);
            // 
            // btnEditTag
            // 
            this.btnEditTag.Location = new System.Drawing.Point(204, 23);
            this.btnEditTag.Name = "btnEditTag";
            this.btnEditTag.Size = new System.Drawing.Size(75, 23);
            this.btnEditTag.TabIndex = 2;
            this.btnEditTag.Text = "Edit tag";
            this.btnEditTag.UseVisualStyleBackColor = true;
            this.btnEditTag.Click += new System.EventHandler(this.btnEditTag_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tagovi u sistemu:";
            // 
            // listBoxTags
            // 
            this.listBoxTags.FormattingEnabled = true;
            this.listBoxTags.Location = new System.Drawing.Point(15, 86);
            this.listBoxTags.Name = "listBoxTags";
            this.listBoxTags.Size = new System.Drawing.Size(264, 264);
            this.listBoxTags.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 359);
            this.Controls.Add(this.listBoxTags);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEditTag);
            this.Controls.Add(this.btnRemoveTag);
            this.Controls.Add(this.btnAddTag);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddTag;
        private System.Windows.Forms.Button btnRemoveTag;
        private System.Windows.Forms.Button btnEditTag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxTags;

    }
}

