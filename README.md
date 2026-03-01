# 🌍 Travelin - Tur Rezervasyon Yönetim Sistemi

ASP.NET Core MVC ile geliştirilmiş, MongoDB tabanlı full-stack tur rezervasyon platformu.

## 🚀 Özellikler

### 👤 Kullanıcı Tarafı
- Tur listeleme, arama ve filtreleme
- Online rezervasyon oluşturma
- Rezervasyon onay e-postası alma (otomatik)

### 🛠️ Admin Paneli
- Tur yönetimi (CRUD) — görsel, tarih, kapasite, süre
- Rezervasyon yönetimi — onaylama, reddetme, silme
- Tura özel rezervasyon listeleme
- Excel export (ClosedXML) — tüm rezervasyonlar veya tura özel
- Rezervasyon onaylandığında kullanıcıya otomatik e-posta gönderimi
- AI destekli içerik üretimi (OpenAI & Claude AI entegrasyonu)

## 🤖 Yapay Zeka Entegrasyonu
- **OpenAI GPT** — Admin panelinde tur açıklaması, içerik ve öneri üretimi
- **Claude AI** — Admin panelinde akıllı içerik desteği ve öneri sistemi

## 📧 E-posta Sistemi
- Rezervasyon onaylandığında kullanıcıya otomatik bildirim e-postası

## 🧰 Kullanılan Teknolojiler
- ASP.NET Core MVC (.NET 8)
- MongoDB & AutoMapper
- OpenAI API & Claude AI
- ClosedXML (Excel Export)
- Bootstrap 5 & Bootstrap Icons
- Repository Pattern, Service Layer, DTO Mimarisi

---

## 📌 Proje Detayları

### 🗄️ Veritabanı & Mimari
MongoDB üzerinde **Booking** ve **Tour** koleksiyonları tasarlandı. Tüm veri akışı **DTO (Data Transfer Object)** katmanı üzerinden yönetildi — entity'ler hiçbir zaman doğrudan view'a taşınmadı. **AutoMapper** ile entity↔DTO dönüşümleri otomatikleştirildi. **Service Layer** ve **Interface** yapısıyla bağımlılıklar soyutlandı, test edilebilir ve sürdürülebilir bir mimari kuruldu.

### 🗺️ Tur Yönetimi
Admin panelinde turlar listelenebilir, oluşturulabilir, güncellenebilir ve silinebilir. Her tur için başlık, ülke, şehir, tarih, süre (gün/gece), kapasite, açıklama ve görsel URL bilgileri yönetildi. Liste sayfasında **arama, ülke filtresi ve tarih aralığı** filtreleme özellikleri eklendi. Silme işlemleri **onay modal**'ı ile güvence altına alındı.

### 📋 Rezervasyon Yönetimi
Rezervasyonlar admin panelinde listelendi; **onaylama, reddetme ve silme** işlemleri modal onay adımlarıyla yapılabilir hale getirildi. Her rezervasyonun detayı **detay modal**'ında gösterildi. Rezervasyonlar **Tümü / Onaylı / Beklemede** sekmeleriyle filtrelenebildi. İsim, e-posta ve telefona göre **anlık arama** eklendi.

### ✅ Onay & Durum Sistemi
`IsStatus` alanı ile her rezervasyonun onay durumu MongoDB'de takip edildi. Admin bir rezervasyonu onayladığında durum `true`'ya güncellendi ve kullanıcıya **otomatik e-posta bildirimi** gönderildi. Onaylı rezervasyonlarda **Reddet**, bekleyenlerde **Onayla** butonu dinamik olarak gösterildi.

### 📊 Excel Export
**ClosedXML** kütüphanesi ile iki farklı Excel export özelliği geliştirildi. Birincisi tüm rezervasyonları indiren genel export; ikincisi tura özel rezervasyon raporu. Her iki raporda da başlık satırı renklendirildi, zebra satır renklendirmesi uygulandı, durum sütununda **Onaylı/Beklemede** metni ve satır rengi dinamik olarak ayarlandı. Sütunlar otomatik genişletildi.

### 🤖 Yapay Zeka Entegrasyonu
Admin paneline **OpenAI GPT** ve **Claude AI** entegre edildi. Tur açıklaması oluşturma, içerik önerisi üretme gibi tekrar eden içerik görevleri yapay zeka ile otomatikleştirildi. Bu sayede admin kullanıcıların içerik üretim süreci hızlandırıldı.

### 🎨 Arayüz & UX
Tüm admin sayfaları **Bootstrap 5** ve **Bootstrap Icons** kullanılarak sıfırdan tasarlandı. Tablo kartları, filtre kartları, durum badge'leri, avatar gösterimi ve aksiyon butonları tutarlı bir design system üzerinde inşa edildi. Mobil uyumluluk için responsive breakpoint'ler eklendi; tablolar küçük ekranlarda kart görünümüne dönüştürüldü.
