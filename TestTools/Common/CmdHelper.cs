using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestTools.Common
{
    public class CmdHelper
    {
        public static void Execute(string[] cmdStrings, string directory, Action<string, string> action)
        {
            Process process = new Process();//实例
            process.StartInfo.FileName = "cmd.exe"; //设定程序名  
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;//设定不显示窗口
            process.StartInfo.RedirectStandardInput = true;   //重定向标准输入
            process.StartInfo.RedirectStandardOutput = true;  //重定向标准输出
            process.StartInfo.RedirectStandardError = true;//重定向错误输出
            process.Start();

            string drive = Path.GetPathRoot(directory).ToString().TrimEnd(new char[] { '\\' });
            process.StandardInput.WriteLine(drive);
            process.StandardInput.WriteLine("cd " + directory);
            for (int i = 0; i < cmdStrings.Length; i++)
            {
                string cmdString = cmdStrings[i];
                process.StandardInput.WriteLine(cmdString);//执行的命令
            }
            process.StandardInput.WriteLine("exit");

            string err = process.StandardError.ReadToEnd();
            string str = process.StandardOutput.ReadToEnd();
            System.Diagnostics.Debug.WriteLine("err:" + err);
            System.Diagnostics.Debug.WriteLine("request:" + str);
            
            string log = DateTime.Now.ToString("yyyy年MM月dd日 hh:mm:ss") + "\r\nerror:" + err + "\r\n" + "str:" + str + "\r\n";
            LogRoot.Debug(log);
            
            action(err, str);
            process.WaitForExit();
            process.Close();
        }
    }
}
