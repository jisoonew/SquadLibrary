using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace 스쿼드_도서관
{
    public partial class ManagerBookManagement : UserControl
    {
        public ManagerBookManagement()
        {
            InitializeComponent();
        }

        readonly string myconnect = "datasource = localhost; port = 3306; username=root; password=1234;";
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234");

        private void bookmanagement_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(myconnect))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 메모 from squad_library.search1", connection);

                    connection.Open();

                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "search1");
                    dataGridView1.DataSource = ds.Tables["search1"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadData()
        {
            MySqlConnection con = new MySqlConnection(myconnect);
            MySqlCommand cmd_db = new MySqlCommand("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 메모  FROM squad_library.search1;", con);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd_db;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            //텍스트 박스 초기화
            textBox8.Text = ""; // 이미지 주소
            textBox1.Text = "";
            textBox7.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox11.Text = "";
        }

        // 도서 추가 기능
        private void button1_Click(object sender, EventArgs e)
        {
            string selectQuery = "select 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 메모 from squad_library.search1 where 도서번호 = @도서번호";

            string updateQuery = "update squad_library.search1 set 도서명 = @도서명, 책표지 = @책표지, 글쓴이 = @글쓴이, 출판사 = @출판사, 출판일 = @출판일, 페이지 = @페이지," +
                "도서가격 = @도서가격, 도서상태 = @도서상태, 메모 = @메모 where 도서번호 = @도서번호";

            try
            {
                using (MySqlConnection myconn = new MySqlConnection(myconnect))
                {
                    MySqlCommand selectCmd = new MySqlCommand(selectQuery, myconn);

                    myconn.Open();

                    selectCmd.Parameters.AddWithValue("@도서번호", this.textBox7.Text);

                    using (MySqlDataReader dataReader = selectCmd.ExecuteReader())
                    {

                        // 만약 이미 저장되어 있는 도서라면?
                        if (dataReader.Read())
                        {
                            using (MySqlConnection updateConn = new MySqlConnection(myconnect))
                            {
                                MySqlCommand updateCmd = new MySqlCommand(updateQuery, updateConn);
                                MySqlDataAdapter updateAdapter = new MySqlDataAdapter(updateCmd);

                                // 선택한 이미지 파일 경로
                                string imagePath = textBox8.Text;

                                // 이미지 파일을 바이트 배열로 읽어오기
                                byte[] imageData = File.ReadAllBytes(imagePath);

                                updateConn.Open();

                                updateCmd.Parameters.AddWithValue("@도서명", this.textBox1.Text);
                                updateCmd.Parameters.AddWithValue("@도서번호", this.textBox7.Text);
                                updateCmd.Parameters.AddWithValue("@글쓴이", this.textBox2.Text);
                                updateCmd.Parameters.AddWithValue("@출판사", this.textBox4.Text);
                                updateCmd.Parameters.AddWithValue("@출판일", this.textBox3.Text);
                                updateCmd.Parameters.AddWithValue("@페이지", this.textBox6.Text);
                                updateCmd.Parameters.AddWithValue("@도서가격", this.textBox5.Text);
                                updateCmd.Parameters.AddWithValue("@도서상태", this.comboBox1.Text);
                                updateCmd.Parameters.AddWithValue("@메모", this.textBox11.Text);
                                updateCmd.Parameters.Add("@책표지", MySqlDbType.Blob).Value = imageData;

                                DataTable updateDataSet = new DataTable();

                                updateAdapter.Fill(updateDataSet);

                                BindingSource updateSource = new BindingSource();
                                updateSource.DataSource = updateDataSet;

                                updateAdapter.Update(updateDataSet);

                                MessageBox.Show("도서 정보를 수정하였습니다.");
                            }
                        }
                        else
                        {
                            string query = "insert into squad_library.search1(도서명, 책표지,  도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 메모)" +
                "value(@도서명, @책표지, @도서번호, @글쓴이, @출판사, @출판일, @페이지, @도서가격, @도서상태, @메모); ";

                            using (MySqlConnection insertConn = new MySqlConnection(myconnect))
                            {
                                MySqlCommand cmd = new MySqlCommand(query, insertConn);
                                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                                // 선택한 이미지 파일 경로
                                string imagePath = textBox8.Text;

                                // 이미지 파일을 바이트 배열로 읽어오기
                                byte[] imageData = File.ReadAllBytes(imagePath);

                                insertConn.Open();

                                cmd.Parameters.AddWithValue("@도서명", this.textBox1.Text);
                                cmd.Parameters.AddWithValue("@도서번호", this.textBox7.Text);
                                cmd.Parameters.AddWithValue("@글쓴이", this.textBox2.Text);
                                cmd.Parameters.AddWithValue("@출판사", this.textBox4.Text);
                                cmd.Parameters.AddWithValue("@출판일", this.textBox3.Text);
                                cmd.Parameters.AddWithValue("@페이지", this.textBox6.Text);
                                cmd.Parameters.AddWithValue("@도서가격", this.textBox5.Text);
                                cmd.Parameters.AddWithValue("@도서상태", this.comboBox1.Text);
                                cmd.Parameters.AddWithValue("@메모", this.textBox11.Text);
                                cmd.Parameters.Add("@책표지", MySqlDbType.Blob).Value = imageData;

                                DataTable dataSet = new DataTable();

                                mySqlDataAdapter.Fill(dataSet);

                                BindingSource bSource = new BindingSource();
                                bSource.DataSource = dataSet;

                                mySqlDataAdapter.Update(dataSet);
                                    
                                MessageBox.Show("도서 정보가 저장되었습니다.");
                            }
                        }
                    }
                    MySqlDataAdapter selectAdapter = new MySqlDataAdapter(selectCmd);
                    DataSet selectData = new DataSet();
                    selectAdapter.Fill(selectData, "selectData");
                    dataGridView1.DataSource = selectData.Tables["selectData"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 도서 목록
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[0].Value.ToString(); // 제목
            textBox7.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[1].Value.ToString(); // 도서번호
            textBox2.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[2].Value.ToString(); // 글쓴이
            textBox4.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[3].Value.ToString(); // 출판사
            textBox3.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[4].Value.ToString(); // 출판일
            textBox6.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[5].Value.ToString(); // 페이지
            textBox5.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[6].Value.ToString(); // 가격
            comboBox1.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[7].Value.ToString(); // 도서상태
            textBox11.Text = dataGridView1.Rows[this.dataGridView1.CurrentCellAddress.Y].Cells[8].Value.ToString(); // 메모

            try
            {
                // MySqlDataAdapter는 데이터베이스와 데이터를 주고받을 때 사용되는 클래스 중 하나이다.
                using (MySqlConnection mySqlConnection = new MySqlConnection(myconnect))
                {
                    mySqlConnection.Open();

                    MySqlCommand sqlCommand = new MySqlCommand("SELECT count(*)  FROM squad_library.bookrent where 도서번호 = '" + this.textBox7.Text + "'", mySqlConnection);
                    MySqlCommand loanDateCommand = new MySqlCommand("SELECT 대출일  FROM squad_library.bookrent where 도서번호 = '" + this.textBox7.Text + "'", mySqlConnection);

                    string query = "SELECT 책표지 FROM squad_library.search1 WHERE 도서번호 = @도서번호";
                    MySqlCommand blobCommand = new MySqlCommand(query, mySqlConnection);
                    blobCommand.Parameters.AddWithValue("@도서번호", this.textBox7.Text);

                    // 이미지 데이터를 바이트 배열로 가져옴
                    byte[] imageData = (byte[])blobCommand.ExecuteScalar();

                    // 이미지 로드
                    using (MySqlDataReader blobReader = blobCommand.ExecuteReader())
                    {
                        if (blobReader.Read()) // 데이터가 있는지 확인
                        {
                            // longblob에 데이터가 있다면 길이가 0 이상이다.
                            if (imageData.Length > 0)
                            {
                                // BLOB 데이터를 읽어와서 스트림으로 변환
                                using (MemoryStream ms = new MemoryStream((byte[])blobReader["책표지"]))
                                {
                                    // 스트림을 사용하여 이미지를 로드하고 표시
                                    pictureBox1.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                pictureBox1.Image = null; // 또는 다른 이미지를 설정
                            }
                        }
                        else
                        {
                            // 데이터가 없는 경우에 대한 처리
                            // 이미지를 초기화하거나 기본 이미지를 설정할 수 있습니다.
                            pictureBox1.Image = null; // 또는 다른 이미지를 설정
                        }
                    }

                    int rentCount = Convert.ToInt32(sqlCommand.ExecuteScalar());

                    // 대출 여부
                    if (rentCount > 0)
                    {
                        DateTime loanDate = Convert.ToDateTime(loanDateCommand.ExecuteScalar());
                        DateTime returnDate = DateTime.Now;

                        TimeSpan period = returnDate - loanDate;
                        int gapDate = (int)period.TotalDays;

                        if (gapDate > 14)
                        {
                            comboBox2.Text = "연체";
                        }
                        else
                        {
                            comboBox2.Text = "대출 중";
                        }
                    }
                    else
                    {
                        comboBox2.Text = "대출 가능";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 도서 삭제
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("삭제 할 항목을 찾지 못했습니다.");
            }
            else
            {
                //delete를 통해 DB로 삭제된 데이터 전송 - 기본키 기준으로 삭제위치 탐색
                string Query = "delete from squad_library.search1 where 도서번호 ='" + this.textBox7.Text + "';";
                string rentQuery = "delete from squad_library.bookrent where 도서번호 ='" + this.textBox7.Text + "';";

                try
                {
                    using (MySqlConnection conDataBase = new MySqlConnection(myconnect))
                    {
                        MySqlCommand cmdDatabase = new MySqlCommand(Query, conDataBase);
                        MySqlDataReader myReader;
                        MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(cmdDatabase);

                        MySqlCommand rentDatabase = new MySqlCommand(rentQuery, conDataBase);
                        MySqlDataAdapter rentAdapter = new MySqlDataAdapter(rentDatabase);
                        MySqlDataReader rentReader;

                        conDataBase.Open();

                        myReader = cmdDatabase.ExecuteReader();
                        rentReader = rentDatabase.ExecuteReader();

                        // 도서 테이블의 데이터가 있다면 삭제
                        while (myReader.Read())
                        {
                            DataSet deleteDataSet = new DataSet();
                            sqlAdapter.Fill(deleteDataSet);
                            sqlAdapter.Update(deleteDataSet);
                        }

                        // 대출 테이블의 데이터가 있다면 삭제
                        while(rentReader.Read())
                        {
                            DataSet rentDeleteDataSet = new DataSet();
                            rentAdapter.Fill(rentDeleteDataSet);
                            rentAdapter.Update(rentDeleteDataSet);
                        }

                        MessageBox.Show("도서를 삭제했습니다.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                LoadData();
            }
        }

        // 검색하기
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "도서명")  // if문으로 콤보박스 중 하나의 키워드를 적는다
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 메모  FROM squad_library.search1 where 도서명 = '" + this.textBox12.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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

            else if (comboBox3.Text == "도서 번호")
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 메모  FROM squad_library.search1 where 도서번호 = '" + this.textBox12.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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

            else if (comboBox3.Text == "글쓴이")
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 메모  FROM squad_library.search1 where 글쓴이 = '" + this.textBox12.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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

            else if (comboBox3.Text == "출판사")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 메모  FROM squad_library.search1 where 출판사 = '" + this.textBox12.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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

            else if (comboBox3.Text == "도서 상태")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 메모  FROM squad_library.search1 where 도서상태 = '" + this.textBox12.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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

            else if (comboBox3.Text == "대출 여부")
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234");  //DB 주소 가져오기
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 메모  FROM squad_library.search1 where 대출여부 = '" + this.textBox12.Text + "'", connection);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

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

            else
            {
                MessageBox.Show("검색 결과를 찾지 못했습니다.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadData();  // 새로고침
        }

        // 추천 도서
        private void button2_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO squad_library.user_recommend value('" + this.textBox7.Text + "', '" + this.textBox1.Text + "', '" + this.textBox2.Text + "', '" + this.textBox4.Text + "', '" + this.textBox6.Text + "');";


            MySqlConnection myconn = new MySqlConnection(myconnect);

            MySqlCommand cmd = new MySqlCommand(query, myconn);

            MySqlDataReader myReader;

            try
            {
                myconn.Open();

                myReader = cmd.ExecuteReader();
                MessageBox.Show("추천 도서로 지정되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            myconn.Close();
        }

        // 신착 도서
        private void button6_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO squad_library.newbook value('" + this.textBox7.Text + "', '" + this.textBox1.Text + "', '" + this.textBox2.Text + "', '" + this.textBox4.Text + "', '" + this.textBox6.Text + "');";

            MySqlConnection myconn = new MySqlConnection(myconnect);

            MySqlCommand cmd = new MySqlCommand(query, myconn);

            MySqlDataReader myReader;

            try
            {
                myconn.Open();

                myReader = cmd.ExecuteReader();
                MessageBox.Show("신착 도서로 지정되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 이미지 불러오기
        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.BMP;*.JPG;*.JPEG,*.PNG";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = dialog.FileName; // 이미지 경로 출력
                pictureBox1.Load(dialog.FileName);
            }
        }
    }
}
