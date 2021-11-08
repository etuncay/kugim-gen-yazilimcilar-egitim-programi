using Microsoft.EntityFrameworkCore;

namespace Haber.Data
{
    public class HaberDbContext : DbContext
    {
        public HaberDbContext(DbContextOptions<HaberDbContext> options) : base(options) { }


        public DbSet<KullaniciEntity> Kullanici { get; set; }
        public DbSet<KullaniciYetkiEntity> KullaniciYetki { get; set; }

    }
}
