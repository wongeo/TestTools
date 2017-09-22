using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestTools.Common
{
    public class PATH
    {
        private static readonly string AppDirectory = Environment.CurrentDirectory;

        public static string GetAppDirectory() { return AppDirectory; }

        public static string GetPlatformToolsDirectory()
        {
            return Path.Combine(AppDirectory, "platform-tools");
        }

        public static string GetAdbPath()
        {
            return Path.Combine(GetPlatformToolsDirectory(), "adb.exe");
        }

        public static string GetLogsDirectory()
        {
            string directory = Path.Combine(AppDirectory, "Logs");
            return GetDirectory(directory);
        }

        public static string GetScreensDirectory()
        {
            string directory = Path.Combine(AppDirectory, "Screens");

            return GetDirectory(directory);
        }

        public static string GetDataDirectory()
        {
            string directory = Path.Combine(AppDirectory, "Data");

            return GetDirectory(directory);
        }

        private static string GetDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            return directory;
        }

        public static void Open(string path)
        {
            System.Diagnostics.Process.Start("explorer.exe", path);
        }
    }
}
