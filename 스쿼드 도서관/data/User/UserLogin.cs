using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace 스쿼드_도서관
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        string myConnection = "datasource=localhost;port=3306;username=root;password=1234";

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand SelectCommand = new MySqlCommand("select * from squad_library.mydata where 아이디 = '" + textBox1.Text + "' and 비밀번호='" + textBox2.Text + "'", myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    UserUnregister ug = new UserUnregister();
                    ug.textBox1.Text = this.textBox2.Text;
                    MessageBox.Show("로그인 성공");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("다시 로그인하세요.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            UserMainHomeLogin uh2 = new UserMainHomeLogin();
            uh2.Show();

        }
        private string GetString(int v)
        {
            throw new NotImplementedException();
        }

        private void User_login2_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserJoin ul1 = new UserJoin();
            ul1.Show();
        }
    }
}
