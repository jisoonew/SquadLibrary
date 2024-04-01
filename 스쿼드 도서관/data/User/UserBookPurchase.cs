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
    public partial class UserBookPurchase : UserControl
    {
        int selectedRow;
        public UserBookPurchase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myconnect = "datasource = localhost; port = 3306; username=root; password=qkrwltn5130!";
            string query = "insert into squad_library.userbookpurchase(제목,글쓴이,출판사,출판일,도서가격,배송지)" +
                "value('" + textBox1.Text + "','" + textBox4.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox5.Text + "')";

            MySqlConnection myconn = new MySqlConnection(myconnect);

            MySqlCommand mycommand = new MySqlCommand(query, myconn);
            MySqlDataReader myReader;
            try
            {

                myconn.Open();
                myReader = mycommand.ExecuteReader();

                MessageBox.Show("구매 신청 완료");

                myconn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadData();
        }

        private void Userbookpurchase_Load(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");
                MySqlDataAdapter adapter = new MySqlDataAdapter("select 제목,글쓴이,출판사,출판일,도서가격,배송지 from squad_library.userbookpurchase", connection);

                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "userbookpurchase");
                dataGridView1.DataSource = ds.Tables["userbookpurchase"];

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
            MySqlCommand cmd_db = new MySqlCommand("SELECT 제목,글쓴이,출판사,출판일,도서가격,배송지 FROM squad_library.userbookpurchase;", con);

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
            textBox1.Text = "";
            textBox4.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string myconnect = "datasource = localhost; port = 3306; username=root; password=qkrwltn5130!";
            if (textBox1.Text == "")
            {
                MessageBox.Show("항목을 찾지 못했습니다");
            }
            string query = "delete from squad_library.userbookpurchase where 제목 = '" + this.textBox1.Text + "';";

            MySqlConnection myconn = new MySqlConnection(myconnect);
            MySqlCommand mycommand = new MySqlCommand(query, myconn);
            MySqlDataReader myReader;

            try
            {
                myconn.Open();
                myReader = mycommand.ExecuteReader();
                MessageBox.Show("구매 신청 취소");
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox4.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
            textBox6.Text = row.Cells[4].Value.ToString();
            textBox5.Text = row.Cells[5].Value.ToString();
        }
    }
}
