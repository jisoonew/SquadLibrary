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
    public partial class UserQAView : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=squad_library;Uid=root;Pwd=qkrwltn5130!");
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();

        string _server = "localhost";
        int _port = 3306;
        string _database = "squad_library";
        string _id = "root";
        string _pw = "qkrwltn5130!";
        string _connectionAddress = "";

        public UserQAView()
        {
            InitializeComponent();
            _connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _server, _port, _database, _id, _pw);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                dataGridView1.Columns["글번호"].ValueType = typeof(int);
                dataGridView1.Sort(dataGridView1.Columns["글번호"], ListSortDirection.Ascending);

            }
            else if (comboBox1.SelectedIndex == 1)
            {

                dataGridView1.Columns["글번호"].ValueType = typeof(int);
                dataGridView1.Sort(dataGridView1.Columns["글번호"], ListSortDirection.Descending);

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            UserQAContent qc = new UserQAContent();
            qc.Show();
        }

        private void userQA01_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=qkrwltn5130!");
                MySqlDataAdapter adap = new MySqlDataAdapter("select * from squad_library.question1", conn);

                conn.Open();

                DataSet ds = new DataSet();
                adap.Fill(ds, "question1");
                dataGridView1.DataSource = ds.Tables["question1"];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("회원정보 DB 연결에 실패하였습니다.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");
                MySqlDataAdapter adapter = new MySqlDataAdapter("select * from squad_library.question1", connection);

                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "question1");
                dataGridView1.DataSource = ds.Tables["question1"];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void searchData(string valueToSearch)
        {
            string query = "SELECT * FROM squad_library.question1 WHERE CONCAT('글번호', '제목', '내용', '작성자', '작성일') like '%" + valueToSearch + "%'";

            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            searchData("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "글 번호")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost; port=3306; username=root; password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *  FROM squad_library.question1 where 글번호 = '" + textBox1.Text + "' ", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    connection.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "question1");  //book 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["question1"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show("검색에 실패하였습니다.");
                }
            }

            if (comboBox1.Text == "제목")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost; port=3306; username=root; password=EUNHA0530");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *  FROM squad_library.question1 where 제목  LIKE  '%" + textBox1.Text + "%' ", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    connection.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "alluser");  //book 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["alluser"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show("검색에 실패하였습니다.");
                }
            }

            if (comboBox1.Text == "내용")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost; port=3306; username=root; password=EUNHA0530");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM squad_library.question1 where 내용 LIKE  '%" + textBox1.Text + "%' ", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    connection.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "alluser");  //book 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["alluser"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show("검색에 실패하였습니다.");
                }
            }

            if (comboBox1.Text == "작성자")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost; port=3306; username=root; password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *  FROM squad_library.question1 where 작성자 LIKE  '%" + textBox1.Text + "%' ", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    connection.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "question1");  //book 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["question1"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show("검색에 실패하였습니다.");
                }
            }

            if (comboBox1.Text == "작성일")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost; port=3306; username=root; password=qkrwltn5130!");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *  FROM squad_library.question1 where 작성일 LIKE  '%" + textBox1.Text + "%' ", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    connection.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "question1");  //book 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["question1"];  // 테이블 보이기
                }
                catch (Exception ex)
                {
                    MessageBox.Show("검색에 실패하였습니다.");
                }
            }
        }


    }
}
