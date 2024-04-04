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
using MySql.Data.MySqlClient;
using System.Data.Sql;


namespace 스쿼드_도서관
{
    public partial class ManagerLogin : Form
    {
        public ManagerLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string myconnection = "datasource=localhost;port=3306;username=root;password=1234";
                MySqlConnection myconnect = new MySqlConnection(myconnection);

                MySqlCommand cmd = new MySqlCommand("Select * from squad_library.manager_pw where 비밀번호 ='"+ this.textBox2.Text +"';", myconnect);
                MySqlDataReader myread;
                myconnect.Open();
                myread = cmd.ExecuteReader();
                int count = 0;
                ManagerMainHome mH = new ManagerMainHome();


                string myconnection2 = "datasource=localhost;port=3306;username=root;password=1234";
                MySqlConnection myconnect2 = new MySqlConnection(myconnection2);

                MySqlCommand cmd2 = new MySqlCommand("Select * from squad_library.manager_pw2 where 비밀번호 ='" + this.textBox2.Text + "';", myconnect2);
                MySqlDataReader myread2;
                myconnect2.Open();
                myread2 = cmd2.ExecuteReader();
                int count2 = 0;
                EmployeeMainHome mH0 = new EmployeeMainHome();


                while (myread2.Read())
                { 
                    count2 = count2 + 1;
                }

                while (myread.Read())
                {
                    count = count + 1;
                }

                while (myread.Read())
                {
                    count = count + 1;
                }

                if (textBox2.Text == "")
                {
                    MessageBox.Show("비밀번호가 입력되지 않았습니다.");
                }

                else if (count == 1)
                {
                    MessageBox.Show("관리자로 로그인 되었습니다.");
                    this.Hide();
                    mH.Show();
                }

                else if (count2 == 1)
                {
                    MessageBox.Show("알바생 로그인 되었습니다.");
                    this.Hide();
                    mH0.Show();
                }

                else
                {
                    MessageBox.Show("비밀번호가 일치하지 않습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeMainHome mH0 = new EmployeeMainHome();
            mH0.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void manager_login_Load(object sender, EventArgs e)
        {

        }
    }
}
