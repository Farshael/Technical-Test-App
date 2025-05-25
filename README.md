# TechnicalTest 

Aplikasi web ini dibuat menggunakan ASP.NET Core dengan fitur-fitur seperti registrasi pengguna, login, edit profil, upload foto profil, konfirmasi email, manajemen produk dan kategori, soft delete dan restore, serta tampilan dashboard dinamis.

## Cara Menjalankan Aplikasi

1. Clone repository:
```bash
git clone https://github.com/username/TechnicalTest.git
cd TechnicalTest

2. Atur koneksi database di file appsettings.json:
json
Copy code
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TechnicalTestDb;Trusted_Connection=True;"
}

3. Restore dependensi:
bash
Copy code
dotnet restore

4. Jalankan migrasi untuk membuat database:
bash
Copy code
dotnet ef database update

5. Jalankan aplikasi:
bash
Copy code
dotnet run

6. Aplikasi dapat diakses di:
https://localhost:5001
http://localhost:5000

7. Fitur
- Registrasi dan login pengguna
- Konfirmasi email saat registrasi
- Edit profil dan upload foto profil
- CRUD kategori produk dan produk
- Soft delete dan fitur restore
- Tampilan antarmuka modern menggunakan Bootstrap


--- 
