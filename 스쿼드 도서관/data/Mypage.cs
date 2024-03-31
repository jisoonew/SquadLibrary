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
    public partial class Mypage : Form
    {
        public Mypage()
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
            mydata md = new mydata();
            ToPanel(md);
        }

        private void 도ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mydatachange mdc = new mydatachange();
            ToPanel(mdc);
        }

        private void 도서대여반ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userbookrental ubr = new userbookrental();
            ToPanel(ubr);
        }

        private void 연체ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Useroverdue uo = new Useroverdue();
            ToPanel(uo);
        }

        private void 신청ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Userbookrequest1 request = new Userbookrequest1();
            ToPanel(request);
        }

        private void 구매ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Userbookpurchase ubp = new Userbookpurchase();
            ToPanel(ubp);
        }

        private void 즐겨찾기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userbookmark ubm = new userbookmark();
            ToPanel(ubm);
        }

        private void 회원탈퇴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Userunregister un = new Userunregister();
            ToPanel(un);
        }

        private void 대여ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userbookrental ubr = new userbookrental();
            ToPanel(ubr);
        }
    }
}
