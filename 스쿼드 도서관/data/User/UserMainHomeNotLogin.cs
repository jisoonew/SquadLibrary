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
    public partial class UserMainHomeNotLogin : Form
    {
        public UserMainHomeNotLogin()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234");  //DB 주소 가져오기

        private void button4_Click(object sender, EventArgs e)
        {
            UserAllSearch us3 = new UserAllSearch();

            if (this.textBox1.Text == "" && this.comboBox1.Text == "" || this.comboBox1.Text == "도서명" && this.textBox1.Text == "" || this.comboBox1.Text == "글쓴이" && this.textBox1.Text == "")
            {
                MessageBox.Show("입력되지 않았습니다!");
            }

            else if (this.comboBox1.Text == "도서명")
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 책번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부,메모  FROM squad_library.search1 where 도서명 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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
                    us3.dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기
                    us3.pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\" + this.textBox1.Text + ".jpg");
                    us3.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    us3.Show();
                }
            }

            else if (this.comboBox1.Text == "글쓴이")
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 책번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부,메모  FROM squad_library.search1 where 글쓴이 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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
                    us3.dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기
                    us3.pictureBox2.Load(@"C:\Users\pjsu2\OneDrive\바탕 화면\스쿼드 도서 이미지\" + this.textBox1.Text + ".jpg");
                    us3.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    us3.Show();
                }
            }

            else
            {
                MessageBox.Show("입력되지 않았습니다!");
            }
        }
        

        private void 전체도서목록ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UserAllSearch us3 = new UserAllSearch();
            us3.Show();

            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 책번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부,메모  FROM squad_library.search1", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

            connection.Open();  // DB 연결 시작

            DataSet ds = new DataSet();  //DataSet에 데이터 넣음
            adapter.Fill(ds, "search1");  //search1 테이블 채우기
            us3.dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기
        }

        private void User_Homepage1_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 제목, 내용 FROM squad_library.question1", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

            connection.Open();  // DB 연결 시작

            DataSet ds = new DataSet();  //DataSet에 데이터 넣음
            adapter.Fill(ds, "question1");  //search1 테이블 채우기
            dataGridView2.DataSource = ds.Tables["question1"];  // 테이블 보이기


            MySqlDataAdapter adapter1 = new MySqlDataAdapter("SELECT 제목, 내용 FROM squad_library.manager_notice", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

            DataSet ds1 = new DataSet();  //DataSet에 데이터 넣음
            adapter1.Fill(ds1, "manager_notice");  //search1 테이블 채우기
            dataGridView1.DataSource = ds1.Tables["manager_notice"];  // 테이블 보이기
        }

        private void 추천도서목록ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UserRecommend ur = new UserRecommend();
            ur.Show();

        }

        private void 신착도서목록ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UserNewBook un = new UserNewBook();
            un.Show();
        }

        private void 도서관연혁ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            UserJoin form3 = new UserJoin();
            form3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserLogin form6 = new UserLogin();
            form6.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserMypage form4 = new UserMypage();
            form4.Show();
        }
    }
}
