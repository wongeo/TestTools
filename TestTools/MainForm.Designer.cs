namespace TestTools
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBugReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnScreen = new System.Windows.Forms.Button();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.labMsg = new System.Windows.Forms.Label();
            this.groupBoxClear = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.rbTing = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanelPattern = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelProject = new System.Windows.Forms.FlowLayoutPanel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.groupBoxClear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBugReport
            // 
            this.btnBugReport.Location = new System.Drawing.Point(275, 20);
            this.btnBugReport.Name = "btnBugReport";
            this.btnBugReport.Size = new System.Drawing.Size(75, 23);
            this.btnBugReport.TabIndex = 0;
            this.btnBugReport.Text = "BUG日志";
            this.btnBugReport.UseVisualStyleBackColor = true;
            this.btnBugReport.Click += new System.EventHandler(this.btnBugReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "型号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "项目";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(275, 104);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "浏览";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnScreen
            // 
            this.btnScreen.Location = new System.Drawing.Point(275, 59);
            this.btnScreen.Name = "btnScreen";
            this.btnScreen.Size = new System.Drawing.Size(75, 23);
            this.btnScreen.TabIndex = 7;
            this.btnScreen.Text = "截图";
            this.btnScreen.UseVisualStyleBackColor = true;
            this.btnScreen.Click += new System.EventHandler(this.btnScreen_Click);
            // 
            // btnUninstall
            // 
            this.btnUninstall.Location = new System.Drawing.Point(17, 121);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(75, 23);
            this.btnUninstall.TabIndex = 8;
            this.btnUninstall.Text = "卸载";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // labMsg
            // 
            this.labMsg.AutoSize = true;
            this.labMsg.Location = new System.Drawing.Point(13, 398);
            this.labMsg.Name = "labMsg";
            this.labMsg.Size = new System.Drawing.Size(53, 12);
            this.labMsg.TabIndex = 10;
            this.labMsg.Text = "提示消息";
            // 
            // groupBoxClear
            // 
            this.groupBoxClear.Controls.Add(this.btnDelete);
            this.groupBoxClear.Controls.Add(this.radioButton2);
            this.groupBoxClear.Controls.Add(this.rbTing);
            this.groupBoxClear.Controls.Add(this.btnUninstall);
            this.groupBoxClear.Location = new System.Drawing.Point(258, 183);
            this.groupBoxClear.Name = "groupBoxClear";
            this.groupBoxClear.Size = new System.Drawing.Size(127, 210);
            this.groupBoxClear.TabIndex = 12;
            this.groupBoxClear.TabStop = false;
            this.groupBoxClear.Text = "选择操作的应用";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(17, 164);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 23);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "删除所有文件夹";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(17, 64);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(95, 16);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.Text = "iReader 读书";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // rbTing
            // 
            this.rbTing.AutoSize = true;
            this.rbTing.Checked = true;
            this.rbTing.Location = new System.Drawing.Point(17, 33);
            this.rbTing.Name = "rbTing";
            this.rbTing.Size = new System.Drawing.Size(95, 16);
            this.rbTing.TabIndex = 0;
            this.rbTing.TabStop = true;
            this.rbTing.Text = "iReader 听书";
            this.rbTing.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(391, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 435);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanelPattern
            // 
            this.flowLayoutPanelPattern.AutoScroll = true;
            this.flowLayoutPanelPattern.Location = new System.Drawing.Point(11, 24);
            this.flowLayoutPanelPattern.Name = "flowLayoutPanelPattern";
            this.flowLayoutPanelPattern.Size = new System.Drawing.Size(241, 153);
            this.flowLayoutPanelPattern.TabIndex = 16;
            // 
            // flowLayoutPanelProject
            // 
            this.flowLayoutPanelProject.AutoScroll = true;
            this.flowLayoutPanelProject.Location = new System.Drawing.Point(14, 198);
            this.flowLayoutPanelProject.Name = "flowLayoutPanelProject";
            this.flowLayoutPanelProject.Size = new System.Drawing.Size(238, 153);
            this.flowLayoutPanelProject.TabIndex = 17;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(135, 357);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(117, 36);
            this.btnHelp.TabIndex = 18;
            this.btnHelp.Text = "点击查看更新日志";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 436);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.flowLayoutPanelProject);
            this.Controls.Add(this.flowLayoutPanelPattern);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxClear);
            this.Controls.Add(this.labMsg);
            this.Controls.Add(this.btnScreen);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBugReport);
            this.Name = "MainForm";
            this.Text = "测试工具（有问题反馈给王井，QQ：29992379）";
            this.groupBoxClear.ResumeLayout(false);
            this.groupBoxClear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBugReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnScreen;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.Label labMsg;
        private System.Windows.Forms.GroupBox groupBoxClear;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton rbTing;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPattern;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProject;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnHelp;
    }
}

