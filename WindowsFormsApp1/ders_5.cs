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
            // listeleme iþlemi yapýldý.
            string sql = $"select * from Musteri where sehir = @sehir_";
            SqlCommand _sqlcommand = new SqlCommand(sql,SqlConnection);
            _sqlcommand.Parameters.AddWithValue("sehir_",sehirler.Text);

            SqlDataAdapter _dataAtapter = new SqlDataAdapter(_sqlcommand);
            DataTable _dataTable = new DataTable();
            _dataAtapter.Fill(_dataTable);

            dataGridView1.DataSource = _dataTable;


            }
        }
    }
