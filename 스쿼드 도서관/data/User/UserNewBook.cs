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
    public partial class UserNewBook : Form
    {
        public UserNewBook()
        {
            InitializeComponent();
        }

        private void usernewbook_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=1234");
                MySqlDataAdapter adap = new MySqlDataAdapter("select 도서명, 도서번호, 글쓴이, 출판사, 출판일, 페이지, 도서가격, 도서상태, 대출여부,메모 from squad_library.search1", conn);

                conn.Open();

                DataSet ds = new DataSet();
                adap.Fill(ds, "alluser");
                dataGridView1.DataSource = ds.Tables["alluser"];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("회원정보 DB 연결에 실패하였습니다.");
            }
        }
    }
}
