using JarvisGoogleAPI.Domain.Repositories.EntityFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JarvisGoogleAPI.View
{
    public partial class ProgramsForm : MetroForm
    {

        private EfProcNamesRepository repos = new EfProcNamesRepository(new Domain.AppDbContext());

        public ProgramsForm()
        {
            InitializeComponent();
        }

        private void ProgramsForm_Load(object sender, EventArgs e)
        {
            grid.DataSource = repos.GetProcNamesAsList();
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void changeButton_Click(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }
    }
}
