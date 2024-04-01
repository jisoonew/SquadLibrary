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
    public partial class ManagerLibrarySettings : UserControl
    {
        static string myConnection = "Server=localhost;Database=squad_library;username=root;password=qkrwltn5130!;";

        public ManagerLibrarySettings()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            MySqlConnection con = new MySqlConnection(myConnection);
            MySqlCommand cmd_db = new MySqlCommand("SELECT 날짜, 내용  FROM squad_library.holiday;", con);

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
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void library_set_Load(object sender, EventArgs e)
        {
            try  //휴관일 DB
            {
                MySqlConnection connection = new MySqlConnection(myConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM squad_library.holiday", connection);

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

            LoadData(); // 새로고침

            try  //휴관일 DB
            {
                MySqlConnection connection = new MySqlConnection(myConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM squad_library.library_set", connection);

                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "squad_library");
                dataGridView1.DataSource = ds.Tables["squad_library"];

                textBox1.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[4].Value.ToString();

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LoadData(); // 새로고침
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("추가할 내용을 입력해주세요!");
                textBox6.Focus();
            }
            else
            {
                string myconnection = "datasource = localhost; port = 3306; username=root; password=qkrwltn5130!;";
                string query = "insert into squad_library.holiday values('" + this.dateTimePicker1.Text + "', '" + this.textBox6.Text + "'); ";


                MySqlConnection myconn = new MySqlConnection(myconnection);

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

                LoadData();
            }
        }

        



        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            string myconnect = "datasource = localhost; port = 3306; username=root; password=qkrwltn5130!;";
            string query = "update squad_library.library_set set " + "도서관명 = '" + this.textBox1.Text + "', 연락처 = '" + this.textBox2.Text + "', 주소 = '" + this.textBox3.Text + "', 이메일 = '" + this.textBox4.Text + "', pw = '" + this.textBox5.Text + "'";


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

            LoadData();
        }

        public void BindGrid()
        {
            MySqlConnection myConnection = new MySqlConnection("Server=localhost;Database=squad_library;username=root;password=qkrwltn5130!");
            MySqlCommand com = new MySqlCommand("Select * from squad_library.holiday", myConnection);
            MySqlDataAdapter adt = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("정보를 삭제하시겠습니까?", "delete record", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MySqlConnection myConnection = new MySqlConnection("Server=localhost;Database=squad_library;username=root;password=qkrwltn5130!");
                String content = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["내용"].FormattedValue.ToString());
                myConnection.Open();
                MySqlCommand cmd = new MySqlCommand("delete squad_library.holiday where 내용 = '" + content + "'", myConnection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("삭제되었습니다.");
                myConnection.Close();
                BindGrid();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=qkrwltn5130!";
            if (textBox6.Text == "")
            {
                MessageBox.Show("삭제 할 항목을 찾지 못했습니다.");
            }
            else
            {
                //delete를 통해 DB로 삭제된 데이터 전송 - 기본키 기준으로 삭제위치 탐색
                string Query = "delete from squad_library.holiday where 내용 ='" + this.textBox6.Text + "';";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                try
                {
                    conDataBase.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("도서를 삭제했습니다.");

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

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[1].Value.ToString();
        }

    }
    }
