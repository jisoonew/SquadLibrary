﻿using System;
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
    public partial class UserMainHomeLogin : Form
    {
        public UserMainHomeNotLogin uh1 = new UserMainHomeNotLogin();

        public UserMainHomeLogin()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserMypage mpg = new UserMypage();
            mpg.Show();
        }

        // 도서 검색 기능
        private void button4_Click(object sender, EventArgs e)
        {
            UserBookSearch us1 = new UserBookSearch();

            if (this.textBox1.Text == "" && this.comboBox1.Text == "" || this.comboBox1.Text == "도서명" && this.textBox1.Text == "" || this.comboBox1.Text == "글쓴이" && this.textBox1.Text == "")
            {
                MessageBox.Show("입력되지 않았습니다!");
            }

            if (this.comboBox1.Text == "도서명")
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234");  //DB 주소 가져오기
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부,메모 FROM squad_library.search1 where 도서명 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                connection.Open();  // DB 연결 시작

                DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                adapter.Fill(ds, "search1");  //search1 테이블 채우기

                // 데이터가 없는 경우 처리
                if (ds.Tables["search1"].Rows.Count == 0)
                {
                    MessageBox.Show("검색 결과가 없습니다."); // 콘솔에 메시지 출력
                }
                else
                {
                    us1.dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기
                    us1.pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\" + this.textBox1.Text + ".jpg");
                    us1.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    us1.Show();
                }
            }

            else if (this.comboBox1.Text == "글쓴이")
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234");  //DB 주소 가져오기
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부,메모  FROM squad_library.search1 where 글쓴이 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                connection.Open();  // DB 연결 시작

                DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                adapter.Fill(ds, "search1");  //search1 테이블 채우기

                // 데이터가 없는 경우 처리
                if (ds.Tables["search1"].Rows.Count == 0)
                {
                    MessageBox.Show("검색 결과가 없습니다."); // 콘솔에 메시지 출력
                }
                else
                {
                    us1.dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기
                    us1.pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\" + this.textBox1.Text + ".jpg");
                    us1.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    us1.Show();
                }
            }
            else if (this.textBox1.Text == "" && this.comboBox1.Text == "" || this.comboBox1.Text == "도서명" && this.textBox1.Text == "" || this.comboBox1.Text == "글쓴이" && this.textBox1.Text == "")
            {
                MessageBox.Show("입력되지 않았습니다!");
            }

            else
            {
                MessageBox.Show("입력되지 않았습니다!");
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void 추천도서목록ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UserRecommend ur = new UserRecommend();
            ur.Show();
        }

        private void 전체도서목록ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UserBookSearch us1 = new UserBookSearch();
            us1.Show();
        }

        private void 신착도서목록ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UserNewBook un = new UserNewBook();
            un.Show();
        }

        private void 도서관연혁ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LibraryHistory lg = new LibraryHistory();
            lg.Show();
        }

        private void 직원소개ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LibraryIntroduction lg2 = new LibraryIntroduction();
            lg2.Show();
        }

        private void 개관안내ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UserLibraryUseTime uly = new UserLibraryUseTime();
            uly.Show();
        }

        private void 대출반납연체안내ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UserLibraryUse uly2 = new UserLibraryUse();
            uly2.Show();
        }

        private void 이용자준수사항ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UserCaution uc = new UserCaution();
            uc.Show();
        }

        private void 공지사항ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UserAnnouncement un = new UserAnnouncement();
            un.Show();
        }

        private void 묻고답하기ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UserQAView uq = new UserQAView();
            uq.Show();
        }

        private void User_Homepage2_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234");  //DB 주소 가져오기
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 제목, 내용 FROM squad_library.question1", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

            connection.Open();  // DB 연결 시작

            DataSet ds = new DataSet();  //DataSet에 데이터 넣음
            adapter.Fill(ds, "question1");  //search1 테이블 채우기
            dataGridView2.DataSource = ds.Tables["question1"];  // 테이블 보이기


            MySqlDataAdapter adapter1 = new MySqlDataAdapter("SELECT 제목, 내용 FROM squad_library.manager_notice", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

            DataSet ds1 = new DataSet();  //DataSet에 데이터 넣음
            adapter1.Fill(ds1, "manager_notice");  //search1 테이블 채우기
            dataGridView1.DataSource = ds1.Tables["manager_notice"];  // 테이블 보이기


            pictureBox3.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\사이코패스는 일상의 그늘에 숨어지낸다.jpg");
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox4.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\리얼 제주.jpg");
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox5.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\엔드 오브 타임.jpg");
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;


            pictureBox8.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\장면들.jpg");
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox7.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\떨림과 울림.jpg");
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox6.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\서울의 맛집.jpg");
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserMainHomeNotLogin uh1 = new UserMainHomeNotLogin();
            uh1.Show();
        }
    }
}
