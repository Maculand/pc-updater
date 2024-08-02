using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PC_Updater
{
    public partial class error : Form
    {
        private string[] _failedFiles;

        public error(string message, string[] failedFiles)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            labelErrorMessage.Text = message;
            _failedFiles = failedFiles;
            richTextBox1.Text = string.Join(Environment.NewLine, _failedFiles);
            richTextBox1.ReadOnly = true; // Make the RichTextBox read-only
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFailedFilesToFile();
        }

        private void SaveFailedFilesToFile()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "テキストファイル (*.txt)|*.txt";
                saveFileDialog.Title = "保存先を選択";
                saveFileDialog.FileName = "failed_files.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllLines(saveFileDialog.FileName, _failedFiles);
                        MessageBox.Show("エクスポートに成功しました", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to save the file. Error: {ex.Message}", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
