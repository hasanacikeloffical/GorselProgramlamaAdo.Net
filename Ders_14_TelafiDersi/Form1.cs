using CrystalDecisions.CrystalReports.Engine;
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

namespace Ders_14_TelafiDersi
    {
    public partial class Form1 :Form
        {
        
        string connectionString = @"Data Source=DESKTOP-KM10E7C;Integrated Security=True;initial catalog=MusteriSiparis";

        public Form1()
            {
            InitializeComponent();
            }
        
        private void TumMusteriRaporu()
            {
            DataTable dt = new DataTable();

            using(SqlConnection baglanti = new SqlConnection(connectionString))
                {
                string query = @"SELECT [Id],[Ad],[Soyad],[Sehir],[Ulke],[Telefon] FROM [dbo].[Musteri]";

                SqlDataAdapter adapter = new SqlDataAdapter(query,baglanti);
                adapter.Fill(dt);
                }
            RaporuGoster(dt); 
            }

        private void RaporuGoster(DataTable Veritablosu)
            {
            ReportDocument rapor = new ReportDocument(); 
            try
                {
                string yol = Application.StartupPath + "\\MusteriRaporu.rpt";   // projenin çalýþtýðý klasörün yerini gösteren metottur.raporun yolunu buldu
                rapor.Load(yol); // raporu bulup açmasýný saðlayan metottur. raporu açtý.
                rapor.SetDataSource(Veritablosu); // içini veri ile doldurdun.
                crystalReportViewer1.ReportSource = rapor; // ekrandaki göstericiye baðladýn.
                crystalReportViewer1.Refresh(); // ekraný tazeleyerek kullanýcýya gösterdin.
                }
            catch(Exception ex) 
                {
                MessageBox.Show("Rapor yüklenirken bir hata oluþtu");
                }         
            }

        private void button1_Click(object sender,EventArgs e)
            {
            TumMusteriRaporu();
            }
        }
    }
