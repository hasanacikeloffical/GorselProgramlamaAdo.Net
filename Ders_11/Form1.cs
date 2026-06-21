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

namespace Ders_11
    {
    public partial class Form1 :Form
        {
        BindingSource bs;
        DataTable dt;
        public Form1()
            {
            InitializeComponent();
            }

        private void Form1_Load(object sender,EventArgs e)
            {
            string Contact = @"Data Source=DESKTOP-KM10E7C;Initial Catalog=MusteriSiparis;Integrated Security=True;";
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Musteri",Contact);
            dt = new DataTable();
            adp.Fill(dt);

            bs = new BindingSource(); // front kýsmýnda istediðim þeyleri yapmamýzý saðlar. yani veritabanýna gidip gelme yapmaz.
            bs.DataSource = dt;

            dataGridView1.DataSource = bs;
            bindingNavigator1.BindingSource = bs;

            bs.ListChanged += bs_ListChanged; // listede deðiþiklik olduðunda bs_ListChanged metodunu çalýþtýrýr.
            bs.PositionChanged += bs_positionChanged; // position deðiþtiðinde bs_positionChanged metodunu çalýþtýrýr.
            KonumGüncelle(); // form açýldýðýnda konum güncellemesi yapar.

            foreach(DataColumn col in dt.Columns) // dataTable daki kolonlarý tek tek dolaþýr.
                {
                Alanlar.Items.Add(col.ColumnName); // Alanlar comboBox'ýna kolon adlarýný ekler.

                }

            textBox1.DataBindings.Add("Text", bs, "Id"); // textBox1 i dataTable hücreleri birbirine baðlayarak verileri dolmasýný saðlar.
            textBox2.DataBindings.Add("Text", bs, "Ad");
            textBox3.DataBindings.Add("Text", bs, "SoyAd");
            textBox4.DataBindings.Add("Text", bs, "Sehir");
            textBox5.DataBindings.Add("Text", bs, "Ulke");
            textBox6.DataBindings.Add("Text", bs, "telefon");
            
            }

        private void bs_positionChanged(object Sender,EventArgs a)
            {
            KonumGüncelle();
            }

        private void bs_ListChanged(object sender,EventArgs e)
            {
            KonumGüncelle();
            }

        private void KonumGüncelle()
            {
            int KayýtSayisi = bs.Count;
            int Konum = bs.Position + 1; // 0 dan baþladýðý için +1 yapýyoruz.
            label1.Text = $"{Konum} / {KayýtSayisi}";

            }

        private void button1_Click(object sender,EventArgs e)
            {
            string filtre = Filtre.Text.Trim(); // textBox1 deki deðeri alýr ve boþluklarý temizler.
            if(string.IsNullOrEmpty(filtre)) // eðer filtre boþ ise
                {
                bs.RemoveFilter(); // filtreyi kaldýrýr.
                }
            else
                {

                bs.Filter = $"Ad like '%{Filtre.Text}%'"; // filter ile arama yapýyoruz. MusteriAdi kolonunda textBox1 deki deðeri arar.
                }
            }

        private void button2_Click(object sender,EventArgs e)
            {
            bs.RemoveFilter();
            Filtre.Clear();
            }

        private void button3_Click(object sender,EventArgs e)
            {
            if(bs.Sort == "Ad desc")
            bs.Sort = "Ad asc"; // sort ile sýralama yapýyoruz. Ad kolonunu artan þekilde sýralar.
            else bs.Sort = "Ad desc";  // Ad kolonunu azalan þekilde sýralar.

            button3.Text = bs.Sort == "Ad desc" ? "Ad Sýrala (Z-A)" : "Ad Sýrala (A-Z)"; // butonun textini sýralama durumuna göre deðiþtirir.
            }

        private void button4_Click(object sender,EventArgs e)
            {
              string metin = Alanlar.Text.Trim(); // comboBox'tan seçilen deðeri alýr ve boþluklarý temizler.
              
              metin += SýralýYön.SelectedIndex == 0 ? " asc" : " desc"; // sýralama yönüne göre metne "asc" veya "desc" ekler.
             bs.Sort = metin; // sort ile sýralama yapar.
            }

        private void button5_Click(object sender,EventArgs e)
            {
             bs.AddNew(); // yeni bir kayýt ekler.
            }

        private void button6_Click(object sender,EventArgs e)
            {
              dt.AcceptChanges(); // yapýlan deðiþiklikleri onaylar ve veritabanýna kaydeder.
              MessageBox.Show("Deðiþiklikler kaydedildi."); // kullanýcýya deðiþikliklerin kaydedildiðini bildirir.
            }

        private void button7_Click(object sender,EventArgs e)
            {
            bs.RemoveCurrent(); // mevcut kaydý siler.
            }
        }
    }
