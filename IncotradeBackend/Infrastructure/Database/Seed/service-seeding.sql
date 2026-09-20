INSERT INTO "Services" (
    "Name",
    "Description",
    "DurationMinutes",
    "Price",
    "IsLocked",
    "CreatedAt",
    "UpdatedAt"
)
VALUES
('Cắt tóc cơ bản', 'Dịch vụ cắt tóc cơ bản', 30, 100000, FALSE, NOW(), NOW()),
('Cắt tóc cao cấp', 'Cắt tóc kết hợp tư vấn và tạo kiểu', 60, 250000, FALSE, NOW(), NOW()),
('Nhuộm tóc', 'Dịch vụ nhuộm tóc chuyên nghiệp', 120, 500000, TRUE, NOW(), NOW()),
('Gội đầu', 'Gội đầu kết hợp massage da đầu', 30, 80000, FALSE, NOW(), NOW()),
('Phục hồi tóc', 'Dưỡng tóc chuyên sâu và phục hồi tóc hư tổn', 90, 350000, FALSE, NOW(), NOW()),
('Tỉa râu', 'Cắt tỉa và tạo kiểu râu chuyên nghiệp', 20, 70000, TRUE, NOW(), NOW()),
('Chăm sóc da mặt', 'Làm sạch da mặt và chăm sóc da chuyên sâu', 60, 300000, FALSE, NOW(), NOW()),
('Massage đầu', 'Massage thư giãn vùng đầu và da đầu', 45, 150000, TRUE, NOW(), NOW()),
('Duỗi tóc', 'Dịch vụ duỗi tóc chuyên nghiệp', 180, 800000, FALSE, NOW(), NOW()),
('Tạo kiểu tóc cô dâu', 'Tạo kiểu tóc dành cho cô dâu và các dịp đặc biệt', 120, 600000, TRUE, NOW(), NOW());