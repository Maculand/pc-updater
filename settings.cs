using System;
using System.Drawing;
using System.Windows.Forms;

namespace PC_Updater
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            notifyIcon.Visible = true; // notifyIcon を表示
        }

        private void settings_Load(object sender, EventArgs e)
        {
            // 初期化処理があればここに追加
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                notifyIcon.BalloonTipTitle = "通知が有効になりました";
                notifyIcon.BalloonTipText = "通知を有効にしていただきありがとうございます!";
                notifyIcon.ShowBalloonTip(2000); // 1000ミリ秒（1秒）表示
            }
            else if (radioButton1.Checked)
            {
                
                
                    notifyIcon.BalloonTipTitle = "通知が無効になりました";
                    notifyIcon.BalloonTipText = "この設定はいつでも変更出来ます";
                    notifyIcon.ShowBalloonTip(2000); // 1000ミリ秒（1秒）表示
                
            }
        }


    }
}
