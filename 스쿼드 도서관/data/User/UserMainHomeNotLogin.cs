﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            // 추천 도서

            string query = "SELECT search.책표지 FROM squad_library.recommend reco join squad_library.search1 search on reco.도서번호 = search.도서번호 ORDER BY reco.등록 DESC LIMIT 3;";

            MySqlCommand command = new MySqlCommand(query, connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                int pictureBoxIndex = 3; // pictureBox3부터 시작
                while (reader.Read() && pictureBoxIndex >= 3 && pictureBoxIndex <= 5)
                {
                    byte[] imageData = (byte[])reader["책표지"];

                    PictureBox pictureBox = (PictureBox)this.Controls.Find("pictureBox" + pictureBoxIndex, true)[0];
                    DisplayImageFromDatabase(imageData, pictureBox);

                    pictureBoxIndex++;
                }
            }

            string queryLabel = "SELECT search.도서명 FROM squad_library.recommend reco JOIN squad_library.search1 search ON reco.도서번호 = search.도서번호 ORDER BY reco.등록 DESC LIMIT 3";
            MySqlCommand commandLabel = new MySqlCommand(queryLabel, connection);

            using (MySqlDataReader readerLabel = commandLabel.ExecuteReader())
            {
                int labelIndex = 5; // label5부터 시작

                while (readerLabel.Read() && labelIndex <= 7)
                {
                    string bookName = readerLabel["도서명"].ToString();

                    switch (labelIndex)
                    {
                        case 5:
                            label5.Text = bookName;
                            break;
                        case 6:
                            label6.Text = bookName;
                            break;
                        case 7:
                            label7.Text = bookName;
                            break;
                    }

                    labelIndex++;
                }
            }

            // 신착 도서
            string newBookQuery = "SELECT search.책표지 FROM squad_library.newbook reco join squad_library.search1 search on reco.도서번호 = search.도서번호 ORDER BY reco.등록 DESC LIMIT 3;";

            MySqlCommand newBookCommand = new MySqlCommand(newBookQuery, connection);

            using (MySqlDataReader reader2 = newBookCommand.ExecuteReader())
            {
                int pictureBoxIndex2 = 6;
                while (reader2.Read() && pictureBoxIndex2 <= 8)
                {
                    byte[] imageData2 = (byte[])reader2["책표지"];

                    PictureBox pictureBox2 = (PictureBox)this.Controls.Find("pictureBox" + pictureBoxIndex2, true)[0];
                    DisplayImageFromDatabase(imageData2, pictureBox2);

                    pictureBoxIndex2++;
                }

            }

            string queryLabel2 = "SELECT search.도서명 FROM squad_library.newbook reco JOIN squad_library.search1 search ON reco.도서번호 = search.도서번호 ORDER BY reco.등록 DESC LIMIT 3";
            MySqlCommand commandLabel2 = new MySqlCommand(queryLabel2, connection);

            using (MySqlDataReader readerLabe2 = commandLabel2.ExecuteReader())
            {
                int labelIndex2 = 8; // label8부터 시작

                while (readerLabe2.Read() && labelIndex2 <= 10)
                {
                    string bookName2 = readerLabe2["도서명"].ToString();

                    switch (labelIndex2)
                    {
                        case 8:
                            label8.Text = bookName2;
                            break;
                        case 9:
                            label9.Text = bookName2;
                            break;
                        case 10:
                            label10.Text = bookName2;
                            break;
                    }

                    labelIndex2++;
                }
            }
        }

        // 이미지 데이터를 PictureBox에 출력하는 함수
        private void DisplayImageFromDatabase(byte[] imageData, PictureBox pictureBox)
        {
            if (imageData != null && imageData.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pictureBox.Image = Image.FromStream(ms);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                // 이미지 데이터가 없는 경우 기본 이미지를 설정할 수 있습니다.
                pictureBox.Image = null;
            }
        }

        private void DisplayBookNamesFromDatabase(MySqlConnection connection, Label[] labels)
        {
            try
            {
                string query = "SELECT search.도서명 FROM squad_library.recommend reco JOIN squad_library.search1 search ON reco.도서번호 = search.도서번호 ORDER BY reco.등록 DESC LIMIT 3";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    int labelIndex = 0;
                    while (reader.Read() && labelIndex < labels.Length)
                    {
                        string bookName = reader["도서명"].ToString();
                        labels[labelIndex].Text = bookName;

                        labelIndex++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 발생: " + ex.Message);
            }
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
