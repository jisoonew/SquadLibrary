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
    public partial class ManagerMainHome : Form
    {
        public ManagerMainHome()
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
            ManagerBookSetup bu = new ManagerBookSetup();
            mainPanel(bu);
        }

        private void 반납ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerBookReturn br = new ManagerBookReturn();
            mainPanel(br);
        }

        private void 연체ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerBookOverdue bo = new ManagerBookOverdue();
            mainPanel(bo);
        }

        private void 도서관ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 회원관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInformationPage au = new UserInformationPage();
            mainPanel(au);
        }

        private void 도서관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 불러오기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerBookCall bc = new ManagerBookCall();
            mainPanel(bc);
        }

        private void 검색도서정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerBookInformation bi = new ManagerBookInformation();
            mainPanel(bi);
        }

        private void 공지사항ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerNotice mn = new ManagerNotice();
            mainPanel(mn);
        }

        private void 묻고답하기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerQA qa = new ManagerQA();
            mainPanel(qa);
        }

        private void 환경설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 운영규정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerLibrarySettings ls = new ManagerLibrarySettings();
            mainPanel(ls);
        }

        private void 대출환경설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerSettings set2 = new ManagerSettings();
            mainPanel(set2);
        }

        private void 신청구매도서목록ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerApplicationBook mr = new ManagerApplicationBook();
            mainPanel(mr);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        // 대출 페이지
        private void manager_Hompage2_Load(object sender, EventArgs e)
        {
            ManagerBookSetup managerSetUp = new ManagerBookSetup();
            mainPanel(managerSetUp);
        }

        private void 구매도서ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerBuyBook mr2 = new ManagerBuyBook();
            mainPanel(mr2);
        }

        private void 도서관리ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManagerBookManagement bm = new ManagerBookManagement();
            mainPanel(bm);
        }

        private void 신착추천도서ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerNewBook mn = new ManagerNewBook();
            mainPanel(mn);
        }
    }
}
