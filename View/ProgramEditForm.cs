using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JarvisGoogleAPI.View
{
    public partial class ProgramEditForm : Form
    {
        public ProgramEditForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            usernameTextBox.Text = usernameTextBox.Text.ToLower().Trim();
            systemnameTextBox.Text = systemnameTextBox.Text.Trim();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
