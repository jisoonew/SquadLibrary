using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 스쿼드_도서관.data;

namespace 스쿼드_도서관
{
    public partial class manager_Hompage2 : Form
    {
        public manager_Hompage2()
        {
            InitializeComponent();
        }

        private void mainPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(c);
        }

        private void 대출ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            booksetup bu = new booksetup();
            mainPanel(bu);
        }

        private void 반납ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bookreturn br = new bookreturn();
            mainPanel(br);
        }

        private void 연체ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bookoverdue bo = new bookoverdue();
            mainPanel(bo);
        }

        private void 도서관ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 회원관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alluser au = new alluser();
            mainPanel(au);
        }

        private void 도서관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 불러오기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bookcall bc = new bookcall();
            mainPanel(bc);
        }

        private void 검색도서정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bookinformation bi = new bookinformation();
            mainPanel(bi);
        }

        private void 공지사항ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            managernotice mn = new managernotice();
            mainPanel(mn);
        }

        private void 묻고답하기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QA qa = new QA();
            mainPanel(qa);
        }

        private void 환경설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 운영규정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            library_set ls = new library_set();
            mainPanel(ls);
        }

        private void 대출환경설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            set2 set2 = new set2();
            mainPanel(set2);
        }

        private void 신청구매도서목록ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            managerrequest mr = new managerrequest();
            mainPanel(mr);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void manager_Hompage2_Load(object sender, EventArgs e)
        {

        }

        private void 구매도서ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            managerrequest2 mr2 = new managerrequest2();
            mainPanel(mr2);
        }

        private void 도서관리ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bookmanagement bm = new bookmanagement();
            mainPanel(bm);
        }

        private void 신착추천도서ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mn_newbook mn = new mn_newbook();
            mainPanel(mn);
        }
    }
}
