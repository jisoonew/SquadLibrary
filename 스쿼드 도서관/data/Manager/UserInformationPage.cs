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
    public partial class UserInformationPage : UserControl
    {
        public UserInformationPage()
        {
            InitializeComponent();
        }

        // readonly == 상수, 런타임 상수 입니다. 즉, "프로그램이 실행중에 초기화 하는것도 가능한" 상수
        string query = "datasource=localhost; port=3306; username=root; password=1234; charset=utf8mb4;";
        readonly MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234; charset=utf8mb4;");

        private void UserManagement_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(query))
                {
                    MySqlDataAdapter adap = new MySqlDataAdapter("select * from squad_library.user", conn);

                    conn.Open();

                    DataSet ds = new DataSet();
                    adap.Fill(ds, "userData");
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = ds;
                    dataGridView1.DataSource = ds.Tables["userData"];
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("회원정보 DB연결에 실패하였습니다. 다시 시도해주세요!");
            }
        }

        public void LoadData()
        {
            MySqlDataAdapter adap = new MySqlDataAdapter("select * from squad_library.user", conn);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM squad_library.user;", conn);

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

        // 신규 회원 등록
        private void NewUser_Click(object sender, EventArgs e)
        {
            String sqlQuery = "INSERT INTO squad_library.user (회원번호, 회원명, 아이디, 비밀번호, 생년월일, 성별, 등급, 회원상태, 대출금지일, 전화번호, 이메일, 주소, 메모) " +
            "VALUES (@회원번호, @회원명, @아이디, @비밀번호, @생년월일, @성별, @등급, @회원상태, @대출금지일, @전화번호, @이메일, @주소, @메모)";

            // 아이디는 15를 초과되면 안됨
            if(userID.TextLength > 15)
            {
                MessageBox.Show("아이디가 15자를 초과하였습니다.");
                userID.Text = "";
            } else if (userID.TextLength < 5)
            {
                MessageBox.Show("아이디가 5자 미만입니다.");
                userID.Text = "";
            } 
            else if (userID.Text == "")
            {
                MessageBox.Show("아이디를 입력하세요.");

            } else if(userName.Text == "") 
            {
                MessageBox.Show("회원명을 입력해주세요.");
            } else if(userPassword.Text == "")
            {
                MessageBox.Show("비밀번호를 입력해주세요.");
            } else
            {
                try
                {
                    conn.Open();
                    MySqlCommand myCommand = new MySqlCommand(sqlQuery, conn);

                    Random random = new Random();
                    int userNumRandom = random.Next(100000, 999999);

                    myCommand.Parameters.AddWithValue("@회원번호", userNumRandom);
                    myCommand.Parameters.AddWithValue("@회원명", userName.Text);
                    myCommand.Parameters.AddWithValue("@아이디", userID.Text);
                    myCommand.Parameters.AddWithValue("@비밀번호", userPassword.Text);
                    myCommand.Parameters.AddWithValue("@생년월일", userBirth.Text);
                    myCommand.Parameters.AddWithValue("@성별", userGender.Text);
                    myCommand.Parameters.AddWithValue("@등급", grade.Text);
                    myCommand.Parameters.AddWithValue("@회원상태", userStatus.Text);
                    myCommand.Parameters.AddWithValue("@대출금지일", noLoan.Text);
                    myCommand.Parameters.AddWithValue("@전화번호", userPhone.Text);
                    myCommand.Parameters.AddWithValue("@이메일", userEmail.Text);
                    myCommand.Parameters.AddWithValue("@주소", userAddress.Text);
                    myCommand.Parameters.AddWithValue("@메모", userMemo.Text);

                    MySqlDataReader myReader;
                    myReader = myCommand.ExecuteReader();

                    conn.Close();
                    MessageBox.Show("회원이 등록되었습니다.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            LoadData();
        }

        // 기존 회원 정보 수정
        private void button1_Click(object sender, EventArgs e)
        {
            string Query = "update squad_library.user set 회원명=@회원명, 아이디=@아이디, 비밀번호=@비밀번호, 생년월일=@생년월일, 성별=@성별, 등급=@등급, 회원상태=@회원상태, 대출금지일=@대출금지일, 전화번호=@전화번호, 이메일=@이메일, 주소=@주소, 메모=@메모 where 회원번호=@회원번호";
            MySqlCommand cmd = new MySqlCommand(Query, conn);

            conn.Open();
            cmd.Parameters.AddWithValue("@회원번호", userNum.Text);
            cmd.Parameters.AddWithValue("@회원명", userName.Text);
            cmd.Parameters.AddWithValue("@아이디", userID.Text);
            cmd.Parameters.AddWithValue("@비밀번호", userPassword.Text);
            cmd.Parameters.AddWithValue("@생년월일", userBirth.Text);
            cmd.Parameters.AddWithValue("@성별", userGender.Text);
            cmd.Parameters.AddWithValue("@등급", grade.Text);
            cmd.Parameters.AddWithValue("@회원상태", userStatus.Text);
            cmd.Parameters.AddWithValue("@대출금지일", noLoan.Text);
            cmd.Parameters.AddWithValue("@전화번호", userPhone.Text);
            cmd.Parameters.AddWithValue("@이메일", userEmail.Text);
            cmd.Parameters.AddWithValue("@주소", userAddress.Text);
            cmd.Parameters.AddWithValue("@메모", userMemo.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("수정 완료");
            DataTable datatable = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(datatable);
            dataGridView1.DataSource = datatable;

            LoadData();

            userID.Text = "";
            userName.Text = "";
            userGender.Text = "";
            grade.Text = "";
            userStatus.Text = "";
            yesLoan.Text = "";
            noLoan.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            userPhone.Text = "";
            userEmail.Text = "";
            userAddress.Text = "";
            userMemo.Text = "";
        }

        // 회원 정보 삭제
        private void button2_Click(object sender, EventArgs e)
        {
            if (userID.Text == "")
            {
                MessageBox.Show("삭제 할 항목을 찾지 못했습니다.");
            }
            else
            {
                //delete를 통해 DB로 삭제된 데이터 전송 - 기본키 기준으로 삭제위치 탐색
                string Query = "delete from squad_library.user where 회원번호 ='" + this.userNum.Text + "';";
                string rentQuery = "delete from squad_library.bookrent where 회원번호 = @회원번호";
                MySqlConnection rentConnection = new MySqlConnection(query);
                MySqlCommand rentDelete = new MySqlCommand(rentQuery, rentConnection);
                rentDelete.Parameters.AddWithValue("@회원번호", userNum.Text);

                MySqlConnection conDataBase = new MySqlConnection(query);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                try
                {
                    conDataBase.Open();
                    myReader = cmdDatabase.ExecuteReader();

                    while (myReader.Read())
                    {
                        int query = cmdDatabase.ExecuteNonQuery(); // 삭제를 진행하고 영향을 받은 행의 수를 반환
                        int rentEx = rentDelete.ExecuteNonQuery();

                        if (query > 0 || rentEx > 0)
                        {
                            MessageBox.Show("회원 정보를 삭제했습니다.");
                        }
                        else
                        {
                            MessageBox.Show("회원 정보를 삭제할 수 없습니다.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                LoadData();
            }
        }

        // 회원 정보
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                userNum.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); // 회원번호
                userName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); // 회원명
                userID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(); // 아이디
                userPassword.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(); // 비밀번호
                userBirth.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(); // 생년월일
                userGender.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(); // 성별
                grade.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(); // 등급
                userStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString(); // 회원 상태
                noLoan.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString(); // 대출금지일
                userPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString(); // 전화번호
                userEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString(); // 이메일
                userAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString(); // 주소
                userMemo.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString(); // 메모

                using (MySqlConnection connection = new MySqlConnection(query))
                {
                    MySqlCommand mySqlCommand = new MySqlCommand("select count(*) from squad_library.user user join squad_library.bookrent rent on user.회원번호 = rent.회원번호 where rent.회원번호 = @회원번호", connection);
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0]; // 회원번호
                    mySqlCommand.Parameters.AddWithValue("@회원번호", selectedRow);
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);

                    connection.Open();

                    int resultNum = mySqlCommand.ExecuteNonQuery();
                    yesLoan.Text = (5 - resultNum).ToString(); // 대출 가능 권 수
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 검색 기능
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text == "회원명")
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *  FROM squad_library.user where 회원명 = '" + this.textBox6.Text + "'", conn);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    conn.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "user");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["user"];  // 테이블 보이기

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("검색에 실패하였습니다.");
                }
            }
            else if(comboBox4.Text == "회원번호")
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *  FROM squad_library.user where 회원번호 = '" + this.textBox6.Text + "'", conn);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    conn.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "user");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["user"];  // 테이블 보이기

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("검색에 실패하였습니다.");
                }
            } else if(comboBox4.Text == "전화번호")
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *  FROM squad_library.user where 전화번호 = '" + this.textBox6.Text + "'", conn);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    conn.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "user");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["user"];  // 테이블 보이기

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("검색에 실패하였습니다.");
                }
            } else if(comboBox4.Text == "아이디")
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *  FROM squad_library.user where 아이디 = '" + this.textBox6.Text + "'", conn);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    conn.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "user");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["user"];  // 테이블 보이기

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("검색에 실패하였습니다.");
                }
            } else if(comboBox4.Text == "등급")
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *  FROM squad_library.user where 등급 = '" + this.textBox6.Text + "'", conn);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    conn.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "user");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["user"];  // 테이블 보이기

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("검색에 실패하였습니다.");
                }
            } else if(comboBox4.Text == "회원상태")
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *  FROM squad_library.user where 회원상태 = '" + this.textBox6.Text + "'", conn);  // 콤보 박스 옆에 텍스트 박스 값 DB에 넣기

                    conn.Open();  // DB 연결 시작

                    DataSet ds = new DataSet();  //DataSet에 데이터 넣음
                    adapter.Fill(ds, "user");  //search1 테이블 채우기
                    dataGridView1.DataSource = ds.Tables["user"];  // 테이블 보이기

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("검색에 실패하였습니다.");
                }
            }
           
        }

        // 새로 고침
        private void button5_Click(object sender, EventArgs e)
        {
            userNum.Text = ""; // 회원번호
            userName.Text = ""; // 회원명
            userID.Text = ""; // 아이디
            userPassword.Text = ""; // 비밀번호
            userBirth.Text = ""; // 생년월일
            userGender.Text = ""; // 성별
            grade.Text = ""; // 등급
            userStatus.Text = ""; // 회원상태
            userPhone.Text = ""; // 전화번호
            userEmail.Text = ""; // 이메일
            yesLoan.Text = ""; // 대출 가능
            noLoan.Text = ""; // 대출 금지
            textBox10.Text = ""; // 신청도서
            textBox11.Text = ""; // 구매도서
            userAddress.Text = ""; // 주소
            userMemo.Text = ""; // 메모

            LoadData();
        }
    }
}
