using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace 스쿼드_도서관.data
{
    public partial class ManagerBookReturn : UserControl
    {
        public ManagerBookReturn()
        {
            InitializeComponent();
        }
        readonly MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234");

        private void bookreturn_Load(object sender, EventArgs e)
        {

            try // 대출 회원 정보 DB 연결 (bookrent_user)
            {
                MySqlDataAdapter userAdap = new MySqlDataAdapter("select DISTINCT u.회원번호, 회원명, 등급, 회원상태, 전화번호, 주소, u.메모 from squad_library.user u inner join squad_library.bookrent br on u.회원번호 = br.회원번호;", conn);
                MySqlDataAdapter bookAdap = new MySqlDataAdapter("select br.도서번호, s.도서명, s.글쓴이, s.출판사, s.도서상태, br.대출일, br.반납일, br.메모 from squad_library.search1 s inner join squad_library.bookrent br on s.도서번호 = br.도서번호;", conn);

                conn.Open();

                DataTable dataTable = new DataTable();
                userAdap.Fill(dataTable);
                BindingSource userBindSource = new BindingSource();
                userBindSource.DataSource = dataTable;
                dataGridView1.DataSource = userBindSource;

                DataTable rentData = new DataTable();
                bookAdap.Fill(rentData);
                BindingSource rentBindSource = new BindingSource();
                rentBindSource.DataSource = rentData;
                dataGridView2.DataSource = rentBindSource;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        // 회원 정보 출력
        public void LoadUserData()
        {
            try
            {
                using (MySqlDataAdapter adap = new MySqlDataAdapter("select DISTINCT u.회원번호, 회원명, 등급, 회원상태, 전화번호, 주소, u.메모 from squad_library.user u inner join squad_library.bookrent br on u.회원번호 = br.회원번호;", conn))
                {
                    DataTable datatable = new DataTable();
                    adap.Fill(datatable);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = datatable;
                    dataGridView1.DataSource = bSource;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadData1 : " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void LoadData2()
        {
            
            MySqlCommand cmd = new MySqlCommand("select br.도서번호, s.도서명, s.글쓴이, s.출판사, s.도서상태, br.대출일, br.반납일, br.메모 from squad_library.search1 s inner join squad_library.bookrent br on s.도서번호 = br.도서번호;", conn);

            try
            {
                using (MySqlDataAdapter adap = new MySqlDataAdapter("select br.도서번호, s.도서명, s.글쓴이, s.출판사, s.도서상태, br.대출일, br.반납일, br.메모 from squad_library.search1 s inner join squad_library.bookrent br on s.도서번호 = br.도서번호;", conn)) {
                    
                    conn.Open();

                    adap.SelectCommand = cmd;
                    DataTable datatable = new DataTable();
                    adap.Fill(datatable);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = datatable;
                    dataGridView2.DataSource = bSource;
                    adap.Update(datatable);
                }
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

        // 대출한 회원 정보만 출력
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string query = "SELECT s.도서번호, s.도서명, s.글쓴이, s.출판사, s.도서상태, br.대출일, br.반납일, br.메모 " +
                                       "FROM squad_library.bookrent br " +
                                       "INNER JOIN squad_library.search1 s ON br.도서번호 = s.도서번호 " +
                                       "WHERE br.회원번호 = @memberId";

            string queryCount = "SELECT count(*) " +
                                       "FROM squad_library.bookrent br " +
                                       "INNER JOIN squad_library.search1 s ON br.도서번호 = s.도서번호 " +
                                       "WHERE br.회원번호 = @memberId";

            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

            string memberId = selectedRow.Cells[0].Value?.ToString();

            string connSelect = "datasource = localhost; port = 3306; username = root; password=1234";

            if (string.IsNullOrEmpty(memberId))
            {
                MessageBox.Show("선택된 회원의 ID가 없습니다.");
                return;
            }

            try
            {

                using (MySqlConnection conn = new MySqlConnection(connSelect))
                {
                    conn.Open();

                    using (MySqlCommand countCommand = new MySqlCommand(queryCount, conn))
                    {
                        countCommand.Parameters.AddWithValue("@memberId", memberId);
                        int loanedBooksCount = Convert.ToInt32(countCommand.ExecuteScalar());

                        // 대출 가능 수 출력
                        textBox4.Text = (5 - loanedBooksCount).ToString(); // 예: 최대 3권 대출 가능하다면 (3 - 대출 중인 도서 수)
                    }
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        textBox17.Text = memberId; // 회원번호
                        textBox1.Text = selectedRow.Cells[1].Value?.ToString();//회원명
                        comboBox3.Text = selectedRow.Cells[2].Value?.ToString(); // 등급
                        comboBox2.Text = selectedRow.Cells[3].Value?.ToString(); // 회원상태
                                                                                 //textBox4.Text = (5 - loanedBooksCount).ToString(); ; // 대출가능수
                        textBox3.Text = selectedRow.Cells[4].Value?.ToString(); // 전화번호
                        textBox7.Text = selectedRow.Cells[5].Value?.ToString(); // 주소
                        textBox8.Text = selectedRow.Cells[6].Value?.ToString(); // 메모

                        DataSet ds = new DataSet();

                        command.Parameters.AddWithValue("@memberId", memberId);

                        MySqlDataAdapter adap = new MySqlDataAdapter(command);
                        adap.Fill(ds, "bookrent_book");
                        dataGridView2.DataSource = ds.Tables["bookrent_book"];

                        conn.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        // 회원 정보 검색 기능
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text == "회원명")
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select DISTINCT u.회원번호, 회원명, 등급, 회원상태, 전화번호, 주소, u.메모 from squad_library.user u inner join squad_library.bookrent br on u.회원번호 = br.회원번호 and u.회원명 = '" + this.textBox11.Text + "';", conn);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    conn.Open();  // DB 연결 시작

                    DataTable userData = new DataTable();
                    adapter.Fill(userData);
                    BindingSource userBinding = new BindingSource();
                    userBinding.DataSource = userData;
                    dataGridView1.DataSource = userBinding;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        // 반납 기능
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox14.Text == "")
            {
                MessageBox.Show("반납 할 도서 정보가 없습니다.");
            }

            else
            {
                //delete를 통해 DB로 삭제된 데이터 전송 - 기본키 기준으로 삭제위치 탐색
                string Query = "delete from squad_library.bookrent where 도서번호 ='" + this.textBox13.Text + "';";
                MySqlCommand cmdDatabase = new MySqlCommand(Query, conn);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmdDatabase);

                try
                {
                    conn.Open();
                    DataTable deleteData = new DataTable();
                    mySqlDataAdapter.Fill(deleteData);
                    mySqlDataAdapter.Update(deleteData);
                    MessageBox.Show("도서가 반납되었습니다.");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                LoadUserData();
                LoadData2();
            }
        }

        void UPDATEUSER() // 대출 불가일때 반납이 처리되면 대출 가능으로 바꿔주기
        {
            if (comboBox2.Text == "대출 불가")
            {
                MySqlConnection conn = new MySqlConnection("datasource = localhost; port = 3306; username = root; password=1234");
                string Query = "update squad_library.alluser set 대출여부 = '대출 가능'  where 도서번호=@도서번호";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@도서번호", textBox13.Text);
                cmd.Parameters.AddWithValue("대출 가능", comboBox2.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                DataTable datatable = new DataTable();
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                adap.Fill(datatable);
            }
        }

        // 회원 정보 수정
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "update squad_library.user set 회원명=@회원명, 등급=@등급, 회원상태=@회원상태, 전화번호=@전화번호, 주소=@주소, 메모=@메모 where 회원번호=@회원번호";
                MySqlCommand cmd = new MySqlCommand(Query, conn);

                conn.Open();

                cmd.Parameters.AddWithValue("@회원번호", textBox17.Text);
                cmd.Parameters.AddWithValue("@회원명", textBox1.Text);
                cmd.Parameters.AddWithValue("@등급", comboBox3.Text);
                cmd.Parameters.AddWithValue("@회원상태", comboBox2.Text);
                cmd.Parameters.AddWithValue("@전화번호", textBox3.Text);
                cmd.Parameters.AddWithValue("@주소", textBox7.Text);
                cmd.Parameters.AddWithValue("@메모", textBox8.Text);

                cmd.ExecuteNonQuery();

                DataTable datatable = new DataTable();
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                adap.Fill(datatable);
                adap.Update(datatable);

                LoadUserData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("button1_Click" + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 책 대출 정보 조회
            string memberId = dataGridView1.Rows[e.RowIndex].Cells[0].Value?.ToString();


            // 선택된 책 정보 표시

            textBox13.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value?.ToString(); // 도서 번호
            textBox14.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value?.ToString(); // 도서명
            textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value?.ToString(); // 글쓴이
            textBox16.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value?.ToString(); // 출판사
            comboBox4.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value?.ToString(); // 도서 상태
            textBox10.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value?.ToString(); // 대출일
            textBox9.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value?.ToString(); // 반납일
            textBox15.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value?.ToString(); // 메모

            try
            {
                // MySqlDataAdapter는 데이터베이스와 데이터를 주고받을 때 사용되는 클래스 중 하나이다.
                using (MySqlCommand sqlCommand = new MySqlCommand("SELECT count(*)  FROM squad_library.bookrent where 도서번호 = '" + this.textBox13.Text + "'", conn))
                {
                    conn.Open();  // DB 연결 시작

                    using (MySqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {

                        if (dataReader.Read())
                        {

                            int rentCount = Convert.ToInt32(dataReader[0]);

                            DateTime loanDate; // 대출일
                            DateTime returnDate; // 현재 날짜

                            if (DateTime.TryParse(textBox10.Text, out loanDate) && DateTime.TryParse(DateTime.Now.ToString("yyyy-MM-dd"), out returnDate))
                            {
                                // 대출일과 반납일 사이의 기간을 계산
                                TimeSpan period = returnDate - loanDate;

                                // 차이를 일(day) 단위로 출력
                                int gapDate = (int)period.TotalDays;

                                if (gapDate > 14)
                                {
                                    comboBox5.Text = "연체";
                                }
                                else if (gapDate <= 14)
                                {
                                    comboBox5.Text = "대출 중"; // 대출 여부
                                }
                                else
                                {
                                    comboBox5.Text = "대출 가능"; // 대출 여부
                                }
                            }
                            else
                            {
                                // 올바른 날짜 형식이 아닌 경우 예외 처리
                                Console.WriteLine("날짜 형식이 잘못되었습니다.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox17.Text = "";
            textBox1.Text = "";
            comboBox3.Text = "";
            comboBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox6.Text = "";
            textBox11.Text = "";

            textBox13.Text = "";
            textBox14.Text = "";
            textBox5.Text = "";
            textBox16.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";
            textBox15.Text = "";

            LoadUserData();
            LoadData2();
        }
    }
}
