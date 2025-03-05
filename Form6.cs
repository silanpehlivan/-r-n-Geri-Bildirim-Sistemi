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
    public partial class FormGeriBildirim : Form
    {
        SqlConnection bağlanti;
        SqlCommand komut;
        SqlDataAdapter da;
       
        public FormGeriBildirim()
        {
            InitializeComponent();
           
        }
        private void SetupDataGridView()
        {
            // DataGridView'de ComboBox eklemek için
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.HeaderText = "Puan";
            comboBoxColumn.Items.AddRange(1, 2, 3, 4, 5); // Puanlar
            dataGridView1.Columns.Add(comboBoxColumn); // DataGridView'e ekle

            // Başka sütunlar ekleyebilirsiniz (örneğin ürün adı, kullanıcı adı vb.)
            dataGridView1.Columns.Add("Yorum", "Yorum");
        }



        void GeriBildirimleriGetir()
        {
            bağlanti = new SqlConnection("Server=LAPTOP-EMFFS378; database=ÜrünBildirimi; Integrated security=true;");
            bağlanti.Open();
            da = new SqlDataAdapter("select * from GeriBildirimler", bağlanti);
            DataTable dt = new DataTable(); //tablolarımı çekerim
            DataTable tablo = new DataTable();
            da.Fill(tablo); //tablolarımı ekliyorum.
            dataGridView1.DataSource = tablo; //Bağlantımı yaptım.           
            bağlanti.Close(); //Bağlantımı kapattım.
            dataGridView1.Columns[0].Visible = false;
            //dataGridView1.Columns[1].Visible = false;
            //dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[6].Visible = false;

        }
        private void FormGeriBildirim_Load(object sender, EventArgs e)
        {
            GeriBildirimleriGetir();
            // Veritabanından Puanları çeker ve ComboBox'a ekler
            string connectionString = "Server=LAPTOP-EMFFS378; database=ÜrünBildirimi; Integrated security=true;";

            try
            {
                using (bağlanti = new SqlConnection(connectionString))
                {
                    bağlanti.Open();

                    // Puanları almak için sorgu (Puanlar GeriBildirimler tablosundan alınmaktadır)
                    string query = "SELECT DISTINCT Puan FROM GeriBildirimler";  // Puanları almak için sorgu
                    SqlCommand komut = new SqlCommand(query, bağlanti);

                    SqlDataReader reader = komut.ExecuteReader();

                    // ComboBox'ı temizleyelim
                    comboBoxPuan.Items.Clear();

                    // Puanları ComboBox'a ekliyoruz
                    while (reader.Read())
                    {
                        comboBoxPuan.Items.Add(reader["Puan"].ToString());
                    }

                    //Eğer puanlar yoksa, 1 - 5 arasında sabit bir liste de ekleyebilirsiniz:
                    for (int i = 1; i <= 5; i++)
                    {
                        comboBoxPuan.Items.Add(i);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Puanları çekerken bir hata oluştu: " + ex.Message);
            }


        }


        private void button1_Click(object sender, EventArgs e)
        {
            { // Kullanıcıdan alınan veriler
                if (string.IsNullOrWhiteSpace(textBoxÜrünID.Text) || string.IsNullOrWhiteSpace(textBoxKullanıcıID.Text) || comboBoxPuan.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen tüm alanları doğru şekilde doldurun.");
                    return;
                }

                // ComboBox'tan seçilen puan
                int puan = Convert.ToInt32(comboBoxPuan.SelectedItem); // Puanı alıyoruz

                // Diğer kullanıcıdan alınan veriler
                int ürünID = Convert.ToInt32(textBoxÜrünID.Text); // Ürün ID'si
                int kullanıcıID = Convert.ToInt32(textBoxKullanıcıID.Text); // Kullanıcı ID'si
                string yorum = textBoxYorum.Text; // Yorum

                // Veritabanı bağlantısı ve komut işlemleri
                string connectionString = "Server=LAPTOP-EMFFS378; database=ÜrünBildirimi; Integrated security=true;";

                try
                {
                    using (bağlanti = new SqlConnection(connectionString))
                    {
                        bağlanti.Open();
                        string query = "INSERT INTO GeriBildirimler (ÜrünID, KullanıcıID, Puan, Yorum) " +
                                       "VALUES (@ÜrünID, @KullanıcıID, @Puan, @Yorum)";

                        using (komut = new SqlCommand(query, bağlanti))
                        {
                            // Parametreler
                            komut.Parameters.AddWithValue("@ÜrünID", ürünID);
                            komut.Parameters.AddWithValue("@KullanıcıID", kullanıcıID);
                            komut.Parameters.AddWithValue("@Puan", puan);
                            komut.Parameters.AddWithValue("@Yorum", yorum); // Yorum parametresi eklenmiş olmalı

                            // Komutu çalıştır
                            komut.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Geri bildirim başarıyla kaydedildi!");
                }
                catch (SqlException sqlEx)
                {
                    // Veritabanı hatalarını özel olarak ele alalım
                    MessageBox.Show("Veritabanı hatası: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    // Diğer hataları genel olarak ele alalım
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    // Veritabanı bağlantısını kapatmayı unutmayalım
                    if (bağlanti.State == ConnectionState.Open)
                    {
                        bağlanti.Close();
                    }
                }

                // Veritabanındaki geri bildirimleri güncellemek için
                GeriBildirimleriGetir();

                textBoxKullanıcıID.Clear();
                textBoxÜrünID.Clear();
                textBoxYorum.Clear();
                comboBoxPuan.SelectedIndex = -1; // ComboBox'taki seçili öğeyi temizle
                hiddenGeriBildirimID = 0; // GeriBildirimID'yi sıfırlıyoruz


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // DataGridView'da herhangi bir satır seçildi mi kontrol edelim
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz geri bildirimi seçin.");
                return;
            }

            // Seçilen satırdaki GeriBildirimID değerini alalım
            int geriBildirimID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["GeriBildirimID"].Value);

            // Silme işlemi için sorgu
            string connectionString = "Server=LAPTOP-EMFFS378; database=ÜrünBildirimi; Integrated security=true;";

            try
            {
                using (bağlanti = new SqlConnection(connectionString))
                {
                    bağlanti.Open();

                    // Geri bildirim silme sorgusu
                    string query = "DELETE FROM GeriBildirimler WHERE GeriBildirimID = @GeriBildirimID";

                    using (komut = new SqlCommand(query, bağlanti))
                    {
                        // Parametreyi ekleyelim
                        komut.Parameters.AddWithValue("@GeriBildirimID", geriBildirimID);

                        // Komutu çalıştır
                        int rowsAffected = komut.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Geri bildirim başarıyla silindi!");
                            GeriBildirimleriGetir(); // Silme işleminden sonra geri bildirimleri yenileyelim
                        }
                        else
                        {
                            MessageBox.Show("Silme işlemi başarısız oldu.");
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Veritabanı hatası: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
            finally
            {
                if (bağlanti.State == ConnectionState.Open)
                {
                    bağlanti.Close();
                }
            }
            textBoxKullanıcıID.Clear();
            textBoxÜrünID.Clear();
            textBoxYorum.Clear();
            comboBoxPuan.SelectedIndex = -1; // ComboBox'taki seçili öğeyi temizle
            hiddenGeriBildirimID = 0; // GeriBildirimID'yi sıfırlıyoruz


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (hiddenGeriBildirimID == 0)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz geri bildirimi seçin.");
                return;
            }

            // Kullanıcıdan alınan yeni veriler
            string yeniYorum = textBoxYorum.Text; // Yeni yorum
            int yeniPuan = Convert.ToInt32(comboBoxPuan.SelectedItem); // Yeni puan
            int yeniÜrünID=Convert.ToInt32(textBoxÜrünID.Text);
            int yeniKullanıcıID=Convert.ToInt32(textBoxKullanıcıID.Text);

            string connectionString = "Server=LAPTOP-EMFFS378; database=ÜrünBildirimi; Integrated security=true;";

            try
            {
                using (bağlanti = new SqlConnection(connectionString))
                {
                    bağlanti.Open();
                    string query = "UPDATE GeriBildirimler SET ÜrünID=@ÜrünID, KullanıcıID=@KullanıcıID, Puan = @Puan, Yorum = @Yorum WHERE GeriBildirimID = @GeriBildirimID";
                    using (komut = new SqlCommand(query, bağlanti))
                    {
                        komut.Parameters.AddWithValue("@GeriBildirimID", hiddenGeriBildirimID);
                        komut.Parameters.AddWithValue("@ÜrünID", yeniÜrünID);
                        komut.Parameters.AddWithValue("@KullanıcıID", yeniKullanıcıID);
                        komut.Parameters.AddWithValue("@Puan", yeniPuan);
                        komut.Parameters.AddWithValue("@Yorum", yeniYorum);

                        int rowsAffected = komut.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Geri bildirim başarıyla güncellendi!");
                            GeriBildirimleriGetir(); // Güncelleme işleminden sonra geri bildirimleri yenileyelim
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme işlemi başarısız oldu.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }

            // Güncelleme işleminden sonra alanları temizle
            textBoxÜrünID.Clear();
            textBoxKullanıcıID.Clear();
            textBoxYorum.Clear();
            comboBoxPuan.SelectedIndex = -1; // ComboBox'taki seçili öğeyi temizle
            hiddenGeriBildirimID = 0; // GeriBildirimID'yi sıfırlıyoruz


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                hiddenGeriBildirimID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["GeriBildirimID"].Value);
                textBoxÜrünID.Text = dataGridView1.Rows[e.RowIndex].Cells["ÜrünID"].Value.ToString();
                textBoxKullanıcıID.Text = dataGridView1.Rows[e.RowIndex].Cells["KullanıcıID"].Value.ToString();
                textBoxYorum.Text = dataGridView1.Rows[e.RowIndex].Cells["Yorum"].Value.ToString();
                comboBoxPuan.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["Puan"].Value.ToString();


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
         private int hiddenGeriBildirimID; // GeriBildirimID'yi saklamak için

        private void textBoxYorum_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormGeriBildirim_MouseEnter(object sender, EventArgs e)
        {
           
            // Random random = new Random();
            //int interval = random.Next(1, 1000); // 1ms ile 1000ms arasında rastgele bir süre

            //// Zamanlayıcı oluşturuluyor
            //Timer timer = new Timer
            //{
            //    Interval = interval // Belirlenen rastgele zaman aralığı
            //};

            //timer.Tick += (s, ev) =>
            //{
            //    // Yeni bir Label oluşturuluyor
            //    Label label = new Label
            //    {
            //        Bounds = new System.Drawing.Rectangle(100, 100, 200, 50), // Pozisyon ve boyut
            //        BackColor = System.Drawing.Color.Red, // Arka plan rengi
            //        ForeColor = System.Drawing.Color.White, // Yazı rengi
            //        Text = "Buraya SQL sorgusu ile yapılan yorumları yazdır",
            //        TextAlign = System.Drawing.ContentAlignment.MiddleCenter // Metni ortalama
            //    };

            //    // Label'i forma ekle
            //    this.Controls.Add(label);

            //    // Zamanlayıcıyı durdur
            //    timer.Stop();
            //    timer.Dispose();
            //};

            //// Timer başlatılıyor
            //timer.Start();
            
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.FromArgb(34, 139, 34))//eklediğim renk
            {

                button1.BackColor = Color.FromArgb(205, 92, 92); //ana rengim
            }
            else
            {
                button1.BackColor = Color.FromArgb(34, 139, 34);
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.FromArgb(205, 92, 92))
            {

                button1.BackColor = Color.FromArgb(34, 139, 34); 
            }
            else
            {
                button1.BackColor = Color.FromArgb(205, 92, 92);
            }
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.FromArgb(250, 235, 215))//eklediğim renk
            {

                button2.BackColor = Color.FromArgb(205, 92, 92); //ana rengim
            }
            else
            {
                button2.BackColor = Color.FromArgb(250, 235, 215);
            }
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.FromArgb(205, 92, 92))
            {

                button2.BackColor = Color.FromArgb(250, 235, 215);
            }
            else
            {
                button2.BackColor = Color.FromArgb(205, 92, 92);
            }
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.FromArgb(70, 130, 180))//eklediğim renk
            {

                button3.BackColor = Color.FromArgb(205, 92, 92); //ana rengim
            }
            else
            {
                button3.BackColor = Color.FromArgb(70, 130, 180);
            }
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.FromArgb(205, 92, 92))
            {

                button3.BackColor = Color.FromArgb(70, 130, 180);
            }
            else
            {
                button3.BackColor = Color.FromArgb(205, 92, 92);
            }
        }
    }
}
