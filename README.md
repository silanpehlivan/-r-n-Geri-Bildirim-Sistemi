💬 Ürün Geri Bildirim Sistemi

Bu proje, kullanıcıların ürünler hakkında geri bildirim oluşturmasını, görüntülemesini ve yönetmesini sağlayan bir masaüstü uygulamasıdır. C# programlama dili, Windows Forms (WinForms) arayüzü ve SQL Server veritabanı kullanılarak geliştirilmiştir. Projenin temel amacı, kullanıcı geri bildirim süreçlerini dijital ortamda yönetmek ve temel veritabanı işlemlerini (CRUD) uygulamalı bir şekilde göstermektir.




📝 Proje Hakkında

Uygulama, kullanıcıların ürünlerle ilgili yorum ve puanlama yapabildiği, bu geri bildirimleri yönetebildiği kapsamlı bir sistem sunar. Temel olarak aşağıdaki modülleri içerir:

•
Kullanıcı Yönetimi: Kullanıcıların sisteme kaydolması, giriş yapması ve bilgilerini yönetmesi.

•
Ürün Yönetimi: Ürünlerin eklenmesi, güncellenmesi, silinmesi ve listelenmesi.

•
Kategori Yönetimi: Ürünlerin kategorilere ayrılması ve kategori bilgilerinin yönetilmesi.

•
Geri Bildirim Yönetimi: Kullanıcıların ürünler hakkında puan ve yorum bırakması, bu geri bildirimlerin görüntülenmesi, güncellenmesi ve silinmesi.

Proje, kullanıcı dostu bir arayüz ile temel CRUD (Create, Read, Update, Delete) işlemlerini etkin bir şekilde gerçekleştirmektedir.




⚙️ Teknik Detaylar

Özellik
Açıklama
Dil
C#
Platform
.NET Framework 4.7.2
Arayüz
Windows Forms (WinForms)
Veritabanı
SQL Server
IDE
Visual Studio
Mimari
Nesne Yönelimli Programlama (OOP) İlkeleri
Veri Erişim
ADO.NET, Typed DataSet Yapıları
Şifreleme
SHA-256 (Giriş Ekranı), BCrypt (Kullanıcı Kayıt/Güncelleme)







🚀 Kullanılan Teknolojiler ve Kütüphaneler

Proje geliştirilirken aşağıdaki temel teknolojiler ve NuGet paketleri kullanılmıştır:

•
C#: Uygulamanın ana programlama dili.

•
Windows Forms: Kullanıcı arayüzünün oluşturulması için kullanılan .NET Framework teknolojisi.

•
SQL Server: Veritabanı yönetim sistemi.

•
ADO.NET: Veritabanı bağlantısı ve veri işlemleri için kullanılan .NET veri erişim teknolojisi.

•
Typed DataSet: Veritabanı tablolarının uygulama içinde tip güvenli bir şekilde temsil edilmesi.

•
BCrypt.Net-Next: Kullanıcı şifrelerinin güvenli bir şekilde hash'lenmesi için kullanılan kütüphane.

•
Bunifu.UI.WinForms: Modern UI bileşenleri ve tasarım öğeleri için kullanılan üçüncü taraf kütüphane.

•
MaterialSkin.2: Material Design prensiplerine uygun arayüz tasarımı için kullanılan kütüphane.




📋 Temel Özellikler

✅ Kullanıcı Kimlik Doğrulama ve Yönetimi

•
Güvenli kullanıcı girişi (SHA-256 hash ile şifre kontrolü).

•
Yeni kullanıcı kaydı (BCrypt ile şifre hash'leme).

•
Kullanıcı bilgilerini görüntüleme, güncelleme ve silme.

✅ Ürün Yönetimi

•
Yeni ürün ekleme (Ad, Açıklama, Fiyat, Stok Miktarı, Kategori).

•
Mevcut ürün bilgilerini güncelleme.

•
Ürünleri silme (ilişkili geri bildirimleri de siler).

•
Ürünleri kategoriye göre listeleme.

✅ Kategori Yönetimi

•
Yeni kategori ekleme.

•
Mevcut kategori adlarını güncelleme.

•
Kategorileri silme (ilişkili ürünleri 'Diğer' kategoriye taşır).

✅ Geri Bildirim ve Değerlendirme Sistemi

•
Ürünler için puan (1-5 arası) ve yorum bırakma.

•
Mevcut geri bildirimleri görüntüleme, güncelleme ve silme.

•
Geri bildirimleri ürün ve kullanıcı bazında yönetme.




🛠️ Kurulum ve Çalıştırma

Projeyi yerel ortamınızda kurmak ve çalıştırmak için aşağıdaki adımları izleyin:

1️⃣ Projeyi İndirin

Projeyi ZIP olarak indirip istediğiniz bir dizine çıkarın.

2️⃣ Visual Studio ile Açın

Çıkarılan klasördeki Sql_Proje.sln dosyasını Visual Studio (2019 veya üzeri önerilir) ile açın.

3️⃣ Veritabanını Yapılandırın

Proje, iki ana veritabanı bağlantısı kullanmaktadır: MusteriBildirimi ve ÜrünBildirimi. Bu veritabanlarını SQL Server üzerinde oluşturmanız ve App.config dosyasındaki bağlantı dizelerini kendi SQL Server yapılandırmanıza göre güncellemeniz gerekmektedir. Örnek bağlantı dizeleri App.config dosyasında aşağıdaki gibi görünmektedir:

XML


<connectionStrings>
    <add name="Sql_Proje.Properties.Settings.MusteriBildirimiConnectionString"
        connectionString="Data Source=LAPTOP-EMFFS378;Initial Catalog=MusteriBildirimi;Integrated Security=True;Encrypt=False"
        providerName="System.Data.SqlClient" />
    <add name="Sql_Proje.Properties.Settings.ÜrünBildirimiConnectionString"
        connectionString="Data Source=LAPTOP-EMFFS378;Initial Catalog=ÜrünBildirimi;Integrated Security=True;TrustServerCertificate=True"
        providerName="System.Data.SqlClient" />
</connectionStrings>



Not: LAPTOP-EMFFS378 yerine kendi SQL Server adınızı veya IP adresinizi yazmanız gerekmektedir. Encrypt=False ve TrustServerCertificate=True ayarları, yerel geliştirme ortamları için uygun olabilir ancak üretim ortamlarında güvenlik önlemleri gözden geçirilmelidir.

Veritabanı tablolarını oluşturmak için gerekli SQL scriptleri genellikle projenin Sql_Proje.zip veya benzeri bir dosya içinde bulunabilir. Eğer yoksa, MusteriBildirimiDataSet.xsd ve ÜrünBildirimiDataSet.xsd dosyalarındaki şema tanımlarından faydalanarak tabloları manuel olarak oluşturmanız gerekebilir.

4️⃣ Projeyi Çalıştırın

Visual Studio içerisinde F5 tuşuna basarak veya Başlat butonuna tıklayarak projeyi çalıştırabilirsiniz. Uygulama, FormKG (Giriş Formu) ile başlayacaktır.




📂 Proje Yapısı

Plain Text


.Geri-Bildirim-Sistemi-master/
├── App.config                     # Uygulama yapılandırma ve veritabanı bağlantı dizeleri
├── Form1.cs (FormKG)              # Kullanıcı giriş ekranı (Login)
├── Form2.cs                       # Ana menü ekranı (Modül seçimleri)
├── Form3.cs (Formkullanıcı)       # Kullanıcı yönetimi ekranı (CRUD)
├── Form4.cs (Formkategori)        # Kategori yönetimi ekranı (CRUD)
├── Form5.cs (Formürünler)         # Ürün yönetimi ekranı (CRUD)
├── Form6.cs (FormGeriBildirim)    # Geri bildirim yönetimi ekranı (CRUD)
├── Form7.cs (Formürünresmi)       # Ürün resmi görüntüleme (minimal)
├── Program.cs                     # Uygulamanın başlangıç noktası
├── MusteriBildirimiDataSet.xsd    # Müşteri bildirimleri için Typed DataSet şeması
├── ÜrünBildirimiDataSet.xsd       # Ürün bildirimleri için Typed DataSet şeması
├── Sql_Proje.csproj               # C# proje dosyası
├── Sql_Proje.sln                  # Visual Studio çözüm dosyası
├── Resources/                     # Uygulama kaynakları (resimler, ikonlar vb.)
├── packages.config                # NuGet paket bağımlılıkları
└── LICENSE                        # Proje lisans bilgisi






🎯 Projenin Amacı

Bu proje, aşağıdaki öğrenim ve uygulama hedeflerini gerçekleştirmek üzere tasarlanmıştır:

•
SQL Veritabanı Entegrasyonu: C# WinForms uygulamaları ile SQL Server veritabanı arasında bağlantı kurma ve veri manipülasyonu yapma.

•
CRUD İşlemleri: Veritabanı üzerinde Create, Read, Update, Delete (CRUD) operasyonlarının pratik uygulaması.

•
Windows Forms Geliştirme: Kullanıcı arayüzü tasarımı ve olay tabanlı programlama prensipleriyle masaüstü uygulamaları geliştirme.

•
Nesne Yönelimli Programlama (OOP): Projede OOP prensiplerini (sınıflar, nesneler, metotlar vb.) uygulama.

•
Kullanıcı Geri Bildirim Yönetimi: Gerçek dünya senaryolarında kullanıcı geri bildirimlerini dijital bir platformda yönetme yeteneği kazanma.




📜 Lisans

Bu proje MIT Lisansı ile lisanslanmıştır. Daha fazla bilgi için lütfen LICENSE dosyasını inceleyiniz.




👩‍💻 Yazar

Şilan Pehlivan

