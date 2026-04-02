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
            // db baðlantýsý
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=DESKTOP-KM10E7C;Initial Catalog=MusteriSiparis;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            connection.Open();
            MessageBox.Show("Baðlantý Baþarýlý");

            // burada veri çekme iþlemleri için kullanýlýr.
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Musteri", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            MessageBox.Show("veri çekme iþlemi baþarýlý");
            // dtset içerisinde datatable tanýmlamak zorundayýz çünkü dset içerisinde birden fazla datatable olabilir. dset içerisinde barýnmaktadýr.

            dataGridView1.DataSource = dataTable;

            MessageBox.Show(dataTable.Columns.Count.ToString());
            
            //foreach(DataColumn column in dataTable.Columns)
            //    {
                 
            //    }
            }
        
        }
    }
