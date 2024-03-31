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
    public partial class Userunregister : UserControl
    {
        public Userunregister()
        {
            InitializeComponent();
        }

        private void Userunregister_Load(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");
                MySqlDataAdapter adapter = new MySqlDataAdapter("select 비밀번호 from squad_library.mydata", connection);

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
            string sql = "Server=localhost;Port=3306;username=root;password=cse1234";
            MySqlConnection con = new MySqlConnection(sql);
            MySqlCommand cmd_db = new MySqlCommand("SELECT 비밀번호 FROM squad_library.mydata;", con);

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myconnect = "datasource = localhost; port = 3306; username=root; password=qkrwltn5130!";
            string query = "delete from squad_library.mydata where 비밀번호 = '" + this.textBox1.Text + "';";

            MySqlConnection myconn = new MySqlConnection(myconnect);
            MySqlCommand mycommand = new MySqlCommand(query, myconn);
            MySqlDataReader myReader;
            try
            {
                if (textBox1.Text == textBox2.Text)
                {
                    myconn.Open();
                    myReader = mycommand.ExecuteReader();
                    MessageBox.Show("탈퇴 완료");
                }
                else
                {
                    MessageBox.Show("다시 입력하세요.");
                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadData();
        }
    }
}
