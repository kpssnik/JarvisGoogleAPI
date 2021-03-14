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

        public void HandleCommand(string command)
        {         
            string[] splitted = command.ToLower().Split(' ');

            //MessageBox.Show($"{splitted[1]}  {procNamesPairs[splitted[1]]}");

            if (splitted[0].Equals(commandPairs["process_start"]))
            {
                Process.Start(procNamesPairs[splitted[1]]);
            }
            else if (splitted[0].Equals(commandPairs["process_kill"]))
            {
                foreach(var process in Process.GetProcesses())
                {
                    if (process.ProcessName.ToLower().Contains(procNamesPairs[splitted[1]]))
                    {
                        process.Kill();
                    }
                }
               
            }
        }

    }
}
