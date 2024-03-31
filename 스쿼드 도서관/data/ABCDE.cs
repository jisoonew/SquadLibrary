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
    public partial class ABCDE : Form
    {
        public ABCDE()
        {
            InitializeComponent();
        }

        private void practice_Load(object sender, EventArgs e)
        {
            string myConnection = "datasource=localhost;port=3306;username=root;password=1234";
            MySqlConnection myConn = new MySqlConnection(myConnection);

            MySqlCommand SelectCommand = new MySqlCommand("select * from squad_library.mydata", myConn);
            MySqlDataReader myReader;
            myConn.Open();
        }
    }
}
