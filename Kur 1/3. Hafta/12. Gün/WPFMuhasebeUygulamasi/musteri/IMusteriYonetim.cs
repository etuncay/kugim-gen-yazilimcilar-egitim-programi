using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFMuhasebeUygulamasi.musteri.Models;

namespace WPFMuhasebeUygulamasi.musteri
{
    public interface IMusteriYonetim
    {
        List<MusteriDbModel> Liste();
        MusteriDbModel Getir(int id);
        bool Ekle(MusteriDbModel model);
        bool Guncelle(MusteriDbModel model);
        bool Sil(int id);
        void DataGridYenile(DataGrid dataGrid);
    }
}
