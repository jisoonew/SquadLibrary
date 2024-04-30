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
    public partial class ManagerBookSetup : UserControl
    {
        public ManagerBookSetup()
        {
            InitializeComponent();
        }

        readonly MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234;");
        string connSelect = "datasource = localhost; port = 3306; username = root; password=1234";

        private void booksetup_Load(object sender, EventArgs e)
        {
            try // 회원 정보 DB 연결
            {
                MySqlDataAdapter adap = new MySqlDataAdapter("select 회원번호, 회원명, 등급, 회원상태, 전화번호, 주소, 메모 from squad_library.user", conn);

                conn.Open();

                DataSet ds = new DataSet();
                adap.Fill(ds, "user");
                dataGridView1.DataSource = ds.Tables["user"];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try  // 도서 정보 DB 연결
            {
                MySqlDataAdapter adap = new MySqlDataAdapter("select 도서번호, 도서명, 글쓴이, 출판사, 도서상태, 대출일, 반납일, 메모 from squad_library.search1", conn);

                conn.Open();

                DataSet ds = new DataSet();
                adap.Fill(ds, "booksetup");
                dataGridView2.DataSource = ds.Tables["booksetup"];

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ManagerBookReturn br = new ManagerBookReturn();
            dateTimePicker1.Format = DateTimePickerFormat.Long;
            dateTimePicker1.Value = DateTime.Now.AddDays(14);
            textBox10.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textBox9.Text = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            dateTimePicker1.Value = DateTime.Now;
        }

        // 회원 목록
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox17.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

                // MySqlCommand : MySQL 데이터베이스로 쿼리를 보내고 데이터를 검색, 삽입, 갱신 또는 삭제할 수 있습니다.
                using (MySqlCommand command = new MySqlCommand("select count(*) from squad_library.bookrent where 회원번호 = @회원번호", conn))
                {
                    command.Parameters.AddWithValue("@회원번호", textBox17.Text);

                    conn.Open();

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

                                conn.Close();
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
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // 연결 닫기
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox17.Text = ""; // 회원 번호
            textBox1.Text = ""; // 회원명
            comboBox3.Text = ""; // 등급
            comboBox2.Text = ""; // 회원 상태
            textBox4.Text = ""; // 대출 가능
            textBox3.Text = ""; // 전화번호
            textBox7.Text = ""; // 주소
            textBox8.Text = ""; // 메모
            comboBox6.Text = ""; // 검색 필터
            textBox11.Text = ""; // 검색 창

            LoadData1();
        }

        // 검색 기능
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text == "회원명")
            {
                try
                {
                    // MySqlDataAdapter는 데이터베이스와 데이터를 주고받을 때 사용되는 클래스 중 하나이다.
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 회원번호, 회원명, 등급, 회원상태, 전화번호, 주소, 메모  FROM squad_library.user where 회원명 = '" + this.textBox11.Text + "'", conn))
                    {
                        conn.Open();  // DB 연결 시작

                        DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                        adapter.Fill(ds, "user");  //search1 테이블 채우기
                        dataGridView1.DataSource = ds.Tables["user"];  // 테이블 보이기

                    } // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기
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
            else if (comboBox6.Text == "회원번호")
            {
                try
                {
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT 회원번호, 회원명, 등급, 회원상태, 전화번호, 주소, 메모  FROM squad_library.user where 회원번호 = '" + this.textBox11.Text + "'", conn))
                    {

                        conn.Open();

                        // DataSet는 여러 테이블을 포함할 수 있는 메모리 내 데이터 저장소
                        // DataTable는 하나의 테이블만 포함할 수 있는 메모리 내 데이터 저장소
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable); // dataAdapter의 결과를 dataTable에 담는다
                        BindingSource bindingData = new BindingSource(); // 간단한 데이터 표시라면 DataSet을 사용하고, 데이터 조작과 유지 관리가 복잡해질 경우 BindingSource를 사용
                        bindingData.DataSource = dataTable; // BindingSource에 dataTable의 값을 담는다
                        dataGridView1.DataSource = bindingData; // 테이블 데이터 채우기
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
            else if (comboBox6.Text == "등급")
            {
                try
                {
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT 회원번호, 회원명, 등급, 회원상태, 전화번호, 주소, 메모  FROM squad_library.user where 등급 = '" + this.textBox11.Text + "'", conn))
                    {
                        conn.Open();

                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        BindingSource bindingSource = new BindingSource();
                        bindingSource.DataSource = dataTable;
                        dataGridView1.DataSource = bindingSource;

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
        }

        // 도서 목록
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox13.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString(); // 도서 번호
                textBox14.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString(); // 도서명
                textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString(); // 글쓴이
                textBox16.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString(); // 출판사
                comboBox4.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString(); // 도서 상태
                textBox15.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString(); // 메모

                // MySqlDataAdapter는 데이터베이스와 데이터를 주고받을 때 사용되는 클래스 중 하나이다.
                using (MySqlCommand sqlCommand = new MySqlCommand("SELECT count(*)  FROM squad_library.bookrent where 도서번호 = '" + this.textBox13.Text + "'", conn))
                {
                    conn.Open();  // DB 연결 시작

                    using (MySqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {

                        if (dataReader.Read())
                        {

                            int rentCount = Convert.ToInt32(dataReader[0]);

                            // 해당 도서가 대출 중이라면...
                            if (rentCount == 1)
                            {
                                comboBox5.Text = "대출 중"; // 대출 여부
                            }
                            else
                            {
                                comboBox5.Text = "대출 가능"; // 대출 여부
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



        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "도서명")  // if문으로 콤보박스 중 하나의 키워드를 적는다
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서번호, 도서명, 글쓴이, 출판사, 도서상태, 대출여부, 대출일, 반납일, 메모 FROM squad_library.search1 where 도서명 = '" + this.textBox12.Text + "'", conn);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    conn.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "search1");  //search1 테이블 채우기
                    dataGridView2.DataSource = ds.Tables["search1"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (comboBox7.Text == "글쓴이")  // if문으로 콤보박스 중 하나의 키워드를 적는다
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234; Convert zero Datetime = true");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서번호, 도서명, 글쓴이, 출판사, 도서상태, 대출여부, 대출일, 반납일, 메모 FROM squad_library.search1 where 글쓴이 = '" + this.textBox12.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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

            if (comboBox7.Text == "출판사")  // if문으로 콤보박스 중 하나의 키워드를 적는다
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234; Convert zero Datetime = true");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서번호, 도서명, 글쓴이, 출판사, 도서상태, 대출여부, 대출일, 반납일, 메모 FROM squad_library.search1 where 출판사 = '" + this.textBox12.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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

        // 대출하기
        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox4.Text == "0")
            {
                MessageBox.Show("더 이상 도서를 대출할 수 없습니다.");
            }

            else if (comboBox2.Text == "연체")
            {
                MessageBox.Show("연체 회원은 도서를 대출할 수 없습니다.");
            }

            else if (comboBox2.Text == "대출 금지")
            {
                MessageBox.Show("대출이 금지된 회원입니다.");
            }

            else if (comboBox5.Text == "대출 중")
            {
                MessageBox.Show("이미 대출 중인 도서 입니다.");
            }

            else if (comboBox5.Text == "대출 불가")
            {
                MessageBox.Show("대출이 불가능한 도서입니다.");
            }

            else if (comboBox5.Text == "연체")
            {
                MessageBox.Show("연체 도서는 대출할 수 없습니다.");
            }
            else //(cmd.ExecuteNonQuery() == 1)
            {
                try
                {
                    string connectionString = "datasource=localhost;port=3306;username=root;password=1234;Convert Zero Datetime=true";

                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        // 대출 중인 도서를 대출 회원 테이블에 추가
                        string insertQuery = "INSERT INTO squad_library.bookrent (회원번호, 도서번호, 대출일, 반납일, 메모) " +
                                             "VALUES (@회원번호, @도서번호, @대출일, @반납일, @메모)";

                        MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);

                        insertCmd.Parameters.AddWithValue("@회원번호", textBox17.Text);
                        insertCmd.Parameters.AddWithValue("@도서번호", textBox13.Text);
                        insertCmd.Parameters.AddWithValue("@대출일", textBox10.Text);
                        insertCmd.Parameters.AddWithValue("@반납일", textBox9.Text);
                        insertCmd.Parameters.AddWithValue("@메모", textBox15.Text);

                        insertCmd.ExecuteNonQuery();

                        MessageBox.Show("도서가 대출되었습니다.");

                        // 입력 필드 초기화
                        ClearInputFields();

                        // 데이터 다시 로드
                        LoadData1();
                        LoadData2();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류가 발생했습니다: " + ex.Message);
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

        // 입력 필드 초기화 메서드
        private void ClearInputFields()
        {
            textBox17.Text = "";
            textBox1.Text = "";
            comboBox3.Text = "";
            comboBox2.SelectedIndex = -1;
            textBox4.Text = "";
            textBox3.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox5.Text = "";
            textBox16.Text = "";
            comboBox4.Text = "";
            comboBox5.SelectedIndex = -1;
            textBox10.Text = "";
            textBox9.Text = "";
            textBox15.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox13.Text = ""; // 도서 번호
            textBox14.Text = ""; // 도서명
            textBox5.Text = ""; // 글쓴이
            textBox16.Text = ""; // 출판사
            comboBox4.Text = ""; // 도서 상태
            comboBox5.Text = ""; // 대출 여부
            textBox10.Text = ""; // 대출일 
            textBox9.Text = ""; // 반납일
            textBox15.Text = ""; // 메모
            comboBox7.Text = ""; // 검색 필터
            textBox12.Text = ""; // 검색 창

            LoadData2();
        }

        void INSERTBookRent() // 대출 회원 정보 저장
        {
            // 테이블에 회원번호가 있으면 삽입되지 않음
            MySqlConnection conn = new MySqlConnection("datasource = localhost; port = 3306; username = root; password=1234; Convert Zero Datetime = true");
            //MySqlDataReader Rd;
            conn.Open();

            ManagerBookReturn br = new ManagerBookReturn();
            dateTimePicker1.Format = DateTimePickerFormat.Long;
            dateTimePicker1.Value = DateTime.Now.AddDays(14);
            textBox10.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textBox9.Text = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            dateTimePicker1.Value = DateTime.Now;

            ManagerBookOverdue bo = new ManagerBookOverdue();

            String sqlQuery = "insert into squad_library.bookrent_user(회원번호, 회원명, 등급, 회원상태, 대출가능권수, 전화번호, 주소, 회원정보메모, 도서번호, 도서명, 글쓴이, 출판사, 도서상태, 대출여부, 대출일, 반납일, 도서정보메모)"
+ "values('" + textBox17.Text + "','" + textBox1.Text + "','" + comboBox3.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox5.Text + "','" + textBox16.Text + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + textBox10.Text + "','" + textBox9.Text + "','" + textBox15.Text + "');";

            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        void UPDATEBook1() // 도서 대출했으니까 대출 여부를 대출 중으로 바꿔주기
        {
            string Query = "update squad_library.search1 set 대출여부 = '대출 중'  where 도서번호=@도서번호";
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@도서번호", textBox13.Text);
            cmd.Parameters.AddWithValue("대출 중", comboBox5.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            DataTable datatable = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(datatable);
            dataGridView2.DataSource = datatable;

            LoadData1();
        }

        void UPDATEBook2() // 도서 대출했으니까 대출 여부를 대출 중으로 바꿔주기
        {
            string Query = "update squad_library.bookrent_user set 대출여부 = '대출 중'  where 도서번호=@도서번호";
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@도서번호", textBox13.Text);
            cmd.Parameters.AddWithValue("대출 중", comboBox5.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            DataTable datatable = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(datatable);
            dataGridView2.DataSource = datatable;

            LoadData1();
        }

        void UPDATEUser1() //대출 가능 권수 = 0 일때 회원 상태 대출 불가로 변경 해줘야 함
        {
            if (textBox4.Text == "0")
            {
                string Query = "update squad_library.alluser set 회원상태 = '대출 불가' where 회원번호=@회원번호";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@회원번호", textBox17.Text);
                cmd.Parameters.AddWithValue("대출 불가", comboBox2.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                DataTable dt = new DataTable();
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                adap.Fill(dt);
                dataGridView1.DataSource = dt;

                LoadData1();
            }
        }

        void UPDATEUser2() //대출 가능 권수  -1 해야 됨
        {
            string Query = "update squad_library.alluser set 대출가능수 = @대출가능수 - 1 where 회원번호=@회원번호";
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@회원번호", textBox17.Text);
            cmd.Parameters.AddWithValue("@대출가능수", textBox4.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            DataTable dt = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void LoadData1()
        {
            MySqlDataAdapter adap = new MySqlDataAdapter("select * from squad.user", conn);
            MySqlCommand cmd = new MySqlCommand("SELECT 회원번호, 회원명, 등급, 회원상태, 전화번호, 주소, 메모 FROM squad_library.user;", conn);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connSelect))
                {
                    adap.SelectCommand = cmd;
                    DataTable datatable = new DataTable();
                    adap.Fill(datatable);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = datatable;
                    dataGridView1.DataSource = bSource;
                    adap.Update(datatable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadData2()
        {
            MySqlConnection conn = new MySqlConnection("datasource = localhost; port = 3306; username = root; password=1234; Convert zero Datetime = true ;");
            MySqlDataAdapter adap = new MySqlDataAdapter("select 도서번호, 도서명, 글쓴이, 출판사, 도서상태, 대출일, 반납일, 메모 from squad_library.search1", conn);
            MySqlCommand cmd = new MySqlCommand("SELECT 도서번호, 도서명, 글쓴이, 출판사, 도서상태, 대출일, 반납일, 메모 FROM squad_library.search1;", conn);

            try
            {
                adap.SelectCommand = cmd;
                DataTable datatable = new DataTable();
                adap.Fill(datatable);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = datatable;
                dataGridView2.DataSource = bSource;
                adap.Update(datatable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource = localhost; port = 3306; username = root; password=1234; Convert Zero Datetime = true ;");
            string Query = "update squad_library.user set 회원명=@회원명, 등급=@등급, 회원상태=@회원상태, 대출가능수=@대출가능수, 전화번호=@전화번호, 주소=@주소, 메모=@메모 where 회원번호=@회원번호";
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@회원번호", textBox17.Text);
            cmd.Parameters.AddWithValue("@회원명", textBox1.Text);
            cmd.Parameters.AddWithValue("@등급", comboBox3.Text);
            cmd.Parameters.AddWithValue("@회원상태", comboBox2.Text);
            cmd.Parameters.AddWithValue("@대출가능수", textBox4.Text);
            cmd.Parameters.AddWithValue("@전화번호", textBox3.Text);
            cmd.Parameters.AddWithValue("@주소", textBox7.Text);
            cmd.Parameters.AddWithValue("@메모", textBox8.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("수정 완료");
            DataTable datatable = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(datatable);
            dataGridView1.DataSource = datatable;

            LoadData1();
        }
    }
}
