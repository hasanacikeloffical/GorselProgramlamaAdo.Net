using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ders_12
    {
    public partial class Form1 :Form
        {
        DataTable UrunTable;
        DataView UrunView;

        public Form1()
            {
            InitializeComponent();
            VeriTablosuOlustur();
            DataViewOlusturBagla();
            CategoryFiltreDoldur();
            }
          
           private void CategoryFiltreDoldur()
            {
              CategoryFiltre.Items.Clear(); // ComboBox'ýn mevcut öðelerini temizledik. Böylece tekrar doldururken eski öðeler kalmaz.
              CategoryFiltre.Items.Add("Tümü"); // ComboBox'a "Tümü" seçeneði ekledik. Bu seçenek, tüm kategorileri göstermek için kullanýlacak.
            var categories = UrunTable.AsEnumerable() // DataTable'ý Enumerable hale getirdik. Bu sayede LINQ sorgularý yapabiliriz.
                                   .Select(row => row.Field<String>("Category")) // Her satýrdaki "Category" alanýný seçtik. Bu, kategorilerin bir listesini oluþturur.
                                   .Distinct()                                              // LINQ sorgusu ile kategorileri benzersiz hale getirdik ve ComboBox'a ekledik.        
                                   .OrderBy(k => k);  // Kategorileri alfabetik olarak sýraladýk. Bu, kullanýcýlarýn kategorileri daha kolay bulmasýný saðlar.
            // kullanýlmasaydý, kategoriler ComboBox'a eklenirken tekrar eden öðeler olabilirdi ve kullanýcýlar için kafa karýþtýrýcý olabilirdi.

            foreach(var Kat in categories)
                {
                CategoryFiltre.Items.Add(Kat); // Her benzersiz kategoriyi ComboBox'a ekledik.
                }
            
                CategoryFiltre.SelectedIndex = 0; // ComboBox'ýn varsayýlan olarak ilk öðesini seçili hale getirdik. Bu, "Tümü" seçeneðini varsayýlan olarak gösterecek.

            }
            
        private void DataViewOlusturBagla()
            {
              UrunView = new DataView(UrunTable); // DataTable üzerinden DataView oluþturduk. Bu sayede DataTable'daki verileri filtreleyebilir ve sýralayabiliriz.
              UrunView.Sort="UrunId ASC"; // DataView'i UrunId sütununa göre artan þekilde sýraladýk.  
            dataGridView1.DataSource = UrunView; // DataView'i DataGridView'e baðladýk. Böylece DataGridView, DataView'deki verileri gösterecektir.
             

            }  

        private void VeriTablosuOlustur()
            {
             UrunTable = new DataTable("Ürünler");

            UrunTable.Columns.Add("UrunId", typeof(int));
            UrunTable.Columns.Add("UrunName", typeof(string));
            UrunTable.Columns.Add("Category", typeof(string));
            UrunTable.Columns.Add("UrunFiyat", typeof(decimal));
            UrunTable.Columns.Add("StoktaVarmi", typeof(bool));

            UrunTable.Rows.Add(1,"Telefon","Elektronik",1202,true);
            UrunTable.Rows.Add(2,"Klavye","Elektronik",12102,false);
            UrunTable.Rows.Add(3,"BÝlgisayar","Elektronik",12502,true);
            UrunTable.Rows.Add(4,"Tablet","Elektronik",1202,true);
            UrunTable.Rows.Add(5,"Gömlek","Giyim",12023,true);
            UrunTable.Rows.Add(6,"Ayakkabý","Giyim",12052,false);
            UrunTable.Rows.Add(7,"Kosmos","Kitap",12092,true);
            UrunTable.Rows.Add(8,"Ufolar","Makaleler",15202,true);
            UrunTable.Rows.Add(9,"Fare","Elektronik",1202,true);
            UrunTable.Rows.Add(10,"RAM","Elektronik",12002,true);
            UrunTable.Rows.Add(11,"Masa","Mobilya",12032,true);
            
            }
        
        private void FiltreUygula()
            {
              string filtre = ""; // Filtreyi baþlatýyoruz. Baþlangýçta boþ bir filtre olacak.

            // Kategori filtresi
            if(CategoryFiltre.SelectedItem != null && CategoryFiltre.SelectedItem.ToString() != "Tümü") // Eðer ComboBox'ta bir kategori seçilmiþse ve bu kategori "Tümü" deðilse
                {
                filtre = $"Category = '{CategoryFiltre.SelectedItem}'"; // Filtreyi oluþturuyoruz. Bu filtre, seçilen kategoriye göre DataView'i filtreleyecek.
                }

            // Stok Durumu filtresi
            if(StokDurum.Checked)
                {
                if(!string.IsNullOrEmpty(filtre)) // Eðer filtre daha önce oluþturulmuþsa
                    filtre +=  " AND "; // Filtreye "AND" ekliyoruz. Bu, birden fazla filtreyi birleþtirmek için kullanýlýr.
                filtre += "StoktaVarmi = true ";  // Stokta olan ürünleri filtreliyoruz. Bu filtre, sadece stokta olan ürünleri gösterecek.
                }
            
            // ada göre filtre 
            if(!string.IsNullOrEmpty(Arama.Text))
                {
                if(!string.IsNullOrEmpty(filtre)) // Eðer filtre daha önce oluþturulmuþsa
                    filtre += " AND "; // Filtreye "AND" ekliyoruz. Bu, birden fazla filtreyi birleþtirmek için kullanýlýr.
                filtre += $"UrunName like '%{Arama.Text.Replace("'","''")}%'"; // Arama.Text içindeki tek týrnaklarý iki týrnakla deðiþtiriyoruz. Bu, SQL enjeksiyonunu önlemek için yapýlýr. Ardýndan filtreyi oluþturuyoruz. Bu filtre, ürün adýnda Arama.Text içindeki metni içeren ürünleri gösterecek. 


                }

            UrunView.RowFilter = filtre; // DataView'in RowFilter özelliðine oluþturduðumuz filtreyi uyguluyoruz. Bu, DataGridView'de sadece filtreye uyan ürünleri gösterecek.

            SiralamaAyarla(); // Filtreyi uyguladýktan sonra sýralamayý ayarlýyoruz. Bu, kullanýcýlarýn filtreleme iþlemi yaptýktan sonra ürünleri sýralamasýný saðlar.
            }

        private void BtnAra_Click(object sender,EventArgs e)
            {
             FiltreUygula(); // Ara butonuna týklandýðýnda filtreyi uyguluyoruz. Bu, kullanýcýlarýn filtreleme iþlemini baþlatmasýný saðlar.
            }

        private void CategoryFiltre_SelectedIndexChanged(object sender,EventArgs e)
            {
             FiltreUygula(); // ComboBox'ta kategori deðiþtiðinde filtreyi uyguluyoruz. Bu, kullanýcýlarýn kategoriye göre filtreleme yapmasýný saðlar.
            }

        private void StokDurum_CheckedChanged(object sender,EventArgs e)
            {
            FiltreUygula(); // CheckBox'ta stok durumu deðiþtiðinde filtreyi uyguluyoruz. Bu, kullanýcýlarýn stok durumuna göre filtreleme yapmasýný saðlar.
            }

        private void SiralamaAyarla()
            {
              if(FiyatArtan.Checked)
                UrunView.Sort = "UrunFiyat ASC"; // Eðer FiyatArtan RadioButton'ý seçiliyse, DataView'i UrunFiyat sütununa göre artan þekilde sýralýyoruz.
            else if (FiyatAzalan.Checked)
                UrunView.Sort = "UrunFiyat DESC"; // Eðer FiyatAzalan RadioButton'ý seçiliyse, DataView'i UrunFiyat sütununa göre azalan þekilde sýralýyoruz.
            else
                UrunView.Sort = "UrunId ASC"; // Eðer hiçbir RadioButton seçili deðilse, DataView'i UrunId sütununa göre artan þekilde sýralýyoruz.
              
            }

        private void BtnDelete_Click(object sender,EventArgs e)
            {
             CategoryFiltre.SelectedIndex = 0; // ComboBox'ta "Tümü" seçeneðini seçili hale getiriyoruz. Bu, kategori filtresini sýfýrlamak için yapýlýr.
             StokDurum.Checked = false; // CheckBox'ý iþaretlenmemiþ hale getiriyoruz. Bu, stok durumu filtresini sýfýrlamak için yapýlýr.
             Arama.Text = ""; // TextBox'ý boþ hale getiriyoruz. Bu, ada göre filtreyi sýfýrlamak için yapýlýr.
             FiyatArtan.Checked = false; // RadioButton'ý iþaretlenmemiþ hale getiriyoruz. Bu, fiyat artan filtresini sýfýrlamak için yapýlýr.
             FiyatAzalan.Checked = false; // RadioButton'ý iþaretlenmemiþ hale getiriyoruz. Bu, fiyat azalan filtresini sýfýrlamak için yapýlýr.
             
             
             UrunView.Sort = "UrunId ASC"; // DataView'i UrunId sütununa göre artan þekilde sýralýyoruz. Bu, sýralama filtresini sýfýrlamak için yapýlýr.
            FiltreUygula(); // Filtreyi uyguluyoruz. Bu, tüm filtreleri sýfýrladýktan sonra DataGridView'de tüm ürünleri göstermek için yapýlýr.
            }

        private void FiyatArtan_CheckedChanged(object sender,EventArgs e)
            {
             if(FiyatArtan.Checked)
              FiltreUygula(); // Eðer FiyatArtan RadioButton'ý seçiliyse, filtreyi uyguluyoruz. Bu, kullanýcýlarýn fiyat artan sýralamasýný yapmasýný saðlar.
            }

        private void FiyatAzalan_CheckedChanged(object sender,EventArgs e)
            {
               if (FiyatAzalan.Checked)
                 FiltreUygula(); // Eðer FiyatAzalan RadioButton'ý seçiliyse, filtreyi uyguluyoruz. Bu, kullanýcýlarýn fiyat azalan sýralamasýný yapmasýný saðlar.
            }

        private void Arama_KeyPress(object sender,KeyPressEventArgs e)
            {
              if(e.KeyChar == (char)Keys.Enter)
                {
                FiltreUygula();
                e.Handled = true; // iptal eder auto olarak. 
                }
            }
        }
    }
