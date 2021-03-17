using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JarvisGoogleAPI.Tools
{
    public static class FileManager
    {
        private static readonly List<string> dirs = new List<string>()
        {
            "Screenshots"
        };

        public static void RecoverArchitecture()
        {
            foreach(var dir in dirs)
            {
                if (Directory.Exists(dir) == false) Directory.CreateDirectory(dir);
            }

        }

    }
}
