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

namespace Sql_Proje
{
    public partial class Formürünler : Form
    {
        SqlConnection bağlanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public Formürünler()
        {
            InitializeComponent();
        }
        void ÜrünGetir() //Sql server ile bağlantısını sağladım..
        {
            bağlanti = new SqlConnection("Server=LAPTOP-EMFFS378; database=ÜrünBildirimi; Integrated security=true;");
            bağlanti.Open();
            da = new SqlDataAdapter("select * from Ürünler", bağlanti);
            DataTable dt = new DataTable(); //tablolarımı çekerim
            DataTable tablo = new DataTable();
            da.Fill(tablo); //tablolarımı ekliyorum.
            dataGridView1.DataSource = tablo; //Bağlantımı yaptım.           
            bağlanti.Close(); //Bağlantımı kapattım.
            dataGridView1.Columns[0].Visible = false;

        }

        private void Formürünler_Load(object sender, EventArgs e)
        {
            
            ÜrünGetir();
            KategoriDoldur();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow seçiliSatır = dataGridView1.CurrentRow;

                // TextBox ve ComboBox'lara veri aktarımı
                textBox1.Text = seçiliSatır.Cells["ÜrünAdı"].Value?.ToString() ?? string.Empty;
                textBox2.Text = seçiliSatır.Cells["Açıklama"].Value?.ToString() ?? string.Empty;

                // Fiyat ve Stok verilerini NumericUpDown'a aktarırken doğrulama yap
                decimal fiyat = seçiliSatır.Cells["Fiyat"].Value != null ? Convert.ToDecimal(seçiliSatır.Cells["Fiyat"].Value) : 0;
                decimal stok = seçiliSatır.Cells["StokMiktarı"].Value != null ? Convert.ToDecimal(seçiliSatır.Cells["StokMiktarı"].Value) : 0;

                // NumericUpDown sınırları içinde değilse sınır değerini ata
                numericUpDown1.Value = Math.Min(Math.Max(fiyat, numericUpDown1.Minimum), numericUpDown1.Maximum);
                numericUpDown2.Value = Math.Min(Math.Max(stok, numericUpDown2.Minimum), numericUpDown2.Maximum);

                // ComboBox için Kategori seçimi
                int kategoriID = seçiliSatır.Cells["KategoriID"].Value != null ? Convert.ToInt32(seçiliSatır.Cells["KategoriID"].Value) : 0;

                foreach (var item in comboBox1.Items)
                {
                    var kategori = item as dynamic;
                    if (kategori != null && kategori.Value == kategoriID)
                    {
                        comboBox1.SelectedItem = kategori;
                        break;
                    }
                }
            }
        }
        void KategoriDoldur()
        {
            try
            {
                bağlanti = new SqlConnection("Server=LAPTOP-EMFFS378; database=ÜrünBildirimi; Integrated security=true;");
                bağlanti.Open();

                string sorgu = "SELECT KategoriID, KategoriAdı FROM Kategoriler"; // Kategori adlarını çek
                komut = new SqlCommand(sorgu, bağlanti);
                SqlDataReader dr = komut.ExecuteReader();

                // ComboBox doldurma
                while (dr.Read())
                {
                    comboBox1.Items.Add(new { Text = dr["KategoriAdı"].ToString(), Value = dr["KategoriID"] });
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategoriler yüklenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                if (bağlanti != null)
                    bağlanti.Close();
            }
        }

        // ComboBox'ın düzgün çalışması için Text ve Value bağlama
        private void cmbKategoriID_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var item = comboBox1.Items[e.Index] as dynamic;
                e.Graphics.DrawString(item.Text, e.Font, Brushes.Black, e.Bounds);
            }
        }

        private void button1_Click(object sender, EventArgs e)//ekleme işlemi yap
        {
            try
            {
                // Gerekli doğrulama işlemi
                if (string.IsNullOrEmpty(textBox1.Text) || numericUpDown1.Value <= 0 || comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen tüm alanları doğru doldurun.");
                    return;
                }

                // Seçilen kategoriyi almak için dynamic kullanıyoruz
                var seçiliKategori = (dynamic)comboBox1.SelectedItem;
                int kategoriID = seçiliKategori?.Value ?? 0; // Seçilen kategori ID'si, varsayılan olarak 0

                // Kategori kontrolü
                if (kategoriID == 0)
                {
                    MessageBox.Show("Geçerli bir kategori seçiniz.");
                    return;
                }

                // Veritabanı bağlantısı açılıyor
                using (bağlanti = new SqlConnection("Server=LAPTOP-EMFFS378; database=ÜrünBildirimi; Integrated security=true;"))
                {
                    bağlanti.Open();

                    // SQL komutunu oluştur
                    string sorgu = "INSERT INTO Ürünler (ÜrünAdı, Açıklama, Fiyat, StokMiktarı, KategoriID) " +
                                   "VALUES (@ÜrünAdı, @Açıklama, @Fiyat, @StokMiktarı, @KategoriID)";
                    using (komut = new SqlCommand(sorgu, bağlanti))
                    {
                        // Parametreleri komuta ekle
                        komut.Parameters.AddWithValue("@ÜrünAdı", textBox1.Text);
                        komut.Parameters.AddWithValue("@Açıklama", textBox2.Text);
                        komut.Parameters.AddWithValue("@Fiyat", numericUpDown1.Value);
                        komut.Parameters.AddWithValue("@StokMiktarı", numericUpDown2.Value);
                        komut.Parameters.AddWithValue("@KategoriID", kategoriID);

                        // Veritabanına veri ekle
                        komut.ExecuteNonQuery();
                    }
                }

                // Kullanıcıya başarı mesajı
                MessageBox.Show("Ürün başarıyla eklendi.");

                // Tabloyu güncelle
                ÜrünGetir();
            }
            catch (Exception ex)
            {
                // Hata mesajı
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı kapat
                if (bağlanti != null && bağlanti.State == ConnectionState.Open)
                    bağlanti.Close();
            }

            // Giriş alanlarını temizle
            GirişAlanlarınıTemizle();

        }

        private void button2_Click(object sender, EventArgs e) //Silme işlemi
        {
            try
            {
                if (dataGridView1.CurrentRow != null) // Satırın seçili olup olmadığını kontrol et
                {
                    // Seçili satırdaki 'ÜrünID' ve 'KategoriID' değerlerini alıyoruz
                    DataGridViewRow seçiliSatır = dataGridView1.CurrentRow;

                    object ürünIDObj = seçiliSatır.Cells["ÜrünID"].Value;
                    object kategoriIDObj = seçiliSatır.Cells["KategoriID"].Value;

                    // Null kontrolü
                    if (ürünIDObj == null || kategoriIDObj == null)
                    {
                        MessageBox.Show("Seçilen satırda gerekli bilgiler eksik.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int ürünID = Convert.ToInt32(ürünIDObj);
                    int kategoriID = Convert.ToInt32(kategoriIDObj);

                    DialogResult result = MessageBox.Show("Bu ürünü silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        using (SqlConnection bağlanti = new SqlConnection("Server=LAPTOP-EMFFS378; database=ÜrünBildirimi; Integrated security=true;"))
                        {
                            bağlanti.Open();

                            // Ürünle ilişkili geri bildirimleri sil
                            string geriBildirimSilSorgu = "DELETE FROM GeriBildirimler WHERE ÜrünID = @ÜrünID";
                            using (SqlCommand geriBildirimKomut = new SqlCommand(geriBildirimSilSorgu, bağlanti))
                            {
                                geriBildirimKomut.Parameters.AddWithValue("@ÜrünID", ürünID);
                                geriBildirimKomut.ExecuteNonQuery();
                            }

                            // Ürün silme işlemi
                            string ürünSilSorgu = "DELETE FROM Ürünler WHERE ÜrünID = @ÜrünID";
                            using (SqlCommand ürünKomut = new SqlCommand(ürünSilSorgu, bağlanti))
                            {
                                ürünKomut.Parameters.AddWithValue("@ÜrünID", ürünID);
                                ürünKomut.ExecuteNonQuery();
                                MessageBox.Show("Ürün başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            // Kategori kontrolü
                            string kategoriSorgu = "SELECT COUNT(*) FROM Ürünler WHERE KategoriID = @KategoriID";
                            using (SqlCommand kategoriKomut = new SqlCommand(kategoriSorgu, bağlanti))
                            {
                                kategoriKomut.Parameters.AddWithValue("@KategoriID", kategoriID);
                                int kategoriSayisi = (int)kategoriKomut.ExecuteScalar();

                                if (kategoriSayisi == 0) // Eğer kategoride başka ürün yoksa
                                {
                                    string kategoriSilSorgu = "DELETE FROM Kategoriler WHERE KategoriID = @KategoriID";
                                    using (SqlCommand kategoriSilKomut = new SqlCommand(kategoriSilSorgu, bağlanti))
                                    {
                                        kategoriSilKomut.Parameters.AddWithValue("@KategoriID", kategoriID);
                                        kategoriSilKomut.ExecuteNonQuery();
                                        MessageBox.Show("Kategori başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }

                        // Tabloyu güncelle
                        ÜrünGetir();
                    }
                }
                else
                {
                    MessageBox.Show("Silmek için bir ürün seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GirişAlanlarınıTemizle();
        }


        // Giriş alanlarını temizleyen yardımcı metot
        private void GirişAlanlarınıTemizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            comboBox1.SelectedIndex = -1;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null) // Satırın seçili olup olmadığını kontrol et
                {
                    // Seçili satırdaki 'ÜrünID' değerini alıyoruz
                    DataGridViewRow seçiliSatır = dataGridView1.CurrentRow;

                    object ürünIDObj = seçiliSatır.Cells["ÜrünID"].Value;

                    // Null kontrolü
                    if (ürünIDObj == null)
                    {
                        MessageBox.Show("Seçilen satırda ürün ID bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int ürünID = Convert.ToInt32(ürünIDObj);

                    // Giriş alanlarını kontrol et
                    if (string.IsNullOrEmpty(textBox1.Text) || numericUpDown1.Value <= 0 || comboBox1.SelectedItem == null)
                    {
                        MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Seçilen kategori bilgisi
                    var seçiliKategori = (dynamic)comboBox1.SelectedItem;
                    int kategoriID = seçiliKategori?.Value ?? 0;

                    // Veritabanı bağlantısı
                    bağlanti = new SqlConnection("Server=LAPTOP-EMFFS378; database=ÜrünBildirimi; Integrated security=true;");
                    bağlanti.Open();

                    // Güncelleme sorgusu
                    string sorgu = "UPDATE Ürünler SET ÜrünAdı = @ÜrünAdı, Açıklama = @Açıklama, Fiyat = @Fiyat, StokMiktarı = @StokMiktarı, KategoriID = @KategoriID WHERE ÜrünID = @ÜrünID";
                    komut = new SqlCommand(sorgu, bağlanti);

                    // Parametreleri ekle
                    komut.Parameters.AddWithValue("@ÜrünAdı", textBox1.Text);
                    komut.Parameters.AddWithValue("@Açıklama", textBox2.Text);
                    komut.Parameters.AddWithValue("@Fiyat", numericUpDown1.Value);
                    komut.Parameters.AddWithValue("@StokMiktarı", numericUpDown2.Value);
                    komut.Parameters.AddWithValue("@KategoriID", kategoriID);
                    komut.Parameters.AddWithValue("@ÜrünID", ürünID);

                    // Güncelleme işlemini gerçekleştir
                    int etkilenenSatırSayısı = komut.ExecuteNonQuery();

                    if (etkilenenSatırSayısı > 0)
                    {
                        MessageBox.Show("Ürün başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tabloyu güncelle
                        ÜrünGetir();

                        // Giriş alanlarını temizle
                        GirişAlanlarınıTemizle();
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme sırasında bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Güncellemek için bir ürün seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Bağlantıyı kapat
                if (bağlanti != null)
                    bağlanti.Close();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            //{
            //    if (Convert.ToInt32(dataGridView1.Rows[i].Cells["Ü"].Value.ToString() >= 40)) ;
            //    {

            //    }
            //}
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.FromArgb(158,157, 190))//eklediğim renk
            {

                button1.BackColor = Color.FromArgb(172, 170, 233); //ana rengim
            }
            else
            {
                button1.BackColor = Color.FromArgb(158, 157, 190);
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.FromArgb(172, 170, 233))
            {

                button1.BackColor = Color.FromArgb(255, 255, 224); 
            }
            else
            {
                button1.BackColor = Color.FromArgb(172, 170, 233);
            }
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.FromArgb(153 ,186, 221))//eklediğim renk
            {

                button2.BackColor = Color.FromArgb(172, 170, 233); //ana rengim
            }
            else
            {
                button2.BackColor = Color.FromArgb(153, 186, 221);
            }
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.FromArgb(172, 170, 233))
            {

                button2.BackColor = Color.FromArgb(153, 186, 221);
            }
            else
            {
                button2.BackColor = Color.FromArgb(172, 170, 233);
            }
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.FromArgb(255, 231, 186))//eklediğim renk
            {

                button3.BackColor = Color.FromArgb(172, 170, 233); //ana rengim
            }
            else
            {
                button3.BackColor = Color.FromArgb(255, 231, 186);
            }
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.FromArgb(172, 170, 233))
            {

                button3.BackColor = Color.FromArgb(255,231, 186);
            }
            else
            {
                button3.BackColor = Color.FromArgb(172, 170, 233);
            }
        }
    }
}
