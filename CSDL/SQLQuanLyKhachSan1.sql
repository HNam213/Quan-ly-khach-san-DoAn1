CREATE TABLE Khach (
    MaKhach INT IDENTITY(1,1) PRIMARY KEY,
    TenKhach NVARCHAR(250) NOT NULL,
    CCCD NVARCHAR(20) NOT NULL,
    SDT NVARCHAR(20) NOT NULL,
    QuocTich NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(20) NOT NULL
);
--Chèn dữ liệu vào bảng
INSERT INTO Khach
(TenKhach, SDT, QuocTich, GioiTinh, SoNguoi, CCCD, DiaChi)
VALUES
(N'Trần Hoài Nam', '0917443781', N'Việt Nam', N'Nam', 1, '091205001357', N'An Giang, Việt Nam');
INSERT INTO DatPhong
(NgayDat, Checkin, TinhTrang, MaNV, IdKhach, MaPhong)
VALUES
('2025-12-01', '2026-01-01', N'Đang dùng', 3, 2, 1);

SELECT * FROM Phong

SELECT * FROM DatPhong

CREATE TABLE DatPhong (
    MaDP INT IDENTITY(1,1) PRIMARY KEY,
    MaKhach INT NOT NULL,
    NgayDat DATETIME NOT NULL,
    Checkin DATETIME NULL,
    Checkout DATETIME NULL,
    TinhTrang NVARCHAR(50) NOT NULL DEFAULT N'Chưa nhận phòng',
    MaPhong INT NOT NULL,

    CONSTRAINT FK_DatPhong_Khach
        FOREIGN KEY (MaKhach) REFERENCES Khach(MaKhach),

    CONSTRAINT FK_DatPhong_Phong
        FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong)
);

ALTER TABLE NhanVien
ADD AnhDaiDien VARBINARY(MAX)

ALTER TABLE Phong
ADD AnhPhong VARBINARY(MAX)

INSERT INTO Khach (TenKhach, CCCD, SDT, QuocTich, GioiTinh)
SELECT DISTINCT
    TenKhach, CCCD, SDT, QuocTich, GioiTinh
FROM Khach_Cu;

DELETE FROM DatPhong;
DELETE FROM Khach_Cu;

--Đổi tên cột trong bảng
EXEC sp_rename 'DatPhong.MaKhach', 'IdKhach', 'COLUMN';

sp_help Khach

INSERT INTO DatPhong(IdKhach)
VALUES (N'Nguyen Van A', '123456789', '0912345678', N'Vietnam', N'Nam', N'Hanoi', 2)

--Update dữ liệu
UPDATE Phong
SET TinhTrang = N'Chưa Thanh Toán'
WHERE MaPhong = 6;

UPDATE DatPhong
SET TinhTrang = N'Đang dùng'
WHERE MaDP = 10;

ALTER TABLE NhanVien
ALTER COLUMN GioiTinh NVARCHAR(50);

--reset bộ đếm tự động của khóa chính về 0
DBCC CHECKIDENT ('Khach', RESEED, 1);
DBCC CHECKIDENT ('DatPhong', RESEED, 1);

UPDATE Khach
SET IdKhach = 8
WHERE Ma= 8;

ALTER TABLE Phong
ADD CONSTRAINT FK_Phong_DatPhong
FOREIGN KEY (TinhTrang)
REFERENCES Khach(TinhTrang);


--Thêm Cột trong bảng (((NVARCHAR(255);)
ALTER TABLE DichVu
ADD LoaiDV NVARChar(100);
--Sửa Kiểu dữ liệu của cột trong bảng
ALTER TABLE Khach
ALTER COLUMN DiaChi NVARCHAR(255);
--Thêm Khoá Ngoại
ALTER TABLE Phong
ADD CONSTRAINT FK_Phong_DatPhong
FOREIGN KEY (TinhTrang)
REFERENCES DatPhong(TinhTrang);
--Xóa Cột Khỏi Bảng
ALTER TABLE HoaDon
DROP COLUMN TenNhanVien;
--Xóa Khóa Ngoại
ALTER TABLE DatPhong
DROP CONSTRAINT FK_DatPhong_Khach;
--xóa dữ liệu trong bảng
DELETE FROM DatPhong;
DELETE FROM Khach;
DELETE FROM HoaDon;

CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    MaDP INT NOT NULL,
    NgayLap DATETIME NOT NULL DEFAULT GETDATE(),
    TongTien DECIMAL(18,2) NOT NULL,

    CONSTRAINT FK_HoaDon_DatPhong
        FOREIGN KEY (MaDP) REFERENCES DatPhong(MaDP)
);
ALTER TABLE HoaDon
ADD SoNgayO INT NOT NULL DEFAULT 1;

SELECT *
FROM Khach
INNER JOIN DatPhong 
    ON Khach.MaKhach = DatPhong.MaKhach;


    SELECT Khach.MaKhach, DatPhong.MaPhong, DatPhong.Checkin
FROM Khach
INNER JOIN DatPhong 
    ON Khach.MaKhach = DatPhong.MaKhach;

SELECT *
FROM Khach
INNER JOIN DatPhong 
    ON Khach.MaKhach = DatPhong.MaKhach
INNER JOIN Phong 
    ON DatPhong.MaPhong = Phong.MaPhong;



    ALTER TABLE HoaDon ADD
    TenKhach      NVARCHAR(100),
    SDT           NVARCHAR(20),

    SoPhong       NVARCHAR(10),
    LoaiPhong     NVARCHAR(50),
    LoaiGiuong    NVARCHAR(50),
    GiaPhong      FLOAT,

    TenNhanVien   NVARCHAR(100)


    INSERT INTO HoaDon
(
    MaDP,
    NgayLap,

    TenKhach,
    SDT,

    SoPhong,
    LoaiPhong,
    LoaiGiuong,
    GiaPhong,

    SoNgayO,
    TongTien,MaNV,TenNhanVien)
SELECT
    dp.MaDP,
    GETDATE(),

    k.TenKhach,
    k.SDT,

    p.SoPhong,
    p.LoaiPhong,
    p.LoaiGiuong,
    p.GiaPhong,

    DATEDIFF(DAY, dp.Checkin, dp.Checkout) AS SoNgayO,
    DATEDIFF(DAY, dp.Checkin, dp.Checkout) * p.GiaPhong AS TongTien,

    nv.MaNV,
    nv.TenNhanVien
FROM DatPhong dp
JOIN Khach k     ON dp.IdKhach = k.IdKhach
JOIN Phong p     ON dp.MaPhong = p.MaPhong
JOIN NhanVien nv ON dp.MaNV    = nv.MaNV
WHERE dp.TinhTrang = N'Đã Thanh Toán'AND NOT EXISTS (
    SELECT 1 FROM HoaDon hd WHERE hd.MaDP = dp.MaDP
)

SELECT
    k.TenKhach,
    p.SoPhong,
    nv.TenNhanVien,
    dp.Checkin,
    dp.Checkout
FROM DatPhong dp
JOIN Khach k ON dp.IdKhach = k.IdKhach
JOIN Phong p ON dp.MaPhong = p.MaPhong
JOIN NhanVien nv ON dp.MaNV = nv.MaNV


-- Bảng DichVu
CREATE TABLE DichVu (
    IdDichVu INT IDENTITY(1,1) PRIMARY KEY,  -- Tự tăng
    TenDichVu NVARCHAR(100) NOT NULL,
    DonVi NVARCHAR(50) NOT NULL,            -- Ví dụ: 'Cái', 'Lần', 'Kg'
    DonGia DECIMAL(18,2) NOT NULL           -- Giá dịch vụ
);

-- Bảng DichVuKhach
CREATE TABLE DichVuKhach (
    Id INT IDENTITY(1,1) PRIMARY KEY,       -- Tự tăng
    IdKhach INT NULL,                        -- Cho phép NULL nếu khách không dùng dịch vụ
    IdDichVu INT NULL,                       -- Cho phép NULL nếu khách không dùng dịch vụ
    SoLuong INT DEFAULT 0,
    DonGia DECIMAL(18,2) NULL,              -- Lưu giá dịch vụ lúc khách dùng
    TongDon AS (SoLuong * DonGia),          -- Tính tổng tiền từ SoLuong * DonGia
    CONSTRAINT FK_DichVuKhach_Khach FOREIGN KEY (IdKhach) 
        REFERENCES Khach(IdKhach),
    CONSTRAINT FK_DichVuKhach_DichVu FOREIGN KEY (IdDichVu) 
        REFERENCES DichVu(IdDichVu) 
        ON DELETE SET NULL                   -- Khi xóa dịch vụ, IdDichVu trong DichVuKhach sẽ tự động NULL
);

ALTER TABLE DichVu
ALTER COLUMN DonGia INT;


INSERT INTO DichVu (MaDV, TenDichVu, LoaiDV, DonVi, DonGia)
VALUES

(N'AN01', N'Mì gói', N'Ăn nhanh', N'Gói', 15000),
(N'AN02', N'Mì ly', N'Ăn nhanh', N'Ly', 20000),
(N'AN03', N'Snack', N'Ăn nhanh', N'Gói', 15000),
(N'GL01', N'Giặt đồ', N'Giặt là', N'Kg', 30000),
(N'GL02', N'Giặt + sấy', N'Giặt là', N'Kg', 40000),
(N'GL03', N'Giặt nhanh', N'Giặt là', N'Kg', 50000),
(N'GL04', N'Ủi quần áo', N'Giặt là', N'Bộ', 15000),
(N'GL05', N'Giặt chăn', N'Giặt là', N'Cái', 40000),
(N'GL06', N'Giặt ga giường', N'Giặt là', N'Bộ', 50000),
(N'VS01', N'Dọn phòng', N'Vệ sinh', N'Lần', 30000),
(N'VS02', N'Dọn phòng ngoài giờ', N'Vệ sinh', N'Lần', 50000),
(N'PH01', N'Phụ thu thêm người', N'Phòng', N'Người', 50000),
(N'PH02', N'Thuê thêm chăn', N'Phòng', N'Lần', 30000),
(N'PH03', N'Thuê thêm gối', N'Phòng', N'Lần', 20000),
(N'PH04', N'Thuê nệm phụ', N'Phòng', N'Ngày', 100000),
(N'PH05', N'Check-in sớm', N'Phòng', N'Lần', 100000),
(N'PH06', N'Check-out trễ', N'Phòng', N'Giờ', 50000),
(N'PH07', N'Gia hạn phòng', N'Phòng', N'Giờ', 80000),
(N'PH08', N'Đổi phòng', N'Phòng', N'Lần', 50000),
(N'GX01', N'Gửi xe máy', N'Gửi xe', N'Ngày', 10000),
(N'GX02', N'Gửi xe ô tô', N'Gửi xe', N'Ngày', 50000),
(N'DC01', N'Thuê xe máy', N'Di chuyển', N'Ngày', 120000),
(N'DC02', N'Đưa đón sân bay', N'Di chuyển', N'Lượt', 200000),
(N'DC03', N'Gọi taxi', N'Di chuyển', N'Lượt', 10000),
(N'TI01', N'Bàn chải + Kem đánh răng', N'Tiện ích', N'Bộ', 20000),
(N'TI02', N'Khăn tắm', N'Tiện ích', N'Cái', 20000),
(N'TI03', N'Bản Đồ + Sách hướng dẫn', N'Tiện ích', N'Bộ', 50000),
(N'TI04', N'Dao cạo râu', N'Tiện ích', N'Cái', 10000),
(N'TI05', N'Dầu gội', N'Tiện ích', N'Chai', 80000),
(N'TI06', N'Sữa tắm', N'Tiện ích', N'Chai', 90000),
(N'TI07', N'Nước rửa tay', N'Tiện ích', N'Chai', 30000),
(N'SP01', N'Suối nước nóng', N'SP', N'Lượt', 200000),
(N'SP02', N'Massage', N'SP', N'Lượt', 150000),
(N'SP03', N'Xông hơi', N'SP', N'Lượt', 100000);