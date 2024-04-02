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
    public partial class UserBookSearch : Form
    {
        static string myConnection = "Server=localhost;Database=squad_library;username=root;password=1234;";

        public UserMainHomeNotLogin uh1 = new UserMainHomeNotLogin();

        public UserBookSearch()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserSearchDetails us2 = new UserSearchDetails();
            

            us2.textBox10.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();  //도서명
            us2.textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();  //글쓴이
            us2.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();  //도서번호
            us2.textBox9.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();  //출판일
            us2.textBox8.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();  //출판사
            us2.comboBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();  //도서상태
            us2.comboBox1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();  //대출여부
            us2.textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();  //도서가격
            us2.textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();  //페이지
            us2.textBox3.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();  //줄거리
            us2.ShowDialog();

            if (us2.label1.Text == "서울의 맛집")
            {
                us2.pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\서울의 맛집.jpg");
                us2.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (us2.label1.Text == "리얼 제주")
            {
                us2.pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\리얼 제주.jpg");
                us2.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (us2.label1.Text == "선량한 차별주의자")
            {
                us2.pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\선량한 차별주의자.jpg");
                us2.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (us2.label1.Text == "떨림과 울림")
            {
                us2.pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\떨림과 울림.jpg");
                us2.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (us2.label1.Text == "나의 문화유산답가기 365일")
            {
                us2.pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\나의 문화유산 답사기.jpg");
                us2.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (us2.label1.Text == "장면들")
            {
                us2.pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\장면들.jpg");
                us2.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (us2.label1.Text == "7일,168시간")
            {
                us2.pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\7일, 168시간.jpg");
                us2.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (us2.label1.Text == "직장인들을 위한 실무 엑셀")
            {
                us2.pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\직장인들을 위한 실무 엑셀.jpg");
                us2.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (us2.label1.Text == "디지털이다")
            {
                us2.pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\디지털이다.jpg");
                us2.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (us2.label1.Text == "이상한 정상가족")
            {
                us2.pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\이사한 정상가족.jpg");
                us2.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (us2.label1.Text == "노예의 길")
            {
                us2.pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\노예의 길.jpg");
                us2.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (us2.label1.Text == "전쟁의 기술")
            {
                us2.pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\전쟁의 기술.jpg");
                us2.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                us2.pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\Do it! BERT와 GPT로 배우는 자연어 처리.jpg");
                us2.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void User_Search1_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234");  //DB 주소 가져오기
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부,메모  FROM squad_library.search1", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

            connection.Open();  // DB 연결 시작

            DataSet ds = new DataSet();  //DataSet에 데이터 넣음
            adapter.Fill(ds, "search1");  //search1 테이블 채우기
            dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기

            pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\서울의 맛집.jpg");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            connection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label5.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[0].Value.ToString();

            if (label5.Text == "서울의 맛집")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\서울의 맛집.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label5.Text == "리얼 제주")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\리얼 제주.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label5.Text == "선량한 차별주의자")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\선량한 차별주의자.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label5.Text == "떨림과 울림")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\떨림과 울림.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label5.Text == "나의 문화유산답가기 365일")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\나의 문화유산 답사기.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label5.Text == "장면들")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\장면들.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label5.Text == "7일,168시간")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\7일, 168시간.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label5.Text == "직장인들을 위한 실무 엑셀")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\직장인들을 위한 실무 엑셀.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label5.Text == "디지털이다")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\디지털이다.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label5.Text == "이상한 정상가족")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\이사한 정상가족.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label5.Text == "노예의 길")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\노예의 길.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (label5.Text == "전쟁의 기술")
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\전쟁의 기술.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\Do it! BERT와 GPT로 배우는 자연어 처리.jpg");
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
            MySqlCommand cmd_db = new MySqlCommand("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부,메모 FROM squad_library.search1;", con);

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
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234");  //DB 주소 가져오기
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부,메모  FROM squad_library.search1 where 도서명 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                connection.Open();  // DB 연결 시작

                DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                adapter.Fill(ds, "search1");  //search1 테이블 채우기
                dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기
            }

            else if (this.comboBox1.Text == "글쓴이")
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234");  //DB 주소 가져오기
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부,메모  FROM squad_library.search1 where 글쓴이 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                connection.Open();  // DB 연결 시작

                DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                adapter.Fill(ds, "search1");  //search1 테이블 채우기
                dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기
            }

            else
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234");  //DB 주소 가져오기
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부,메모  FROM squad_library.search1 where 출판사 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                connection.Open();  // DB 연결 시작

                DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                adapter.Fill(ds, "search1");  //search1 테이블 채우기
                dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserMypage mpg = new UserMypage();
            mpg.Show();
        }
    }
}
