# HƯỚNG DẪN CHẠY DỰ ÁN


## 1. Môi trường

- .NET 10
- Docker Desktop để chạy và tạo PostgreSQL container thông qua  `docker-compose.yml`
- EF Core CLI (Nếu chạy trên Visual Studio Code để chạy migration và update database bằng CLI):

## 2. Cấu hình database

Connection string trong `IncotradeBackend/appsettings.Development.json`:

```json
"Dev": "Host=localhost;Port=5432;Database=incodetrade_db;Username=dev;Password=dev"
```

Database PostgreSQL cấu hình trong `docker-compose.yml`:

- Host: `localhost`
- Port: `5432`
- Database: `incodetrade_db`
- Username: `dev`
- Password: `dev`

## 3. Khởi động PostgreSQL

Trong thư mục gốc của repo, chạy:

```powershell
docker compose up -d
```

Kiểm tra container đang chạy:

```powershell
docker ps
```

Container database cần có tên `incodetrade_db`.

## 4. Restore và build project

Trong thư mục gốc của repo, chạy:

```powershell
dotnet restore .\IncotradeBackend.sln
dotnet build .\IncotradeBackend.sln
```

## 5. Khở tạo bảng trong database bằng migration

Chạy EF Core migration để tạo các bảng:

```powershell
cd IncotradeBackend
dotnet ef database update
```

Các file migrations sẽ nằm trong IncotradeBackend/Infrastructure/Database/Migrations


## 7. Seed dữ liệu mẫu để test

Các file seed nằm trong:

```text
IncotradeBackend/Infrastructure/Database/Seed
```

Thu tu nen chay:

1. `clean-up.sql`
2. `user-seeding.sql`
3. `service-seeding.sql`
4. `staff-seeding.sql`
5. `booking-seeding.sql`

`clean-up.sql` sẽ `TRUNCATE` (Xóa và reset auto-increment) tất cả các bảng trong schema `public`, ngoại trừ bảng `__EFMigrationsHistory`.


## 6. Chạy project

Chạy project với profile HTTPS:

```powershell
cd IncotradeBackend
dotnet run --launch-profile https
```


API sẽ chạy ở port:

```text
https://localhost:7168
```


## 8. Tài khỏan mẫu

File `user-seeding.sql` tạo các user sau:

| Email | Role |
| --- | --- |
| `admin@example.com` | `ADMIN` |
| `nguyenvana@example.com` | `CUSTOMER` |
| `khoa.tran@example.com` | `CUSTOMER` |
| `mai.le@example.com` | `CUSTOMER` |

Mật khẩu:

```text
Test@123456
```
