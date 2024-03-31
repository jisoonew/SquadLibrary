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
    public partial class managerrequest2 : UserControl
    {
        static string myConnection = "Server=localhost;Database=squad_library;username=root;password=qkrwltn5130!; allow user variables=true";

        public managerrequest2()
        {
            InitializeComponent();
        }

        private void managerrequest2_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(myConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 신청번호, 도서명, 글쓴이, 출판사, 가격, 구매날짜, 배송예상날짜, 배송완료날짜 FROM squad_library.managerrequet2", connection);

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
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 신청번호, 회원명, 회원등급, 전화번호, 이메일, 주소, 메모, 현황 FROM squad_library.managerrequet2", connection);

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

        }


        /*private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox8.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[0].Value.ToString();
            textBox9.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[1].Value.ToString();
            textBox10.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[2].Value.ToString();
            textBox11.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[3].Value.ToString();
            textBox12.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[4].Value.ToString();
            textBox13.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[5].Value.ToString();
            textBox14.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[6].Value.ToString();
            textBox15.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[7].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView2.Rows[this.dataGridView2.CurrentCellAddress.Y].Cells[0].Value.ToString();
            textBox1.Text = dataGridView2.Rows[this.dataGridView2.CurrentCellAddress.Y].Cells[1].Value.ToString();
            textBox3.Text = dataGridView2.Rows[this.dataGridView2.CurrentCellAddress.Y].Cells[2].Value.ToString();
            textBox2.Text = dataGridView2.Rows[this.dataGridView2.CurrentCellAddress.Y].Cells[3].Value.ToString();
            textBox5.Text = dataGridView2.Rows[this.dataGridView2.CurrentCellAddress.Y].Cells[4].Value.ToString();
            textBox4.Text = dataGridView2.Rows[this.dataGridView2.CurrentCellAddress.Y].Cells[5].Value.ToString();
            textBox7.Text = dataGridView2.Rows[this.dataGridView2.CurrentCellAddress.Y].Cells[6].Value.ToString();
            textBox16.Text = dataGridView2.Rows[this.dataGridView2.CurrentCellAddress.Y].Cells[7].Value.ToString();
        }*/

        public void LoadData1()
        {
            MySqlConnection connection = new MySqlConnection(myConnection);
            MySqlCommand cmd_db = new MySqlCommand("SELECT 신청번호, 도서명, 글쓴이, 출판사, 가격, 구매날짜, 배송예상날짜, 배송완료날짜  FROM squad_library.managerrequet2;", connection);

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
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadData2()
        {
            MySqlConnection con = new MySqlConnection(myConnection);
            MySqlCommand cmd_db = new MySqlCommand("SELECT 신청번호, 회원명, 회원등급, 전화번호, 이메일, 주소, 메모, 현황 FROM squad_library.managerrequet2;", con);

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
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Query = "delete from squad_library.managerrequet2 where 신청번호 ='" + this.textBox6.Text + "' || 신청번호 = '" + this.textBox8.Text + "'; ALTER TABLE squad_library.managerrequest AUTO_INCREMENT=1; SET @COUNT = 0; UPDATE squad_library.managerrequest SET 신청번호 = @COUNT:= @COUNT + 1; ";
            MySqlConnection conDataBase = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("취소처리 되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string Query = "delete from squad_library.managerrequet2 where 신청번호 ='" + this.textBox6.Text + "'; ALTER TABLE squad_library.managerrequest AUTO_INCREMENT=1; SET @COUNT = 0; UPDATE squad_library.managerrequest SET 신청번호 = @COUNT:= @COUNT + 1; ";
            MySqlConnection conDataBase = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("취소처리 되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LoadData();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                string Query = "update squad_library.managerrequet2 set 신청번호=@신청번호, 도서명=@도서명, 글쓴이=@글쓴이, 출판사=@출판사, 가격=@가격, 구매날짜=@구매날짜, 배송예상날짜=@배송예상날짜, 배송완료날짜=@배송완료날짜, 회원명=@회원명, 회원등급=@회원등급, 주소=@주소, 메모=@메모, 전화번호=@전화번호, 이메일=@이메일, 현황=@현황 where 신청번호=@신청번호";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand SelectCommand = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;
                myConn.Open();

                SelectCommand.Parameters.AddWithValue("@신청번호", textBox6.Text);
                SelectCommand.Parameters.AddWithValue("@도서명", textBox1.Text);
                SelectCommand.Parameters.AddWithValue("@글쓴이", textBox3.Text);
                SelectCommand.Parameters.AddWithValue("@출판사", textBox2.Text);
                SelectCommand.Parameters.AddWithValue("@가격", textBox5.Text);
                SelectCommand.Parameters.AddWithValue("@구매날짜", textBox4.Text);
                SelectCommand.Parameters.AddWithValue("@배송예상날짜", textBox7.Text);
                SelectCommand.Parameters.AddWithValue("@배송완료날짜", textBox16.Text);
                SelectCommand.Parameters.AddWithValue("@회원명", textBox9.Text);
                SelectCommand.Parameters.AddWithValue("@회원등급", textBox10.Text);
                SelectCommand.Parameters.AddWithValue("@주소", textBox13.Text);
                SelectCommand.Parameters.AddWithValue("@메모", textBox14.Text);
                SelectCommand.Parameters.AddWithValue("@전화번호", textBox11.Text);
                SelectCommand.Parameters.AddWithValue("@이메일", textBox12.Text);
                textBox15.Text = "접수";
                SelectCommand.Parameters.AddWithValue("@현황", textBox15.Text);

                myReader = SelectCommand.ExecuteReader();
                MessageBox.Show("접수처리 되었습니다.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LoadData_2();
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void LoadData()
        {
            MySqlConnection con = new MySqlConnection(myConnection);
            MySqlCommand cmd_db = new MySqlCommand("SELECT 신청번호, 도서명, 글쓴이, 출판사, 가격, 구매날짜, 배송예상날짜, 배송완료날짜 FROM squad_library.managerrequet2;", con);

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

        public void LoadData_2()
        {
            MySqlConnection con = new MySqlConnection(myConnection);
            MySqlCommand cmd_db = new MySqlCommand("SELECT 신청번호, 회원명, 회원등급, 전화번호, 이메일, 주소, 메모, 현황 FROM squad_library.managerrequet2;", con);

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=qkrwltn5130!");
                MySqlDataAdapter adap = new MySqlDataAdapter("select 신청번호, 도서명, 글쓴이, 출판사, 가격, 구매날짜, 배송예상날짜, 배송완료날짜 from squad_library.managerrequet2", conn);

                conn.Open();

                DataSet ds = new DataSet();

                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBox16.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

                //adap.Fill(ds, "managerrequet2");
                //dataGridView2.DataSource = ds.Tables["managerrequet2"];

                textBox8.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox9.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox10.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox11.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox12.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox13.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox14.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBox15.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                //adap.Fill(ds, "bookrent_user");
                //dataGridView2.DataSource = ds.Tables["bookrent_user"];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
