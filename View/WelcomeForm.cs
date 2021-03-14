using System;
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

namespace JarvisGoogleAPI.View
{
    public partial class WelcomeForm : Form
    {
        private ConvertManager convertManager;
        private CommandManager commandManager;

        private UserActivityHook hooker;

        public WelcomeForm()
        {

            hooker = new UserActivityHook();
            InitializeComponent();
            convertManager = new ConvertManager();
            commandManager = new CommandManager();

            hooker.Start();
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            hooker.KeyUp += new KeyEventHandler(MyKeyUp);
        }

        private void MyKeyUp(object sender, KeyEventArgs e)
        {
            if (convertManager.DoRecord(e) == true)
            {
                commandManager.HandleCommand(convertManager.Result);
            }
        }
    }
}
