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

namespace Ders_9
    {
    public partial class Form1 :Form
        {
        string ConnectionString = @"Data Source=DESKTOP-KM10E7C;
            Initial Catalog=StokYonetimi;
            Integrated Security=True;";
        public Form1()
            {
            InitializeComponent();
            }
        private void UrunlerListele()
            {
            string query = "Select urunId, Ad, Fiyat, Stok From Urunler";
            using(SqlConnection conn = new SqlConnection(ConnectionString)) // using ifadesi, IDisposable arayüzünü uygulayan nesnelerin kullanýmýný kolaylaþtýrmak için kullanýlýr. Bu ifade, bir nesnenin oluþturulmasý, kullanýlmasý ve ardýndan otomatik olarak temizlenmesi (dispose edilmesi) iþlemlerini yönetir. using ifadesi, kaynaklarýn doðru þekilde serbest býrakýlmasýný saðlar ve bellek sýzýntýlarýný önler.
            using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                  conn.Open();
                  SqlDataReader reader = cmd.ExecuteReader();  // ExecuteReader() methodu, sorgudan oluþan kayýtlarý okumak için kullanýlýr. Bu method, sorgunun sonucunu bir SqlDataReader nesnesi olarak döndürür.
                  DataTable dt = new DataTable();
                  dt.Load(reader); // DataTable'ýn Load() methodu, bir veri kaynaðýndan (örneðin, bir SqlDataReader) veri yüklemek için kullanýlýr. Bu method, veri kaynaðýndaki verileri DataTable'a aktarýr ve DataTable'ý doldurur.
                ListelemeSayfasý.DataSource = dt;
                reader.Close();

                }
                }

        private void UrunEkle(string ad, decimal fiyat, int stok)
            {
            string query = "insert into urunler (Ad, fiyat, stok) values (@ad, @fiyat, @stok)";
            using(SqlConnection conn = new SqlConnection(ConnectionString))
            using(SqlCommand cmd = new SqlCommand(query,conn))
                {
                cmd.Parameters.AddWithValue("@ad",ad);
                cmd.Parameters.AddWithValue("@fiyat",fiyat);
                cmd.Parameters.AddWithValue("@stok",stok);
                conn.Open();
                int KayitSayisi= cmd.ExecuteNonQuery(); // ExecuteNonQuery() methodu, SQL sorgusunu çalýþtýrýr ve etkilenen satýr sayýsýný döndürür. Bu method, genellikle INSERT, UPDATE veya DELETE gibi veri deðiþtiren sorgular için kullanýlýr.
                UrunlerListele();
                
                }
            }
        private void UrunGüncelle(int id, string ad, decimal fiyat, int stok)
            {
            string query = "update Urunler Set ad=@ad, fiyat=@fiyat, stok=@stok where urunId=@id";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query,conn))
                    {
                cmd.Parameters.AddWithValue("@ad",ad);
                cmd.Parameters.AddWithValue("@fiyat",fiyat);
                cmd.Parameters.AddWithValue("@stok",stok);
                cmd.Parameters.AddWithValue("@id",id);
                conn.Open();
                int KayitSayisi= cmd.ExecuteNonQuery(); // ExecuteNonQuery() methodu, SQL sorgusunu çalýþtýrýr ve etkilenen satýr sayýsýný döndürür. Bu method, genellikle INSERT, UPDATE veya DELETE gibi veri deðiþtiren sorgular için kullanýlýr.
                UrunlerListele();
                    }
            }
        
        private void Listeleme_Click(object sender,EventArgs e)
            {
            UrunlerListele();
            }

        private void Ekle_Click(object sender,EventArgs e)
            {
            UrunEkle(UrunAdý.Text, decimal.Parse(UrunFiyati.Text), int.Parse(UrunStok.Text));
            }

        private void Güncelle_Click(object sender,EventArgs e)
            {
            
            if(ListelemeSayfasý.SelectedRows.Count == 0) return;
            int id = (int)ListelemeSayfasý.SelectedRows[0].Cells["UrunId"].Value;
            UrunGüncelle(id, UrunAdý.Text, decimal.Parse(UrunFiyati.Text), int.Parse(UrunStok.Text));

            }
        }
    }
