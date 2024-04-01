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
    public partial class ManagerNewBook : UserControl
    {
        public ManagerNewBook()
        {
            InitializeComponent();
        }

        static string myConnection = "Server=localhost;Database=squad_library;username=root;password=qkrwltn5130!;";

        private ManagerBookManagement bmn = new ManagerBookManagement();

        private void button1_Click(object sender, EventArgs e)
        {
            string myconnect = "datasource = localhost; port = 3306; username=root; password=qkrwltn5130!;";
            string query = "INSERT INTO squad_library.newbook value('" + bmn.textBox7.Text + "', '" + bmn.textBox1.Text + "', '" + bmn.textBox2.Text + "', '" + bmn.textBox4.Text + "', '" + bmn.textBox6.Text + "');";


            MySqlConnection myconn = new MySqlConnection(myconnect);

            MySqlCommand cmd = new MySqlCommand(query, myconn);

            MySqlDataReader myReader;

            try
            {
                myconn.Open();

                myReader = cmd.ExecuteReader();
                MessageBox.Show("신착 도서로 지정되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string myconnect = "datasource = localhost; port = 3306; username=root; password=qkrwltn5130!;";
            string query = "INSERT INTO squad_library.user_recommend value('" + bmn.textBox7.Text + "', '" + bmn.textBox1.Text + "', '" + bmn.textBox2.Text + "', '" + bmn.textBox4.Text + "', '" + bmn.textBox6.Text + "');";


            MySqlConnection myconn = new MySqlConnection(myconnect);

            MySqlCommand cmd = new MySqlCommand(query, myconn);

            MySqlDataReader myReader;

            try
            {
                myconn.Open();

                myReader = cmd.ExecuteReader();
                MessageBox.Show("추천 도서로 지정되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            myconn.Close();
        }

        private void mn_newbook_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(myConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM squad_library.newbook", connection);

                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "squad_library");
                dataGridView1.DataSource = ds.Tables["squad_library"];

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                MySqlConnection connection = new MySqlConnection(myConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM squad_library.user_recommend", connection);

                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "squad_library");
                dataGridView2.DataSource = ds.Tables["squad_library"];

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                MySqlConnection connection = new MySqlConnection(myConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서번호, 도서명, 글쓴이, 출판사, 페이지 FROM squad_library.search1", connection);

                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "squad_library");
                dataGridView3.DataSource = ds.Tables["squad_library"];

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=qkrwltn5130!";
            //delete를 통해 DB로 삭제된 데이터 전송 - 기본키 기준으로 삭제위치 탐색
            string Query = "delete from squad_library.newbook where 도서번호 = '" + this.label1.Text + "';";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("신착 도서를 삭제했습니다.");

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

        public void LoadData()
        {
            string sql = "Server=localhost;Port=3306;username=root;password=qkrwltn5130!";
            MySqlConnection con = new MySqlConnection(sql);
            MySqlCommand cmd_db = new MySqlCommand("SELECT * FROM squad_library.newbook;", con);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd_db;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadData2()
        {
            string sql = "Server=localhost;Port=3306;username=root;password=qkrwltn5130!";
            MySqlConnection con = new MySqlConnection(sql);
            MySqlCommand cmd_db = new MySqlCommand("SELECT * FROM squad_library.user_recommend;", con);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd_db;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView2.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[0].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=qkrwltn5130!";
            //delete를 통해 DB로 삭제된 데이터 전송 - 기본키 기준으로 삭제위치 탐색
            string Query = "delete from squad_library.user_recommend where 도서번호 = '" + this.label2.Text + "';";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("추천 도서를 삭제했습니다.");

                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LoadData2();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = dataGridView2.Rows[this.dataGridView2.CurrentCellAddress.Y].Cells[0].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
