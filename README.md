# 🏢 Kurumsal Yemekhane Stok, Fatura ve Maliyet Analiz Otomasyonu

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![MSSQL](https://img.shields.io/badge/MSSQL-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Desktop App](https://img.shields.io/badge/App-Windows_Forms-0078D7?style=for-the-badge)

Bu proje, TEİAŞ (Türkiye Elektrik İletim A.Ş.) bünyesinde gerçekleştirilen Ar-Ge stajı kapsamında, kurum yemekhanesinin günlük tüketim, faturalandırma ve stok maliyet hesaplama (ERP) süreçlerini dijitalleştirmek amacıyla geliştirilmiş, veritabanı (MSSQL) destekli bir masaüstü otomasyonudur.

## 📌 Proje Amacı ve Çözülen Problem
Büyük ölçekli devlet kurumlarında günlük yemekhane tüketimleri, malzeme stokları ve harici/dahili fatura girişleri manuel yapıldığında ciddi maliyet hesaplama hatalarına ve stok açıklarına yol açar. Bu proje ile;
- Manuel evrak ve Excel tabanlı stok takibi tamamen dijitalleştirilmiş, veri kaybı önlenmiştir.
- Günlük tüketim malzemeleri, dahili/harici fatura dökümleri ve gelir-gider (avans) dengesi tek ekrandan yönetilebilir hale getirilmiştir.
- Kullanıcı yetkilendirmesi ile işlem güvenliği (kimin hangi stoğu girdiği/çıkardığı) sağlanmıştır.

## ⚙️ Sistem Mimarisi ve Teknik Özellikler
Uygulama, Windows Forms (WinForms) altyapısı üzerinde C# ile geliştirilmiş olup, arka planda güçlü bir ilişkisel veritabanı mimarisi kullanır.
1. **Veritabanı Katmanı (MSSQL):** Stok hareketleri, fatura kayıtları ve kullanıcı logları için ilişkisel tablolar kurgulanmıştır.
2. **Finansal Modül:** Avans girişi, dahili/harici fatura ekleme ve döküm listeleme işlemleri matematiksel bir algoritmaya bağlanmıştır.
3. **Stok ve Kategori Yönetimi:** Ürün giriş/çıkış (stok_hareketi), özel yemek listesi oluşturma ve kişi/kullanıcı bazlı yönetim modülleri mevcuttur.
4. **Arayüz (UI/UX):** Kurum personelinin teknoloji okuryazarlığı göz önüne alınarak hızlı tepki veren ve sade bir arayüz tasarlanmıştır.

## 💻 Kurulum ve Test
1. Repoyu klonlayın ve Visual Studio üzerinden `.sln` dosyasını açın.
2. `Database` klasörü (veya ilgili SQL scripti) üzerinden veritabanı şemasını SQL Server (SSMS) üzerinde ayağa kaldırın.
3. `App.config` dosyası içindeki `ConnectionString` ayarını kendi yerel veritabanı sunucunuza göre güncelleyin.
4. Projeyi derleyip (Build) çalıştırın.

> **Not:** Kurumun (TEİAŞ) güvenlik politikaları ve veri gizliliği (KVKK) gereği, repodaki veritabanı bağlantı dizeleri ve varsa örnek personel/fatura verileri anonimleştirilmiştir.
