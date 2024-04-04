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
    public partial class ManagerBookSetup : UserControl
    {
        public ManagerBookSetup()
        {
            InitializeComponent();
        }

        readonly MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234;");

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
                MySqlDataAdapter adap = new MySqlDataAdapter("select 도서번호, 도서명, 글쓴이, 출판사, 도서상태, 대출여부, 대출일, 반납일, 메모 from squad_library.search1", conn);

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

            try // 대출 회원 정보 DB 연결 (bookrent_user)
            {
                MySqlDataAdapter adap = new MySqlDataAdapter("select 회원번호, 도서명, 글쓴이, 출판사, 도서상태, 대출여부, 대출일, 반납일 from squad_library.bookrent_user", conn);

                conn.Open();

                DataSet ds = new DataSet();
                adap.Fill(ds, "bookrent_user");
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
                using (MySqlCommand command = new MySqlCommand("select count(*) from squad_library.booksetup where 회원번호 = @회원번호", conn))
                {
                    command.Parameters.AddWithValue("@회원번호", textBox17.Text);

                    conn.Open();

                    MySqlDataReader dataReader;

                    dataReader = command.ExecuteReader();

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text == "회원명")
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 회원번호, 회원명, 등급, 회원상태, 대출가능수, 전화번호, 주소, 메모  FROM squad_library.alluser where 회원명 = '" + this.textBox11.Text + "'", conn);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    conn.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "alluser");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["alluser"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox13.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox14.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox16.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox4.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboBox5.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox15.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            //MySqlDataReader Rd;
            conn.Open();

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

            else if (textBox5.Text == "대출 중")
            {
                MessageBox.Show("이미 대출 중인 도서 입니다.");
            }

            else if (textBox5.Text == "대출 불가")
            {
                MessageBox.Show("대출이 불가능한 도서입니다.");
            }

            else if (textBox5.Text == "연체")
            {
                MessageBox.Show("연체 도서는 대출할 수 없습니다.");
            }
            else //(cmd.ExecuteNonQuery() == 1)
                {
                // 도서 대출하면 대출 회원 테이블에 새로 데이터 저장되는거
                UPDATEBook1();
                UPDATEBook2();
                //UPDATEUser2();
                UPDATEUser1();
                INSERTBookRent();

                MessageBox.Show("도서가 대출되었습니다.");
                textBox17.Text = ""; // 회원 번호
                textBox1.Text = ""; // 회원명
                comboBox3.Text = ""; // 등급
                comboBox2.Text = ""; // 회원 상태
                textBox4.Text = ""; // 대출 가능
                textBox3.Text = ""; // 전화번호
                textBox7.Text = ""; // 주소
                textBox8.Text = ""; // 메모

                textBox13.Text = ""; // 도서 번호
                textBox14.Text = ""; // 도서명
                textBox5.Text = ""; // 글쓴이
                textBox16.Text = ""; // 출판사
                comboBox4.Text = ""; // 도서 상태
                comboBox5.Text = ""; // 대출 여부
                textBox10.Text = ""; // 대출일 
                textBox9.Text = ""; // 반납일
                textBox15.Text = ""; // 메모
                LoadData1();
                LoadData2();
            }

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
            MySqlDataAdapter adap = new MySqlDataAdapter("select * from squad.alluser", conn);
            MySqlCommand cmd = new MySqlCommand("SELECT 회원번호, 회원명, 등급, 회원상태, 대출가능수, 전화번호, 주소, 메모 FROM squad_library.alluser;", conn);

            try
            {
                adap.SelectCommand = cmd;
                DataTable datatable = new DataTable();
                adap.Fill(datatable);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = datatable;
                dataGridView1.DataSource = bSource;
                adap.Update(datatable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadData2()
        {
            MySqlConnection conn = new MySqlConnection("datasource = localhost; port = 3306; username = root; password=1234; Convert zero Datetime = true ;");
            MySqlDataAdapter adap = new MySqlDataAdapter("select 도서번호, 도서명, 글쓴이, 출판사, 도서상태, 대출여부, 대출일, 반납일, 메모 from squad_library.search1", conn);
            MySqlCommand cmd = new MySqlCommand("SELECT 도서번호, 도서명, 글쓴이, 출판사, 도서상태, 대출여부, 대출일, 반납일, 메모 FROM squad_library.search1;", conn);

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
