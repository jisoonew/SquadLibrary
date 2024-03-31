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
    public partial class userbookrental : UserControl
    {
        public userbookrental()
        {
            InitializeComponent();
        }

        private void userbookrental_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");
                MySqlDataAdapter adapter = new MySqlDataAdapter("select * from squad_library.userbookrental", connection);

                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "userbookrental");
                dataGridView1.DataSource = ds.Tables["userbookrental"];

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
            MySqlCommand cmd_db = new MySqlCommand("SELECT * FROM squad.userbookrental;", con);

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myConnection = "datasource=localhost;port=3306;username=root;password=qkrwltn5130!";

            try
            {

                string Query = "update squad_library.userbookrental set " + "반납일 = '" + this.textBox1.Text + "'where 도서번호 = '" + this.label5.Text + "'";


                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand SelectCommand = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                MessageBox.Show("수정되었습니다.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[6].Value.ToString();
            label5.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[0].Value.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            User_Search4 us4 = new User_Search4();
            us4.dateTimePicker1.Format = DateTimePickerFormat.Long;
            us4.dateTimePicker1.Value = DateTime.Now.AddDays(17);
            label2.Text = us4.dateTimePicker1.Value.ToString("yyyy-MM-dd");
            textBox1.Text = label2.Text;
            us4.dateTimePicker1.Value = DateTime.Now;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            User_Search4 us4 = new User_Search4();
            us4.dateTimePicker1.Format = DateTimePickerFormat.Long;
            us4.dateTimePicker1.Value = DateTime.Now.AddDays(20);
            label4.Text = us4.dateTimePicker1.Value.ToString("yyyy-MM-dd");
            textBox1.Text = label4.Text;
            us4.dateTimePicker1.Value = DateTime.Now;
        }
    }
}
