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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
    {
    public partial class ders_6 :Form
        {
        public ders_6()
            {
            InitializeComponent();
            }
        SqlConnection SqlConnection;
        string Database = @"Data Source=DESKTOP-KM10E7C;Initial Catalog=MusteriSiparis;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        private void button1_Click(object sender,EventArgs e)
            {
            string sorgu = @" select
                           m.Id,
                           m.Ad + '  ' + m.Soyad AdSoyad,
                           m.Ulke,
                           max(s.SiparisTarih) SiparisTarih,
                           avg(s.ToplamTutar) OrtalamaTutar
                           from
                           Musteri m
                           join Siparis s on s.Musteri_Id = m.Id
                           group by
                           m.Id,
                           m.Ad,
                           m.Soyad,
                           m.Ulke";

            // burada veri kaynaðý ile denetim arasýnda köprü görevi gören bir kodtur.
            // desing ve yönlendirme iþlemlerinde bana yardýmcý olacaktýr. 
            SqlDataAdapter _sqlDataAdapter = new SqlDataAdapter(sorgu, Database);
            DataTable _dataTable = new DataTable();
            _sqlDataAdapter.Fill(_dataTable);

            BindingSource _BindingSource = new BindingSource();
            _BindingSource.DataSource = _dataTable;
            dataGridView1.DataSource = _BindingSource;
            
            dataGridView1.Columns.Clear(); // DataGridView'in mevcut sütunlarýný temizledik.

            DataGridViewTextBoxColumn textBoxColumnID = new DataGridViewTextBoxColumn();
            textBoxColumnID.Name = "MusteriId"; // Kimlik bilgisi için bir isim verdik.
            textBoxColumnID.HeaderText = "Id";  // Baþlýk bilgisi için bir isim verdik.
            textBoxColumnID.DataPropertyName = "Id";  // Veri kaynaðýndaki hangi sütunla eþleþtirileceðini belirttik.
            textBoxColumnID.Width = 50; // Sütun geniþliðini belirledik.
            textBoxColumnID.ReadOnly = true; // Sütunu salt okunur yaparak düzenlenmesini engelledik.
            dataGridView1.Columns.Add(textBoxColumnID); // DataGridView'e yeni bir sütun ekledik.

            DataGridViewTextBoxColumn textBoxColumnName = new DataGridViewTextBoxColumn();
            textBoxColumnName.Name = "MusteriAdSoyad"; // Kimlik bilgisi için bir isim verdik.
            textBoxColumnName.HeaderText = "Ad Soyad";  // Baþlýk bilgisi için bir isim verdik.
            textBoxColumnName.DataPropertyName = "AdSoyad";  // Veri kaynaðýndaki hangi sütunla eþleþtirileceðini belirttik.
            textBoxColumnName.Width = 150; // Sütun geniþliðini belirledik.
            textBoxColumnName.ReadOnly = true; // Sütunu salt okunur yaparak düzenlenmesini engelledik.
            dataGridView1.Columns.Add(textBoxColumnName); // DataGridView'e yeni bir sütun ekledik.

            DataGridViewComboBoxColumn dataGridViewComboBoxColumnUlke = new DataGridViewComboBoxColumn();
            dataGridViewComboBoxColumnUlke.Name = "MusteriUlke"; // Kimlik bilgisi için bir isim verdik.
            dataGridViewComboBoxColumnUlke.HeaderText = "Müþteri Ülkeleri";  // Baþlýk bilgisi için bir isim verdik.
            dataGridViewComboBoxColumnUlke.DataPropertyName = "Ulke";  // Veri kaynaðýndaki hangi sütunla eþleþtirileceðini belirttik.
            dataGridViewComboBoxColumnUlke.Width = 120; // Sütun geniþliðini belirledik.
            dataGridViewComboBoxColumnUlke.Items.AddRange("Argentina",
                                                           "Austria",
                                                           "Belgium",
                                                           "Brazil",
                                                           "Canada",
                                                           "Denmark",
                                                           "Finland",
                                                           "France",
                                                           "Germany",
                                                           "Ireland",
                                                           "Italy",
                                                           "Mexico",
                                                           "Norway",
                                                           "Poland",
                                                           "Portugal",
                                                           "Spain",
                                                           "Sweden",
                                                           "Switzerland",
                                                           "UK",
                                                           "USA",
                                                           "Venezuela");
            dataGridView1.Columns.Add(dataGridViewComboBoxColumnUlke); // DataGridView'e yeni bir sütun ekledik.

            DataGridViewTextBoxColumn dataGridViewTextBoxColumnTarih = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumnTarih.Name = "SiparisTarih"; // Kimlik bilgisi için bir isim verdik.
            dataGridViewTextBoxColumnTarih.HeaderText = "Sipariþ Tarihi";  // Baþlýk bilgisi için bir isim verdik.
            dataGridViewTextBoxColumnTarih.DataPropertyName = "SiparisTarih";  // Veri kaynaðýndaki hangi sütunla eþleþtirileceðini belirttik.
            dataGridViewTextBoxColumnTarih.Width = 120; // Sütun geniþliðini belirledik.
            dataGridViewTextBoxColumnTarih.DefaultCellStyle.BackColor = Color.LightYellow; // Hücrelerin arka plan rengini açýk sarý olarak belirledik.
            dataGridViewTextBoxColumnTarih.DefaultCellStyle.Format = "dd/MM/yyyy"; // Hücrelerdeki tarih formatýný gün/ay/yýl olarak belirledik.
            dataGridViewTextBoxColumnTarih.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Hücrelerdeki metni ortalayarak hizaladýk.
            dataGridView1.Columns.Add(dataGridViewTextBoxColumnTarih); // DataGridView'e yeni bir sütun ekledik.


            DataGridViewTextBoxColumn dataGridViewTextBoxColumnTutar = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumnTutar.Name = "OrtalamaTutar"; // Kimlik bilgisi için bir isim verdik.
            dataGridViewTextBoxColumnTutar.HeaderText = "Ortalama Tutar";  // Baþlýk bilgisi için bir isim verdik.
            dataGridViewTextBoxColumnTutar.DataPropertyName = "OrtalamaTutar";  // Veri kaynaðýndaki hangi sütunla eþleþtirileceðini belirttik.
            dataGridViewTextBoxColumnTutar.Width = 70; // Sütun geniþliðini belirledik.
            dataGridViewTextBoxColumnTutar.DefaultCellStyle.BackColor = Color.LightCyan; // Hücrelerin arka plan rengini açýk camgöbeði olarak belirledik.
            dataGridViewTextBoxColumnTutar.DefaultCellStyle.Format = "C2"; // iki ondalýk basamaklý para birimi formatýný belirledik.
            dataGridView1.Columns.Add(dataGridViewTextBoxColumnTutar); // DataGridView'e yeni bir sütun ekledik.

            DataGridViewButtonColumn dataGridViewButtonColumnButton = new DataGridViewButtonColumn();
            dataGridViewButtonColumnButton.Name = "Sil";  // Kimlik bilgisi için bir isim verdik.
            dataGridViewButtonColumnButton.HeaderText = "Ýþlem";  // Baþlýk bilgisi için bir isim verdik.
            dataGridViewButtonColumnButton.Text = "Sil";  // Butonun üzerinde görünecek metni belirledik.
            dataGridViewButtonColumnButton.UseColumnTextForButtonValue = true; // Butonun deðerini metin olarak kullanmasýný saðladýk.
            dataGridViewButtonColumnButton.Width = 50; // Sütun geniþliðini belirledik.
            dataGridView1.Columns.Add(dataGridViewButtonColumnButton); // DataGridView'e yeni bir sütun ekledik.

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // çift  satýrlarý arka plan rengini açýk gri olarak belirledik.
            
            
            }
        }
    
    }
