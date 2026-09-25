-- ============================================================
-- 3. Add 10 Bookings with various statuses
-- ============================================================

-- 1. COMPLETED - Nguyễn Văn A - Cắt tóc cơ bản
INSERT INTO "Bookings" (
    "BookingCode", "CustomerId", "ServiceId", "StaffId",
    "StartTime", "EndTime", "ServedDate", "Status",
    "CustomerNote", "CancellationReason",
    "CreatedAt", "UpdatedAt"
)
SELECT
    'BK0001',
    u."Id",
    sv."Id",
    st."Id",
    TIME '09:00',
    TIME '09:30',
    CURRENT_DATE - 3,
    'COMPLETED',
    'Cắt gọn hai bên',
    NULL,
    NOW(),
    NOW()
FROM "Users" u
JOIN "Services" sv ON sv."Name" = 'Cắt tóc cơ bản'
JOIN "Staffs" st ON st."Email" = 'an.nguyen@example.com'
WHERE u."Email" = 'nguyenvana@example.com';


-- 2. COMPLETED - Trần Minh Khoa - Gội đầu
INSERT INTO "Bookings" (
    "BookingCode", "CustomerId", "ServiceId", "StaffId",
    "StartTime", "EndTime", "ServedDate", "Status",
    "CustomerNote", "CancellationReason",
    "CreatedAt", "UpdatedAt"
)
SELECT
    'BK0002',
    u."Id",
    sv."Id",
    st."Id",
    TIME '10:00',
    TIME '10:30',
    CURRENT_DATE - 2,
    'COMPLETED',
    NULL,
    NULL,
    NOW(),
    NOW()
FROM "Users" u
JOIN "Services" sv ON sv."Name" = 'Gội đầu'
JOIN "Staffs" st ON st."Email" = 'binh.tran@example.com'
WHERE u."Email" = 'khoa.tran@example.com';


-- 3. CANCELLED - Lê Thị Mai - Chăm sóc da mặt
INSERT INTO "Bookings" (
    "BookingCode", "CustomerId", "ServiceId", "StaffId",
    "StartTime", "EndTime", "ServedDate", "Status",
    "CustomerNote", "CancellationReason",
    "CreatedAt", "UpdatedAt"
)
SELECT
    'BK0003',
    u."Id",
    sv."Id",
    st."Id",
    TIME '13:00',
    TIME '14:00',
    CURRENT_DATE - 1,
    'CANCELLED',
    NULL,
    'Khách hàng có việc đột xuất',
    NOW(),
    NOW()
FROM "Users" u
JOIN "Services" sv ON sv."Name" = 'Chăm sóc da mặt'
JOIN "Staffs" st ON st."Email" = 'chau.le@example.com'
WHERE u."Email" = 'mai.le@example.com';


-- 4. CONFIRMED - Nguyễn Văn A - Cắt tóc cao cấp
INSERT INTO "Bookings" (
    "BookingCode", "CustomerId", "ServiceId", "StaffId",
    "StartTime", "EndTime", "ServedDate", "Status",
    "CustomerNote", "CancellationReason",
    "CreatedAt", "UpdatedAt"
)
SELECT
    'BK0004',
    u."Id",
    sv."Id",
    st."Id",
    TIME '11:00',
    TIME '12:00',
    CURRENT_DATE,
    'CONFIRMED',
    'Tư vấn kiểu tóc phù hợp khuôn mặt',
    NULL,
    NOW(),
    NOW()
FROM "Users" u
JOIN "Services" sv ON sv."Name" = 'Cắt tóc cao cấp'
JOIN "Staffs" st ON st."Email" = 'duy.pham@example.com'
WHERE u."Email" = 'nguyenvana@example.com';


-- 5. PENDING - Trần Minh Khoa - Phục hồi tóc
INSERT INTO "Bookings" (
    "BookingCode", "CustomerId", "ServiceId", "StaffId",
    "StartTime", "EndTime", "ServedDate", "Status",
    "CustomerNote", "CancellationReason",
    "CreatedAt", "UpdatedAt"
)
SELECT
    'BK0005',
    u."Id",
    sv."Id",
    st."Id",
    TIME '14:00',
    TIME '15:30',
    CURRENT_DATE,
    'PENDING',
    'Tóc khô và hư tổn',
    NULL,
    NOW(),
    NOW()
FROM "Users" u
JOIN "Services" sv ON sv."Name" = 'Phục hồi tóc'
JOIN "Staffs" st ON st."Email" = 'giang.hoang@example.com'
WHERE u."Email" = 'khoa.tran@example.com';


-- 6. CONFIRMED - Lê Thị Mai - Duỗi tóc
INSERT INTO "Bookings" (
    "BookingCode", "CustomerId", "ServiceId", "StaffId",
    "StartTime", "EndTime", "ServedDate", "Status",
    "CustomerNote", "CancellationReason",
    "CreatedAt", "UpdatedAt"
)
SELECT
    'BK0006',
    u."Id",
    sv."Id",
    st."Id",
    TIME '09:00',
    TIME '12:00',
    CURRENT_DATE + 1,
    'CONFIRMED',
    NULL,
    NULL,
    NOW(),
    NOW()
FROM "Users" u
JOIN "Services" sv ON sv."Name" = 'Duỗi tóc'
JOIN "Staffs" st ON st."Email" = 'huy.vo@example.com'
WHERE u."Email" = 'mai.le@example.com';


-- 7. PENDING - Nguyễn Văn A - Massage đầu
INSERT INTO "Bookings" (
    "BookingCode", "CustomerId", "ServiceId", "StaffId",
    "StartTime", "EndTime", "ServedDate", "Status",
    "CustomerNote", "CancellationReason",
    "CreatedAt", "UpdatedAt"
)
SELECT
    'BK0007',
    u."Id",
    sv."Id",
    st."Id",
    TIME '15:00',
    TIME '15:45',
    CURRENT_DATE + 1,
    'PENDING',
    'Massage nhẹ',
    NULL,
    NOW(),
    NOW()
FROM "Users" u
JOIN "Services" sv ON sv."Name" = 'Massage đầu'
JOIN "Staffs" st ON st."Email" = 'lan.dang@example.com'
WHERE u."Email" = 'nguyenvana@example.com';


-- 8. CONFIRMED - Trần Minh Khoa - Tạo kiểu tóc cô dâu
INSERT INTO "Bookings" (
    "BookingCode", "CustomerId", "ServiceId", "StaffId",
    "StartTime", "EndTime", "ServedDate", "Status",
    "CustomerNote", "CancellationReason",
    "CreatedAt", "UpdatedAt"
)
SELECT
    'BK0008',
    u."Id",
    sv."Id",
    st."Id",
    TIME '10:00',
    TIME '12:00',
    CURRENT_DATE + 2,
    'CONFIRMED',
    'Tạo kiểu cho buổi chụp hình',
    NULL,
    NOW(),
    NOW()
FROM "Users" u
JOIN "Services" sv ON sv."Name" = 'Tạo kiểu tóc cô dâu'
JOIN "Staffs" st ON st."Email" = 'nam.bui@example.com'
WHERE u."Email" = 'khoa.tran@example.com';


-- 9. CANCELLED - Lê Thị Mai - Nhuộm tóc
INSERT INTO "Bookings" (
    "BookingCode", "CustomerId", "ServiceId", "StaffId",
    "StartTime", "EndTime", "ServedDate", "Status",
    "CustomerNote", "CancellationReason",
    "CreatedAt", "UpdatedAt"
)
SELECT
    'BK0009',
    u."Id",
    sv."Id",
    st."Id",
    TIME '13:00',
    TIME '15:00',
    CURRENT_DATE + 2,
    'CANCELLED',
    NULL,
    'Khách hàng muốn đổi lịch',
    NOW(),
    NOW()
FROM "Users" u
JOIN "Services" sv ON sv."Name" = 'Nhuộm tóc'
JOIN "Staffs" st ON st."Email" = 'phuong.do@example.com'
WHERE u."Email" = 'mai.le@example.com';


-- 10. PENDING - Nguyễn Văn A - Tỉa râu
INSERT INTO "Bookings" (
    "BookingCode", "CustomerId", "ServiceId", "StaffId",
    "StartTime", "EndTime", "ServedDate", "Status",
    "CustomerNote", "CancellationReason",
    "CreatedAt", "UpdatedAt"
)
SELECT
    'BK0010',
    u."Id",
    sv."Id",
    st."Id",
    TIME '16:00',
    TIME '16:20',
    CURRENT_DATE + 3,
    'PENDING',
    NULL,
    NULL,
    NOW(),
    NOW()
FROM "Users" u
JOIN "Services" sv ON sv."Name" = 'Tỉa râu'
JOIN "Staffs" st ON st."Email" = 'tuan.ngo@example.com'
WHERE u."Email" = 'nguyenvana@example.com';
