using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormMiniToTaskBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //1.将Form属性ShowInTaskbar改为false，这样程序将不会在任务栏中显示。
            //2.将Form属性WindowState选择为 Minimized，以便起来自动最小化隐藏。
            string startup = Application.ExecutablePath; //取得程序路径 
            int pp = startup.LastIndexOf("\\");
            startup = startup.Substring(0, pp);
            string icon = startup + "\\testIcon.ico";
            //3.一定为notifyIcon1其设置图标，否则无法显示在通知栏。或者在其属性中设置
            notifyIcon1.Icon = new Icon(icon);
        }

        private void showItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void hideItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void exitItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要退出程序吗？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                notifyIcon1.Visible = false;
                this.Close();
                this.Dispose();
                Application.Exit();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }
    }
}
