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

        

        private void listBox1_SelectedIndexChanged(object sender,EventArgs e)
            {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=DESKTOP-KM10E7C;Initial Catalog=MusteriSiparis;Integrated Security=True";
            connection.Open();
            var data = new SqlDataAdapter("Select * From Musteri",connection);
            DataTable dataTable = new DataTable();
            data.Fill(dataTable);
            listBox1.DisplayMember = "MusteriAd";
            listBox1.ValueMember = "MusteriId";
            listBox1.DataSource = dataTable;

            }

        private void button1_Click(object sender,EventArgs e)
            {
               MessageBox.Show("Seçilen Müþteri Id: " + listBox1.SelectedValue.ToString());
            }
        }
    }
