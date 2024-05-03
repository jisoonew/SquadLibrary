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
    public partial class ManagerBookInformation : UserControl
    {
        static string conString = "Server=localhost;Database=squad_library;username=root;password=1234";
        MySqlConnection connection = new MySqlConnection(conString);  //DB 주소 가져오기

        public ManagerBookInformation()
        {
            InitializeComponent();
        }

        private void bookinformation_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 글쓴이, 출판사, 도서상태, 도서번호 FROM squad_library.search1", connection);

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "도서명")  // if문으로 콤보박스 중 하나의 키워드를 적는다
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서번호, 도서명, 글쓴이, 출판사, 도서상태  FROM squad_library.search1 where 도서명 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서번호, 도서명, 글쓴이, 출판사, 도서상태  FROM squad_library.search1 where 글쓴이 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서번호, 도서명, 글쓴이, 출판사, 도서상태  FROM squad_library.search1 where 출판사 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서번호, 도서명, 글쓴이, 출판사, 도서상태  FROM squad_library.search1 where 도서상태 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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
            else if(comboBox3.Text == "대출 여부")
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서번호, 도서명, 글쓴이, 출판사, 도서상태  FROM squad_library.search1 where 대출여부 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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
            else if (comboBox3.Text == "책번호")
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서번호, 도서명, 글쓴이, 출판사, 도서상태  FROM squad_library.search1 where 도서번호 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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
        }
    }
}
