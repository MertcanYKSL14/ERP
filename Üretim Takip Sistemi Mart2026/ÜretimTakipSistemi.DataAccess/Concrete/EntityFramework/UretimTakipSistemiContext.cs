using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Concrete.EntityFramework
{
    public class UretimTakipSistemiContext : DbContext
    {
        public UretimTakipSistemiContext() : base("name=UretimTakipSistemiContext")
        {
        }

        public DbSet<PressDurum> PressDurum { get; set; }
        public DbSet<Pressler> Pressler { get; set; }
        public DbSet<PressTakipSayac> PressTakipSayac { get; set; }
        public DbSet<Urunler> Urunler { get; set; }
        public DbSet<PressTakipSayacGecmis> PressTakipSayacGecmis { get; set; }
        public DbSet<PressTakipDurum> PressTakipDurum { get; set; }
        public DbSet<SacAmbariBarkod> SacAmbariBarkod { get; set; }
        public DbSet<SacAmbariStokKarti> SacAmbariStokKarti { get; set; }
        public DbSet<SacAmbariStokListesi> SacAmbariStokListesi { get; set; }
        public DbSet<SacAmbariUrunGecmisi> SacAmbariUrunGecmisi { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PressDurum>()
               .Property(e => e.Kategori)
               .IsUnicode(false);

            modelBuilder.Entity<PressDurum>()
                .HasMany(e => e.PressTakipSayac)
                .WithRequired(e => e.PressDurum)
                .HasForeignKey(e => e.DurumId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PressDurum>()
                .HasMany(e => e.PressTakipDurum)
                .WithRequired(e => e.PressDurum)
                .HasForeignKey(e => e.DurumId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pressler>()
                .Property(e => e.PressAd)
                .IsUnicode(false);

            modelBuilder.Entity<Pressler>()
                .HasMany(e => e.PressTakipDurum)
                .WithRequired(e => e.Pressler)
                .HasForeignKey(e => e.PressId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pressler>()
                .HasMany(e => e.PressTakipSayac)
                .WithRequired(e => e.Pressler)
                .HasForeignKey(e => e.PressId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pressler>()
                .HasMany(e => e.PressTakipSayacGecmis)
                .WithRequired(e => e.Pressler)
                .HasForeignKey(e => e.PressId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PressTakipSayac>()
                .Property(e => e.StokKodu)
                .IsUnicode(false);

            modelBuilder.Entity<PressTakipSayac>()
                .Property(e => e.StokAdi)
                .IsUnicode(false);

            modelBuilder.Entity<PressTakipSayac>()
                .Property(e => e.Operasyon)
                .IsUnicode(false);

            modelBuilder.Entity<PressTakipSayacGecmis>()
                .Property(e => e.Operasyon)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariBarkod>()
                .Property(e => e.StokKodu)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariBarkod>()
                .Property(e => e.StokAdi)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariBarkod>()
                .Property(e => e.Barkod)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariBarkod>()
                .Property(e => e.Kalite)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariBarkod>()
                .Property(e => e.Kalinlik)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariBarkod>()
                .Property(e => e.TbEn)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariBarkod>()
                .Property(e => e.TbBoy)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariStokKarti>()
                .Property(e => e.StokKodu)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariStokKarti>()
                .Property(e => e.StokAdi)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariStokKarti>()
                .Property(e => e.Kalinlik)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariStokKarti>()
                .Property(e => e.Kalite)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariStokKarti>()
                .Property(e => e.SacKalitesi)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariStokListesi>()
                .Property(e => e.StokKodu)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariStokListesi>()
                .Property(e => e.StokAdi)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariStokListesi>()
                .Property(e => e.Barkod)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariStokListesi>()
                .Property(e => e.Kalite)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariStokListesi>()
                .Property(e => e.Kalinlik)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariStokListesi>()
                .Property(e => e.TbEn)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariStokListesi>()
                .Property(e => e.TbBoy)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariStokListesi>()
                .Property(e => e.R_P)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariStokListesi>()
                .Property(e => e.Operator)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariStokListesi>()
                .Property(e => e.Müsteri)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariStokListesi>()
                .Property(e => e.Irsaliye)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariUrunGecmisi>()
                .Property(e => e.StokKodu)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariUrunGecmisi>()
                .Property(e => e.StokAdi)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariUrunGecmisi>()
                .Property(e => e.Barkod)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariUrunGecmisi>()
                .Property(e => e.Kalite)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariUrunGecmisi>()
                .Property(e => e.R_P)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariUrunGecmisi>()
                .Property(e => e.Kalinlik)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariUrunGecmisi>()
                .Property(e => e.TbEn)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariUrunGecmisi>()
                .Property(e => e.TbBoy)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariUrunGecmisi>()
                .Property(e => e.Operator)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariUrunGecmisi>()
                .Property(e => e.Müsteri)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariUrunGecmisi>()
                .Property(e => e.Bilgi)
                .IsUnicode(false);

            modelBuilder.Entity<SacAmbariUrunGecmisi>()
                .Property(e => e.Irsaliye)
                .IsUnicode(false);
        }
    }
}
