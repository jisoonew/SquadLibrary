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
    public partial class alluser : UserControl
    {
        public alluser()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void alluser_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234");
                MySqlDataAdapter adap = new MySqlDataAdapter("select * from squad_library.alluser", conn);

                conn.Open();

                DataSet ds = new DataSet();
                adap.Fill(ds, "alluser");
                dataGridView1.DataSource = ds.Tables["alluser"];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("회원정보 DB연결에 실패하였습니다. 다시 시도해주세요!");
            }
        }

        public void LoadData()
        {
            MySqlConnection conn = new MySqlConnection("datasource = localhost; port = 3306; username = root; password=1234");
            MySqlDataAdapter adap = new MySqlDataAdapter("select * from squad_library.alluser", conn);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM squad_library.alluser;", conn);

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
                MessageBox.Show("정보를 불러오지 못하였습니다.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource = localhost; port = 3306; username = root; password=1234");
            String sqlQuery = "insert into squad_library.alluser(회원명, 성별, 등급, 회원상태, 대출가능수, 대출금지일, 신청도서, 구매도서, 전화번호, 이메일, 주소, 메모)"
                    + "values('" + textBox8.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox3.Text + "','" + textBox9.Text + "','" + textBox2.Text + "','" + textBox1.Text + "')";


            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("회원이 등록되었습니다.");
            }

            else
            {
                MessageBox.Show("회원 등록에 실패했습니다.");
            }
            conn.Close();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource = localhost; port = 3306; username = root; password=1234");
            string Query = "update squad_library.alluser set 회원명=@회원명, 성별=@성별, 등급=@등급, 회원상태=@회원상태, 대출가능수=@대출가능수, 대출금지일=@대출금지일, 신청도서=@신청도서, 구매도서=@구매도서, 전화번호=@전화번호, 이메일=@이메일, 주소=@주소, 메모=@메모 where 회원번호=@회원번호";
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@회원번호", textBox7.Text);
            cmd.Parameters.AddWithValue("@회원명", textBox8.Text);
            cmd.Parameters.AddWithValue("@성별", comboBox1.Text);
            cmd.Parameters.AddWithValue("@등급", comboBox2.Text);
            cmd.Parameters.AddWithValue("@회원상태", comboBox3.Text);
            cmd.Parameters.AddWithValue("@대출가능수", textBox5.Text);
            cmd.Parameters.AddWithValue("@대출금지일", textBox4.Text);
            cmd.Parameters.AddWithValue("@신청도서", textBox10.Text);
            cmd.Parameters.AddWithValue("구매도서", textBox11.Text);
            cmd.Parameters.AddWithValue("@전화번호", textBox3.Text);
            cmd.Parameters.AddWithValue("@이메일", textBox9.Text);
            cmd.Parameters.AddWithValue("@주소", textBox2.Text);
            cmd.Parameters.AddWithValue("@메모", textBox1.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("수정 완료");
            DataTable datatable = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(datatable);
            dataGridView1.DataSource = datatable;

            LoadData();

            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox3.Text = "";
            textBox9.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; port=3306; username=root; password=1234";
            if (textBox7.Text == "")
            {
                MessageBox.Show("삭제 할 항목을 찾지 못했습니다.");
            }
            else
            {
                //delete를 통해 DB로 삭제된 데이터 전송 - 기본키 기준으로 삭제위치 탐색
                string Query = "delete from squad_library.alluser where 회원번호 ='" + this.textBox7.Text + "';";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                try
                {
                    conDataBase.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("회원 정보를 삭제했습니다.");

                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                LoadData();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text == "회원명")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *  FROM squad_library.alluser where 회원명 = '" + this.textBox6.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    connection.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "alluser");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["alluser"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show("검색에 실패하였습니다.");
                }
            }
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox3.Text = "";
            textBox9.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
            textBox6.Text = "";
            comboBox4.Text = "";

            LoadData();
        }
    }
}
