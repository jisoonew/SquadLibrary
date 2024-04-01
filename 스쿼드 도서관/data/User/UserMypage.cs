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
    public partial class UserMypage : Form
    {
        public UserMypage()
        {
            InitializeComponent();
        }

        private void ToPanel(Control c) {
            c.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(c);
        }

        private void 내정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserMydata md = new UserMydata();
            ToPanel(md);
        }

        private void 도ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MydataChange mdc = new MydataChange();
            ToPanel(mdc);
        }

        private void 도서대여반ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserBookRental ubr = new UserBookRental();
            ToPanel(ubr);
        }

        private void 연체ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserOverdue uo = new UserOverdue();
            ToPanel(uo);
        }

        private void 신청ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserApplicationBook request = new UserApplicationBook();
            ToPanel(request);
        }

        private void 구매ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserBookPurchase ubp = new UserBookPurchase();
            ToPanel(ubp);
        }

        private void 즐겨찾기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userbookmark ubm = new userbookmark();
            ToPanel(ubm);
        }

        private void 회원탈퇴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserUnregister un = new UserUnregister();
            ToPanel(un);
        }

        private void 대여ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserBookRental ubr = new UserBookRental();
            ToPanel(ubr);
        }
    }
}
