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
    public partial class User_Search3 : Form
    {
        static string myConnection = "Server=localhost;Database=squad_library;username=root;password=qkrwltn5130!;";

        public User_Search3()
        {
            InitializeComponent();
        }

        private void User_Search3_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            User_Search4 us4 = new User_Search4();

            us4.textBox10.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();  //도서명
            us4.textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();  //글쓴이
            us4.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();  //도서번호
            us4.textBox9.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();  //출판일
            us4.textBox8.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();  //출판사
            us4.comboBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();  //도서상태
            us4.comboBox1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();  //대출여부
            us4.textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();  //도서가격
            us4.textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();  //페이지
            us4.textBox3.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();  //줄거리
            us4.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label5.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[0].Value.ToString();

            if (label5.Text == "서울의 맛집")
            {
                pictureBox2.Load(@"C:/Users/pjsu2/OneDrive/바탕 화면/융합 소프트웨어 과제/1234455.png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label5.Text == "리얼 제주")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\융합 소프트웨어 과제\영화 포스터\마션.jfif");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\융합 소프트웨어 과제\영화 포스터\킹덤.png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            MySqlConnection con = new MySqlConnection(myConnection);
            MySqlCommand cmd_db = new MySqlCommand("SELECT 도서명, 책번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부,메모 FROM squad_library.search1;", con);

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
            if (this.comboBox1.Text == "도서명")
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");  //DB 주소 가져오기
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 책번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부,메모  FROM squad_library.search1 where 도서명 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                connection.Open();  // DB 연결 시작

                DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                adapter.Fill(ds, "search1");  //search1 테이블 채우기
                dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기
            }

            else if (this.comboBox1.Text == "글쓴이")
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");  //DB 주소 가져오기
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 책번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부,메모  FROM squad_library.search1 where 글쓴이 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                connection.Open();  // DB 연결 시작

                DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                adapter.Fill(ds, "search1");  //search1 테이블 채우기
                dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기
            }

            else
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");  //DB 주소 가져오기
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 책번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부,메모  FROM squad_library.search1 where 출판사 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                connection.Open();  // DB 연결 시작

                DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                adapter.Fill(ds, "search1");  //search1 테이블 채우기
                dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기
            }
        }
    }
}
