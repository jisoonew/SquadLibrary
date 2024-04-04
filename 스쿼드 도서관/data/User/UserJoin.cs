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
    public partial class UserJoin : Form
    {
      
        public UserJoin()
        {
            InitializeComponent();
        }

        private MySqlConnection connection = new MySqlConnection("datasource = localhost; port = 3306; username=root; password=1234; CharSet=utf8mb4;");
        private int PasswordCheckCount = 0;

        void JoinNewUser(int random, string gender)
        {
            string queryMan = "INSERT INTO squad_library.user (회원번호, 회원명, 아이디, 비밀번호, 생년월일, 성별, 등급, 회원상태, 대출금지일, 전화번호, 이메일, 주소) " +
            "VALUES (@회원번호, @회원명, @아이디, @비밀번호, @생년월일, @성별, @등급, @회원상태, @대출금지일, @전화번호, @이메일, @주소)";

            MySqlCommand myCommand = new MySqlCommand(queryMan, connection);

            myCommand.Parameters.AddWithValue("@회원번호", random);
            myCommand.Parameters.AddWithValue("@회원명", userName.Text);
            myCommand.Parameters.AddWithValue("@아이디", userID.Text);
            myCommand.Parameters.AddWithValue("@비밀번호", userPassword.Text);
            myCommand.Parameters.AddWithValue("@생년월일", userBirth.Text);
            myCommand.Parameters.AddWithValue("@성별", gender);
            myCommand.Parameters.AddWithValue("@등급", "회원");
            myCommand.Parameters.AddWithValue("@회원상태", "대출 가능");
            myCommand.Parameters.AddWithValue("@대출금지일", DBNull.Value); // 값이 없는 경우 DBNull.Value로 설정
            myCommand.Parameters.AddWithValue("@전화번호", userPhone.Text);
            myCommand.Parameters.AddWithValue("@이메일", $"{userEmail.Text}@{userDomain.Text}");
            myCommand.Parameters.AddWithValue("@주소", $"{userRoadAddress.Text} {userDetailAddress.Text}");

            MySqlDataReader myReader;

            try
            {
                myReader = myCommand.ExecuteReader();
                connection.Close();
                MessageBox.Show("회원 가입이 완료되었습니다.");
                this.Hide();
                UserLogin userLogin = new UserLogin();
                userLogin.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 회원가입
        private void Button3_Click(object sender, EventArgs e)
        {
            String userId = userID.Text;

            int userIdLength;
            userIdLength = userId.Length;

            if (userIdLength > 15)
            {
                MessageBox.Show("아이디가 15자를 초과하였습니다.");
                userId = "";
            }
            else if (userIdLength < 5)
            {
                MessageBox.Show("아이디가 5자 미만입니다.");
                userId = "";
            }
            else
            {
                // 사용자가 남자 회원이라면 && 비밀번호 중복 확인
                if (userMan.Checked == true && PasswordCheckCount == 1)
                {
                    Random random = new Random();
                    int randomNumber = random.Next(100000, 999999); // 총 6자리의 랜덤 값을 회원 번호로 지정

                    int restartRandom = random.Next(100000, 999999); // 회원번호가 중복 되었을 때 사용한다.

                    MySqlCommand command = new MySqlCommand("select 회원번호 from squad_library.user where 회원번호 = '" + randomNumber.ToString() + "'", connection);

                    MySqlDataReader dataReader;

                    try
                    {
                        connection.Open();

                        dataReader = command.ExecuteReader();

                        // 만약 DB에 회원번호가 중복된다면, 랜덤 값 다시 받기
                        if (dataReader.Read())
                        {
                            dataReader.Close();

                            JoinNewUser(restartRandom, "남자");
                        }
                        else // 회원번호가 중복되지 않다면 회원가입 진행
                        {
                            dataReader.Close();

                            JoinNewUser(randomNumber, "남자");
                            
                        }

                        dataReader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close(); // 예외 발생 시에도 연결 닫기
                        }
                    }
                }

                // 사용자가 여자 회원이라면 && 비밀번호 중복 확인
                else if (userWoman.Checked == true && PasswordCheckCount == 1)
                {
                    Random random = new Random();
                    int randomWoman = random.Next(100000, 999999); // 총 6자리의 랜덤 값을 회원 번호로 지정

                    MySqlCommand command = new MySqlCommand("select '회원번호' from squad_library.user where 회원번호 = '" + randomWoman.ToString() + "'", connection);

                    MySqlDataReader dataReader;

                    connection.Open();

                    dataReader = command.ExecuteReader();

                    // 만약 DB에 회원번호가 중복된다면, 랜덤 값 다시 받기
                    if (dataReader.Read())
                    {
                        dataReader.Close();

                        int restartRandomWoman = random.Next(100000, 999999); // 총 6자리의 랜덤 값을 회원 번호로 지정

                        JoinNewUser(restartRandomWoman, "여자");

                    }
                    else // 회원번호가 중복되지 않다면 회원가입 진행
                    {
                        dataReader.Close();

                        JoinNewUser(randomWoman, "여자");
                    }
                }

                else if (PasswordCheckCount == 0)
                {
                    MessageBox.Show("비밀번호 중복 확인을 해주세요!");
                }

                else
                {
                    MessageBox.Show("성별을 입력해주세요!");
                }
            }

            userMan.CheckedChanged += uiRdb_Button_CheckedChanged;

            userWoman.CheckedChanged += uiRdb_Button_CheckedChanged;

            void uiRdb_Button_CheckedChanged(object a, EventArgs b)
            {
                RadioButton btn = a as RadioButton;
                string msg = string.Empty;

                if (btn.Checked == false)
                {//라디오 버튼 컨트롤 체크 안되어 있으면
                    return;
                }
            }
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            String en = userID.Text;

            int en1, ko1;
            en1 = en.Length;

            try
            {
                // 쿼리를 보내고 실행한다.
                MySqlCommand SelecCommand = new MySqlCommand("select * from squad_library.user where 아이디 = '" + this.userID.Text + "'", connection);
                // 데이터를 읽어온다.
                MySqlDataReader reader;

                connection.Open();

                reader = SelecCommand.ExecuteReader(); // ExecuteReader 쿼리를 실행 이후의 결과 값을 reader로 읽어온다.
                int count = 0;

                while (reader.Read())
                {
                    count += 1;
                }

                if (count == 1)
                {
                    MessageBox.Show("사용하고 있는 아이디입니다.");
                    userID.Text = "";
                }
                else if (en1 > 15)
                {
                    MessageBox.Show("15자를 초과했습니다.");
                    userID.Text = "";
                }
                else if (en1 < 5)
                {
                    MessageBox.Show("5자 미만입니다.");
                    userID.Text = "";
                }
                else
                {
                    MessageBox.Show("사용할 수 있는 아이디입니다.");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (userPassword.Text == userPasswordCheck.Text)
                {
                    MessageBox.Show("비밀번호가 일치합니다.");
                    PasswordCheckCount += 1;
                }
                else if (userPassword.Text != userPasswordCheck.Text)
                {
                    MessageBox.Show("비밀번호가 일치하지 않습니다. 다시 입력해주세요.");
                    userPassword.Text = "";
                    userPasswordCheck.Text = "";
                } else if (userPassword.Text == "" || userPasswordCheck.Text == "")
                {
                    MessageBox.Show("비밀번호를 입력해주세요.");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetString(int v)
        {
            throw new NotImplementedException();
        }
    }
}
