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
    public partial class mydatachange : UserControl
    {
        public mydatachange()
        {
            InitializeComponent();
        }

        private void mydatachange_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");
                MySqlDataAdapter adapter = new MySqlDataAdapter("select '회원명','생년월일', '전화번호', '이메일','비밀번호','주소'", connection);

                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "mydata");

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadData()
        {
            string sql = "Server=localhost;Port=3306;username=root;password=qkrwltn5130!";
            MySqlConnection con = new MySqlConnection(sql);
            MySqlCommand cmd_db = new MySqlCommand("SELECT  회원명,생년월일, 전화번호, 이메일,비밀번호,주소  FROM squad_library.mydata;", con);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd_db;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myconnect = "datasource = localhost; port = 3306; username=root; password=qkrwltn5130!";
            string query = "update squad_library.mydata set 회원명 = '" + this.textBox1.Text + "', 생년월일 = '" + this.textBox2.Text + "', 전화번호 = '" + this.textBox3.Text + "', 이메일 = '" + this.textBox4.Text + "', 주소 = '" + this.textBox5.Text + "', 비밀번호 = '" + this.textBox6.Text + "' where 회원명 = '" + this.textBox1.Text + "'";

            MySqlConnection myconn = new MySqlConnection(myconnect);
            MySqlCommand mycommand = new MySqlCommand(query, myconn);
            MySqlDataReader myReader;
            try
            {
                myconn.Open();
                myReader = mycommand.ExecuteReader();
                MessageBox.Show("저장되었습니다.");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadData();
        }
    }
}
