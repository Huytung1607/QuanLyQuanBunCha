CREATE DATABASE QuanLyQuanBunCha
Go
USE QuanLyQuanBunCha
Go
-- Tạo bảng dangnhap
CREATE TABLE dangnhap (
    tendangnhap NVARCHAR(50),
    password NVARCHAR(255) NOT NULL,
    CONSTRAINT pk_dangnhap PRIMARY KEY (tendangnhap)
);
Go
-- Tạo bảng dangky
CREATE TABLE dangky (
    mataikhoan INT IDENTITY(1,1),
    tentaikhoan NVARCHAR(100) NOT NULL,
    tendangnhap NVARCHAR(50),
    password NVARCHAR(255) NOT NULL,
    sodienthoai VARCHAR(20),
    diachi NVARCHAR(255),
    CONSTRAINT pk_dangky PRIMARY KEY (mataikhoan),
    CONSTRAINT fk_dangky_dangnhap FOREIGN KEY (tendangnhap) REFERENCES dangnhap(tendangnhap)
);
Go
-- Tạo bảng khachhang
CREATE TABLE khachhang (
    makhachhang VARCHAR(20) ,
    tenkhachhang NVARCHAR(100) NOT NULL,
    sodienthoai VARCHAR(20),
    diachi NVARCHAR(255),
    CONSTRAINT pk_khachhang PRIMARY KEY (makhachhang)
);
-- Tạo bảng nhanvien
CREATE TABLE nhanvien (
    manhanvien VARCHAR(20) ,
    tennhanvien NVARCHAR(100) NOT NULL,
    vitrilamviec NVARCHAR(50),
    sodienthoai VARCHAR(20),
    diachi NVARCHAR(255),
    CONSTRAINT pk_nhanvien PRIMARY KEY (manhanvien)
);

-- Tạo bảng donhang
CREATE TABLE donhang (
    madonhang VARCHAR(20) ,
    makhachhang VARCHAR(20),
    manhanvien VARCHAR(20),
    ngaytao DATE,
    tonggiatri DECIMAL(10,2),
    trangthai NVARCHAR(50),
    CONSTRAINT pk_donhang PRIMARY KEY (madonhang),
    CONSTRAINT fk_donhang_khachhang FOREIGN KEY (makhachhang) REFERENCES khachhang(makhachhang),
    CONSTRAINT fk_donhang_nhanvien FOREIGN KEY (manhanvien) REFERENCES nhanvien(manhanvien)
);

-- Tạo bảng khohang
CREATE TABLE khohang (
    makho VARCHAR(20),
    manhanvien VARCHAR(20),
    nhacungcap NVARCHAR(100),
    tennguyenlieu NVARCHAR(100),
    soluong INT,
    CONSTRAINT pk_khohang PRIMARY KEY (makho),
    CONSTRAINT fk_khohang_nhanvien FOREIGN KEY (manhanvien) REFERENCES nhanvien(manhanvien)
);

-- Tạo bảng thanhtoan
CREATE TABLE thanhtoan (
    mathanhtoan VARCHAR(20),
    madonhang VARCHAR(20),
    ngaythanhtoan DATE,
    phuongthucthanhtoan NVARCHAR(50),
    sotien DECIMAL(10,2),
    CONSTRAINT pk_thanhtoan PRIMARY KEY (mathanhtoan),
    CONSTRAINT fk_thanhtoan_donhang FOREIGN KEY (madonhang) REFERENCES donhang(madonhang)
);

--Chèn bảng dangnhap
INSERT INTO dangnhap (tendangnhap, password)
VALUES
(N'vancuong', 'password123'),
(N'hoangthuy', '12345678'),
(N'phuonglan', 'mypassword'),
(N'kimtuan', 'tuan1234'),
(N'dinhkhanh', 'khanh5678'),
(N'ngocbao', 'bao3210'),
(N'minhhoang', 'hoang9876'),
(N'quanghieu', 'hieu4321'),
(N'trinhson', 'son12345'),
(N'nguyenthai', 'thai0987');

--Chèn bảng dangky
INSERT INTO dangky (tentaikhoan, tendangnhap, password, sodienthoai, diachi)
VALUES
(N'Nguyễn Văn Cường', N'vancuong', 'password123', '0912345678', N'Hà Nội'),
(N'Lê Thị Thùy', N'hoangthuy', '12345678', '0923456789', N'Quảng Ninh'),
(N'Phan Phương Lan', N'phuonglan', 'mypassword', '0934567890', N'Đà Nẵng'),
(N'Kim Tuấn', N'kimtuan', 'tuan1234', '0945678901', N'Hồ Chí Minh'),
(N'Đinh Khánh', N'dinhkhanh', 'khanh5678', '0956789012', N'Cần Thơ'),
(N'Ngọc Bảo', N'ngocbao', 'bao3210', '0967890123', N'Hải Phòng'),
(N'Minh Hoàng', N'minhhoang', 'hoang9876', '0978901234', N'Nghệ An'),
(N'Quang Hiếu', N'quanghieu', 'hieu4321', '0989012345', N'Bình Dương'),
(N'Trịnh Sơn', N'trinhson', 'son12345', '0990123456', N'Bắc Ninh'),
(N'Nguyễn Thái', N'nguyenthai', 'thai0987', '0901234567', N'Phú Thọ');

--Chèn bảng khachhang
INSERT INTO khachhang (makhachhang, tenkhachhang, sodienthoai, diachi)
VALUES
('KH01', N'Nguyễn Văn An', '0912345678', N'Hà Nội'),
('KH02', N'Lê Thị Hoa', '0923456789', N'Hồ Chí Minh'),
('KH03', N'Phạm Văn Bình', '0934567890', N'Đà Nẵng'),
('KH04', N'Trần Thị Nga', '0945678901', N'Hải Phòng'),
('KH05', N'Hoàng Văn Cường', '0956789012', N'Cần Thơ'),
('KH06', N'Nguyễn Thị Hương', '0967890123', N'Bắc Giang'),
('KH07', N'Vũ Văn Sơn', '0978901234', N'Lào Cai'),
('KH08', N'Phan Thị Tuyết', '0989012345', N'Ninh Bình'),
('KH09', N'Bùi Văn Lộc', '0990123456', N'Quảng Ninh'),
('KH10', N'Tạ Thị Lan', '0901234567', N'Hà Nam');
--Chèn bảng nhanvien
INSERT INTO nhanvien (manhanvien, tennhanvien, vitrilamviec, sodienthoai, diachi)
VALUES 
('NV01', N'Trần Văn Nam', N'Phục vụ', '0911223344', N'Hà Nội'),
('NV02', N'Lê Thị Hằng', N'Đầu bếp', '0922233445', N'Hồ Chí Minh'),
('NV03', N'Nguyễn Văn Hải', N'Lễ tân', '0933344556', N'Đà Nẵng'),
('NV04', N'Hoàng Thị Mai', N'Quản lý', '0944455667', N'Hải Phòng'),
('NV05', N'Phạm Văn Tân', N'Phục vụ', '0955566778', N'Cần Thơ'),
('NV06', N'Trần Thị Lan', N'Phục vụ', '0966677889', N'Hà Nội'),
('NV07', N'Vũ Văn Khánh', N'Bếp phó', '0977788990', N'Quảng Ninh'),
('NV08', N'Phan Thị Hồng', N'Bồi bàn', '0988899001', N'Ninh Bình'),
('NV09', N'Bùi Văn Thành', N'Lễ tân', '0999900012', N'Lào Cai'),
('NV10', N'Tạ Thị Huyền', N'Quản lý', '0910011223', N'Bắc Ninh');
--Chèn bảng donhang
INSERT INTO donhang (madonhang, makhachhang, manhanvien, ngaytao, tonggiatri, trangthai)
VALUES 
('DH01', 'KH01', 'NV01', '2024-11-01', 200000.00, N'Hoàn thành'),
('DH02', 'KH02', 'NV02', '2024-11-02', 350000.00, N'Hoàn thành'),
('DH03', 'KH03', 'NV03', '2024-11-03', 150000.00, N'Chờ xử lý'),
('DH04', 'KH04', 'NV04', '2024-11-04', 450000.00, N'Hoàn thành'),
('DH05', 'KH05', 'NV05', '2024-11-05', 300000.00, N'Chờ xử lý'),
('DH06', 'KH06', 'NV06', '2024-11-06', 250000.00, N'Hoàn thành'),
('DH07', 'KH07', 'NV07', '2024-11-07', 400000.00, N'Hủy bỏ'),
('DH08', 'KH08', 'NV08', '2024-11-08', 500000.00, N'Hoàn thành'),
('DH09', 'KH09', 'NV09', '2024-11-09', 550000.00, N'Hoàn thành'),
('DH10', 'KH10', 'NV10', '2024-11-10', 600000.00, N'Chờ xử lý');
--Chèn bảng khohang
INSERT INTO khohang (makho, manhanvien, nhacungcap, tennguyenlieu, soluong)
VALUES 
('KHO01', 'NV01', N'Công ty A', N'Bún', 100),
('KHO02', 'NV02', N'Công ty B', N'Chả', 50),
('KHO03', 'NV03', N'Công ty C', N'Thịt nướng', 30),
('KHO04', 'NV04', N'Công ty D', N'Rau sống', 200),
('KHO05', 'NV05', N'Công ty E', N'Nước chấm', 150),
('KHO06', 'NV06', N'Công ty F', N'Ớt', 70),
('KHO07', 'NV07', N'Công ty G', N'Tỏi', 80),
('KHO08', 'NV08', N'Công ty H', N'Hành khô', 60),
('KHO09', 'NV09', N'Công ty I', N'Chanh', 90),
('KHO10', 'NV10', N'Công ty J', N'Muối', 100);
--Chèn bảng thanhtoan
INSERT INTO thanhtoan (mathanhtoan, madonhang, ngaythanhtoan, phuongthucthanhtoan, sotien)
VALUES 
('TT01', 'DH01', '2024-11-01', N'Tiền mặt', 200000.00),
('TT02', 'DH02', '2024-11-02', N'Thẻ ngân hàng', 350000.00),
('TT03', 'DH03', '2024-11-03', N'Tiền mặt', 150000.00),
('TT04', 'DH04', '2024-11-04', N'Chuyển khoản', 450000.00),
('TT05', 'DH05', '2024-11-05', N'Tiền mặt', 300000.00),
('TT06', 'DH06', '2024-11-06', N'Thẻ ngân hàng', 250000.00),
('TT07', 'DH07', '2024-11-07', N'Tiền mặt', 400000.00),
('TT08', 'DH08', '2024-11-08', N'Chuyển khoản', 500000.00),
('TT09', 'DH09', '2024-11-09', N'Tiền mặt', 550000.00),
('TT10', 'DH10', '2024-11-10', N'Thẻ ngân hàng', 600000.00);
