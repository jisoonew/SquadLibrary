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
    public partial class user_recommend : Form
    {
        public user_recommend()
        {
            InitializeComponent();
        }

        private void user_recommend_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=qkrwltn5130!");
                MySqlDataAdapter adap = new MySqlDataAdapter("select * from squad_library.user_recommend", conn);

                conn.Open();

                DataSet ds = new DataSet();
                adap.Fill(ds, "user_recommend");
                dataGridView1.DataSource = ds.Tables["user_recommend"];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("회원정보 DB 연결에 실패하였습니다.");
            }

           
        }
    }
}
