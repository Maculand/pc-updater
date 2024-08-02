namespace PC_Updater
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ヘルプToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新の確認ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.バージョン情報ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.フィードバックToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pCUpdaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定を開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(20, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 53);
            this.button2.TabIndex = 1;
            this.button2.Text = "不要ファイルスキャン";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(17, 358);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 170);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "スキャン";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(227, 60);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(159, 53);
            this.button4.TabIndex = 2;
            this.button4.Text = "システムスキャン";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "あなたのPCを快適に!";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ヘルプToolStripMenuItem,
            this.pCUpdaterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1019, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ヘルプToolStripMenuItem
            // 
            this.ヘルプToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更新の確認ToolStripMenuItem,
            this.バージョン情報ToolStripMenuItem,
            this.フィードバックToolStripMenuItem});
            this.ヘルプToolStripMenuItem.Name = "ヘルプToolStripMenuItem";
            this.ヘルプToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.ヘルプToolStripMenuItem.Text = "ヘルプ";
            // 
            // 更新の確認ToolStripMenuItem
            // 
            this.更新の確認ToolStripMenuItem.Name = "更新の確認ToolStripMenuItem";
            this.更新の確認ToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.更新の確認ToolStripMenuItem.Text = "更新の確認";
            this.更新の確認ToolStripMenuItem.Click += new System.EventHandler(this.更新の確認ToolStripMenuItem_Click);
            // 
            // バージョン情報ToolStripMenuItem
            // 
            this.バージョン情報ToolStripMenuItem.Name = "バージョン情報ToolStripMenuItem";
            this.バージョン情報ToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.バージョン情報ToolStripMenuItem.Text = "バージョン情報";
            this.バージョン情報ToolStripMenuItem.Click += new System.EventHandler(this.バージョン情報ToolStripMenuItem_Click);
            // 
            // フィードバックToolStripMenuItem
            // 
            this.フィードバックToolStripMenuItem.Name = "フィードバックToolStripMenuItem";
            this.フィードバックToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.フィードバックToolStripMenuItem.Text = "フィードバック";
            this.フィードバックToolStripMenuItem.Click += new System.EventHandler(this.フィードバックToolStripMenuItem_Click);
            // 
            // pCUpdaterToolStripMenuItem
            // 
            this.pCUpdaterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定を開くToolStripMenuItem});
            this.pCUpdaterToolStripMenuItem.Name = "pCUpdaterToolStripMenuItem";
            this.pCUpdaterToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.pCUpdaterToolStripMenuItem.Text = "PC Updater";
            // 
            // 設定を開くToolStripMenuItem
            // 
            this.設定を開くToolStripMenuItem.Name = "設定を開くToolStripMenuItem";
            this.設定を開くToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.設定を開くToolStripMenuItem.Text = "設定を開く";
            this.設定を開くToolStripMenuItem.Click += new System.EventHandler(this.設定を開くToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(17, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 175);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "推奨タスク";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(20, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 46);
            this.button3.TabIndex = 0;
            this.button3.Text = "設定を開く";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Location = new System.Drawing.Point(629, 147);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(353, 417);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PC Updater Plus";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(32, 32);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(200, 50);
            this.button5.TabIndex = 0;
            this.button5.Text = "お手軽スクリーンショット";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 686);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "PC Updater";
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ヘルプToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新の確認ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem バージョン情報ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem pCUpdaterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 設定を開くToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripMenuItem フィードバックToolStripMenuItem;
        private System.Windows.Forms.Button button5;
    }
}

