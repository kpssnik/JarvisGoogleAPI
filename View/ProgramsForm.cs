using JarvisGoogleAPI.Domain.Entities;
using JarvisGoogleAPI.Domain.Repositories.EntityFramework;
using MetroFramework.Forms;
using System;
using System.Collections;
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
        private WelcomeForm parent;

        public ProgramsForm()
        {
            InitializeComponent();
        }
        public ProgramsForm(WelcomeForm parent)
        {
            InitializeComponent();

            this.parent = parent;
            this.parent.commandController.UpdateDictionaries();

        }

        private void ProgramsForm_Load(object sender, EventArgs e)
        {
            grid.DataSource = repos.GetProcNamesAsList();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ProgramEditForm editForm = new ProgramEditForm();
            editForm.ShowDialog();

            if (editForm.DialogResult == DialogResult.OK)
            {
                ProcName pn = new ProcName()
                {
                    UserName = editForm.usernameTextBox.Text,
                    SystemName = editForm.systemnameTextBox.Text
                };

                repos.SaveProcName(pn);

            }

            GridRefresh();

        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            ProgramEditForm editForm = new ProgramEditForm();

            if (grid.SelectedRows.Count > 0)
            {
                int index = grid.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(grid[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;


                ProcName pn = repos.GetProcNamesAsList().Find(x => x.Id == id);

                editForm.usernameTextBox.Text = pn.UserName;
                editForm.systemnameTextBox.Text = pn.SystemName;

                editForm.ShowDialog();

                if (editForm.DialogResult == DialogResult.OK)
                {
                    pn.UserName = editForm.usernameTextBox.Text;
                    pn.SystemName = editForm.systemnameTextBox.Text;

                    repos.SaveProcName(pn);

                    GridRefresh();
                }

            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count > 0)
            {
                int index = grid.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(grid[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                ProcName pn = repos.GetProcNamesAsList().Find(x => x.Id == id);

                repos.DeleteProcName(pn);

            }

            GridRefresh();


        }

        private void ProgramsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parent.commandController.UpdateDictionaries();
        }

       

        private void GridRefresh()
        {
            parent.commandController.UpdateDictionaries();
            repos = new EfProcNamesRepository(new Domain.AppDbContext());
            grid.DataSource = repos.GetProcNamesAsList();
            grid.Update();
            grid.Refresh();
        }
    }
}
