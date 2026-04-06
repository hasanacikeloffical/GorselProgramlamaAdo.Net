using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
    {
    public partial class ders_5 :Form
        {
        public ders_5()
            {
            InitializeComponent();
            }
        SqlConnection SqlConnection;
        string Database = @"Data Source=DESKTOP-KM10E7C;Initial Catalog=MusteriSiparis;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";


        private void ders_5_Load(object sender,EventArgs e)
            {
            SqlConnection = new SqlConnection(Database);
            SqlConnection.Open();
            string sql = "select distinct Ulke from Musteri";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql,SqlConnection);
            DataTable _dataTable = new DataTable();
            dataAdapter.Fill(_dataTable);

            Ulkeler.DataSource = _dataTable;
            Ulkeler.DisplayMember = "Ulke";   // veri alma ardýndan listeleme iþlemi bu þekilde yapýlýr.

            //foreach (DataRow _dataRow in _dataTable.Rows)
            //    {
            //        Ulkeler.Items.Add(_dataRow["Ulke"].ToString());
            //    }  bu listeleme iþlemi 




            }

        private void Ulkeler_SelectedIndexChanged(object sender,EventArgs e)
            {
               string sql = $"select distinct Sehir from Musteri where ulke = @ulke_";
            SqlCommand _sqlcommand = new SqlCommand(sql,SqlConnection);
            _sqlcommand.Parameters.AddWithValue("ulke_",Ulkeler.Text);

            SqlDataAdapter _dataAtapter = new SqlDataAdapter(_sqlcommand);
              DataTable _dataTable = new DataTable();
            _dataAtapter.Fill(_dataTable);

            sehirler.DataSource = _dataTable;
            sehirler.DisplayMember = "Sehir";


            
            }

        

        private void sehirler_SelectedIndexChanged(object sender,EventArgs e)
            {
                Filters();
            }

        

        private void textBox1_TextChanged(object sender,EventArgs e)
            {
               Filters();
            }


        private void Filters()
            {
            // listeleme iþlemi yapýldý.
            string sql = $"select * from Musteri where sehir = @sehir_";
            if(textBox1.Text.Trim().Length > 0)
            {
                sql += $" and (Ad like '%{textBox1.Text.Trim()}%' or Soyad like '%{textBox1.Text.Trim()}%')";
            }

            if(textBox2.Text.Trim().Length > 0) 
                {
                sql += $" and Telefon like '%{textBox2.Text.Trim()}%'"; 
                }
            SqlCommand _sqlcommand = new SqlCommand(sql,SqlConnection);
            _sqlcommand.Parameters.AddWithValue("sehir_",sehirler.Text);

            SqlDataAdapter _dataAtapter = new SqlDataAdapter(_sqlcommand);
            DataTable _dataTable = new DataTable();
            _dataAtapter.Fill(_dataTable);

            dataGridView1.DataSource = _dataTable;


            }

        private void textBox2_TextChanged(object sender,EventArgs e)
            {
             Filters();
            }

         private void dataGridView1_SelectionChanged(object sender,EventArgs e)
            {
            string sql = $"Select * from Siparis where Musteri_Id = @musteriId";
            SqlCommand _sqlCommand = new SqlCommand(sql,SqlConnection);
            int MusteriNo = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Id"].Value); // datagridview üzerinden seçilen satýrýn id'sini alarak sipariþleri listeleme iþlemi yapýldý.
            _sqlCommand.Parameters.AddWithValue("musteriId",MusteriNo);

            SqlDataAdapter _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
            DataTable _dataTable = new DataTable();
            _sqlDataAdapter.Fill(_dataTable);
            dataGridView2.DataSource = _dataTable;
            }
        }
    }
