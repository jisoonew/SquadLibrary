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
    public partial class ManagerBookOverdue : UserControl
    {
        public ManagerBookOverdue()
        {
            InitializeComponent();
        }


        MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234");

        private void bookoverdue_Load(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToShortDateString(); //현재 날짜

            string datea = DateTime.Now.AddDays(14).ToShortDateString();

            DateTime t1 = DateTime.Parse(date);

            DateTime t2 = DateTime.Parse(datea);

            TimeSpan sum = t1 - t2;

            int fnsum = sum.Days;

            if (fnsum <= 0)
            {
                textBox18.Text = "";
            }
            else
            {
                textBox18.Text = fnsum.ToString();
            }

            ManagerBookReturn br = new ManagerBookReturn();

            try // 대출 회원 정보 DB 연결 (bookrent_user)
            {
                MySqlDataAdapter adap = new MySqlDataAdapter("select user.회원번호, user.회원명, user.등급, user.회원상태, user.전화번호, user.주소, user.메모 from squad_library.bookrent rent join squad_library.user user on rent.회원번호 = user.회원번호 WHERE date(rent.반납일) < date(now());", conn);

                conn.Open();

                DataSet ds = new DataSet();
                adap.Fill(ds, "bookrent_user");
                dataGridView1.DataSource = ds.Tables["bookrent_user"];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try // 대출 회원 정보 DB 연결 (bookrent_user)
            {
                MySqlDataAdapter adap = new MySqlDataAdapter("select rent.도서번호, search.도서명, search.글쓴이, search.출판사, search.도서상태, rent.대출일, rent.반납일, rent.메모 from squad_library.bookrent rent join squad_library.search1 search on rent.도서번호 = search.도서번호", conn);

                conn.Open();

                DataSet ds = new DataSet();
                adap.Fill(ds, "bookrent_user");
                //dataGridView2.DataSource = ds.Tables["bookrent_user"];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try // alluser 연동
            {
                MySqlDataAdapter adap = new MySqlDataAdapter("select * from squad_library.user", conn);

                conn.Open();

                DataSet ds = new DataSet();
                //adap.Fill(ds, "alluser");
                //dataGridView1.DataSource = ds.Tables["alluser"];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("회원정보 DB연결에 실패하였습니다. 다시 시도해주세요!");
            }

            try  // 도서 정보 DB 연결
            {
                MySqlDataAdapter adap = new MySqlDataAdapter("select 도서번호,도서명, 글쓴이, 출판사, 도서상태, 대출여부, 대출일, 반납일, 메모 from squad_library.search1", conn);

                conn.Open();

                DataSet ds = new DataSet();
                //adap.Fill(ds, "search1");
                //dataGridView2.DataSource = ds.Tables["search1"];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("도서정보 DB 연결에 실패하였습니다.");
            }
            }


        
private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {   
                MySqlDataAdapter userAdap = new MySqlDataAdapter("select user.회원번호, user.회원명, user.등급, user.회원상태, user.전화번호, user.주소, user.메모 from squad_library.bookrent rent join squad_library.user user on rent.회원번호 = user.회원번호 WHERE date(rent.반납일) < date(now());", conn);

                DataSet userDs = new DataSet();

                conn.Open();

                userAdap.Fill(userDs, "userDataset");
                textBox19.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); // 회원번호
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); // 회원명
                comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(); // 등급
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(); // 회원상태
                // textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(); // 대출가능

                MySqlCommand command = new MySqlCommand("select count(*) from squad_library.bookrent where 회원번호 = '" + textBox19.Text + "'", conn);
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {

                    // 회원이 대출한 도서가 있다면
                    if (dataReader.Read())
                    {
                        try
                        {
                            // 쿼리 실행 및 결과값 받아오기
                            int count = Convert.ToInt32(dataReader[0]);

                            // 회원은 최대 5권을 대출 가능
                            textBox4.Text = (5 - count).ToString(); // 결과값을 문자열로 변환하여 TextBox에 할당
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else
                    {
                        textBox4.Text = "0";
                    }
                }

                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(); // 전화번호
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(); // 주소
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(); // 메모

                MySqlDataAdapter adap = new MySqlDataAdapter("select rent.도서번호, search.도서명, search.글쓴이, search.출판사, search.도서상태, rent.대출일, rent.반납일, rent.메모 from squad_library.bookrent rent join squad_library.search1 search on rent.도서번호 = search.도서번호 WHERE date(rent.반납일) < date(now()) and rent.회원번호 = '" + textBox19.Text + "';", conn);
                DataSet ds = new DataSet();
                adap.Fill(ds, "bookrent_user");
                dataGridView2.DataSource = ds.Tables["bookrent_user"];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DateTime loanDate; // 반납일
                DateTime returnDate; // 현재

                if (e.RowIndex >= 0) // 클릭된 셀이 헤더가 아닌 경우에만 실행
                {
                    DataGridViewRow row = dataGridView2.Rows[e.RowIndex]; // 클릭된 행 가져오기
                    textBox13.Text = row.Cells["도서번호"].Value.ToString(); // 도서번호 텍스트 상자에 값을 설정
                    textBox14.Text = row.Cells["도서명"].Value.ToString(); // 도서명 텍스트 상자에 값을 설정
                    textBox5.Text = row.Cells["글쓴이"].Value.ToString(); // 글쓴이 텍스트 상자에 값을 설정
                    textBox16.Text = row.Cells["출판사"].Value.ToString(); // 출판사 텍스트 상자에 값을 설정
                    comboBox4.Text = row.Cells["도서상태"].Value.ToString(); // 도서상태 콤보 상자에 값을 설정
                    comboBox5.Text = "연체"; // 연체 콤보 상자에 기본값으로 설정
                    textBox10.Text = row.Cells["대출일"].Value.ToString(); // 대출일 텍스트 상자에 값을 설정
                    textBox9.Text = row.Cells["반납일"].Value.ToString(); // 반납일 텍스트 상자에 값을 설정
                    textBox15.Text = row.Cells["메모"].Value.ToString(); // 메모 텍스트 상자에 값을 설정

                    if (DateTime.TryParse(textBox9.Text, out loanDate) && DateTime.TryParse(DateTime.Now.ToString("yyyy-MM-dd"), out returnDate))
                    {
                        TimeSpan difference = returnDate - loanDate;
                        int differenceInDays = (returnDate - loanDate).Days * 1000;
                        textBox18.Text = difference.Days.ToString(); // 대출일
                        textBox17.Text = differenceInDays+"원";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 검색 기능
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox6.Text == "회원명")
                {
                    MySqlDataAdapter userAdap = new MySqlDataAdapter("select user.회원번호, user.회원명, user.등급, user.회원상태, user.전화번호, user.주소, user.메모 from squad_library.bookrent rent join squad_library.user user on rent.회원번호 = user.회원번호 WHERE date(rent.반납일) < date(now()) and 회원명 = '" + textBox11.Text + "';", conn);
                    DataSet ds = new DataSet();
                    userAdap.Fill(ds, "bookrent_user");
                    dataGridView1.DataSource = ds.Tables["bookrent_user"];
                }
                else
                {
                    MessageBox.Show("검색 결과가 없습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 반납
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
    }
