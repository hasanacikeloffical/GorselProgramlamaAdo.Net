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
        
        private void UrunSil(int id)
            {
            string query = "delete from Urunler where urunId=@Urunid";
            using(SqlConnection conn = new SqlConnection(ConnectionString))
            using(SqlCommand cmd = new SqlCommand(query,conn))
                {
                cmd.Parameters.AddWithValue("@Urunid",id);
                conn.Open();
                int KayitSayisi = cmd.ExecuteNonQuery(); // ExecuteNonQuery() methodu, SQL sorgusunu çalýþtýrýr ve etkilenen satýr sayýsýný döndürür. This method is typically used for INSERT, UPDATE, or DELETE queries.
                UrunlerListele();
                }
            }

        private void StokTransfer(int KaynakUrunId,int HedefUrunId,int Miktar)
            {
            using(SqlConnection conn = new SqlConnection(ConnectionString))
                {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(); // BeginTransaction() methodu, bir SQL baðlantýsý üzerinde yeni bir iþlem baþlatýr. Bu method, iþlemi yönetmek ve gerektiðinde geri almak (rollback) veya onaylamak (commit) için kullanýlýr.   
                try
                    {
                    string sqlKaynak = "Update Urunler Set Stok = Stok - @Miktar where UrunId = @id";
                    using(SqlCommand cmd = new SqlCommand(sqlKaynak,conn,trans))
                        {
                        cmd.Parameters.AddWithValue("@Miktar",Miktar);
                        cmd.Parameters.AddWithValue("@id",KaynakUrunId);
                        cmd.ExecuteNonQuery();

                        }

                    string SqlHareketKaynak = "Insert into StokHareketleri (UrunId,Miktar,Tarih,Tip) values (@id,@Miktar, Getdate(), 'Çýkýþ')";
                    using(SqlCommand cmd = new SqlCommand(SqlHareketKaynak,conn,trans))
                        {
                        cmd.Parameters.AddWithValue("@Miktar",Miktar);
                        cmd.Parameters.AddWithValue("@id",KaynakUrunId);
                        cmd.ExecuteNonQuery();

                        }
                    string sqlHedef = "Update Urunler Set Stok = Stok + @Miktar where UrunId = @id";
                    using(SqlCommand cmd = new SqlCommand(sqlHedef,conn,trans))
                        {
                        cmd.Parameters.AddWithValue("@Miktar",Miktar);
                        cmd.Parameters.AddWithValue("@id",HedefUrunId);
                        cmd.ExecuteNonQuery();

                        }

                    string SqlHareketHedef = "Insert into StokHareketleri (UrunId,Miktar,Tarih,Tip) values (@id,@Miktar, Getdate(), 'Giriþ')";
                    using(SqlCommand cmd = new SqlCommand(SqlHareketHedef,conn,trans))
                        {
                        cmd.Parameters.AddWithValue("@Miktar",Miktar);
                        cmd.Parameters.AddWithValue("@id",HedefUrunId);
                        cmd.ExecuteNonQuery();

                        }
                    trans.Commit(); // Commit() methodu, bir SQL iþlemini onaylar ve yapýlan deðiþiklikleri veritabanýna kalýcý olarak kaydeder. 
                    UrunlerListele();
                    }
                catch
                    {
                    trans.Rollback(); // Rollback() methodu, bir SQL iþlemini geri alýr. Bu method, bir iþlem sýrasýnda bir hata oluþtuðunda veya iþlemi tamamlamak istemediðinizde kullanýlýr. Rollback() methodu, iþlemi baþlatan BeginTransaction() methodu ile birlikte kullanýlýr.
                    }
                }
            }

        private void FiyatGuncelleSP(int UrunId, decimal yeniFiyat)
            {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UrunFiyatGuncelle",conn))
                {
                 
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

        private void Sil_Click(object sender,EventArgs e)
            {

            if(ListelemeSayfasý.SelectedRows.Count == 0) return;
            int id = (int)ListelemeSayfasý.SelectedRows[0].Cells["UrunId"].Value;
            UrunSil(id);

            }

        private void UrunStokTranfer_Click(object sender,EventArgs e)
            {
              if(ListelemeSayfasý.SelectedRows.Count == 0) return;
            int id = (int)ListelemeSayfasý.SelectedRows[0].Cells["UrunId"].Value;
            int hedef = int.Parse(UrunTransferId.Text);
            int miktar = int.Parse(UrunTransferMiktar.Text);
            StokTransfer(id, hedef, miktar  );
            }
        }
    }
