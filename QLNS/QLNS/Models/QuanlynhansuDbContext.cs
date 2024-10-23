using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLNS.Models;

namespace QLNS.Models
{
    public class QuanlynhansuDbContext : DbContext
    {
        public QuanlynhansuDbContext(DbContextOptions<QuanlynhansuDbContext> options) : base(options) { }
        public DbSet<BangCap> BangCap { get; set; }
        public DbSet<ChucVu> ChucVu { get; set; }
        public DbSet<ChuyenMon> ChuyenMon { get; set; }
        public DbSet<DanToc> DanToc { get; set; }
        public DbSet<CongTac> CongTac { get; set; }
        public DbSet<KhenThuong> KhenThuong { get; set; }
        public DbSet<KhoanTru> KhoanTru { get; set; }
        public DbSet<NghiPhep> NghiPhep { get; set; }
        public DbSet<Luong> Luong { get; set; }
        public DbSet<NguoiDung> NguoiDung { get; set; }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<PhongBan> PhongBan { get; set; }
        public DbSet<PhuCap> PhuCap { get; set; }
        public DbSet<QuocTich> QuocTich { get; set; }
        public DbSet<ThoiGianLamViec> ThoiGianLamViec { get; set; }
        public DbSet<TonGiao> TonGiao { get; set; }
        public DbSet<TrinhDo> TrinhDo { get; set; }
        public DbSet<ThongKeThang> ThongKeThang { get; set; }
        public DbSet<ThongKeNam> ThongKeNam { get; set; }
        public DbSet<HopDong> HopDong { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HopDong>().ToTable("HopDong");
            modelBuilder.Entity<ThongKeThang>().ToTable("ThongKeThang");
            modelBuilder.Entity<ThongKeNam>().ToTable("ThongKeNam");
            modelBuilder.Entity<BangCap>().ToTable("BangCap");
            modelBuilder.Entity<ChucVu>().ToTable("ChucVu");
            modelBuilder.Entity<ChuyenMon>().ToTable("ChuyenMon");
            modelBuilder.Entity<DanToc>().ToTable("DanToc");
            modelBuilder.Entity<KhenThuong>().ToTable("KhenThuong");
            modelBuilder.Entity<KhoanTru>().ToTable("KhoanTru");
            modelBuilder.Entity<NghiPhep>().ToTable("NghiPhep");
               modelBuilder.Entity<CongTac>().ToTable("CongTac");
            modelBuilder.Entity<Luong>().ToTable("Luong");
            modelBuilder.Entity<NguoiDung>().ToTable("NguoiDung");
            modelBuilder.Entity<NhanVien>().ToTable("NhanVien");
            modelBuilder.Entity<PhongBan>().ToTable("PhongBan");
            modelBuilder.Entity<PhuCap>().ToTable("PhuCap");
            modelBuilder.Entity<QuocTich>().ToTable("QuocTich");
            modelBuilder.Entity<ThoiGianLamViec>().ToTable("ThoiGianLamViec");
            modelBuilder.Entity<TonGiao>().ToTable("TonGiao");
            modelBuilder.Entity<TrinhDo>().ToTable("TrinhDo");

        }


       
    }
}
