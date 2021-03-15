using JarvisGoogleAPI.Domain;
using JarvisGoogleAPI.Domain.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JarvisGoogleAPI.Controller
{
    public class CommandManager
    {
        private readonly EfCommandsRepository commandsRepos;
        private readonly EfProcNamesRepository procNamesRepos;
        private readonly Dictionary<string, string> commandPairs;
        private readonly Dictionary<string, string> procNamesPairs;    

        public CommandManager()
        {
            commandsRepos = new EfCommandsRepository(new AppDbContext());
            procNamesRepos = new EfProcNamesRepository(new AppDbContext());

            commandPairs = commandsRepos.GetCommandsAsDictionary();
            procNamesPairs = procNamesRepos.GetProcNamesAsDictionary();
        }

        public void HandleCommand(string cmd)
        {
            if (cmd.Equals(string.Empty)) return;
            string[] splitted = cmd.ToLower().Split(' ');
            string command = string.Empty, firstArgument = string.Empty;

            if (splitted.Length > 0) command = splitted[0];
            if (splitted.Length > 1) firstArgument = splitted[1];

            // Process start
            if (command.Equals(commandPairs["process_start"]))
            {
                ProcessStart(firstArgument);
            }
            // Process kill
            else if (command.Equals(commandPairs["process_kill"]))
            {
                ProcessKill(firstArgument);
            }
            // Application exit
            else if (command.Equals(commandPairs["jarvis_shutdown"]))
            {
                ExitConfirmation();
            }
            // Google search
            else if (command.Equals(commandPairs["browser_find"]))
            {
                GoogleSearch(splitted);
            }
        }

        private void ProcessStart(string userProcessName)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start {procNamesPairs[userProcessName]}") { CreateNoWindow = true });
        }

        private void ProcessKill(string userProcessName)
        {
            foreach (var process in Process.GetProcesses())
            {
                if (process.ProcessName.ToLower().Contains(procNamesPairs[userProcessName]))
                {
                    process.Kill();
                }
            }
        }

        private void GoogleSearch(string[] splitted)
        {
            string query = string.Empty;
            for (int i = 1; i < splitted.Length; i++)
            {
                query += "+" + splitted[i];
            }

            Process.Start(new ProcessStartInfo("cmd", $"/c start http://www.google.com/search?q=" + query) { CreateNoWindow = true });
        }

        private void ExitConfirmation()
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите закрыть Джарвиса?", "Вы уверены?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Process.GetCurrentProcess().Kill();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

    }
}
