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
    public partial class bookmanagement : UserControl
    {
        public bookmanagement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myconnect = "datasource = localhost; port = 3306; username=root; password=qkrwltn5130!;";
            string query = "insert into squad_library.search1(도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부, 메모)" +
                "value('" + this.textBox1.Text + "', '" + this.textBox7.Text + "', '" + this.textBox2.Text + "', '" + this.textBox4.Text + "', '" + this.textBox3.Text + "', '" + this.textBox6.Text + "', '" + this.textBox5.Text + "', " +
                "'" + this.comboBox1.Text + "', '" + this.comboBox2.Text + "', '" + this.textBox11.Text + "'); ";


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

        private void bookmanagement_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");
                MySqlDataAdapter adapter = new MySqlDataAdapter("select 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부, 메모 from squad_library.search1", connection);

                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "search1");
                dataGridView1.DataSource = ds.Tables["search1"];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadData()
        {
            string sql = "Server=localhost;Port=3306;username=root;password=qkrwltn5130!";
            MySqlConnection con = new MySqlConnection(sql);
            MySqlCommand cmd_db = new MySqlCommand("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부, 메모  FROM squad_library.search1;", con);

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

            //텍스트 박스 초기화
            textBox1.Text = "";
            textBox7.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox11.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[0].Value.ToString();
            textBox7.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[6].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[7].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[8].Value.ToString();
            textBox11.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[9].Value.ToString();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=qkrwltn5130!";
            if (textBox7.Text == "")
            {
                MessageBox.Show("삭제 할 항목을 찾지 못했습니다.");
            }
            else
            {
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "도서명")  // if문으로 콤보박스 중 하나의 키워드를 적는다
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부, 메모  FROM squad_library.search1 where 도서명 = '" + this.textBox12.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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

            else if (comboBox3.Text == "도서 번호")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부, 메모  FROM squad_library.search1 where 책번호 = '" + this.textBox12.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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

            else if (comboBox3.Text == "글쓴이")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부,메모  FROM squad_library.search1 where 글쓴이 = '" + this.textBox12.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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

            else if (comboBox3.Text == "출판사")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부, 메모  FROM squad_library.search1 where 출판사 = '" + this.textBox12.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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

            else if (comboBox3.Text == "도서 상태")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부, 메모  FROM squad_library.search1 where 도서상태 = '" + this.textBox12.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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

            else if (comboBox3.Text == "대출 여부")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부, 메모  FROM squad_library.search1 where 대출여부 = '" + this.textBox12.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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

        private void button5_Click(object sender, EventArgs e)
        {
            LoadData();  // 새로고침
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string myconnect = "datasource = localhost; port = 3306; username=root; password=qkrwltn5130!;";
            string query = "INSERT INTO squad_library.user_recommend value('" + this.textBox7.Text + "', '" + this.textBox1.Text + "', '" + this.textBox2.Text + "', '" + this.textBox4.Text + "', '" + this.textBox6.Text + "');";


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

        private void button6_Click(object sender, EventArgs e)
        {
            string myconnect = "datasource = localhost; port = 3306; username=root; password=qkrwltn5130!;";
            string query = "INSERT INTO squad_library.newbook value('" + this.textBox7.Text + "', '" + this.textBox1.Text + "', '" + this.textBox2.Text + "', '" + this.textBox4.Text + "', '" + this.textBox6.Text + "');";


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
    }
}
