using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Rick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DisableAllButtons()
        {
            //フォーム上にあるボタンをすべて無効化する
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    c.Enabled = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisableAllButtons();
            //rick.mp4が存在しないならば、
            if (!System.IO.File.Exists("rick.mp4"))
            {
                //yt-dlp.exeを実行する
                ProcessStartInfo startInfo = new ProcessStartInfo(@"yt-dlp.exe");
                startInfo.Arguments = "https://youtu.be/dQw4w9WgXcQ?si=ZX6sOBW4CoZ-xj26 -o \"rick.mp4\"";
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                Process process = Process.Start(startInfo);
                //yt-dlp.exeが終了したら、
                process.Exited += (s, args) =>
                {
                    //rick.mp4を再生する
                    ProcessStartInfo videoplayerinfo = new ProcessStartInfo(@"rick.mp4");
                    Process videoplayer = Process.Start(videoplayerinfo);
                    //このアプリ(Form)を終了させる
                    Application.Exit();
                };
                process.EnableRaisingEvents = true;
            }
            else
            {
                //rick.mp4を再生する
                ProcessStartInfo videoplayerinfo = new ProcessStartInfo(@"rick.mp4");
                Process videoplayer = Process.Start(videoplayerinfo);
                //このアプリ(Form)を終了させる
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisableAllButtons();
            //ブラウザーで特定のURLを開く
            Process.Start("https://media.tenor.com/Pwryf4MuNk0AAAAM/smg4-mario.gif");
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DisableAllButtons();
            Process.Start("https://media.tenor.com/onTlUVMtWy4AAAAM/rickroll-rick.gif");
            Application.Exit();
        }
    }
}
