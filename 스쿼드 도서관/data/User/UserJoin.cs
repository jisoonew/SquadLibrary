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

        private MySqlConnection connection = new MySqlConnection("datasource = localhost; port = 3306; username=root; password=1234");

        private void User_login1_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("select '회원명','성별','생년월일', '전화번호', '이메일', '이메일2', '아이디','비밀번호','주소','주소2'", connection);

                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "mydata");

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            String en = textBox5.Text;

            int en1;
            en1 = en.Length;

            if (en1 > 15)
            {
                MessageBox.Show("아이디가 15자를 초과하였습니다.");
                en = "";
            }
            else if (en1 < 5)
            {
                MessageBox.Show("아이디가 5자 미만입니다.");
                en = "";
            }
            else
            {
                MessageBox.Show("아이디 조건에 부합합니다.");
            }

            radioButton1.CheckedChanged += uiRdb_Button_CheckedChanged;

            radioButton2.CheckedChanged += uiRdb_Button_CheckedChanged;

            void uiRdb_Button_CheckedChanged(object a, EventArgs b)
            {
                RadioButton btn = a as RadioButton;
                string msg = string.Empty;

                if (btn.Checked == false)
                {//라디오 버튼 컨트롤 체크 안되어 있으면
                    return;
                }

                msg = string.Format("체크하신 RadioButton은 {0} 번 버튼입니다.", btn.Name);

                MessageBox.Show(msg);
            }

            if (radioButton1.Checked == true)
            {
                string query = "insert into squad_library.mydata(회원명, 성별, 생년월일, 전화번호, 이메일, 이메일2, 아이디,비밀번호,주소,주소2)" +
                    "value('" + textBox1.Text + "', '" + radioButton1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";

                MySqlCommand mycommand = new MySqlCommand(query, connection);

                MySqlDataReader myReader;
                try
                {

                    connection.Open();
                    myReader = mycommand.ExecuteReader();

                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if(radioButton2.Checked == true)
            {
                string query = "insert into squad_library.mydata(회원명, 성별, 생년월일, 전화번호, 이메일, 이메일2, 아이디,비밀번호,주소,주소2)" +
                    "value('" + textBox1.Text + "', '" + radioButton2.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";

                MySqlCommand mycommand = new MySqlCommand(query, connection);


                MySqlDataReader myReader;
                try
                {

                    connection.Open();
                    myReader = mycommand.ExecuteReader();

                    MessageBox.Show("일반회원으로 등록되었습니다.");

                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else
            {
                MessageBox.Show("성별을 입력해주세요!");
            }

            LoadData();

            
        }


        private void LoadData()
        {
            MySqlCommand cmd_db = new MySqlCommand("SELECT 회원명,성별,생년월일, 전화번호, 이메일, 이메일2, 아이디,비밀번호,주소,주소2  FROM squad_library.mydata;", connection);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd_db;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String en = textBox5.Text;

            int en1, ko1;
            en1 = en.Length;

            try
            {
                MySqlCommand SelecCommand = new MySqlCommand("select '회원명','성별','생년월일', '전화번호', '이메일', '이메일2', '아이디','비밀번호','주소','주소2' from squad_library.mydata where 아이디 = '"+this.textBox5.Text+"'", connection);
                MySqlDataReader reader;

                connection.Open();

                reader = SelecCommand.ExecuteReader();
                int count = 0;

                while (reader.Read())
                {
                    count = count + 1;
                }

                if (count == 1)
                {
                    MessageBox.Show("사용하고 있는 아이디입니다.");
                    textBox5.Text = "";
                }
                else if (en1 > 15)
                {
                    MessageBox.Show("15자를 초과했습니다.");
                    textBox5.Text = "";
                }
                else if (en1 < 5)
                {
                    MessageBox.Show("5자 미만입니다.");
                    textBox5.Text = "";
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
                if (textBox6.Text == textBox7.Text)
                {
                    MessageBox.Show("비밀번호가 일치합니다.");
                }
                else if (textBox6.Text != textBox7.Text)
                {
                    MessageBox.Show("비밀번호가 일치하지 않습니다. 다시 입력해주세요.");
                    textBox6.Text = "";
                    textBox7.Text = "";
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
