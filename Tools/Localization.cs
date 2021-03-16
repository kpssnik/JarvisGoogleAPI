using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarvisGoogleAPI.Tools
{
    public static class Localization
    {
        public static Dictionary<string, string> Commands = new Dictionary<string, string>()
        {
            { "process_start", "Запуск процесса" },
            { "process_kill", "Закрытие процесса" },
            { "browser_find", "Поиск в браузере" },
            { "jarvis_shutdown", "Закрытие Джарвиса" },
            { "process_screenshot", "Скриншот экрана" }
        };

        
    }
}
