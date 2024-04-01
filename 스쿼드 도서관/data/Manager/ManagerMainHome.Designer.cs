
namespace 스쿼드_도서관
{
    partial class ManagerMainHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerMainHome));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.대출ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.반납ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.연체ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도서관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도서관ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도서관리ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.신착추천도서ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도서검색ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.검색도서정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.불러오기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.신청구매도서목록ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.구매도서ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.회원관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.게시판ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.공지사항ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.묻고답하기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.환경설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.운영설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.운영규정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.대출환경설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.CadetBlue;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("맑은 고딕 Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.도서관리ToolStripMenuItem,
            this.회원관리ToolStripMenuItem,
            this.게시판ToolStripMenuItem,
            this.환경설정ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 80, 0, 20);
            this.menuStrip1.Size = new System.Drawing.Size(136, 624);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.대출ToolStripMenuItem,
            this.반납ToolStripMenuItem,
            this.연체ToolStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("맑은 고딕 Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 40);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(123, 65);
            this.toolStripMenuItem1.Text = "대출/반납/연체";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 대출ToolStripMenuItem
            // 
            this.대출ToolStripMenuItem.Name = "대출ToolStripMenuItem";
            this.대출ToolStripMenuItem.Size = new System.Drawing.Size(112, 26);
            this.대출ToolStripMenuItem.Text = "대출";
            this.대출ToolStripMenuItem.Click += new System.EventHandler(this.대출ToolStripMenuItem_Click);
            // 
            // 반납ToolStripMenuItem
            // 
            this.반납ToolStripMenuItem.Name = "반납ToolStripMenuItem";
            this.반납ToolStripMenuItem.Size = new System.Drawing.Size(112, 26);
            this.반납ToolStripMenuItem.Text = "반납";
            this.반납ToolStripMenuItem.Click += new System.EventHandler(this.반납ToolStripMenuItem_Click);
            // 
            // 연체ToolStripMenuItem
            // 
            this.연체ToolStripMenuItem.Name = "연체ToolStripMenuItem";
            this.연체ToolStripMenuItem.Size = new System.Drawing.Size(112, 26);
            this.연체ToolStripMenuItem.Text = "연체";
            this.연체ToolStripMenuItem.Click += new System.EventHandler(this.연체ToolStripMenuItem_Click);
            // 
            // 도서관리ToolStripMenuItem
            // 
            this.도서관리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.도서관ToolStripMenuItem,
            this.도서검색ToolStripMenuItem,
            this.신청구매도서목록ToolStripMenuItem,
            this.구매도서ToolStripMenuItem});
            this.도서관리ToolStripMenuItem.Name = "도서관리ToolStripMenuItem";
            this.도서관리ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 0, 4, 40);
            this.도서관리ToolStripMenuItem.Size = new System.Drawing.Size(123, 65);
            this.도서관리ToolStripMenuItem.Text = "도서관리";
            this.도서관리ToolStripMenuItem.Click += new System.EventHandler(this.도서관리ToolStripMenuItem_Click);
            // 
            // 도서관ToolStripMenuItem
            // 
            this.도서관ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.도서관리ToolStripMenuItem1,
            this.신착추천도서ToolStripMenuItem});
            this.도서관ToolStripMenuItem.Name = "도서관ToolStripMenuItem";
            this.도서관ToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.도서관ToolStripMenuItem.Text = "도서관리";
            this.도서관ToolStripMenuItem.Click += new System.EventHandler(this.도서관ToolStripMenuItem_Click);
            // 
            // 도서관리ToolStripMenuItem1
            // 
            this.도서관리ToolStripMenuItem1.Name = "도서관리ToolStripMenuItem1";
            this.도서관리ToolStripMenuItem1.Size = new System.Drawing.Size(195, 26);
            this.도서관리ToolStripMenuItem1.Text = "전체 도서 관리";
            this.도서관리ToolStripMenuItem1.Click += new System.EventHandler(this.도서관리ToolStripMenuItem1_Click);
            // 
            // 신착추천도서ToolStripMenuItem
            // 
            this.신착추천도서ToolStripMenuItem.Name = "신착추천도서ToolStripMenuItem";
            this.신착추천도서ToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.신착추천도서ToolStripMenuItem.Text = "신착 | 추천 도서";
            this.신착추천도서ToolStripMenuItem.Click += new System.EventHandler(this.신착추천도서ToolStripMenuItem_Click);
            // 
            // 도서검색ToolStripMenuItem
            // 
            this.도서검색ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.검색도서정보ToolStripMenuItem,
            this.불러오기ToolStripMenuItem});
            this.도서검색ToolStripMenuItem.Name = "도서검색ToolStripMenuItem";
            this.도서검색ToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.도서검색ToolStripMenuItem.Text = "도서 검색";
            // 
            // 검색도서정보ToolStripMenuItem
            // 
            this.검색도서정보ToolStripMenuItem.Name = "검색도서정보ToolStripMenuItem";
            this.검색도서정보ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.검색도서정보ToolStripMenuItem.Text = "검색/도서정보";
            this.검색도서정보ToolStripMenuItem.Click += new System.EventHandler(this.검색도서정보ToolStripMenuItem_Click);
            // 
            // 불러오기ToolStripMenuItem
            // 
            this.불러오기ToolStripMenuItem.Name = "불러오기ToolStripMenuItem";
            this.불러오기ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.불러오기ToolStripMenuItem.Text = "불러오기";
            this.불러오기ToolStripMenuItem.Click += new System.EventHandler(this.불러오기ToolStripMenuItem_Click);
            // 
            // 신청구매도서목록ToolStripMenuItem
            // 
            this.신청구매도서목록ToolStripMenuItem.Name = "신청구매도서목록ToolStripMenuItem";
            this.신청구매도서목록ToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.신청구매도서목록ToolStripMenuItem.Text = "신청 도서";
            this.신청구매도서목록ToolStripMenuItem.Click += new System.EventHandler(this.신청구매도서목록ToolStripMenuItem_Click);
            // 
            // 구매도서ToolStripMenuItem
            // 
            this.구매도서ToolStripMenuItem.Name = "구매도서ToolStripMenuItem";
            this.구매도서ToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.구매도서ToolStripMenuItem.Text = "구매 도서";
            this.구매도서ToolStripMenuItem.Click += new System.EventHandler(this.구매도서ToolStripMenuItem_Click);
            // 
            // 회원관리ToolStripMenuItem
            // 
            this.회원관리ToolStripMenuItem.Name = "회원관리ToolStripMenuItem";
            this.회원관리ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 0, 4, 40);
            this.회원관리ToolStripMenuItem.Size = new System.Drawing.Size(123, 65);
            this.회원관리ToolStripMenuItem.Text = "회원관리";
            this.회원관리ToolStripMenuItem.Click += new System.EventHandler(this.회원관리ToolStripMenuItem_Click);
            // 
            // 게시판ToolStripMenuItem
            // 
            this.게시판ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.공지사항ToolStripMenuItem,
            this.묻고답하기ToolStripMenuItem});
            this.게시판ToolStripMenuItem.Name = "게시판ToolStripMenuItem";
            this.게시판ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 0, 4, 40);
            this.게시판ToolStripMenuItem.Size = new System.Drawing.Size(123, 65);
            this.게시판ToolStripMenuItem.Text = "게시판";
            // 
            // 공지사항ToolStripMenuItem
            // 
            this.공지사항ToolStripMenuItem.Name = "공지사항ToolStripMenuItem";
            this.공지사항ToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.공지사항ToolStripMenuItem.Text = "공지사항";
            this.공지사항ToolStripMenuItem.Click += new System.EventHandler(this.공지사항ToolStripMenuItem_Click);
            // 
            // 묻고답하기ToolStripMenuItem
            // 
            this.묻고답하기ToolStripMenuItem.Name = "묻고답하기ToolStripMenuItem";
            this.묻고답하기ToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.묻고답하기ToolStripMenuItem.Text = "묻고 답하기";
            this.묻고답하기ToolStripMenuItem.Click += new System.EventHandler(this.묻고답하기ToolStripMenuItem_Click);
            // 
            // 환경설정ToolStripMenuItem
            // 
            this.환경설정ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.운영설정ToolStripMenuItem});
            this.환경설정ToolStripMenuItem.Name = "환경설정ToolStripMenuItem";
            this.환경설정ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 0, 4, 40);
            this.환경설정ToolStripMenuItem.Size = new System.Drawing.Size(123, 65);
            this.환경설정ToolStripMenuItem.Text = "환경설정";
            this.환경설정ToolStripMenuItem.Click += new System.EventHandler(this.환경설정ToolStripMenuItem_Click);
            // 
            // 운영설정ToolStripMenuItem
            // 
            this.운영설정ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.운영규정ToolStripMenuItem,
            this.대출환경설정ToolStripMenuItem});
            this.운영설정ToolStripMenuItem.Name = "운영설정ToolStripMenuItem";
            this.운영설정ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.운영설정ToolStripMenuItem.Text = "운영설정";
            // 
            // 운영규정ToolStripMenuItem
            // 
            this.운영규정ToolStripMenuItem.Name = "운영규정ToolStripMenuItem";
            this.운영규정ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.운영규정ToolStripMenuItem.Text = "도서관 설정";
            this.운영규정ToolStripMenuItem.Click += new System.EventHandler(this.운영규정ToolStripMenuItem_Click);
            // 
            // 대출환경설정ToolStripMenuItem
            // 
            this.대출환경설정ToolStripMenuItem.Name = "대출환경설정ToolStripMenuItem";
            this.대출환경설정ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.대출환경설정ToolStripMenuItem.Text = "대출환경 설정";
            this.대출환경설정ToolStripMenuItem.Click += new System.EventHandler(this.대출환경설정ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(139, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 553);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(710, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "OOO 관리자";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker1.Location = new System.Drawing.Point(139, 47);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-5, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(141, 72);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // ManagerMainHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(794, 624);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ManagerMainHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "manager_Hompage2";
            this.Load += new System.EventHandler(this.manager_Hompage2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 대출ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 반납ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 연체ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도서관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도서관ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도서검색ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 회원관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 게시판ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 공지사항ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 묻고답하기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 환경설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 운영설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 운영규정ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem 불러오기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 검색도서정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 대출환경설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 신청구매도서목록ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem 구매도서ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 신착추천도서ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도서관리ToolStripMenuItem1;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}