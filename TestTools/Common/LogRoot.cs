using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestTools.Common
{
    public class LogRoot
    {
        public static void Debug(string log)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "log.txt");
            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Exists && fileInfo.Length > 2 * 1024 * 1024)
            {
                fileInfo.Delete();
            }
            File.AppendAllText(path, log);
        }
    }
}
