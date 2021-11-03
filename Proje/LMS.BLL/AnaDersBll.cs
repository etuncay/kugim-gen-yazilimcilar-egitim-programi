using LMS.Core.Interfaces;
using LMS.Data;
using LMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.BLL
{
    public class AnaDersBll : IAnaDersBll
    {
        private readonly LMSDbContext _dbcontext;

        public AnaDersBll(LMSDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<AnaDersViewModel> Listele()
        {
            return _dbcontext.AnaDers.Select(q => new AnaDersViewModel()
            {
                Id = q.Id,
                Ad = q.Ad,
                UstId = q.UstId,
                Aciklama = q.Aciklama,
                Aktif = q.Aktif,
                OlusturulmaTarihi = q.OlusturulmaTarihi,
                GuncellenmeTarihi = q.GuncellenmeTarihi
            }).ToList(); 
        }

        public AnaDersViewModel Getir(int id)
        {
            return _dbcontext.AnaDers.Where(q => q.Id == id)
                .Select(q => new AnaDersViewModel()
                {
                    Id = q.Id,
                    Ad = q.Ad,
                    UstId = q.UstId,
                    Aciklama = q.Aciklama,
                    Aktif = q.Aktif,
                    OlusturulmaTarihi = q.OlusturulmaTarihi,
                    GuncellenmeTarihi = q.GuncellenmeTarihi
                }).FirstOrDefault();
        }

        public int Ekle(AnaDersKayitViewModel model)
        {
            var entity = new AnaDersEntity()
            {
                UstId = model.UstId,
                Ad = model.Ad,
                Aciklama = model.Aciklama,
                Aktif = model.Aktif,
                OlusturulmaTarihi = DateTime.Now,
            };
            _dbcontext.AnaDers.Add(entity);

            return _dbcontext.SaveChanges() > 0 ? entity.Id: 0;
        }

        public bool Guncelle(int id, AnaDersKayitViewModel model)
        {
            var query = _dbcontext.AnaDers.FirstOrDefault(q => q.Id == id);
            if (query != null)
            {
                query.Ad = model.Ad;
                query.Aciklama = model.Aciklama;
                query.Aktif = model.Aktif;

                return _dbcontext.SaveChanges() > 0 ? true : false;
            }

            return false;
        }


        public bool Sil(int id)
        {
            var query = _dbcontext.AnaDers.FirstOrDefault(q => q.Id == id);

            if (query != null)
            {
                _dbcontext.AnaDers.Remove(query);

                return _dbcontext.SaveChanges() > 0 ? true : false;

            }

            return false;
        }
    }
}
