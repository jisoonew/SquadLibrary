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
    public partial class manager_Homepage : Form
    {
        public manager_Homepage()
        {
            InitializeComponent();
        }

        private void Panel1(Control c)
        {
            c.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(c);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            booksetup bs = new booksetup();
            Panel1(bs);
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            managernotice mn = new managernotice();
            Panel1(mn);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            alluser au = new alluser();
            Panel1(au);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bookoverdue bo = new bookoverdue();
            Panel1(bo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bookreturn br = new bookreturn();
            Panel1(br);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            QA qa = new QA();
            Panel1(qa);
        }
    }
}
