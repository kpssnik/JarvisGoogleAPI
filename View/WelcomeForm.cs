﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JarvisGoogleAPI.Tools;
using JarvisGoogleAPI.Controller;
using System.Threading;
using System.Diagnostics;
using JarvisGoogleAPI.Domain.Repositories.EntityFramework;
using JarvisGoogleAPI.Domain;
using Microsoft.EntityFrameworkCore;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework.Components;
using JarvisGoogleAPI.Domain.Entities;
using System.Linq;

namespace JarvisGoogleAPI.View
{
    public partial class WelcomeForm : MetroForm
    {
        private ConvertController convertManager;
        private CommandController commandManager;

        private EfCommandsRepository commandsRepos;

        private UserActivityHook hooker;

        bool isStarted = false;

        List<TextBox> tbs; 

        public WelcomeForm()
        {
            InitializeComponent();

            tbs = new List<TextBox>();

            hooker = new UserActivityHook();
            convertManager = new ConvertController();
            commandManager = new CommandController();

            commandsRepos = new EfCommandsRepository(new AppDbContext());

            hooker.Start();

            using (AppDbContext context = new AppDbContext())
            {
                if (context.Database.EnsureCreated())
                {
                    context.Database.Migrate();
                }
            }
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            notifyIcon.Icon = new Icon("icon.ico");
            hooker.KeyUp += new KeyEventHandler(MyKeyUp);

            Point start = new Point(23, 72);

            foreach (var command in commandsRepos.GetCommands())
            {
                Controls.Add(new Label()
                {
                    Location = new Point(0, start.Y),

                    TextAlign = ContentAlignment.MiddleCenter,

                    Text = Localization.Commands[command.SystemName],
                    Width = this.Width,

                    Font = new Font(new FontFamily("Segoe UI"), 12, FontStyle.Bold),
                });

                start.Y += 23;

                TextBox temp = new TextBox()
                {
                    Location = start,
                    Width = 283,
                    Text = command.UserName,
                    TextAlign = HorizontalAlignment.Center,
                    Tag = command,
     
                    Font = new Font(new FontFamily("Segoe UI"), 12)
                };

                temp.TextChanged += textBox_TextChanged;

                Controls.Add(temp);
                tbs.Add(temp);

                start.Y += 35;
            }

            saveCommandsButton.Location = start;
        }
        private void MyKeyUp(object sender, KeyEventArgs e)
        {
            if (isStarted && convertManager.DoRecord(e) == true)
            {
                commandManager.HandleCommand(convertManager.Result);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            isStarted = true;

            Hide();
            notifyIcon.Visible = true;

            startButton.Enabled = false;
            changeProgrammsButton.Enabled = false;
        }

        private void changeProgrammsButton_Click(object sender, EventArgs e)
        {
            var programsForm = new ProgramsForm();
            programsForm.ShowDialog();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            notifyIcon.Visible = false;
        }

        private void saveCommandsButton_Click(object sender, EventArgs e)
        {
            foreach (var textBox in tbs)
            {
                (textBox.Tag as Command).UserName = textBox.Text;

                commandsRepos.SaveCommand((textBox.Tag as Command));
            }

            saveCommandsButton.Enabled = false;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            saveCommandsButton.Enabled = true;
        }
    }
}
