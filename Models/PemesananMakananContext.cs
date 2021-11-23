using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Pemesanan_Makanan.Models
{
    public partial class PemesananMakananContext : DbContext
    {
        public PemesananMakananContext()
        {
        }

        public PemesananMakananContext(DbContextOptions<PemesananMakananContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<LoginAdmin> LoginAdmins { get; set; }
        public virtual DbSet<Pembeli> Pembelis { get; set; }
        public virtual DbSet<Pemilik> Pemiliks { get; set; }
        public virtual DbSet<Pesanan> Pesanans { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Food>(entity =>
            {
                entity.HasKey(e => e.IdMakanan);

                entity.ToTable("food");

                entity.Property(e => e.IdMakanan)
                    .ValueGeneratedNever()
                    .HasColumnName("id_makanan");

                entity.Property(e => e.Harga).HasColumnName("harga");

                entity.Property(e => e.Keterangan)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("keterangan");

                entity.Property(e => e.NamaMakanan)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama_makanan");
            });

            modelBuilder.Entity<LoginAdmin>(entity =>
            {
                entity.HasKey(e => e.IdLogin);

                entity.ToTable("Login Admin");

                entity.Property(e => e.IdLogin).HasColumnName("ID_Login");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pembeli>(entity =>
            {
                entity.HasKey(e => e.IdCustumer);

                entity.ToTable("pembeli");

                entity.Property(e => e.IdCustumer)
                    .ValueGeneratedNever()
                    .HasColumnName("id_custumer");

                entity.Property(e => e.Alamat)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("alamat");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nama)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama");

                entity.Property(e => e.PasswordCustumer)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password_custumer");

                entity.Property(e => e.Telpon).HasColumnName("telpon");
            });

            modelBuilder.Entity<Pemilik>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.ToTable("pemilik");

                entity.Property(e => e.IdAdmin)
                    .ValueGeneratedNever()
                    .HasColumnName("id_admin");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nama)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama");

                entity.Property(e => e.NoTelpon).HasColumnName("no_telpon");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Pesanan>(entity =>
            {
                entity.HasKey(e => e.IdPesanan);

                entity.ToTable("pesanan");

                entity.Property(e => e.IdPesanan)
                    .ValueGeneratedNever()
                    .HasColumnName("id_pesanan");

                entity.Property(e => e.Harga).HasColumnName("harga");

                entity.Property(e => e.IdAdmin).HasColumnName("id_admin");

                entity.Property(e => e.IdCustumer).HasColumnName("id_custumer");

                entity.Property(e => e.IdMakanan).HasColumnName("id_makanan");

                entity.Property(e => e.Keterangan)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("keterangan");

                entity.Property(e => e.NamaMakanan)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama_makanan");

                entity.Property(e => e.Tanggal)
                    .HasColumnType("date")
                    .HasColumnName("tanggal");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany(p => p.Pesanans)
                    .HasForeignKey(d => d.IdAdmin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pesanan_pemilik1");

                entity.HasOne(d => d.IdCustumerNavigation)
                    .WithMany(p => p.Pesanans)
                    .HasForeignKey(d => d.IdCustumer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pesanan_pembeli1");

                entity.HasOne(d => d.IdMakananNavigation)
                    .WithMany(p => p.Pesanans)
                    .HasForeignKey(d => d.IdMakanan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pesanan_food1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
