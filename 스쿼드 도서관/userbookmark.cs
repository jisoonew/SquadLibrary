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
    public partial class userbookmark : UserControl
    {
        public userbookmark()
        {
            InitializeComponent();
        }

        private void userbookmark_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");
                MySqlDataAdapter adapter = new MySqlDataAdapter("select * from  squad_library.userbookmark", connection);

                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "alluser");
                dataGridView1.DataSource = ds.Tables["alluser"];
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
            MySqlCommand cmd_db = new MySqlCommand("SELECT  도서명,글쓴이,출판일,출판사 FROM squad_library.userbookmark;", con);

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

        private void button1_Click(object sender, EventArgs e)
        {
            int rowIndext = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndext);
            string myconnect = "datasource = localhost; port = 3306; username=root; password=cse1234";
            string query = "delete from squad_library.userbookmark 도서명";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MySqlConnection myconn = new MySqlConnection(myconnect);
            MySqlCommand mycommand = new MySqlCommand(query, myconn);
            MySqlDataReader myReader;

            try
            {
                myconn.Open();
                myReader = mycommand.ExecuteReader();
                MessageBox.Show("삭제완료");
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
