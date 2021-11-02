using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models.Data
{
    public class LMSDbContext : DbContext
    {

        public LMSDbContext(DbContextOptions<LMSDbContext> options): base(options){}
        
        public DbSet<KullaniciEntity> Kullanici { get; set; }
        public DbSet<BasvuruEntity> Basvuru { get; set; }
        public DbSet<BasvuruSureciEntity> BasvuruSureci { get; set; }
        public DbSet<AnaDersEntity> AnaDers { get; set; }
        public DbSet<IlEntity> Il { get; set; }
        public DbSet<IlceEntity> Ilce { get; set; }

        public DbSet<IletisimEntity> Iletisim { get; set; }


    }
}
