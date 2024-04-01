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
    public partial class UserAnnouncement : Form
    {
        public UserAnnouncement()
        {
            InitializeComponent();
        }

        private void usernotice01_Load(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");
                MySqlDataAdapter adapter = new MySqlDataAdapter("select 번호, 제목, 작성자, 작성일, 내용, 조회수 from squad_library.manager_notice", connection);

                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "manager_notice");
                dataGridView1.DataSource = ds.Tables["manager_notice"];
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadData()
        {
            string sql = "Server=localhost;Port=3306;username=root;password=qkrwltn5130!";
            MySqlConnection con = new MySqlConnection(sql);
            MySqlCommand cmd_db = new MySqlCommand("SELECT 번호, 제목, 작성자, 작성일, 내용, 조회수 FROM squad_library.manager_notice;", con);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd_db;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                dataGridView1.DataSource = bSource;
                bSource.DataSource = dbdataset;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "제목")  // if문으로 콤보박스 중 하나의 키워드를 적는다
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 번호, 제목, 작성자, 작성일, 내용, 조회수  FROM squad_library.manager_notice where 제목 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    connection.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "manager_notice");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["manager_notice"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (comboBox1.Text == "작성자")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 번호, 제목, 작성자, 작성일, 내용, 조회수  FROM squad_library.manager_notice where 작성자 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    connection.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "manager_notice");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["manager_notice"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (comboBox1.Text == "글번호")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 번호, 제목, 작성자, 작성일, 내용, 조회수  FROM squad_library.manager_notice where 글번호 = '" + this.textBox1.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    connection.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "manager_notice");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["manager_notice"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            else
            {
                MessageBox.Show("검색 결과를 찾지 못했습니다.");
            }

        }
    }
}
