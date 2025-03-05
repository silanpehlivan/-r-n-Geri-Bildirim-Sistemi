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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Cryptography;



namespace Sql_Proje
{
    public partial class FormKG : Form
    {

        SqlConnection con; //connection =bağlantı
        SqlDataReader dr; //Veriyi okurum
        SqlCommand com; //com = komut satırı

        public FormKG()
        {
            InitializeComponent();
        }

        private void FormKG_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            this.Icon = new System.Drawing.Icon(@"C:\Users\HP\Downloads\dislike.ico");
        }
        // Şifreyi SHA-256 ile hash'leyen fonksiyon
        private string HashPassword(string sifre)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(sifre));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Kullanıcı adı ve şifreyi değişkenlere al
            string kullaniciAdi = textBox1.Text.Trim(); //Kullanıcı Adaı
            string sifre = textBox2.Text.Trim(); //Kullanıcı Şifresi

            // Kullanıcı adı ve şifre boşsa uyarı ver
            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifre girin.");
                return; // İşlemi sonlandır
            }

            // Şifreyi hash'le (SHA-256)
            string hashedSifre = HashPassword(sifre);

            // SQL bağlantısını oluştur
            string connectionString = "Server=LAPTOP-EMFFS378; Database=Kullanici; Integrated Security=true;";
            using (con = new SqlConnection(connectionString))
            {
                // Parametreli sorgu kullanımı
                string sorgu = "SELECT * FROM KullaniciBilgi WHERE kullanici_adi = @kullaniciAdi AND sifre = @sifre";
                com = new SqlCommand(sorgu, con);

                // Parametreleri ekle
                com.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                com.Parameters.AddWithValue("@sifre", sifre);

                try
                {
                    // Bağlantıyı aç ve sorguyu çalıştır
                    con.Open();
                    dr = com.ExecuteReader();

                    if (dr.Read())
                    {
                        // Giriş başarılı
                        MessageBox.Show("Tebrikler, başarılı giriş yaptınız!");
                        Form2 form2 = new Form2();
                        form2.Show();
                        this.Hide(); // Şu anki formu gizle
                    }
                    else
                    {
                        // Hatalı giriş
                        MessageBox.Show("Hatalı kullanıcı adı veya şifre girdiniz.");
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda mesaj göster
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    // Bağlantıyı ve veri okuyucuyu kapat
                    if (dr != null && !dr.IsClosed)
                    {
                        dr.Close();
                    }

                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }

            if (button1.BackColor == Color.FromArgb(43, 105, 137))
            {
                button1.BackColor = Color.White;
            }
            else
            {
                button1.BackColor = Color.FromArgb(43, 105, 137);
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {

            if (button1.BackColor == Color.FromArgb(43, 105, 137))
            {
                button1.BackColor = Color.FromArgb(150, 181, 197);
            }
            else
            {
                button1.BackColor = Color.FromArgb(43, 105, 137);
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.FromArgb(150, 181, 197))
            {
                button1.BackColor = Color.FromArgb(43, 105, 137);
            }
            else
            {
                button1.BackColor = Color.FromArgb(150, 181, 197);
            }
        }
    }
}
