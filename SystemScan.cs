using System;
using System.Diagnostics;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_Updater
{
    public partial class SystemScan : Form
    {
        public SystemScan()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        private void SystemScan_Load(object sender, EventArgs e)
        {
            // Windowsのバージョン情報を取得して表示
            DisplayWindowsVersionInfo();

            // インデターミネート状態のプログレスバーの設定
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 20; // アニメーションのスピード設定

            // DISMとSFCの実行を非同期で開始
            RunSystemRepairAsync();
        }

        private void DisplayWindowsVersionInfo()
        {
            string versionName = GetWindowsVersionName();
            lblVersionInfo.Text = $"OS: {versionName}";

            // バージョンに応じたメッセージを設定
            SetUpgradeRecommendationMessage(versionName);
        }

        private string GetWindowsVersionName()
        {
            try
            {
                // WMIを使用して、OSの情報を取得
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem"))
                {
                    foreach (ManagementObject os in searcher.Get())
                    {
                        return os["Caption"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"OSバージョンの取得中にエラーが発生しました: {ex.Message}");
            }

            return "不明なバージョン";
        }

        private void SetUpgradeRecommendationMessage(string versionName)
        {
            if (versionName.Contains("Windows 10"))
            {
                label2.Text = "Windows10のサポート期限は2025年10月に終了します。\n" +
                              "Windows11へアップデートすることを推奨します。";
                label2.Visible = true; // 表示する
            }
            else if (versionName.Contains("Windows 8.1") || versionName.Contains("Windows 8") || versionName.Contains("Windows 7") || versionName.Contains("Windows Vista") || versionName.Contains("Windows XP"))
            {
                label2.Text = "サポート外OSです。\n" +
                              "このまま使用することは危険です。\n" +
                              "別のOSに乗り換えることを推奨します。";
                label2.Visible = true; // 表示する
            }
            else if (versionName.Contains("Windows 11"))
            {
                label2.Visible = false; // 非表示にする
            }
            else
            {
                label2.Text = "サポート状態を確認できませんでした。";
                label2.Visible = true; // 表示する
            }
        }

        private async Task RunSystemRepairAsync()
        {
            try
            {
                // DISMとSFCを交互に2回実行
                await ExecuteSystemRepairStepAsync("DISMの実行中...", 1);
                await ExecuteSystemRepairStepAsync("SFCの実行中...", 2);
                await ExecuteSystemRepairStepAsync("DISMの実行中...", 3);
                await ExecuteSystemRepairStepAsync("SFCの実行中...", 4);

                // 完了時
                labelStatus.Text = "システムの修復が完了しました。";
                progressBar1.Style = ProgressBarStyle.Blocks; // 完了時に通常のスタイルに戻す
            }
            catch (Exception ex)
            {
                MessageBox.Show($"システム修復中にエラーが発生しました: {ex.Message}");
                labelStatus.Text = "エラーが発生しました。";
                progressBar1.Style = ProgressBarStyle.Blocks; // エラー時にも通常のスタイルに戻す
            }
        }

        private async Task ExecuteSystemRepairStepAsync(string statusMessage, int step)
        {
            labelStatus.Text = $"システムチェック中 ({step}/4)";
            await Task.Run(() =>
            {
                if (statusMessage.Contains("DISM"))
                {
                    ExecuteCommand("DISM.exe", "/Online /Cleanup-image /Restorehealth");
                }
                else if (statusMessage.Contains("SFC"))
                {
                    ExecuteCommand("sfc.exe", "/scannow");
                }
            });
        }

        private void ExecuteCommand(string command, string arguments)
        {
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = command;
                    process.StartInfo.Arguments = arguments;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();

                    // コマンドの出力を読み取る
                    string output;
                    while ((output = process.StandardOutput.ReadLine()) != null)
                    {
                        // ここで必要に応じて出力を解析
                    }

                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                labelStatus.Invoke(new Action(() => labelStatus.Text = $"エラー: {ex.Message}"));
            }
        }
    }
}
