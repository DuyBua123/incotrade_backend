INSERT INTO "Staffs" (
    "FullName", 
    "Email", 
    "IsLocked", 
    "CreatedAt", 
    "UpdatedAt"
)
VALUES
    ('Nguyen Van An', 'an.nguyen@example.com', FALSE, NOW(), NOW()),
    ('Tran Thi Binh', 'binh.tran@example.com', FALSE, NOW(), NOW()),
    ('Le Minh Chau', 'chau.le@example.com', TRUE, NOW(), NOW()),
    ('Pham Hoang Duy', 'duy.pham@example.com', FALSE, NOW(), NOW()),
    ('Hoang Thi Giang', 'giang.hoang@example.com', FALSE, NOW(), NOW()),
    ('Vo Quoc Huy', 'huy.vo@example.com', TRUE, NOW(), NOW()),
    ('Dang Ngoc Lan', 'lan.dang@example.com', FALSE, NOW(), NOW()),
    ('Bui Thanh Nam', 'nam.bui@example.com', FALSE, NOW(), NOW()),
    ('Do Thu Phuong', 'phuong.do@example.com', TRUE, NOW(), NOW()),
    ('Ngo Minh Tuan', 'tuan.ngo@example.com', FALSE, NOW(), NOW());

INSERT INTO "WorkSchedules" (
    "StaffId",
    "WorkDate",
    "StartTime",
    "EndTime",
    "CreatedAt",
    "UpdatedAt"
)
SELECT
    s."Id",
    CURRENT_DATE + d.day_offset,
    TIME '09:00',
    TIME '17:00',
    NOW(),
    NOW()
FROM "Staffs" s
CROSS JOIN (
    VALUES
        (-3),
        (-2),
        (-1),
        (0),
        (1),
        (2),
        (3)
) AS d(day_offset);
