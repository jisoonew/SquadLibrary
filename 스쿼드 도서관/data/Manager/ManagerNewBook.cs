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
    public partial class ManagerNewBook : UserControl
    {
        public ManagerNewBook()
        {
            InitializeComponent();
        }

        static string myConnection = "Server=localhost;Database=squad_library;username=root;password=1234;";
        
        private ManagerBookManagement bmn = new ManagerBookManagement();

        private void mn_newbook_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(myConnection))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM squad_library.newbook", connection);
                    MySqlDataAdapter recommendAdapter = new MySqlDataAdapter("SELECT * FROM squad_library.recommend", connection);
                    MySqlDataAdapter bookAdapter = new MySqlDataAdapter("SELECT 도서번호, 도서명, 글쓴이, 출판사, 페이지 FROM squad_library.search1", connection);

                    connection.Open();

                    // 신착 도서
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "newBookDs");
                    dataGridView1.DataSource = ds.Tables["newBookDs"];

                    // 추천 도서
                    DataSet recommendDs = new DataSet();
                    recommendAdapter.Fill(recommendDs, "recommendDs");
                    dataGridView2.DataSource = recommendDs.Tables["recommendDs"];

                    // 전체 도서 출력
                    DataSet bookDs = new DataSet();
                    bookAdapter.Fill(bookDs, "bookDs");
                    dataGridView3.DataSource = bookDs.Tables["bookDs"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 신착 도서 지정
        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView3.SelectedRows[0];
            string bookNum = selectedRow.Cells[0].Value.ToString();
            DateTime today = DateTime.Today;
            string query = "INSERT INTO squad_library.newbook value('" + bookNum + "', '" + today.ToString("yyyy-MM-dd") + "');";

            try
            {
                using (MySqlConnection myconn = new MySqlConnection(myConnection))
                {
                    MySqlCommand cmd = new MySqlCommand(query, myconn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                    myconn.Open();

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    adapter.Update(dataTable);

                    MessageBox.Show("신착 도서로 지정되었습니다.");

                    LoadData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 신착 도서 삭제
        private void button2_Click(object sender, EventArgs e)
        {
            //delete를 통해 DB로 삭제된 데이터 전송 - 기본키 기준으로 삭제위치 탐색
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string bookNum = selectedRow.Cells[0].Value.ToString();
            Console.Write("응애 : " + bookNum);
            string Query = "delete from squad_library.newbook where 도서번호 = '" + bookNum + "';";

            try
            {
                using (MySqlConnection conDataBase = new MySqlConnection(myConnection))
                {
                    MySqlCommand cmdDatabase = new MySqlCommand(Query, conDataBase);

                    conDataBase.Open();

                    int rowsAffected = cmdDatabase.ExecuteNonQuery(); // 쿼리 실행 및 영향을 받은 행 수 반환

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("신착 도서를 삭제했습니다.");
                    }
                    else
                    {
                        MessageBox.Show("해당 도서를 찾을 수 없습니다.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LoadData();
        }

        // 추천 도서 지정
        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView3.SelectedRows[0];
            string bookNum = selectedRow.Cells[0].Value.ToString();
            DateTime today = DateTime.Today;
            string query = "INSERT INTO squad_library.recommend value('" + bookNum + "', '" + today.ToString("yyyy-MM-dd") + "');";

            try
            {
                using (MySqlConnection myconn = new MySqlConnection(myConnection))
                {
                    MySqlCommand cmd = new MySqlCommand(query, myconn);

                    MySqlDataAdapter recommend = new MySqlDataAdapter(cmd);

                    myconn.Open();

                    DataTable dataTable = new DataTable();
                    recommend.Fill(dataTable);
                    recommend.Update(dataTable);

                    MessageBox.Show("추천 도서로 지정되었습니다.");

                    LoadData2();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 추천 도서 삭제
        private void button4_Click(object sender, EventArgs e)
        {
            //delete를 통해 DB로 삭제된 데이터 전송 - 기본키 기준으로 삭제위치 탐색
            DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
            string bookNum = selectedRow.Cells[0].Value.ToString();
            string Query = "delete from squad_library.recommend where 도서번호 = '" + bookNum + "';";

            try
            {
                using (MySqlConnection conDataBase = new MySqlConnection(myConnection))
                {
                    MySqlCommand cmdDatabase = new MySqlCommand(Query, conDataBase);

                    conDataBase.Open();

                    int result = cmdDatabase.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("추천 도서를 삭제했습니다.");
                    }
                    else
                    {
                        MessageBox.Show("해당 도서를 찾을 수 없습니다.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LoadData2();
        }

        // 신착 도서 그리드뷰 로드
        public void LoadData()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(myConnection))
                {
                    MySqlCommand cmd_db = new MySqlCommand("SELECT * FROM squad_library.newbook;", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();

                    con.Open();

                    sda.SelectCommand = cmd_db;
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGridView1.DataSource = bSource;
                    sda.Update(dbdataset);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 추천 도서 그리드뷰 로드
        public void LoadData2()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(myConnection))
                {
                    MySqlCommand cmd_db = new MySqlCommand("SELECT * FROM squad_library.recommend;", con);

                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmd_db;
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGridView2.DataSource = bSource;

                    sda.Update(dbdataset);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 검색
        private void button5_Click(object sender, EventArgs e)
        {
            string query = "SELECT 도서번호, 도서명, 글쓴이, 출판사, 페이지 FROM squad_library.search1 where 도서번호 = @도서번호";
            string bookNameQuery = "SELECT 도서번호, 도서명, 글쓴이, 출판사, 페이지 FROM squad_library.search1 where 도서명 = @도서명";
            string bookQuery = "SELECT 도서번호, 도서명, 글쓴이, 출판사, 페이지 FROM squad_library.search1 where 출판사 = @출판사";

            using (MySqlConnection connection = new MySqlConnection(myConnection))
            {
                if(comboBox1.Text == "도서번호") {
                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                    mySqlCommand.Parameters.AddWithValue("@도서번호", dataGridView3.SelectedRows[0]);

                    DataTable dataTable = new DataTable();
                    mySqlDataAdapter.Fill(dataTable);
                    BindingSource bindingSource = new BindingSource();

                    bindingSource.DataSource = dataTable;
                    dataGridView3.DataSource = bindingSource;
                }
                else if (comboBox1.Text == "도서명")
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(bookNameQuery, connection);
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                    mySqlCommand.Parameters.AddWithValue("@도서명", dataGridView3.SelectedRows[1]);

                    DataTable dataTable = new DataTable();
                    mySqlDataAdapter.Fill(dataTable);
                    BindingSource bindingSource = new BindingSource();

                    bindingSource.DataSource = dataTable;
                    dataGridView3.DataSource = bindingSource;
                }
                else if (comboBox1.Text == "출판사")
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(bookQuery, connection);
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                    mySqlCommand.Parameters.AddWithValue("@출판사", dataGridView3.SelectedRows[3]);

                    DataTable dataTable = new DataTable();
                    mySqlDataAdapter.Fill(dataTable);
                    BindingSource bindingSource = new BindingSource();

                    bindingSource.DataSource = dataTable;
                    dataGridView3.DataSource = bindingSource;
                }
                else
                {
                    MessageBox.Show("해당 도서를 찾을 수 없습니다.");
                }
            }
        }
    }
}
