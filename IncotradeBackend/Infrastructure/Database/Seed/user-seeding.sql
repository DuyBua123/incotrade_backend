INSERT INTO "Users" (
    "FullName",
    "Email",
    "PasswordHash",
    "Role",
    "CreatedAt"
)
VALUES 
(
    'System Admin',
    'admin@example.com',
    'AQAAAAIAAYagAAAAEOc7xqa7Ae9Nb9k17FcA64OAlpSzcy3t6CdriVXSCvAyXE3uEFQ6QQceVA0sEc2SzA==',
    'ADMIN',
    NOW()
), 
(
    'Nguyễn Văn A',
    'nguyenvana@example.com',
    'AQAAAAIAAYagAAAAEOc7xqa7Ae9Nb9k17FcA64OAlpSzcy3t6CdriVXSCvAyXE3uEFQ6QQceVA0sEc2SzA==',
    'CUSTOMER',
    NOW()
),
(
    'Trần Minh Khoa',
    'khoa.tran@example.com',
    'AQAAAAIAAYagAAAAEOc7xqa7Ae9Nb9k17FcA64OAlpSzcy3t6CdriVXSCvAyXE3uEFQ6QQceVA0sEc2SzA==',
    'CUSTOMER',
    NOW()
),
(
    'Lê Thị Mai',
    'mai.le@example.com',
    'AQAAAAIAAYagAAAAEOc7xqa7Ae9Nb9k17FcA64OAlpSzcy3t6CdriVXSCvAyXE3uEFQ6QQceVA0sEc2SzA==',
    'CUSTOMER',
    NOW()
);

