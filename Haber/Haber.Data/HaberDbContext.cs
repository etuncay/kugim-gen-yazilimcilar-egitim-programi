using Microsoft.EntityFrameworkCore;

namespace Haber.Data
{
    public class HaberDbContext : DbContext
    {
        public HaberDbContext(DbContextOptions<HaberDbContext> options) : base(options) { }


        public DbSet<KullaniciEntity> Kullanici { get; set; }
        public DbSet<KullaniciYetkiEntity> KullaniciYetki { get; set; }
        public DbSet<KategoriEntity> Kategori { get; set; }
        public DbSet<YorumEntity> Yorum { get; set; }
        public DbSet<ResimEntity> Resim { get; set; }
        public DbSet<EtiketEntity> Etiket { get; set; }
        public DbSet<IcerikEntity> Icerik { get; set; }
        public DbSet<IcerikEtiketEntity> IcerikEtiket { get; set; }
        public DbSet<CacheEntity> Cache { get; set; }

    }
}
