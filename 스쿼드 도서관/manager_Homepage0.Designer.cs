
namespace 스쿼드_도서관
{
    partial class manager_Homepage0
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(manager_Homepage0));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.반납ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.대출ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.연체ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.반납ToolStripMenuItem,
            this.대출ToolStripMenuItem,
            this.연체ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 80, 0, 20);
            this.menuStrip1.Size = new System.Drawing.Size(136, 624);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 반납ToolStripMenuItem
            // 
            this.반납ToolStripMenuItem.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.반납ToolStripMenuItem.Name = "반납ToolStripMenuItem";
            this.반납ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 0, 4, 40);
            this.반납ToolStripMenuItem.Size = new System.Drawing.Size(129, 69);
            this.반납ToolStripMenuItem.Text = "반납";
            this.반납ToolStripMenuItem.Click += new System.EventHandler(this.반납ToolStripMenuItem_Click);
            // 
            // 대출ToolStripMenuItem
            // 
            this.대출ToolStripMenuItem.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.대출ToolStripMenuItem.Name = "대출ToolStripMenuItem";
            this.대출ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 0, 4, 40);
            this.대출ToolStripMenuItem.Size = new System.Drawing.Size(129, 69);
            this.대출ToolStripMenuItem.Text = "대출";
            this.대출ToolStripMenuItem.Click += new System.EventHandler(this.대출ToolStripMenuItem_Click);
            // 
            // 연체ToolStripMenuItem
            // 
            this.연체ToolStripMenuItem.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.연체ToolStripMenuItem.Name = "연체ToolStripMenuItem";
            this.연체ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 0, 4, 40);
            this.연체ToolStripMenuItem.Size = new System.Drawing.Size(129, 69);
            this.연체ToolStripMenuItem.Text = "연체";
            this.연체ToolStripMenuItem.Click += new System.EventHandler(this.연체ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(138, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 552);
            this.panel1.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker1.Location = new System.Drawing.Point(138, 47);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-5, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(141, 72);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // manager_Homepage0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 624);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "manager_Homepage0";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "manager_Homepage0";
            this.Load += new System.EventHandler(this.manager_Homepage0_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem 반납ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 대출ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 연체ToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}