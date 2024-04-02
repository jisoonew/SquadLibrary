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
    public partial class UserRecommend : Form
    {
        public UserRecommend()
        {
            InitializeComponent();
        }

        private void user_recommend_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234");
                MySqlDataAdapter adap = new MySqlDataAdapter("select * from squad_library.user_recommend", conn);

                conn.Open();

                DataSet ds = new DataSet();
                adap.Fill(ds, "user_recommend");
                dataGridView1.DataSource = ds.Tables["user_recommend"];

                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None; // 도서 번호
                dataGridView1.Columns[0].Width = 80;

                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None; // 도서명
                dataGridView1.Columns[1].Width = 200;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("회원정보 DB 연결에 실패하였습니다.");
            }

           
        }

    }
}
