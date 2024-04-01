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
    public partial class ManagerApplicationBook : UserControl
    {
        static string myConnection = "Server=localhost;Database=squad_library;username=root;password=qkrwltn5130!; allow user variables=true";

        public ManagerApplicationBook()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void managerrequest_Load(object sender, EventArgs e)
        {
           
            try
            {
                MySqlConnection connection = new MySqlConnection(myConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 신청번호, 도서명, 글쓴이, 출판사, 가격, 구매날짜, 배송예상날짜, 배송완료날짜 FROM squad_library.managerrequest", connection);

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

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[6].Value.ToString();
            textBox2.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[7].Value.ToString();
            textBox3.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[0].Value.ToString();
            textBox7.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[4].Value.ToString();

            ManagerMainHome br = new ManagerMainHome();
            br.dateTimePicker1.Format = DateTimePickerFormat.Long;
            br.dateTimePicker1.Value = DateTime.Now;
            textBox7.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "update squad_library.managerrequest set 도서명=@도서명, 글쓴이=@글쓴이, 출판사=@출판사, 가격=@가격, 구매날짜=@구매날짜, 배송예상날짜=@배송예상날짜, 배송완료날짜=@배송완료날짜, 현황=@현황 where 신청번호=@신청번호";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand SelectCommand = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;
                myConn.Open();

                SelectCommand.Parameters.AddWithValue("@도서명", textBox5.Text);
                SelectCommand.Parameters.AddWithValue("@글쓴이", textBox4.Text);
                SelectCommand.Parameters.AddWithValue("@출판사", textBox3.Text);
                SelectCommand.Parameters.AddWithValue("@가격", textBox8.Text);
                SelectCommand.Parameters.AddWithValue("@구매날짜", textBox7.Text);
                SelectCommand.Parameters.AddWithValue("@배송예상날짜", textBox1.Text);
                SelectCommand.Parameters.AddWithValue("@배송완료날짜", textBox2.Text);
                SelectCommand.Parameters.AddWithValue("@현황", "접수");
                SelectCommand.Parameters.AddWithValue("@신청번호", textBox6.Text);

                myReader = SelectCommand.ExecuteReader();
                MessageBox.Show("접수처리 되었습니다.");

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

        public void LoadData()
        {
            MySqlConnection con = new MySqlConnection(myConnection);
            MySqlCommand cmd_db = new MySqlCommand("SELECT 신청번호, 도서명, 글쓴이, 출판사, 가격, 구매날짜, 배송예상날짜, 배송완료날짜, 현황  FROM squad_library.managerrequest;", con);

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

        private void button1_Click(object sender, EventArgs e)
        {
            string Query = "delete from squad_library.managerrequest where 신청번호 ='" + this.textBox6.Text + "'; ALTER TABLE squad_library.managerrequest AUTO_INCREMENT=1; SET @COUNT = 0; UPDATE squad_library.managerrequest SET 신청번호 = @COUNT:= @COUNT + 1; ";
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

    }
}
