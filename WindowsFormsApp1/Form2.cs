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
using System.Windows.Forms.VisualStyles;

namespace WindowsFormsApp1
    {
    public partial class Form2 :Form
        {
        public Form2()
            {
            InitializeComponent();
            }
        string Database = @"Data Source=DESKTOP-KM10E7C;Initial Catalog=MusteriSiparis;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        SqlDataAdapter _dataAdapter;
        DataTable _dataTable;
        private void button1_Click(object sender,EventArgs e)
            {
            try
                {
                string sql = @"select	
                            M.Ad + ' ' + M.Soyad AdSoyad,
                            M.Sehir,
                            COUNT(*) SiparisAdet,
                            case 
                            	when count(*) > 10 then 'iyi'
                            	else 'Normal'
                            	end MusteriTip
                            From
                            Musteri M
                            join Siparis S on S.Musteri_Id = M.Id
                            group by 
                            m.Ad,
                            m.Soyad,
                            m.Sehir";
                _dataAdapter = new SqlDataAdapter(sql,Database);
                _dataTable = new DataTable();
                _dataAdapter.Fill(_dataTable);
                dataGridView1.DataSource = _dataTable;
                }
            catch(Exception ex)
                {
                MessageBox.Show(@"Hata : " + ex.Message,"hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

        private void button2_Click(object sender,EventArgs e)
            {
            if(_dataTable == null)
                {
                MessageBox.Show(@"Önce veriyi yükle...");
                return;
                }
            ColumnsList.Items.Clear();
            ColumnsList.Items.Add("Alan Bilgileri");

            foreach(DataColumn column in _dataTable.Columns)
                { 
                  ColumnsList.Items.Add($"Ad : { column.ColumnName}, Tipi : {column.DataType}");
                }
            }

        private void button3_Click(object sender,EventArgs e)
            {

            if(_dataTable == null)
                {
                MessageBox.Show(@"Önce veriyi yükle...");
                return;
                }
             

             ColumnsList.Items.Add("Veri Bilgileri");
            
            if(!_dataTable.Columns.Contains("MüsteriTip"))
                {
                _dataTable.Columns.Add("MüsteriTip",typeof(string));
                foreach(DataRow row in _dataTable.Rows)
                {
                int Piece = Convert.ToInt16(row["SiparisAdet"]);
                row["MüsteriTip"] = Piece > 10 ? "Ýyi" : "Standart";
                }
            MessageBox.Show(@"Müþteri tipleri güncellendi...");
                }else
                MessageBox.Show(@"Müþteri tipleri zaten güncellendi...");
            }

        }
    }
