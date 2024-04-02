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
    public partial class UserOverdue : UserControl
    {
        public UserOverdue()
        {
            InitializeComponent();
        }

        private void Useroverdue_Load(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=qkrwltn5130!");
                MySqlDataAdapter adapter = new MySqlDataAdapter("select * from squad_library.bookoverdue", connection);

                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "bookoverdue");
                dataGridView1.DataSource = ds.Tables["bookoverdue"];

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
