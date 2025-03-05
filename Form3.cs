using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using BCrypt.Net;
using System.Collections;

namespace Sql_Proje
{
    public partial class Formkullanıcı : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        public Formkullanıcı()
        {
            InitializeComponent();
        }
       
        private bool TestConnection()
        {
            string connectionString = "Server=LAPTOP-EMFFS378; Database=ÜrünBildirimi; Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bağlantı hatası: " + ex.Message);
                    return false;
                }
            }
        }

        void MusteriGetir()
        {
            SqlConnection _bağlanti = new SqlConnection("Server=LAPTOP-EMFFS378; database=ÜrünBildirimi; Integrated security=true;");
            SqlDataAdapter adp = new SqlDataAdapter("select * from Kullanıcılar", _bağlanti);
            DataTable dt = new DataTable(); //tablolarımı çekerim
            adp.Fill(dt); //tablolarımı ekliyorum.
            dataGridView1.DataSource = dt; //Bağlantımı yaptım.
            _bağlanti.Close();
            dataGridView1.Columns[0].Visible = false;//kolonun verilerini bellekte tutar, ancak kullanıcı arayüzünde görünmez hale getirir.[] içrisine indeks numarası vaya kolon adını koyarak silebilirim.
            dataGridView1.Columns[6].Visible = false;
        }

        private void Formkullanıcı_Load(object sender, EventArgs e)
        {
            
            MusteriGetir();
            // DataGridView'in satır yüksekliğini 30 piksel olarak ayarlamak
        }


        // Şifreyi hash'lemek için metot
        private string HashPassword(string sifre)
        {
            // BCrypt ile şifreyi hash'le
            return BCrypt.Net.BCrypt.HashPassword(sifre);
        }

        private void SaveUserToDatabase(string ad, string soyad, string email, string hashedPassword)
        {
            string connectionString = "Server=LAPTOP-EMFFS378; Database=ÜrünBildirimi; Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Bağlantıyı aç
                    conn.Open();

                    // SQL sorgusunu oluştur
                    string query = "INSERT INTO Kullanıcılar (Ad, Soyad, Eposta, ŞifreHash) VALUES (@Ad, @Soyad, @Eposta, @ŞifreHash)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Parametre ekle
                        cmd.Parameters.AddWithValue("@Ad", ad);
                        cmd.Parameters.AddWithValue("@Soyad", soyad);
                        cmd.Parameters.AddWithValue("@Eposta", email);
                        cmd.Parameters.AddWithValue("@ŞifreHash", hashedPassword);

                        // Komutu çalıştır ve veriyi veritabanına ekle
                        cmd.ExecuteNonQuery();
                    }

                    // Başarılı ekleme mesajı
                    MessageBox.Show("Kullanıcı başarıyla veritabanına kaydedildi!");
                }
                catch (Exception ex)
                {
                    // Hata durumunda mesaj göster
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    // Bağlantıyı kapat
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {

        }


        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kullanıcı bilgilerini al
            string kullaniciAdi = textBox1.Text;
            string kullaniciSoyadi = textBox2.Text;
            string email = textBox3.Text;
            string sifre = textBox4.Text;

            // Şifreyi hash'le
            string hashedPassword = HashPassword(sifre);

            // Kullanıcıyı veritabanına kaydet
            SaveUserToDatabase(kullaniciAdi, kullaniciSoyadi, email, hashedPassword);

            // Kullanıcıya bilgilendirme mesajı
            MessageBox.Show("Kullanıcı başarıyla kaydedildi!");

            // DataGridView'ı güncelle
            MusteriGetir();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string email = textBox3.Text;  // E-posta adresi üzerinden kullanıcıyı bul
            string kullaniciAdi = textBox1.Text; // Ad
            string kullaniciSoyadi = textBox2.Text; // Soyad
            string newEmail = textBox3.Text;  // Yeni E-posta
            string newsifre = textBox4.Text;  // Yeni şifreyi al

            // Yeni şifreyi hash'le
            string hashedPassword = HashPassword(newsifre);

            // Veritabanında tüm bilgileri güncelle
            UpdateUserInDatabase(kullaniciAdi, kullaniciSoyadi, newEmail, hashedPassword);

            // Kullanıcıya bilgilendirme mesajı
            MessageBox.Show("Kullanıcı bilgileri başarıyla güncellendi!");

            // DataGridView'ı güncelle
            MusteriGetir();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void UpdateUserInDatabase(string ad, string soyad, string email, string hashedPassword)
        {
            string connectionString = "Server=LAPTOP-EMFFS378; Database=ÜrünBildirimi; Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {

                    // Veritabanı bağlantısını test et
                    if (!TestConnection())
                    {
                        return;  // Eğer bağlantı sağlanamazsa işlemi sonlandır
                    }
                    // Bağlantıyı aç
                    conn.Open();

                    // Sorguyu oluştur
                    string query = "UPDATE Kullanıcılar SET Ad = @Ad, Soyad = @Soyad, Eposta = @Eposta, ŞifreHash = @ŞifreHash WHERE Eposta = @Eposta";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Parametre ekle
                        cmd.Parameters.AddWithValue("@Ad", ad);
                        cmd.Parameters.AddWithValue("@Soyad", soyad);
                        cmd.Parameters.AddWithValue("@Eposta", email);
                        cmd.Parameters.AddWithValue("@ŞifreHash", hashedPassword);

                        // Komutu çalıştır ve verileri güncelle
                        cmd.ExecuteNonQuery();
                    }

                    // Kullanıcıya bilgilendirme mesajı
                    MessageBox.Show("Kullanıcı bilgileri başarıyla güncellendi!");

                }
                catch (Exception ex)
                {
                    // Hata durumunda kullanıcıya bilgi ver
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    // Bağlantıyı kapat
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //// Bağlantı dizesi
            string connectionString = "Server=LAPTOP-EMFFS378; Database=ÜrünBildirimi; Integrated Security=True;";
            string kullaniciSoyadi = textBox2.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Kullanıcı ID'sini al
                    string getUserIdQuery = "SELECT KullanıcıID FROM Kullanıcılar WHERE Soyad = @Soyad";
                    int userId;

                    using (SqlCommand getUserIdCmd = new SqlCommand(getUserIdQuery, conn))
                    {
                        getUserIdCmd.Parameters.AddWithValue("@Soyad", kullaniciSoyadi);
                        object result = getUserIdCmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Silinecek kullanıcı bulunamadı!");
                            return;
                        }

                        userId = Convert.ToInt32(result);
                    }

                    // GeriBildirimler tablosundan sil
                    string deleteFeedbackQuery = "DELETE FROM GeriBildirimler WHERE KullanıcıID = @KullanıcıID";
                    using (SqlCommand deleteFeedbackCmd = new SqlCommand(deleteFeedbackQuery, conn))
                    {
                        deleteFeedbackCmd.Parameters.AddWithValue("@KullanıcıID", userId);
                        deleteFeedbackCmd.ExecuteNonQuery();
                    }

                    // Kullanıcıyı sil
                    string deleteUserQuery = "DELETE FROM Kullanıcılar WHERE KullanıcıID = @KullanıcıID";
                    using (SqlCommand deleteUserCmd = new SqlCommand(deleteUserQuery, conn))
                    {
                        deleteUserCmd.Parameters.AddWithValue("@KullanıcıID", userId);
                        int rowsAffected = deleteUserCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kullanıcı başarıyla silindi!");
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı silinemedi!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }


            // DataGridView'ı güncelle
            MusteriGetir(); // Veritabanındaki en son veriyi al ve DataGridView'ı güncelle

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }



        private void button4_Click_1(object sender, EventArgs e)
        {
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
           

            if (button3.BackColor == Color.FromArgb(188, 143, 143))
            {

                button3.BackColor = Color.FromArgb(153, 180, 209);
            }
            else
            {
                button3.BackColor = Color.FromArgb(188, 143, 143);
            }
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.FromArgb(153, 180, 209))//ayrılırken ana rengi yazdım
            {
                button3.BackColor = Color.FromArgb(188, 143, 143);
            }
            else
            {
                button3.BackColor = Color.FromArgb(153, 180, 209);
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.FromArgb(238, 99, 99))//eklediğim renk
            {

                button1.BackColor = Color.FromArgb(153, 180, 209);//ana rengim
            }
            else
            {
                button1.BackColor = Color.FromArgb(238, 99, 99);
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.FromArgb(153, 180, 209))
            {

                button1.BackColor = Color.FromArgb(238, 99, 99);
            }
            else
            {
                button1.BackColor = Color.FromArgb(153, 180, 209);
            }
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.FromArgb(238 ,130, 98))//eklediğim renk
            {

                button2.BackColor = Color.FromArgb(153, 180, 209);//ana rengim
            }
            else
            {
                button2.BackColor = Color.FromArgb(238, 130, 98);
            }
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if(button2.BackColor==Color.FromArgb(153, 180, 209))
            {
                button2.BackColor = Color.FromArgb(238, 130, 98);
            }
            else
            {
                button2.BackColor = Color.FromArgb(153, 180, 209);
            }
        }
    }
}