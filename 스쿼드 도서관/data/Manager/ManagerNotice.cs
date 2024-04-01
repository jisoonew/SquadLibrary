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

namespace 스쿼드_도서관.data
{
    public partial class ManagerNotice : UserControl
    {
        public ManagerNotice()
        {
            InitializeComponent();
        }

        private void managernotice_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234");
                MySqlDataAdapter adap = new MySqlDataAdapter("select * from squad_library.manager_notice", conn);

                conn.Open();

                DataSet ds = new DataSet();
                adap.Fill(ds, "manager_notice");
                dataGridView1.DataSource = ds.Tables["manager_notice"];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("공지사항 DB 연결에 실패하였습니다.");
            }
        }

        public void LoadData()
        {
            MySqlConnection conn = new MySqlConnection("datasource = localhost; port = 3306; username = root; password=1234");
            MySqlDataAdapter adap = new MySqlDataAdapter("select * from squad_library.manager_notice", conn);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM squad_library.manager_notice;", conn);

            try
            {
                adap.SelectCommand = cmd;
                DataTable datatable = new DataTable();
                adap.Fill(datatable);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = datatable;
                dataGridView1.DataSource = bSource;
                adap.Update(datatable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("입력된 정보가 없어 검색할 수 없습니다.");
            }

            if (comboBox1.Text == "번호")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *  FROM squad_library.manager_notice where 번호 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    connection.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "manager_notice");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["manager_notice"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (comboBox1.Text == "제목")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *  FROM squad_library.manager_notice where 제목 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    connection.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "manager_notice");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["manager_notice"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource = localhost; port = 3306; username = root; password=1234");
            String sqlQuery = "insert into squad_library.manager_notice(제목, 내용)" + "values('" + textBox3.Text + "','" + textBox2.Text + "')";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            MySqlDataReader Rd;

            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("공지 사항이 등록되었습니다.");
            }

            else
            {
                MessageBox.Show("공지 사항 등록에 실패했습니다.");
            }

            conn.Close();

            //UpdateUser();
            LoadData();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            string myConnection = "datasource=localhost;port=3306;username=root;password=1234";

            try
            {

                string Query = "update squad_library.manager_notice set " + "제목 = '" + this.textBox3.Text + "', 내용 = '" + this.textBox2.Text + "' where 번호 = '"+this.textBox4.Text+"'";


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

            textBox4.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=1234";
            if (textBox3.Text == "")
            {
                MessageBox.Show("선택된 공지사항이 없습니다.");
            }

            else
            {
                //delete를 통해 DB로 삭제된 데이터 전송 - 기본키 기준으로 삭제위치 탐색
                string Query = "delete from squad_library.manager_notice where 번호='" + this.textBox4.Text + "';";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                try
                {
                    conDataBase.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("선택한 공지 사항이 삭제되었습니다.");

                    while (myReader.Read())
                    {

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                textBox2.Text = "";
                textBox3.Text = "";

                LoadData();
            }
        }
    }
}
