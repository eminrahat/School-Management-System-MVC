# 🎓 Okul Yönetim ve Öğrenci Not Otomasyon Sistemi

ASP.NET MVC mimarisi kullanılarak geliştirilmiş, kurumsal güvenlik standartlarına ve modern arayüz tasarımına sahip kapsamlı bir okul ve öğrenci yönetim platformudur.

---

## 🚀 Proje Hakkında
Bu proje; eğitim kurumlarının öğrenci kayıtlarını, ders yönetimini, kulüp işlemlerini ve sınav/not ortalamalarını tek bir panel üzerinden dijital olarak yönetebilmesi amacıyla sıfırdan geliştirilmiştir. Temiz kod (Clean Code) prensipleri gözetilerek, Katmanlı Mimari (N-Tier Architecture) yaklaşımına uygun olarak tasarlanmıştır.

---

## 🛠️ Kullanılan Teknolojiler ve Altyapı
* **Backend:** C#, ASP.NET MVC 5, LINQ, Entity Framework (EF) ORM
* **Veritabanı Yönetimi:** MS SQL Server, T-SQL (İlişkisel Veritabanı Tasarımı)
* **Güvenlik:** Forms Authentication (Kullanıcı Oturum ve Yetkilendirme Mekanizması)
* **Frontend & Arayüz:** HTML5, CSS3, JavaScript, Bootstrap 3/4, Glassmorphism & Modern UI Tasarım Prensipleri
* **Versiyon Kontrol:** Git, GitHub

---

## 📸 Ekran Görüntüleri (UI / UX)

### 1. Karşılama ve Giriş Ekranları
Kullanıcıları karşılayan modern, buzlu cam (Glassmorphism) efektli ve okyanus tonlarındaki estetik giriş paneli:
<p align="center">
  <img src="https://raw.githubusercontent.com/eminrahat/School-Management-System-MVC/main/Ogrenci_Not_Mvc/image_e112e8.jpg" width="45%" alt="Karşılama Ekranı">
  <img src="https://raw.githubusercontent.com/eminrahat/School-Management-System-MVC/main/Ogrenci_Not_Mvc/image_e112af.jpg" width="45%" alt="Giriş Paneli">
</p>

### 2. Öğrenci Yönetim Paneli
Kayıtlı öğrencilerin listelendiği, arama ve yönetim işlemlerinin yapıldığı ana ekran:
<p align="center">
  <img src="https://raw.githubusercontent.com/eminrahat/School-Management-System-MVC/main/Ogrenci_Not_Mvc/image_e11254.png" width="100%" alt="Öğrenci Yönetimi">
</p>

### 3. Ders ve Kulüp İşlemleri
Aktif derslerin ve okul kulüplerinin yönetildiği modüller:
<p align="center">
  <img src="https://raw.githubusercontent.com/eminrahat/School-Management-System-MVC/main/Ogrenci_Not_Mvc/image_e10f89.png" width="48%" alt="Ders Yönetimi">
  <img src="https://raw.githubusercontent.com/eminrahat/School-Management-System-MVC/main/Ogrenci_Not_Mvc/image_e10f67.png" width="48%" alt="Kulüp Yönetimi">
</p>

### 4. Sınav ve Not Giriş Sistemi
Öğrencilerin sınav notlarının işlendiği, ortalamaların hesaplandığı ve "Geçti / Kaldı" durumlarının otomatik listelendiği akıllı tablo:
<p align="center">
  <img src="https://raw.githubusercontent.com/eminrahat/School-Management-System-MVC/main/Ogrenci_Not_Mvc/image_e10f2f.png" width="100%" alt="Sınav ve Not Girişi">
</p>

### 5. Sistem Destek ve İstatistik Paneli
Genel okul istatistiklerinin (Toplam öğrenci, ders, kulüp, başarılı/başarısız öğrenci sayıları) anlık takip edildiği yönetim paneli:
<p align="center">
  <img src="https://raw.githubusercontent.com/eminrahat/School-Management-System-MVC/main/Ogrenci_Not_Mvc/image_e10f0b.png" width="100%" alt="Sistem İstatistikleri">
</p>

---

## ⚙️ Başlıca Özellikler ve Mimari Detaylar
* **Güvenlik:** `[Authorize]` öznitelikleri ve `Forms Authentication` entegrasyonu ile yetkisiz kullanıcıların URL'ler üzerinden yönetim panellerine erişimi engellenmiştir.
* **Veritabanı İlişkileri:** Entity Framework yaklaşımıyla öğrenciler, dersler ve kulüpler arasında güçlü ilişkisel tablolar kurulmuştur.
* **Dinamik Hesaplamalar:** Sınav ve proje notları üzerinden otomatik ortalama hesaplama ve başarı durumuna göre dinamik arayüz renklendirmesi (Geçti/Kaldı rozetleri).

---

## 👨‍💻 Geliştirici
* **Emin Rahat** - [GitHub Profilim](https://github.com/eminrahat)
