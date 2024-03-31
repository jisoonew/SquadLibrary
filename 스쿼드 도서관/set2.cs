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
    public partial class set2 : UserControl
    {
        public set2()
        {
            InitializeComponent();
        }

        static string myConnection = "Server=localhost;Database=squad_library;username=root;password=qkrwltn5130!; allow user variables=true";

        private void set2_Load(object sender, EventArgs e)
        {
            try  //휴관일 DB
            {

                MySqlConnection connection = new MySqlConnection(myConnection);

                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM squad_library.set2", connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    textBox1.Text = (reader["회원등급"].ToString());
                    textBox2.Text = (reader["대출권수"].ToString());
                    textBox3.Text = (reader["대출기간"].ToString());
                    textBox4.Text = (reader["신청권수"].ToString());
                }
                
                connection.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            String num = textBox3.Text;
            String num2 = textBox2.Text;
            textBox5.Text = "해당 등급 - 일반 회원 / 알바생 \r\n빌려간 도서 기일 내에 반납하지 않을 시-> 3일에 1000원";
            textBox6.Text = "등급 - 관리자 / 알바생 / 회원 \r\n권수\r\n - 직원 : 10권 \r\n- 회원 : 5권 \r\n기간 \r\n- 직원 : 21일 \r\n- 회원 : 14일 \r\n연장 \r\n- 직원 : 1회 3일(총 1회) \r\n- 회원, 알바생: 1회 3일(총 2회)";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            string myconnect = "datasource = localhost; port = 3306; username=root; password=qkrwltn5130!;";
            string query = "update squad_library.set2 set " + "회원등급 = '" + this.textBox1.Text + "', 대출권수 = '" + this.textBox2.Text + "', 대출기간 = '" + this.textBox3.Text + "', 신청권수 = '" + this.textBox4.Text + "', 연체규정 ='"+this.textBox5.Text+ "', 연장규정 ='" + this.textBox6.Text + "'";


            MySqlConnection myconn = new MySqlConnection(myconnect);

            MySqlCommand cmd = new MySqlCommand(query, myconn);

            MySqlDataReader myReader;

            try
            {
                myconn.Open();

                myReader = cmd.ExecuteReader();
                MessageBox.Show("저장되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
