using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLNS.Migrations
{
    /// <inheritdoc />
    public partial class csdl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BangCap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaBangCap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenBangCap = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangCap", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    LuongCoBan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChuyenMon",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaChuyenMon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenChuyenMon = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuyenMon", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DanToc",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDanToc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenDanToc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanToc", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KhenThuong",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKhenThuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LyDoKhenThuong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TienThuong = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhenThuong", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KhoanTru",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKhoanTru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LyDoKhoanTru = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SoTienKhoanTru = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoanTru", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PhongBan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhongBan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenPhongBan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PhuCap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhuCap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenPhuCap = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SoTienPhuCap = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuCap", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QuocTich",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaQuocTich = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenQuocTich = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuocTich", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThongKeNam",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    namID = table.Column<int>(type: "int", nullable: false),
                    ThangID = table.Column<int>(type: "int", nullable: false),
                    TongDoanhThuThangID = table.Column<float>(type: "real", nullable: false),
                    TongDoanhThuNam = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongKeNam", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThongKeThang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nam = table.Column<int>(type: "int", nullable: false),
                    Thang = table.Column<int>(type: "int", nullable: false),
                    ThucLanh = table.Column<float>(type: "real", nullable: false),
                    TongDoanhThuThang = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongKeThang", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TonGiao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTonGiao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTonGiao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonGiao", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TrinhDo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTrinhDo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTrinhDo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrinhDo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenNhanVien = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CanCuocCongDan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NoiCapCanCuoc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgayCapCanCuoc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BangCapID = table.Column<int>(type: "int", nullable: false),
                    ChucVuID = table.Column<int>(type: "int", nullable: false),
                    ChuyenMonID = table.Column<int>(type: "int", nullable: false),
                    DanTocID = table.Column<int>(type: "int", nullable: false),
                    PhongBanId = table.Column<int>(type: "int", nullable: false),
                    QuocTichID = table.Column<int>(type: "int", nullable: false),
                    TonGiaoID = table.Column<int>(type: "int", nullable: false),
                    TrinhDoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NhanVien_BangCap_BangCapID",
                        column: x => x.BangCapID,
                        principalTable: "BangCap",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_ChucVu_ChucVuID",
                        column: x => x.ChucVuID,
                        principalTable: "ChucVu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_ChuyenMon_ChuyenMonID",
                        column: x => x.ChuyenMonID,
                        principalTable: "ChuyenMon",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_DanToc_DanTocID",
                        column: x => x.DanTocID,
                        principalTable: "DanToc",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_PhongBan_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_QuocTich_QuocTichID",
                        column: x => x.QuocTichID,
                        principalTable: "QuocTich",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_TonGiao_TonGiaoID",
                        column: x => x.TonGiaoID,
                        principalTable: "TonGiao",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_TrinhDo_TrinhDoID",
                        column: x => x.TrinhDoID,
                        principalTable: "TrinhDo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CongTac",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaCongTac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhanVienID = table.Column<int>(type: "int", nullable: false),
                    ChucVuID = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaDiemCongTac = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MucDich = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    BangCapID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongTac", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CongTac_BangCap_BangCapID",
                        column: x => x.BangCapID,
                        principalTable: "BangCap",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CongTac_ChucVu_ChucVuID",
                        column: x => x.ChucVuID,
                        principalTable: "ChucVu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CongTac_NhanVien_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HopDong",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHopDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenHopDong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDung = table.Column<string>(type: "ntext", nullable: true),
                    NgayKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NhanVienID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HopDong_NhanVien_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NghiPhep",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVienID = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoNgayNghi = table.Column<int>(type: "int", nullable: false),
                    LyDoNghi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NghiPhep", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NghiPhep_NhanVien_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVienID = table.Column<int>(type: "int", nullable: false),
                    EmailID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SDTID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChiID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenDangNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Quyen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NguoiDung_NhanVien_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThoiGianLamViec",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVienID = table.Column<int>(type: "int", nullable: false),
                    Thang = table.Column<int>(type: "int", nullable: false),
                    SoNgayNghiID = table.Column<int>(type: "int", nullable: false),
                    SoNgayCong = table.Column<int>(type: "int", nullable: false),
                    NghiPhepID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThoiGianLamViec", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ThoiGianLamViec_NghiPhep_NghiPhepID",
                        column: x => x.NghiPhepID,
                        principalTable: "NghiPhep",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ThoiGianLamViec_NhanVien_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Luong",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVienID = table.Column<int>(type: "int", nullable: false),
                    ThangID = table.Column<int>(type: "int", nullable: false),
                    ThoiGianLamViecID = table.Column<int>(type: "int", nullable: false),
                    LuongCoBanID = table.Column<int>(type: "int", nullable: false),
                    TinhTrangLuong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TongThuNhap = table.Column<float>(type: "real", nullable: false),
                    PhuongThucThanhToan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChucVuID = table.Column<int>(type: "int", nullable: false),
                    LyDoKhoanTruID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhoanTruID = table.Column<int>(type: "int", nullable: false),
                    LyDoKhenThuongID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhenThuongID = table.Column<int>(type: "int", nullable: false),
                    PhuCapID = table.Column<int>(type: "int", nullable: false),
                    TenPhuCapID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Luong", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Luong_ChucVu_ChucVuID",
                        column: x => x.ChucVuID,
                        principalTable: "ChucVu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Luong_KhenThuong_KhenThuongID",
                        column: x => x.KhenThuongID,
                        principalTable: "KhenThuong",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Luong_KhoanTru_KhoanTruID",
                        column: x => x.KhoanTruID,
                        principalTable: "KhoanTru",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Luong_NhanVien_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Luong_PhuCap_PhuCapID",
                        column: x => x.PhuCapID,
                        principalTable: "PhuCap",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Luong_ThoiGianLamViec_ThoiGianLamViecID",
                        column: x => x.ThoiGianLamViecID,
                        principalTable: "ThoiGianLamViec",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CongTac_BangCapID",
                table: "CongTac",
                column: "BangCapID");

            migrationBuilder.CreateIndex(
                name: "IX_CongTac_ChucVuID",
                table: "CongTac",
                column: "ChucVuID");

            migrationBuilder.CreateIndex(
                name: "IX_CongTac_NhanVienID",
                table: "CongTac",
                column: "NhanVienID");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_NhanVienID",
                table: "HopDong",
                column: "NhanVienID");

            migrationBuilder.CreateIndex(
                name: "IX_Luong_ChucVuID",
                table: "Luong",
                column: "ChucVuID");

            migrationBuilder.CreateIndex(
                name: "IX_Luong_KhenThuongID",
                table: "Luong",
                column: "KhenThuongID");

            migrationBuilder.CreateIndex(
                name: "IX_Luong_KhoanTruID",
                table: "Luong",
                column: "KhoanTruID");

            migrationBuilder.CreateIndex(
                name: "IX_Luong_NhanVienID",
                table: "Luong",
                column: "NhanVienID");

            migrationBuilder.CreateIndex(
                name: "IX_Luong_PhuCapID",
                table: "Luong",
                column: "PhuCapID");

            migrationBuilder.CreateIndex(
                name: "IX_Luong_ThoiGianLamViecID",
                table: "Luong",
                column: "ThoiGianLamViecID");

            migrationBuilder.CreateIndex(
                name: "IX_NghiPhep_NhanVienID",
                table: "NghiPhep",
                column: "NhanVienID");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_NhanVienID",
                table: "NguoiDung",
                column: "NhanVienID");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_BangCapID",
                table: "NhanVien",
                column: "BangCapID");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_ChucVuID",
                table: "NhanVien",
                column: "ChucVuID");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_ChuyenMonID",
                table: "NhanVien",
                column: "ChuyenMonID");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_DanTocID",
                table: "NhanVien",
                column: "DanTocID");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_PhongBanId",
                table: "NhanVien",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_QuocTichID",
                table: "NhanVien",
                column: "QuocTichID");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_TonGiaoID",
                table: "NhanVien",
                column: "TonGiaoID");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_TrinhDoID",
                table: "NhanVien",
                column: "TrinhDoID");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiGianLamViec_NghiPhepID",
                table: "ThoiGianLamViec",
                column: "NghiPhepID");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiGianLamViec_NhanVienID",
                table: "ThoiGianLamViec",
                column: "NhanVienID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CongTac");

            migrationBuilder.DropTable(
                name: "HopDong");

            migrationBuilder.DropTable(
                name: "Luong");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "ThongKeNam");

            migrationBuilder.DropTable(
                name: "ThongKeThang");

            migrationBuilder.DropTable(
                name: "KhenThuong");

            migrationBuilder.DropTable(
                name: "KhoanTru");

            migrationBuilder.DropTable(
                name: "PhuCap");

            migrationBuilder.DropTable(
                name: "ThoiGianLamViec");

            migrationBuilder.DropTable(
                name: "NghiPhep");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "BangCap");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "ChuyenMon");

            migrationBuilder.DropTable(
                name: "DanToc");

            migrationBuilder.DropTable(
                name: "PhongBan");

            migrationBuilder.DropTable(
                name: "QuocTich");

            migrationBuilder.DropTable(
                name: "TonGiao");

            migrationBuilder.DropTable(
                name: "TrinhDo");
        }
    }
}
