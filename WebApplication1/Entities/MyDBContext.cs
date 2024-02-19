using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Entities
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<Hanghoa> HangHoa { get; set; }
        public DbSet<Loaihh> Loaihh { get; set; }
        public DbSet<Donhang> Donhang { get; set; }
        public DbSet<Chitietdh> Chitietdh { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donhang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.Madh);
                e.Property(dh => dh.Ngaydh).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.Nguoimua).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<Chitietdh>(e =>
            {
                e.ToTable("ChiTietDonHang");
                e.HasKey(e => new { e.Madh, e.Mahh });

                e.HasOne(e => e.Donhang)
                    .WithMany(e => e.Chitietdh)
                    .HasForeignKey(e => e.Madh)
                    .HasConstraintName("FK_Chitietdh_Donhang");

                e.HasOne(e => e.Hanghoa)
                    .WithMany(e => e.Chitietdh)
                    .HasForeignKey(e => e.Mahh)
                    .HasConstraintName("FK_Chitietdh_Hanghoa");
            });
        }
    }
}
