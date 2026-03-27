using System.Data.Entity;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Concrete.EntityFramework
{
    public class SiparisContext : DbContext
    {
        public SiparisContext() : base("name=SiparisContext")
        {
        }

        public DbSet<Siparis> Siparisler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Siparis>()
                .HasKey(e => e.SiparisID);

            modelBuilder.Entity<Siparis>()
                .Property(e => e.StokNo)
                .IsUnicode(false);

            modelBuilder.Entity<Siparis>()
                .Property(e => e.MusteriAdi)
                .IsUnicode(false);

            modelBuilder.Entity<Siparis>()
                .Property(e => e.ParcaAdi)
                .IsUnicode(false);

            modelBuilder.Entity<Siparis>()
                .Property(e => e.Bolum)
                .IsUnicode(false);

            modelBuilder.Entity<Siparis>()
                .Property(e => e.Durum)
                .IsUnicode(false);

            modelBuilder.Entity<Siparis>()
                .Property(e => e.SiparisNotu)
                .IsUnicode(false);
        }
    }
}
