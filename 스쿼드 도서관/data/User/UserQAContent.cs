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
    public partial class UserQAContent : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=squad_library;Uid=root;Pwd=qkrwltn5130!;");


        public UserQAContent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("제목을 입력해주세요.");
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("내용을 입력해주세요.");
            }
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("일반인지 익명인지 선택하세요.");
            }

            else
            {

                string insertQuery = "INSERT INTO squad_library.question1(제목,내용,작성일) VALUES('" + textBox1.Text + "','" + textBox2.Text + "',now())";

                connection.Open();

                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                try//예외 처리
                {

                    // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻이다
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("글 작성 완료");
                    }
                    else
                    {
                        MessageBox.Show("글 작성 실패");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                connection.Close();
            }
        }

        private void QAcontent_Load(object sender, EventArgs e)
        {

        }
    }
}
