using JarvisGoogleAPI.Domain;
using JarvisGoogleAPI.Domain.Entities;
using JarvisGoogleAPI.Domain.Repositories.EntityFramework;
using JarvisGoogleAPI.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JarvisGoogleAPI.Controller
{
    public class CommandController
    {
        private EfCommandsRepository commandsRepos;
        private EfProcNamesRepository procNamesRepos;
        private Dictionary<string, string> commandPairs;
        private Dictionary<string, string> procNamesPairs;

        public CommandController()
        {

            UpdateDictionaries();
            //ProcName pn = procNamesRepos.GetProcNames().Where(x => x.SystemName == "aga").FirstOrDefault();

            //pn.SystemName = "newAga";

            //procNamesRepos.SaveProcName(pn);

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
            // Screenshot
            else if (command.Equals(commandPairs["process_screenshot"]))
            {
                SaveScreenshot();
            }
            // Error sound
            else
            {
                Console.Beep(300, 300);
            }
        }

        public void UpdateDictionaries()
        {
            commandsRepos = new EfCommandsRepository(new AppDbContext());
            procNamesRepos = new EfProcNamesRepository(new AppDbContext());

            commandPairs = commandsRepos.GetCommandsAsDictionary();
            procNamesPairs = procNamesRepos.GetProcNamesAsDictionary();
        }

        private void ProcessStart(string userProcessName)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start {procNamesPairs[userProcessName]}") { CreateNoWindow = true });
        }

        private void ProcessKill(string userProcessName)
        {
            try
            {
                foreach (var process in Process.GetProcesses())
                {
                    if (process.ProcessName.ToLower().Contains(procNamesPairs[userProcessName]))
                    {
                        process.Kill();
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                Console.Beep(300, 100);
                Console.Beep(250, 100);
            }
        }

        private void GoogleSearch(string[] splitted)
        {
            string query = string.Empty;

            if (splitted[1] == "видео")
            {
                for (int i = 2; i < splitted.Length; i++)
                {
                    query += splitted[i] + "+";
                }
                Process.Start(new ProcessStartInfo("cmd", $"/c start https://www.youtube.com/results?search_query=" + query) { CreateNoWindow = true });
            }
            else if (splitted[1] == "фото")
            {
                for (int i = 2; i < splitted.Length; i++)
                {
                    query += splitted[i] + "+";
                }
                Process.Start(new ProcessStartInfo("cmd", ($"/c start https://google.com/search?q=" + query.Trim('+') + "\"&\"tbm=isch")) { CreateNoWindow = true });
            }



            else
            {
                for (int i = 1; i < splitted.Length; i++)
                {
                    query += "+" + splitted[i];
                }

                Process.Start(new ProcessStartInfo("cmd", $"/c start http://www.google.com/search?q=" + query) { CreateNoWindow = true });
            }

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
        private void SaveScreenshot()
        {
            var image = ScreenCapture.CaptureDesktop();
            image.Save($"{Config.ScreenshotPath}\\{DateTime.Now.ToFileTime()}.jpg", ImageFormat.Jpeg);

            Console.Beep();
        }
    }

    class ScreenCapture
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDesktopWindow();

        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        public static Image CaptureDesktop()
        {
            return CaptureWindow(GetDesktopWindow());
        }

        public static Bitmap CaptureActiveWindow()
        {
            return CaptureWindow(GetForegroundWindow());
        }

        public static Bitmap CaptureWindow(IntPtr handle)
        {
            var rect = new Rect();
            GetWindowRect(handle, ref rect);
            var bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            var result = new Bitmap(bounds.Width, bounds.Height);

            using (var graphics = Graphics.FromImage(result))
            {
                graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }

            return result;
        }
    }
}
