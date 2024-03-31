
namespace 스쿼드_도서관
{
    partial class Mypage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mypage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.내정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.대여ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.연체ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.신청ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.구매ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.즐겨찾기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.회원탈퇴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(141, 504);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(141, 72);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.내정보ToolStripMenuItem,
            this.도ToolStripMenuItem,
            this.대여ToolStripMenuItem,
            this.연체ToolStripMenuItem,
            this.신청ToolStripMenuItem,
            this.구매ToolStripMenuItem,
            this.즐겨찾기ToolStripMenuItem,
            this.회원탈퇴ToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 118);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(136, 326);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 내정보ToolStripMenuItem
            // 
            this.내정보ToolStripMenuItem.Name = "내정보ToolStripMenuItem";
            this.내정보ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 15, 4, 0);
            this.내정보ToolStripMenuItem.Size = new System.Drawing.Size(129, 40);
            this.내정보ToolStripMenuItem.Text = "기본 정보";
            this.내정보ToolStripMenuItem.Click += new System.EventHandler(this.내정보ToolStripMenuItem_Click);
            // 
            // 도ToolStripMenuItem
            // 
            this.도ToolStripMenuItem.Name = "도ToolStripMenuItem";
            this.도ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 15, 4, 0);
            this.도ToolStripMenuItem.Size = new System.Drawing.Size(129, 40);
            this.도ToolStripMenuItem.Text = "정보 수정";
            this.도ToolStripMenuItem.Click += new System.EventHandler(this.도ToolStripMenuItem_Click);
            // 
            // 대여ToolStripMenuItem
            // 
            this.대여ToolStripMenuItem.Name = "대여ToolStripMenuItem";
            this.대여ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 15, 4, 0);
            this.대여ToolStripMenuItem.Size = new System.Drawing.Size(129, 40);
            this.대여ToolStripMenuItem.Text = "도서 대여/반납";
            this.대여ToolStripMenuItem.Click += new System.EventHandler(this.대여ToolStripMenuItem_Click);
            // 
            // 연체ToolStripMenuItem
            // 
            this.연체ToolStripMenuItem.Name = "연체ToolStripMenuItem";
            this.연체ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 15, 4, 0);
            this.연체ToolStripMenuItem.Size = new System.Drawing.Size(129, 40);
            this.연체ToolStripMenuItem.Text = "연체";
            this.연체ToolStripMenuItem.Click += new System.EventHandler(this.연체ToolStripMenuItem_Click);
            // 
            // 신청ToolStripMenuItem
            // 
            this.신청ToolStripMenuItem.Name = "신청ToolStripMenuItem";
            this.신청ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 15, 4, 0);
            this.신청ToolStripMenuItem.Size = new System.Drawing.Size(129, 40);
            this.신청ToolStripMenuItem.Text = "신청";
            this.신청ToolStripMenuItem.Click += new System.EventHandler(this.신청ToolStripMenuItem_Click);
            // 
            // 구매ToolStripMenuItem
            // 
            this.구매ToolStripMenuItem.Name = "구매ToolStripMenuItem";
            this.구매ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 15, 4, 0);
            this.구매ToolStripMenuItem.Size = new System.Drawing.Size(129, 40);
            this.구매ToolStripMenuItem.Text = "구매";
            this.구매ToolStripMenuItem.Click += new System.EventHandler(this.구매ToolStripMenuItem_Click);
            // 
            // 즐겨찾기ToolStripMenuItem
            // 
            this.즐겨찾기ToolStripMenuItem.Name = "즐겨찾기ToolStripMenuItem";
            this.즐겨찾기ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 15, 4, 0);
            this.즐겨찾기ToolStripMenuItem.Size = new System.Drawing.Size(129, 40);
            this.즐겨찾기ToolStripMenuItem.Text = "희망도서";
            this.즐겨찾기ToolStripMenuItem.Click += new System.EventHandler(this.즐겨찾기ToolStripMenuItem_Click);
            // 
            // 회원탈퇴ToolStripMenuItem
            // 
            this.회원탈퇴ToolStripMenuItem.Name = "회원탈퇴ToolStripMenuItem";
            this.회원탈퇴ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 15, 4, 0);
            this.회원탈퇴ToolStripMenuItem.Size = new System.Drawing.Size(129, 40);
            this.회원탈퇴ToolStripMenuItem.Text = "회원 탈퇴";
            this.회원탈퇴ToolStripMenuItem.Click += new System.EventHandler(this.회원탈퇴ToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(141, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(518, 432);
            this.panel3.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CadetBlue;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(141, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(518, 72);
            this.panel2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(205, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "MY PAGE";
            // 
            // Mypage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(659, 504);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Mypage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mypage";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 내정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 대여ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 연체ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 신청ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 구매ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 즐겨찾기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 회원탈퇴ToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}