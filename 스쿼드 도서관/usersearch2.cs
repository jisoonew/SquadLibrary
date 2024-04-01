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
    public partial class usersearch2 : Form
    {
        public usersearch2()
        {
            InitializeComponent();
        }

        private void usersearch2_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=qkrwltn5130!");
                MySqlDataAdapter adap = new MySqlDataAdapter("select * from squad_library.search1", conn);

                conn.Open();

                DataSet ds = new DataSet();
                adap.Fill(ds, "alluser");
                dataGridView1.DataSource = ds.Tables["alluser"];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("회원정보 DB 연결에 실패하였습니다.");
            }
        }

        private void 검색_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "도서명")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost; port=3306; username=root; password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *  FROM squad_library.search1 where 도서명  LIKE  '%" + textBox1.Text + "%' ", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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
            if (comboBox1.Text == "글쓴이")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost; port=3306; username=root; password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *  FROM squad_library.search1 where 글쓴이 LIKE  '%" + textBox1.Text + "%' ", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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
            if (comboBox1.Text == "출판사")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost; port=3306; username=root; password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *  FROM squad_library.search1 where 출판사 LIKE  '%" + textBox1.Text + "%' ", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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
    }
}
