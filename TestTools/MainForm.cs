using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using TestTools.Common;

namespace TestTools
{

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.DragDrop += File_DragDrop;
            this.DragEnter += File_DragEnter;
            Init();
        }

        private void btnBugReport_Click(object sender, EventArgs e)
        {
            if (!IsReady()) { MessageBox.Show("项目和机型不可以为空"); return; }
            new Thread(BugReport) { Name = "获取BugReport线程", IsBackground = true }.Start();
        }

        private void btnScreen_Click(object sender, EventArgs e)
        {
            if (!IsReady()) { MessageBox.Show("项目和机型不可以为空"); return; }
            Screen();
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            new Thread(Uninstall) { Name = "卸载线程", IsBackground = true }.Start();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            PATH.Open(PATH.GetLogsDirectory());
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            PATH.Open(Path.Combine(PATH.GetAppDirectory(), "readme.txt"));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            new Thread(Delete) { IsBackground = true, Name = "删除线程" }.Start();
        }

        #region 拖拽文件
        private string apkFilePath;
        private void File_DragDrop(object sender, DragEventArgs e)
        {
            apkFilePath = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            new Thread(() => { Install(apkFilePath); }) { Name = "安装线程", IsBackground = true }.Start();
        }

        private void File_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        #endregion

        private void BugReport()
        {
            SwitchState(0, "正在获取日志");
            string filePath = GetOutputPath(".txt");
            CmdHelper.Execute(new string[] { "adb bugreport>" + "\"" + filePath + "\"" }, PATH.GetPlatformToolsDirectory(), (error, requst) =>
            {
                if (error.Length == 0)
                {

                }
                else
                {
                    BeginInvoke(new Action(() => { MessageBox.Show(error); }));
                }
                SwitchState(1, "获取完毕");
            });
        }

        private void Screen()
        {
            SwitchState(0, "正在截屏");
            string filePath = GetOutputPath(".png");
            string str1 = "adb shell /system/bin/screencap -p /sdcard/screenshot.png";
            string str2 = string.Format("adb pull /sdcard/screenshot.png {0}", "\"" + filePath + "\"");
            string[] strs = { str1, str2 };
            CmdHelper.Execute(strs, PATH.GetPlatformToolsDirectory(), (error, requst) =>
            {
                string msg = "";
                if (IsError(error))
                {
                    BeginInvoke(new Action(() => { MessageBox.Show(error); }));
                    msg = "截图失败";
                }
                else
                {
                    if (File.Exists(filePath))
                    {
                        MemoryStream ms = new MemoryStream(File.ReadAllBytes(filePath));
                        pictureBox1.Image = Image.FromStream(ms);
                        msg = "截图完成";
                    }
                    else
                    {
                        msg = "截图没成功，filePath不存在";
                    }
                }

                SwitchState(1, msg);
            });
        }

        private void Install(string filePath)
        {
            SwitchState(0, "正在安装");
            string newFilePath = Path.Combine(PATH.GetAppDirectory(), "apk.apk");
            File.Copy(filePath, newFilePath, true);
            string[] strs = { @"adb install " + "\"" + filePath + "\"" };
            CmdHelper.Execute(strs, PATH.GetPlatformToolsDirectory(), (error, requst) =>
            {
                string msg = "";
                if (error.Contains("device not found"))
                {
                    BeginInvoke(new Action(() => { MessageBox.Show(error); }));
                    msg = "安装失败";
                }
                else if (requst.Contains("Failure [INSTALL_FAILED_ALREADY_EXISTS]"))
                {
                    msg = "应用已经存在";
                }
                else
                {
                    msg = "安装完毕";
                }
                File.Delete(newFilePath);
                SwitchState(1, msg);
            });
        }

        private void Uninstall()
        {
            SwitchState(0, "正在卸载");
            string[] strs = { "adb uninstall " + GetPackage() };
            CmdHelper.Execute(strs, PATH.GetPlatformToolsDirectory(), (error, requst) =>
            {
                string msg = "";
                if (error.Length != 0)
                {
                    BeginInvoke(new Action(() => { MessageBox.Show(error); }));
                    msg = "卸载失败";
                }
                else
                {
                    msg = "卸载成功";
                }
                SwitchState(1, msg);
            });
        }

        private string GetPackage()
        {
            if (rbTing.Checked)
            {
                return "com.zhangyue.tingreader";
            }
            else
            {
                return "com.chaozh.iReaderFree";
            }
        }

        private bool IsReady()
        {
            bool isReady = GetPattern().Length != 0 && GetProject().Length != 0;
            return true;
        }

        private bool IsError(string error)
        {
            string[] errors = File.ReadAllText(Path.Combine(PATH.GetPlatformToolsDirectory(), "ErrorTag")).Trim().Split(',');
            foreach (string item in errors)
            {
                if (error.Contains(item.Trim()))
                {
                    return true;
                }
            }
            return false;
        }

        private void SwitchState(int what, string msg)
        {
            if (what == 1)
            {
                BeginInvoke(new Action(() =>
                {
                    foreach (Control item in Controls)
                    {
                        if (item.GetType() == typeof(Button)) { item.Enabled = true; }
                    }
                    groupBoxClear.Enabled = true;
                    this.AllowDrop = true;
                }));
                new SoundPlayer(@"Resources\ok.wav").Play();
            }
            else if (what == 0)
            {
                BeginInvoke(new Action(() =>
                {
                    foreach (Control item in Controls)
                    {
                        if (item.GetType() == typeof(Button)) { item.Enabled = false; }
                    }
                    groupBoxClear.Enabled = false;
                    this.AllowDrop = false;
                }));
            }
            Notify(what, msg);

        }

        private void Notify(int what, string msg)
        {
            this.BeginInvoke(new Action(() =>
            {
                labMsg.Text = msg;
            }));
        }

        private string GetPattern()
        {
            foreach (Control item in flowLayoutPanelPattern.Controls)
            {
                RadioButton radioBtn = item as RadioButton;
                if (radioBtn.Checked)
                {
                    return radioBtn.Text;
                }
            }
            return "";
        }

        private string GetProject()
        {
            foreach (Control item in flowLayoutPanelProject.Controls)
            {
                RadioButton radioBtn = item as RadioButton;
                if (radioBtn.Checked)
                {
                    return radioBtn.Text;
                }
            }
            return "";
        }

        private void Init()
        {
            string path = PATH.GetAppDirectory() + "\\Data\\Pattern.txt";
            if (File.Exists(path))
            {
                string txt = File.ReadAllText(path).Replace("\r\n", ",");
                string[] patterns = txt.Split(',');
                foreach (var item in patterns)
                {
                    RadioButton radioButton = new RadioButton();
                    radioButton.Text = item;
                    flowLayoutPanelPattern.Controls.Add(radioButton);

                }
            }

            string path2 = PATH.GetAppDirectory() + "\\Data\\Project.txt";
            if (File.Exists(path2))
            {
                string txt = File.ReadAllText(path2).Replace("\r\n", ",");
                string[] projects = txt.Split(',');
                foreach (var item in projects)
                {
                    RadioButton radioButton = new RadioButton();
                    radioButton.Text = item;
                    radioButton.Width = 200;
                    flowLayoutPanelProject.Controls.Add(radioButton);
                }
            }

        }

        private void Delete()
        {
            string clear;
            if (rbTing.Checked)
            {
                clear = "clearTing.sh";
            }
            else
            {
                clear = "clearRead.sh";
            }
            
            string[] strs = { string.Format("adb push {0} /sdcard/clear.sh", clear), "adb shell sh /mnt/sdcard/clear.sh" };
            SwitchState(0, "正在删除临时文件");
            CmdHelper.Execute(strs, PATH.GetPlatformToolsDirectory(), (error, requst) =>
            {
                string msg = "";
                if (IsError(error))
                {
                    msg = error;
                }
                else
                {
                    msg = "删除成功";
                }
                SwitchState(1, msg);
            });

        }

        private string GetOutputPath(string extension)
        {
            string pattern = GetPattern().Replace(" ", "_");
            string project = GetProject().Replace(" ", "_");
            string name = string.Format("{0}_{1}_{2}", project, DateTime.Now.ToString("yyyyMMdd_hhmmss"), pattern).Trim('_');
            string fileName = name + extension;
            string directory = "";
            if (extension == ".png")
            {
                directory = PATH.GetScreensDirectory();
            }
            else if (extension == ".txt")
            {
                directory = PATH.GetLogsDirectory();
            }
            string filePath = Path.Combine(directory, fileName);
            return filePath;
        }

    }
}
