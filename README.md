# 💬 Ürün Geri Bildirim Sistemi

Bu proje, kullanıcıların ürünler hakkında geri bildirim oluşturmasını, görüntülemesini ve yönetmesini sağlayan bir masaüstü uygulamasıdır. C#, Windows Forms (WinForms) ve SQL Server teknolojileri kullanılarak geliştirilmiştir.

---

# 📝 Proje Hakkında

Uygulama, kullanıcıların ürünlerle ilgili yorum ve puanlama yapabildiği, bu geri bildirimleri yönetebildiği bir sistem sunar. Temel olarak aşağıdaki işlevleri yerine getirir:

- **Kullanıcı Yönetimi**  
Kullanıcıların sisteme giriş yapması ve bilgilerini yönetmesi.

- **Ürün Yönetimi**  
Ürünlerin eklenmesi, güncellenmesi, silinmesi ve listelenmesi.

- **Kategori Yönetimi**  
Ürünlerin kategorilere ayrılması ve kategori bilgilerinin yönetilmesi.

- **Geri Bildirim Yönetimi**  
Kullanıcıların ürünler hakkında puan ve yorum bırakması, bu geri bildirimlerin görüntülenmesi, güncellenmesi ve silinmesi.

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
├── App.config                               # Uygulama yapılandırma ve veritabanı bağlantı dizeleri
├── Form1.cs (FormKG)                        # Kullanıcı giriş ekranı (Login)
├── Form2.cs                                 # Ana menü ekranı (Modül seçimleri)
├── Form3.cs (Formkullanıcı)                 # Kullanıcı yönetimi ekranı (CRUD)
├── Form4.cs (Formkategori)                  # Kategori yönetimi ekranı (CRUD)
├── Form5.cs (Formürünler)                   # Ürün yönetimi ekranı (CRUD)
├── Form6.cs (FormGeriBildirim)              # Geri bildirim yönetimi ekranı (CRUD)
├── Form7.cs (Formürünresmi)                 # Ürün resmi görüntüleme ekranı
├── Program.cs                               # Uygulamanın başlangıç noktası

├── MusteriBildirimiDataSet.Designer.cs      # Müşteri bildirimleri için Typed DataSet tasarım dosyası
├── MusteriBildirimiDataSet.xsc              # Müşteri bildirimleri için şema kontrol dosyası
├── MusteriBildirimiDataSet.xsd              # Müşteri bildirimleri için Typed DataSet şeması
├── MusteriBildirimiDataSet.xss              # Müşteri bildirimleri için şema depolama dosyası

├── ÜrünBildirimiDataSet.Designer.cs         # Ürün bildirimleri için Typed DataSet tasarım dosyası
├── ÜrünBildirimiDataSet.xsc                 # Ürün bildirimleri için şema kontrol dosyası
├── ÜrünBildirimiDataSet.xsd                 # Ürün bildirimleri için Typed DataSet şeması
├── ÜrünBildirimiDataSet.xss                 # Ürün bildirimleri için şema depolama dosyası

├── Sql_Proje.csproj                         # C# proje dosyası
├── Sql_Proje.sln                            # Visual Studio çözüm dosyası

├── Resources/                               # Uygulama kaynak dosyaları (ikonlar, görseller vb.)
├── Properties/                              # Proje ayarları ve yapılandırma dosyaları
├── packages.config                          # NuGet paket bağımlılıkları

└── LICENSE                                  # Proje lisans bilgisi
```

---
## 📜 Lisans

Bu proje **MIT License** ile lisanslanmıştır. Detaylı bilgi için `LICENSE` dosyasını inceleyebilirsiniz.

## 👩‍💻 Geliştirici

Şilan Pehlivan
