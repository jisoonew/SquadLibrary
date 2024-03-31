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
    public partial class User_Homepage1 : Form
    {
        public User_Homepage1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User_login1 form3 = new User_login1();
            form3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User_login2 form6 = new User_login2();
            form6.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mypage form4 = new Mypage();
            form4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            User_Search3 us3 = new User_Search3();

            if (this.textBox1.Text == "" && this.comboBox1.Text == "" || this.comboBox1.Text == "도서명" && this.textBox1.Text == "" || this.comboBox1.Text == "글쓴이" && this.textBox1.Text == "")
            {
                MessageBox.Show("입력되지 않았습니다!");
            }

            else if (this.comboBox1.Text == "도서명")
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234");  //DB 주소 가져오기
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 책번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부,메모  FROM squad_library.search1 where 도서명 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                connection.Open();  // DB 연결 시작

                DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                adapter.Fill(ds, "search1");  //search1 테이블 채우기
                us3.dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기

                us3.Show();
            }

            else if (this.comboBox1.Text == "글쓴이")
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234");  //DB 주소 가져오기
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 책번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부,메모  FROM squad_library.search1 where 글쓴이 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                connection.Open();  // DB 연결 시작

                DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                adapter.Fill(ds, "search1");  //search1 테이블 채우기
                us3.dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기

                us3.Show();
            }

            else
            {
                MessageBox.Show("입력되지 않았습니다!");
            }
        }
        

        private void 전체도서목록ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            User_Search3 us3 = new User_Search3();
            us3.Show();

            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234");  //DB 주소 가져오기
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 책번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부,메모  FROM squad_library.search1", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

            connection.Open();  // DB 연결 시작

            DataSet ds = new DataSet();  //DataSet에 데이터 넣음
            adapter.Fill(ds, "search1");  //search1 테이블 채우기
            us3.dataGridView1.DataSource = ds.Tables["search1"];  // 테이블 보이기
        }

        private void 추천도서목록ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            user_recommend ur = new user_recommend();
            ur.Show();

        }

        private void 신착도서목록ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            usernewbook un = new usernewbook();
            un.Show();
        }

        private void 도서관연혁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            libraryguide01 lg = new libraryguide01();
            lg.Show();
        }

        private void 직원소개ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            libraryguide02 lg2 = new libraryguide02();
            lg2.Show();
        }

        private void 개관안내ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            userlibraryuse01 uly = new userlibraryuse01();
            uly.Show();
        }

        private void 대출반납연체안내ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            userlibraryuse02 uly2 = new userlibraryuse02();
            uly2.Show();
        }

        private void 이용자준수사항ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            user_compliance01 uc = new user_compliance01();
            uc.Show();
        }

        private void 공지사항ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            usernotice01 un = new usernotice01();
            un.Show();
        }

        private void 묻고답하기ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            userQA01 uq = new userQA01();
            uq.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void User_Homepage1_Load(object sender, EventArgs e)
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
        }
    }
}
