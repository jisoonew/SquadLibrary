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
    public partial class UserDetailsBookInformation : Form
    {
        public UserDetailsBookInformation()
        {
            InitializeComponent();
        }

        private void User_Search4_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Long;
            dateTimePicker1.Value = DateTime.Now.AddDays(14);
            label10.Text = DateTime.Now.ToString("yyyy-MM-dd");
            label12.Text = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            dateTimePicker1.Value = DateTime.Now;

            string myconnect = "datasource = localhost; port = 3306; username=root; password=qkrwltn5130!;";
            string query = "INSERT INTO squad_library.userbookrental values('" + this.textBox2.Text + "', '" + this.textBox10.Text + "', '" + this.textBox8.Text + "', '" + this.textBox1.Text + "', '" + this.textBox7.Text + "', '"+this.label10.Text+ "', '" + this.label12.Text + "');";


            MySqlConnection myconn = new MySqlConnection(myconnect);

            MySqlCommand cmd = new MySqlCommand(query, myconn);

            MySqlDataReader myReader;

            try
            {
                myconn.Open();

                myReader = cmd.ExecuteReader();
                MessageBox.Show("대여했습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("이미 대여한 도서입니다.");
            }
        }
    }
}
