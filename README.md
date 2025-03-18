# Proje Kurulum Kılavuzu

Bu doküman, projeyi çalıştırmak için gerekli adımları içermektedir.

## 1. Connection String'i Düzenleme
`web.config` dosyasını açın ve `connection string` adresini kendi yapılandırmanıza göre güncelleyin.

## 2. Migration Dosyalarını Silme
`Data` katmanında bulunan `Migrations` klasörünü bulun ve içerisindeki tüm dosyaları silin.

## 3. Migrationları Aktif Etme
Package Manager Console açarak aşağıdaki komutu çalıştırın:
```powershell
enable-migrations
```

## 4. Yeni Migration Oluşturma
Aşağıdaki komutu çalıştırarak yeni bir migration ekleyin. `<Migration_Adi>` yerine anlamlı bir isim verin:
```powershell
add-migration <Migration_Adi>
```

## 5. Veritabanını Güncelleme
Aşağıdaki komutu çalıştırarak veritabanını güncelleyin:
```powershell
update-database
```

## 6. UI Katmanını Başlangıç Projesi Olarak Ayarlama ve Çalıştırma
- `UI` katmanına sağ tıklayın.
- **"Set as Startup Project"** seçeneğini seçin.
- Projeyi çalıştırın.

Bu adımları tamamladıktan sonra proje sorunsuz şekilde çalışmalıdır.

