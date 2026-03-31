using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
    {
    public partial class Form1 :Form
        {
        public Form1()
            {
            InitializeComponent();
            }

        private void button1_Click(object sender,EventArgs e)
            {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=DESKTOP-KM10E7C;Initial Catalog=GorselProgramlama;Integrated Security=True";
            connection.Open();
            MessageBox.Show("Baðlantý Açýldý");

            SqlDataAdapter data = new SqlDataAdapter();
            data.SelectCommand.CommandText = "Select * From Musteri";
            data.SelectCommand.Connection = connection;

            DataTable dt = new DataTable();
            data.Fill(dt);
            MessageBox.Show("Veriler Getirildi");
            }
        }
    }
