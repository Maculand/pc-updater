using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_Updater
{
    public partial class Form1 : Form
    {
        private const string OfficialPageUrl = "https://github.com/Maculand/pc-updater/releases/tag/v1.0.7";
        private const string ProgramVersion = "1.0.7";
        private const string VersionFileUrl = "https://github.com/Maculand/pc-updater/releases/download/v1.0.7/PCUpdaterversion.txt";
        private static bool restartAttempted = false; // 再起動フラグ

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            EnsureRunAsAdmin();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // notifyIcon1 の設定
        }

        private void EnsureRunAsAdmin()
        {
            if (restartAttempted) return; // 再起動処理がすでに試行された場合、何もせずに戻る

            var wi = WindowsIdentity.GetCurrent();
            var wp = new WindowsPrincipal(wi);
            bool isAdmin = wp.IsInRole(WindowsBuiltInRole.Administrator);

            if (!isAdmin)
            {
                var processInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = Application.ExecutablePath,
                    Verb = "runas"
                };

                try
                {
                    Process.Start(processInfo);
                    restartAttempted = true; // 再起動処理を試行したフラグを設定
                }
                catch (Exception)
                {
                    MessageBox.Show("管理者として実行していない場合、一部の機能が制限されます", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Environment.Exit(0); // 元のプロセスを強制終了
            }
        }

        private async void CheckForUpdates()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string versionFromFile = await client.GetStringAsync(VersionFileUrl);
                    if (versionFromFile.Trim() != ProgramVersion)
                    {
                        var result = MessageBox.Show("新しいバージョンが利用可能です。ダウンロードページに移動しますか?", "アップデート確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            Process.Start(new ProcessStartInfo
                            {
                                FileName = OfficialPageUrl,
                                UseShellExecute = true
                            });
                        }
                    }
                    else
                    {
                        MessageBox.Show("最新のバージョンです。", "バージョンチェック", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("開発中です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TempFileScan form2 = new TempFileScan();
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            settings settingsForm = new settings();
            settingsForm.ShowDialog();
            MessageBox.Show("この設定はメニューの \nPC Updater -> 設定を開く \nでいつでも開けます", "PC Updater", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 設定を開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings settingsForm = new settings();
            settingsForm.ShowDialog();
        }

        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"バージョン: {ProgramVersion}", "バージョン情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SystemScan systemScan = new SystemScan();
            systemScan.ShowDialog();
        }

        private void フィードバックToolStripMenuItem_Click(object sender, EventArgs e)
        {
            feedbackmail feedbackmail = new feedbackmail();
            feedbackmail.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            screenshots screenshots = new screenshots();
            screenshots.ShowDialog();
        }

        private void 更新の確認ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForUpdates();
        }
    }
}
