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
    public partial class bookcall : UserControl
    {
        static string conString = "Server=localhost;Database=practice;username=root;password=qkrwltn5130!";

        public bookcall()
        {
            InitializeComponent();
        }

        private void bookcall_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(conString);
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 글쓴이, 출판사, 도서갯수, 도서상태, 대출여부, 도서번호 FROM squad_library.search1", connection);

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
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string myConnection = "datasource=localhost;port=3306;username=root;password=qkrwltn5130!";

            try
            {

                string Query = "update squad_library.search1 set " + "도서명 = '" + this.textBox1.Text + "', 글쓴이 = '" + this.textBox2.Text + "', 출판사 = '" + this.textBox3.Text + "', 도서상태 = '" + this.comboBox1.Text + "', 대출여부 = '" + this.comboBox2.Text + "' where 도서번호 = '" + this.textBox7.Text + "'";


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

        public void LoadData()
        {
            string sql = "Server=localhost;Port=3306;username=root;password=qkrwltn5130!";
            MySqlConnection con = new MySqlConnection(sql);
            MySqlCommand cmd_db = new MySqlCommand("SELECT 도서명, 글쓴이, 출판사, 도서갯수, 도서상태, 대출여부, 도서번호  FROM squad_library.search1;", con);

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

            //텍스트 박스 초기화
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox7.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=qkrwltn5130!";
                //delete를 통해 DB로 삭제된 데이터 전송 - 기본키 기준으로 삭제위치 탐색
                string Query = "delete from squad_library.search1 where 도서번호 ='" + this.textBox7.Text + "';";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                try
                {
                    conDataBase.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("도서를 삭제했습니다.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                LoadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string myconnect = "datasource = localhost; port = 3306; username=root; password=qkrwltn5130!";
            string query = "update squad_library.search1 set " + "도서명 = '" + this.textBox1.Text + "', 글쓴이 = '" + this.textBox2.Text + "', 출판사 = '" + this.textBox3.Text + "', 도서상태 = '" + this.comboBox1.Text + "', 대출여부 = '" + this.comboBox2.Text + "' where 도서번호 = '" + this.textBox7.Text + "'";

            MySqlConnection myconn = new MySqlConnection(myconnect);

            MySqlCommand command = new MySqlCommand(query, myconn);

            MySqlDataReader myReader;

            try
            {
                myconn.Open();

                myReader = command.ExecuteReader();
                MessageBox.Show("저장되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "도서명")  // if문으로 콤보박스 중 하나의 키워드를 적는다
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 글쓴이, 출판사, 도서갯수, 도서상태, 대출여부, 도서번호  FROM squad_library.search1 where 도서명 = '" + this.textBox5.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    connection.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "search1");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (comboBox3.Text == "글쓴이")  // if문으로 콤보박스 중 하나의 키워드를 적는다
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 글쓴이, 출판사, 도서갯수, 도서상태, 대출여부, 도서번호  FROM squad_library.search1 where 글쓴이 = '" + this.textBox5.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    connection.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "search1");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (comboBox3.Text == "출판사")  // if문으로 콤보박스 중 하나의 키워드를 적는다
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 글쓴이, 출판사, 도서갯수, 도서상태, 대출여부, 도서번호  FROM squad_library.search1 where 출판사 = '" + this.textBox5.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    connection.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "search1");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (comboBox3.Text == "도서 갯수")  // if문으로 콤보박스 중 하나의 키워드를 적는다
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 글쓴이, 출판사, 도서갯수, 도서상태, 대출여부, 도서번호  FROM squad_library.search1 where 도서갯수 = '" + this.textBox5.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    connection.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "search1");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (comboBox3.Text == "도서 상태")  // if문으로 콤보박스 중 하나의 키워드를 적는다
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 글쓴이, 출판사, 도서갯수, 도서상태, 대출여부, 도서번호  FROM squad_library.search1 where 도서상태 = '" + this.textBox5.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    connection.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "search1");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (comboBox3.Text == "도서 여부")  // if문으로 콤보박스 중 하나의 키워드를 적는다
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 글쓴이, 출판사, 도서갯수, 도서상태, 대출여부, 도서번호  FROM squad_library.search1 where 도서여부 = '" + this.textBox5.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    connection.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "search1");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (comboBox3.Text == "도서 번호")  // if문으로 콤보박스 중 하나의 키워드를 적는다
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 글쓴이, 출판사, 도서갯수, 도서상태, 대출여부, 도서번호  FROM squad_library.search1 where 책번호 = '" + this.textBox5.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    connection.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "search1");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else
            {
                MessageBox.Show("검색 결과를 찾지 못했습니다.");
            }

        }
    }
}
