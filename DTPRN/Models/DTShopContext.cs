using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DTPRN.Models
{
    public partial class DTShopContext : DbContext
    {
        public DTShopContext()
        {
        }

        public DTShopContext(DbContextOptions<DTShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Chitiet> Chitiets { get; set; } = null!;
        public virtual DbSet<Hoadon> Hoadons { get; set; } = null!;
        public virtual DbSet<Khachhang> Khachhangs { get; set; } = null!;
        public virtual DbSet<LoaiSp> LoaiSps { get; set; } = null!;
        public virtual DbSet<Nhanvien> Nhanviens { get; set; } = null!;
        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("Test"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Chitiet>(entity =>
            {
                entity.ToTable("Chitiet");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.HoadonNavigation)
                    .WithMany(p => p.Chitiets)
                    .HasForeignKey(d => d.Hoadon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chitiet_Hoadon");

                entity.HasOne(d => d.SanPhamNavigation)
                    .WithMany(p => p.Chitiets)
                    .HasForeignKey(d => d.SanPham)
                    .HasConstraintName("FK_Chitiet_SanPham");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.ToTable("Hoadon");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ngaymua).HasColumnType("date");

                entity.HasOne(d => d.NguoimuaNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.Nguoimua)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hoadon_Khachhang");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.ToTable("Khachhang");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Khachhang)
                    .HasForeignKey<Khachhang>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Khachhang_Account");
            });

            modelBuilder.Entity<LoaiSp>(entity =>
            {
                entity.ToTable("LoaiSP");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TenLoai)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.ToTable("Nhanvien");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Nhanvien)
                    .HasForeignKey<Nhanvien>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Nhanvien_Account");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.ToTable("SanPham");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LoaiSp).HasColumnName("LoaiSP");

                entity.Property(e => e.TenSp)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LoaiSpNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.LoaiSp)
                    .HasConstraintName("FK_SanPham_LoaiSP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
