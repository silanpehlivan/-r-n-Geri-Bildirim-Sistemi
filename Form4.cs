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

namespace Sql_Proje
{
    public partial class Formkategori : Form
    {
        SqlConnection bağlanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public Formkategori()
        {
            InitializeComponent();
        }
        void KategoriGetir()
        {
            bağlanti = new SqlConnection("Server=LAPTOP-EMFFS378; database=ÜrünBildirimi; Integrated security=true;");
            bağlanti.Open();
            da = new SqlDataAdapter("select * from Kategoriler", bağlanti);
            DataTable dt = new DataTable(); //tablolarımı çekerim
            DataTable tablo = new DataTable();
            da.Fill(tablo); //tablolarımı ekliyorum.
            dataGridView1.DataSource = tablo; //Bağlantımı yaptım.
            bağlanti.Close(); //Bağlantımı kapattım.
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;


        }

        private void Formkategori_Load(object sender, EventArgs e)
        {
            KategoriGetir();
        }

        private void button2_Click(object sender, EventArgs e) //güncelleme işlemi
        {
            // Kontrol: Seçili bir satır ve yeni kategori adı girilmiş mi?
            if (dataGridView1.CurrentRow == null || string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz kategori adını seçin ve yeni kategori adını girin.");
                return;
            }

            // Eski ve yeni kategori adlarını al
            string eskiKategoriAdı = textBox1.Text.Trim();
            string yeniKategoriAdı = textBox2.Text.Trim();

            // Güncelleme sorgusu
            string sorgu = "UPDATE Kategoriler SET KategoriAdı = @YeniKategoriAdı WHERE KategoriAdı = @EskiKategoriAdı";

            using (SqlConnection bağlanti = new SqlConnection("Server=LAPTOP-EMFFS378; database=ÜrünBildirimi; Integrated security=true;"))
            {
                using (SqlCommand komut = new SqlCommand(sorgu, bağlanti))
                {
                    // Parametreleri ekle
                    komut.Parameters.AddWithValue("@EskiKategoriAdı", eskiKategoriAdı);
                    komut.Parameters.AddWithValue("@YeniKategoriAdı", yeniKategoriAdı);

                    try
                    {
                        bağlanti.Open();
                        int etkilenenSatir = komut.ExecuteNonQuery();

                        // Güncelleme durumu
                        if (etkilenenSatir > 0)
                        {
                            MessageBox.Show("Kategori başarıyla güncellendi.");
                        }
                        else
                        {
                            MessageBox.Show("Kategori güncellenemedi. Lütfen doğru bir kategori seçtiğinizden emin olun.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }

            // Tabloyu yenile ve metin kutularını temizle
            KategoriGetir();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e) //ekleme işlemi
        {
            string sorgu = "INSERT INTO Kategoriler(KategoriAdı) VALUES(@KategoriAdı)";
            komut = new SqlCommand(sorgu, bağlanti);
            komut.Parameters.AddWithValue("@KategoriAdı", textBox1.Text);
            bağlanti.Open();
            komut.ExecuteNonQuery();
            bağlanti.Close();
            KategoriGetir();
            textBox1.Clear();
        }
      

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Seçili satırdaki KategoriAdı değerini textBox1'e yaz
            if (dataGridView1.CurrentRow != null)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells["KategoriAdı"].Value.ToString();
                textBox2.Clear(); // Yeni kategori adı için textBox2'yi temizle
            }

        }

        private void button3_Click(object sender, EventArgs e) //silme işlemi
        {
            // Yeni bir kategoriye taşımak için YeniKategoriAdı'nı belirleyin
            string yeniKategoriAdı = "Diğer"; // Varsayılan kategori veya başka bir hedef kategori

            // Ürünler tablosundaki kayıtları yeni kategoriye taşı
            string ürünGüncelleSorgu = @"
        UPDATE Ürünler 
        SET KategoriID = 
        (SELECT KategoriID FROM Kategoriler WHERE KategoriAdı = @YeniKategoriAdı) 
        WHERE KategoriID = 
        (SELECT KategoriID FROM Kategoriler WHERE KategoriAdı = @KategoriAdı)";

            // Kategoriyi sil
            string kategoriSilSorgu = "DELETE FROM Kategoriler WHERE KategoriAdı = @KategoriAdı";

            try
            {
                bağlanti.Open();

                // Ürün güncelleme komutu
                komut = new SqlCommand(ürünGüncelleSorgu, bağlanti);
                komut.Parameters.AddWithValue("@YeniKategoriAdı", yeniKategoriAdı);
                komut.Parameters.AddWithValue("@KategoriAdı", textBox1.Text);
                komut.ExecuteNonQuery();

                // Kategori silme komutu
                komut = new SqlCommand(kategoriSilSorgu, bağlanti);
                komut.Parameters.AddWithValue("@KategoriAdı", textBox1.Text);
                komut.ExecuteNonQuery();

                MessageBox.Show("Kategori başarıyla silindi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                bağlanti.Close();
                KategoriGetir();
                textBox1.Clear();
                
            }

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.FromArgb(139,101,139))//eklediğim renk
            {

                button1.BackColor = Color.FromArgb(143, 188, 139); //ana rengim
            }
            else
            {
                button1.BackColor = Color.FromArgb(139, 101, 139);
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.FromArgb(143, 188, 139))
            {

                button1.BackColor = Color.FromArgb(139,101,139); 
            }
            else
            {
                button1.BackColor = Color.FromArgb(143, 188, 139);
            }
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.FromArgb(82,139,139))//eklediğim renk
            {

                button3.BackColor = Color.FromArgb(143, 188, 139); //ana rengim
            }
            else
            {
                button3.BackColor = Color.FromArgb(82, 139, 139);
            }
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.FromArgb(143, 188, 139))
            {

                button3.BackColor = Color.FromArgb(82, 139, 139);
            }
            else
            {
                button3.BackColor = Color.FromArgb(143, 188, 139);
            }
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.FromArgb(139,125,107))//eklediğim renk
            {

                button2.BackColor = Color.FromArgb(143, 188, 139); //ana rengim
            }
            else
            {
                button2.BackColor = Color.FromArgb(139,125,107);
            }
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.FromArgb(143, 188, 139))
            {

                button2.BackColor = Color.FromArgb(139,125,107);
            }
            else
            {
                button2.BackColor = Color.FromArgb(143, 188, 139);
            }
        }
    }
}
