using System;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace PC_Updater
{
    public partial class TempFileScan : Form
    {
        private string[] allFiles;

        public TempFileScan()
        {

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            comboBox1.Items.Add("既定");
            comboBox1.Items.Add("容量の大きい順");
            comboBox1.Items.Add("容量の小さい順");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // Read-only
            comboBox1.SelectedIndex = 0; // Default to "既定"
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private void TempFileScan_Load(object sender, EventArgs e)
        {
            if (!IsUserAdministrator())
            {
                return; // 管理者権限がない場合
            }
            else
            {
                LoadFilesIntoCheckedListBox();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteSelectedFiles();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            ReloadFiles();
        }

        private void ReloadFiles()
        {
            ResetComboBox();
            progressBar1.Value = 0; // プログレスバーをリセット
            LoadFilesIntoCheckedListBox();
        }

        private void LoadFilesIntoCheckedListBox()
        {
            label3.Text = "スキャン中";  // Display "Scanning" while loading files

            string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string windowsTempPath = @"C:\Windows\TEMP";
            string userTempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp");
            string recycleBinPath = @"C:\$Recycle.Bin";

            string[] downloadFiles = GetFiles(downloadPath).Where(f => f.IndexOf("setup", StringComparison.OrdinalIgnoreCase) >= 0 || f.IndexOf("installer", StringComparison.OrdinalIgnoreCase) >= 0).ToArray();
            string[] windowsTempFiles = GetFiles(windowsTempPath);
            string[] userTempFiles = GetFiles(userTempPath);
            string[] recycleBinFiles = GetFiles(recycleBinPath);
            allFiles = downloadFiles.Concat(recycleBinFiles).Concat(windowsTempFiles).Concat(userTempFiles).ToArray();

            UpdateFileList(allFiles);

            if (checkedListBox1.Items.Count == 0)
            {
                button1.Enabled = false; // Disable button if list is empty
            }
            else
            {
                button1.Enabled = true;
            }

            label3.Text = "スキャン完了";  // Display "Scan Complete" when done
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "既定")
            {
                UpdateFileList(allFiles);
            }
            else if (comboBox1.SelectedItem.ToString() == "容量の大きい順")
            {
                UpdateFileList(allFiles.OrderByDescending(f => GetFileSize(f)).ToArray());
            }
            else if (comboBox1.SelectedItem.ToString() == "容量の小さい順")
            {
                UpdateFileList(allFiles.OrderBy(f => GetFileSize(f)).ToArray());
            }
        }

        private void UpdateFileList(string[] files)
        {
            checkedListBox1.Items.Clear();

            long totalSize = 0;

            progressBar1.Maximum = files.Length;  // Ensure the maximum value is set before setting the progress
            progressBar1.Value = 0;

            foreach (string file in files)
            {
                checkedListBox1.Items.Add(file);
                try
                {
                    FileInfo fileInfo = new FileInfo(file);
                    totalSize += fileInfo.Length;
                }
                catch
                {
                    // Handle cases where file info could not be retrieved
                }
                progressBar1.Value++;
                Application.DoEvents();  // Update the UI to reflect progress
            }

            // Update label with the number of detected files and their total size
            UpdateLabel(files.Length, totalSize);

            // All files loaded, check all items in the CheckedListBox
            CheckAllItems();
        }

        private string[] GetFiles(string path)
        {
            try
            {
                return Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading files from {path}: {ex.Message}");
                return Array.Empty<string>();
            }
        }

        private void CheckAllItems()
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void UpdateLabel(int fileCount, long totalSize)
        {
            string sizeText;

            if (totalSize >= 1024L * 1024L * 1024L)
            {
                // Convert bytes to gigabytes
                double sizeInGB = totalSize / (1024.0 * 1024.0 * 1024.0);
                sizeText = $"{sizeInGB:F2} GB";
            }
            else if (totalSize >= 1024L * 1024L)
            {
                // Convert bytes to megabytes
                double sizeInMB = totalSize / (1024.0 * 1024.0);
                sizeText = $"{sizeInMB:F2} MB";
            }
            else
            {
                // Convert bytes to kilobytes
                double sizeInKB = totalSize / 1024.0;
                sizeText = $"{sizeInKB:F2} KB";
            }

            label2.Text = $"検出ファイル: {fileCount} (容量: {sizeText})";
        }

        private void DeleteSelectedFiles()
        {
            if (MessageBox.Show("選択したファイルを削除してもよろしいですか?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                label3.Text = "削除中";  // Display "Deleting" during the deletion process

                progressBar1.Maximum = checkedListBox1.CheckedItems.Count;
                progressBar1.Value = 0;

                var failedFiles = new System.Collections.Generic.List<string>();

                foreach (var item in checkedListBox1.CheckedItems.Cast<string>().ToList())
                {
                    try
                    {
                        File.Delete(item);
                    }
                    catch
                    {
                        failedFiles.Add(item); // Collect failed files without showing error message
                    }
                    progressBar1.Value++;
                    Application.DoEvents();  // Update the UI to reflect progress
                }

                // Update label and progress bar after deletion is complete
                UpdateLabel(checkedListBox1.Items.Count, CalculateTotalSize());
                label3.Text = "削除完了";  // Display "Deletion Complete" when done

                if (failedFiles.Any())
                {
                    using (error errorForm = new error("以下のファイルの削除に失敗しました:", failedFiles.ToArray()))
                    {
                        errorForm.ShowDialog();
                    }
                }
            }
        }

        private long CalculateTotalSize()
        {
            long totalSize = 0;
            foreach (string file in checkedListBox1.Items.Cast<string>())
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(file);
                    totalSize += fileInfo.Length;
                }
                catch
                {
                    // Handle cases where file info could not be retrieved
                }
            }
            return totalSize;
        }

        private bool IsUserAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        private long GetFileSize(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    return new FileInfo(filePath).Length;
                }
            }
            catch
            {
                // Ignore exceptions and return 0 for file size
            }
            return 0;
        }

        private void TempFileScan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkedListBox1.Items.Count > 0)
            {
                long totalSize = CalculateTotalSize();
                string sizeText;

                if (totalSize >= 1024L * 1024L * 1024L)
                {
                    // Convert bytes to gigabytes
                    double sizeInGB = totalSize / (1024.0 * 1024.0 * 1024.0);
                    sizeText = $"{sizeInGB:F2} GB";
                }
                else if (totalSize >= 1024L * 1024L)
                {
                    // Convert bytes to megabytes
                    double sizeInMB = totalSize / (1024.0 * 1024.0);
                    sizeText = $"{sizeInMB:F2} MB";
                }
                else
                {
                    // Convert bytes to kilobytes
                    double sizeInKB = totalSize / 1024.0;
                    sizeText = $"{sizeInKB:F2} KB";
                }

                DialogResult result = MessageBox.Show($"一部のファイルが削除されていません。合計 {checkedListBox1.Items.Count} 個のファイル ({sizeText}) がまだ存在します。終了しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void ResetComboBox()
        {
            // コンボボックスの選択をリセット
            comboBox1.SelectedIndex = 0;
        }
    }
}
