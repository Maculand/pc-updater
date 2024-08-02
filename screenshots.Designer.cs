namespace PC_Updater
{
    partial class screenshots
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxDelay = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxHideForm = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // comboBoxDelay
            // 
            this.comboBoxDelay.FormattingEnabled = true;
            this.comboBoxDelay.Location = new System.Drawing.Point(121, 35);
            this.comboBoxDelay.Name = "comboBoxDelay";
            this.comboBoxDelay.Size = new System.Drawing.Size(117, 23);
            this.comboBoxDelay.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "何秒後に撮影";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "秒後";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 51);
            this.button1.TabIndex = 3;
            this.button1.Text = "スクリーンショットの作成";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxHideForm
            // 
            this.checkBoxHideForm.AutoSize = true;
            this.checkBoxHideForm.Location = new System.Drawing.Point(15, 108);
            this.checkBoxHideForm.Name = "checkBoxHideForm";
            this.checkBoxHideForm.Size = new System.Drawing.Size(198, 19);
            this.checkBoxHideForm.TabIndex = 4;
            this.checkBoxHideForm.Text = "ウィンドウを撮らないようにする";
            this.checkBoxHideForm.UseVisualStyleBackColor = true;
            // 
            // screenshots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 267);
            this.Controls.Add(this.checkBoxHideForm);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDelay);
            this.MaximizeBox = false;
            this.Name = "screenshots";
            this.ShowIcon = false;
            this.Text = "簡単スクリーンショット";
            this.Load += new System.EventHandler(this.screenshots_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDelay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxHideForm;
    }
}