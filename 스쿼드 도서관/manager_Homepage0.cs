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
    public partial class manager_Homepage0 : Form
    {
        public manager_Homepage0()
        {
            InitializeComponent();
        }

        private void mainPanel2(Control s)
        {
            s.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(s);
        }

        private void manager_Homepage0_Load(object sender, EventArgs e)
        {

        }

        private void 반납ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bookreturn br1 = new bookreturn();
            mainPanel2(br1);
        }

        private void 대출ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            booksetup bs1 = new booksetup();
            mainPanel2(bs1);
        }

        private void 연체ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bookoverdue bo1 = new bookoverdue();
            mainPanel2(bo1);
        }
    }
}
