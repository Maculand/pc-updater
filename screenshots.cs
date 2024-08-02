using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace PC_Updater
{
    public partial class screenshots : Form
    {
        public screenshots()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void screenshots_Load(object sender, EventArgs e)
        {
            // ComboBoxの初期化
            comboBoxDelay.Items.AddRange(new object[] { "0", "3", "5", "10","20","30" });
            comboBoxDelay.SelectedIndex = 0; // デフォルトで0秒を選択

            // ComboBoxのDropDownStyleをDropDownListに設定
            comboBoxDelay.DropDownStyle = ComboBoxStyle.DropDownList;

            // ボタンのテキストを設定
            button1.Text = "スクショを撮る";

            // チェックボックスの初期設定
            checkBoxHideForm.Text = "フォームを隠す";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ComboBoxから遅延時間を取得
            int delay = int.Parse(comboBoxDelay.SelectedItem.ToString());

            // 指定秒数待機
            Thread.Sleep(delay * 1000);

            // CheckBoxの状態に応じてフォームを非表示にする
            bool hideForm = checkBoxHideForm.Checked;
            if (hideForm)
            {
                this.Hide(); // フォームを非表示にする
                // 0.2秒待機
                Thread.Sleep(200);
            }

            // スクリーンショットを撮影
            Bitmap screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(screenshot);
            graphics.CopyFromScreen(0, 0, 0, 0, screenshot.Size);

            // 保存ダイアログを表示
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNGファイル|*.png|JPEGファイル|*.jpg";
            saveFileDialog.Title = "スクリーンショットを保存";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // ファイル形式に応じて画像を保存
                string extension = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower();
                ImageFormat format = ImageFormat.Png;
                if (extension == ".jpg")
                    format = ImageFormat.Jpeg;

                screenshot.Save(saveFileDialog.FileName, format);
            }

            // フォームを再表示する
            if (hideForm)
            {
                this.Show(); // フォームを再表示する
            }
        }
    }
}
