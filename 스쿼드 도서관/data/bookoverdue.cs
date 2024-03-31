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
    public partial class bookoverdue : UserControl
    {
        public bookoverdue()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

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

            bookreturn br = new bookreturn();

            try // 대출 회원 정보 DB 연결 (bookrent_user)
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234");
                MySqlDataAdapter adap = new MySqlDataAdapter("select 회원번호, 회원명, 등급, 회원상태, 대출가능권수, 전화번호, 주소, 회원정보메모 from squad_library.bookrent_user WHERE date(반납일) != date(now());", conn);

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
                MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234");
                MySqlDataAdapter adap = new MySqlDataAdapter("select 도서번호, 도서명, 글쓴이, 출판사, 도서번호, 연체일, 도서상태, 대출여부, 대출일, 반납일, 연체금, 도서정보메모 from squad_library.bookrent_user WHERE date(반납일) != date(now());", conn);

                conn.Open();

                DataSet ds = new DataSet();

                textBox19.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

                adap.Fill(ds, "bookrent_user");
                dataGridView2.DataSource = ds.Tables["bookrent_user"];
                textBox14.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox16.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox13.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox18.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                comboBox4.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                comboBox5.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                textBox10.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
                textBox9.Text = dataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();

                textBox15.Text = dataGridView2.Rows[e.RowIndex].Cells[11].Value.ToString();
                //adap.Fill(ds, "bookrent_user");
                //dataGridView2.DataSource = ds.Tables["bookrent_user"];

                string input = String.Empty;

                /*try
                {
                    int result = Int32.Parse(input);

                } catch { }*/

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }
