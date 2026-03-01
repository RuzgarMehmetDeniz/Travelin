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



# ![Default1](https://github.com/user-attachments/assets/0050edb8-4416-4923-ae92-5f1d878285e7)
# ![Default2](https://github.com/user-attachments/assets/b37e21b4-4c92-48c5-8da1-32c742a37362)
# ![Default3](https://github.com/user-attachments/assets/6444c14d-0030-40da-8a70-0603536a5d16)
# ![Default4](https://github.com/user-attachments/assets/2e7eaefb-c205-4a07-8660-94c2df29b3a8)
# ![Default5](https://github.com/user-attachments/assets/24ada1aa-7bc2-4fb0-adf2-cc7cf9f096f6)
# ![Default6](https://github.com/user-attachments/assets/4f2b713b-0a44-49f0-8349-b0ebbfe3c816)
# ![Default7](https://github.com/user-attachments/assets/3e91f6de-da5e-4231-9107-5f7419cbf75f)
# ![Tur1](https://github.com/user-attachments/assets/8a5f87a3-33d1-4498-ba93-2c1265060b1c)
# ![Tur2](https://github.com/user-attachments/assets/4504df4f-f00f-4d32-a94f-61004ef80cce)
# ![Tur3](https://github.com/user-attachments/assets/a9eb5607-cb35-4f09-b2d1-e04f4d365564)
# ![Tur4](https://github.com/user-attachments/assets/7a20bf13-9b94-4ea4-980c-880f05fe7713)
# ![Tur5](https://github.com/user-attachments/assets/08627a6b-706b-44c7-9b59-3d20e34cca54)
# ![Rota1](https://github.com/user-attachments/assets/c55d8519-db06-41ee-bccb-fafbb4f51c56)
# ![Rezervasyon2](https://github.com/user-attachments/assets/2ee85102-d90f-4be2-9128-1ea6d7c1612e)
# ![Mail](https://github.com/user-attachments/assets/ed56f18b-6010-46d9-b6a9-9743df1b4ac8)
# ![Kategorı1](https://github.com/user-attachments/assets/75a6789c-b9a6-414b-b23b-e43486e3af71)
# ![Excel](https://github.com/user-attachments/assets/d1188808-2ae7-4099-8ae5-6dba981e7365)
# ![Yorumlar1](https://github.com/user-attachments/assets/5d653f0d-828a-4ef9-a422-b2c5fc706385)
# ![AdminTur4](https://github.com/user-attachments/assets/ff0fc437-67d1-4e8c-9af2-e68b047ed93a)
# ![AdminTur3](https://github.com/user-attachments/assets/772ae33e-d4a2-4f44-af8d-c63e483d6364)
# ![AdminTur1](https://github.com/user-attachments/assets/bf6b4b7f-68ad-40d9-a0f8-6135a12d0166)
# ![AdmınRezervasyon3](https://github.com/user-attachments/assets/048f0c79-00ac-45bc-9077-ad79c83bfbfc)
# ![AdmınRezervasyon1](https://github.com/user-attachments/assets/c3702d4a-fd5e-4506-87ac-98f5c38a9dbb)

