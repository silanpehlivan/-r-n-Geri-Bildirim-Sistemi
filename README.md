````markdown
# 💬 Ürün Geri Bildirim Sistemi

Bu proje, kullanıcıların ürünler hakkında geri bildirim oluşturmasını, görüntülemesini ve yönetmesini sağlayan bir masaüstü uygulamasıdır. C#, Windows Forms (WinForms) ve SQL Server teknolojileri kullanılarak geliştirilmiştir.

---

# 📝 Proje Hakkında

Uygulama, kullanıcıların ürünlerle ilgili yorum ve puanlama yapabildiği, bu geri bildirimleri yönetebildiği bir sistem sunar. Temel olarak aşağıdaki işlevleri yerine getirir:

- **Kullanıcı Yönetimi:** Kullanıcıların sisteme giriş yapması ve bilgilerini yönetmesi.

- **Ürün Yönetimi:** Ürünlerin eklenmesi, güncellenmesi, silinmesi ve listelenmesi.

- **Kategori Yönetimi:** Ürünlerin kategorilere ayrılması ve kategori bilgilerinin yönetilmesi.

- **Geri Bildirim Yönetimi:** Kullanıcıların ürünler hakkında puan ve yorum bırakması, bu geri bildirimlerin görüntülenmesi, güncellenmesi ve silinmesi.

---

# ⚙️ Teknik Detaylar

| Özellik | Açıklama |
|---|---|
| Dil | C# |
| Platform | .NET Framework |
| Arayüz | Windows Forms (WinForms) |
| Veritabanı | SQL Server |

---

# 🚀 Kullanılan Teknolojiler

- C#

- Windows Forms

- SQL Server

- ADO.NET

- BCrypt.Net-Next (Şifreleme)

- Bunifu.UI.WinForms (UI Bileşenleri)

---

# 🛠️ Kurulum ve Çalıştırma

Projeyi yerel ortamınızda kurmak ve çalıştırmak için aşağıdaki adımları izleyin:

1. Projeyi ZIP olarak indirip istediğiniz bir dizine çıkarın.

2. Çıkarılan klasördeki `Sql_Proje.sln` dosyasını Visual Studio ile açın.

3. SQL Server üzerinde gerekli veritabanlarını (`MusteriBildirimi`, `ÜrünBildirimi`) oluşturun ve `App.config` dosyasındaki bağlantı dizelerini kendi SQL Server yapılandırmanıza göre güncelleyin.

4. Visual Studio içerisinde `F5` tuşuna basarak veya **Başlat** butonuna tıklayarak projeyi çalıştırın.

---

# 📂 Proje Yapısı

```plaintext
.Geri-Bildirim-Sistemi-master/
├── App.config                     # Uygulama yapılandırma ve veritabanı bağlantı dizeleri
├── Form1.cs (Giriş Ekranı)        # Kullanıcı giriş ekranı
├── Form2.cs (Ana Menü)            # Ana menü ekranı
├── Form3.cs (Kullanıcı Yönetimi)  # Kullanıcı yönetimi ekranı
├── Form4.cs (Kategori Yönetimi)   # Kategori yönetimi ekranı
├── Form5.cs (Ürün Yönetimi)       # Ürün yönetimi ekranı
├── Form6.cs (Geri Bildirim)       # Geri bildirim yönetimi ekranı
├── Program.cs                     # Uygulamanın başlangıç noktası
├── Sql_Proje.sln                  # Visual Studio çözüm dosyası
└── LICENSE                        # Proje lisans bilgisi
````

---

# 📜 Lisans

Bu proje MIT Lisansı ile lisanslanmıştır. Daha fazla bilgi için lütfen `LICENSE` dosyasını inceleyiniz.

---

# 👩‍💻 Yazar

**Şilan Pehlivan**

```
```
