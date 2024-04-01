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
    public partial class ManagerBookReturn : UserControl
    {
        public ManagerBookReturn()
        {
            InitializeComponent();
        }

        private void bookreturn_Load(object sender, EventArgs e)
        {

            try // 대출 회원 정보 DB 연결 (bookrent_user)
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234");
                MySqlDataAdapter adap = new MySqlDataAdapter("select 회원번호, 회원명, 등급, 회원상태, 대출가능권수, 전화번호, 주소, 회원정보메모 from squad_library.bookrent_user", conn);

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
                MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234");
                MySqlDataAdapter adap = new MySqlDataAdapter("select 도서번호, 도서명, 글쓴이, 출판사, 도서상태, 대출여부, 대출일, 반납일, 도서정보메모 from squad_library.bookrent_user", conn);

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
                MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234");
                MySqlDataAdapter adap = new MySqlDataAdapter("select * from squad_library.alluser", conn);

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
                MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234");
                MySqlDataAdapter adap = new MySqlDataAdapter("select 도서번호,도서명, 글쓴이, 출판사, 도서상태, 대출여부, 대출일, 반납일, 도서정보메모 from squad_library.search1", conn);

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

        public void LoadData1()
        {
            MySqlConnection conn = new MySqlConnection("datasource = localhost; port = 3306; username = root; password=1234");
            MySqlDataAdapter adap = new MySqlDataAdapter("select 회원번호, 회원명, 등급, 회원상태, 대출가능권수, 전화번호, 주소, 회원정보메모 from squad_library.bookrent_user", conn);
            MySqlCommand cmd = new MySqlCommand("SELECT 회원번호, 회원명, 등급, 회원상태, 대출가능권수, 전화번호, 주소, 회원정보메모 from squad_library.bookrent_user;", conn);

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
            MySqlConnection conn = new MySqlConnection("datasource = localhost; port = 3306; username = root; password=1234");
            MySqlDataAdapter adap = new MySqlDataAdapter("select 도서번호, 도서명, 글쓴이, 출판사, 도서상태, 대출여부, 대출일, 반납일, 도서정보메모 from squad_library.bookrent_user", conn);
            MySqlCommand cmd = new MySqlCommand("SELECT 도서번호, 도서명, 글쓴이, 출판사, 도서상태, 대출여부, 대출일, 반납일, 도서정보메모 from squad_library.bookrent_user;", conn);

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234");
                MySqlDataAdapter adap = new MySqlDataAdapter("select 도서번호, 도서명, 글쓴이, 출판사, 도서상태, 대출여부, 대출일, 반납일, 도서정보메모 from squad_library.bookrent_user", conn);

                conn.Open();

                DataSet ds = new DataSet();

                textBox17.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

                adap.Fill(ds, "bookrent_user");
                dataGridView2.DataSource = ds.Tables["bookrent_user"];

                textBox13.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox14.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox16.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox4.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboBox5.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox10.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBox9.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                textBox15.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
                //adap.Fill(ds, "bookrent_user");
                //dataGridView2.DataSource = ds.Tables["bookrent_user"];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text == "회원명")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 회원번호, 회원명, 등급, 회원상태, 대출가능권수, 전화번호, 주소, 회원정보메모  FROM squad_library.bookrent_user where 회원명 = '" + this.textBox11.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    connection.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "bookrent_user");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["bookrent_user"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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

            LoadData1();
            LoadData2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=qkrwltn5130!";
            if (textBox14.Text == "")
            {
                MessageBox.Show("반납 할 도서 정보가 없습니다.");
            }

            else
            {
                //delete를 통해 DB로 삭제된 데이터 전송 - 기본키 기준으로 삭제위치 탐색
                string Query = "delete from squad_library.bookrent_user where 도서번호 ='" + this.textBox13.Text + "';";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                UPDATEBook();
                UPDATEUser2();
                UPDATEUSER();

                try
                {
                    conDataBase.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("도서가 반납되었습니다.");

                    while (myReader.Read())
                    {

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                LoadData1();
                LoadData2();
            }
        }

        void UPDATEBook() // 도서 반납했으니까 대출 여부를 대출 가능으로 바꿔주기
        {
            MySqlConnection conn = new MySqlConnection("datasource = localhost; port = 3306; username = root; password=1234");
            string Query = "update squad_library.search1 set 대출여부 = '대출 가능' where 도서번호=@도서번호";
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@도서번호", textBox13.Text);
            cmd.Parameters.AddWithValue("대출 가능", comboBox5.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            DataTable datatable = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(datatable);
            dataGridView2.DataSource = datatable;
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

        void UPDATEUser2() //대출 가능 권수 +1 해야 됨
        {
            MySqlConnection con = new MySqlConnection("datasource = localhost; port = 3306; username = root; password=1234");
            string Query = "update squad_library.alluser set 대출가능수 = @대출가능수 + 1 where 회원번호=@회원번호";
            MySqlCommand cmd = new MySqlCommand(Query, con);
            con.Open();

            cmd.Parameters.AddWithValue("@회원번호", textBox17.Text);
            cmd.Parameters.AddWithValue("@대출가능수", textBox4.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            DataTable dt = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource = localhost; port = 3306; username = root; password=1234");
            string Query = "update squad_library.alluser set 회원명=@회원명, 등급=@등급, 회원상태=@회원상태, 대출가능수=@대출가능수, 전화번호=@전화번호, 주소=@주소, 메모=@메모 where 회원번호=@회원번호";
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

            DataTable datatable = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(datatable);
            dataGridView1.DataSource = datatable;

            LoadData1();
        }
    }
}
