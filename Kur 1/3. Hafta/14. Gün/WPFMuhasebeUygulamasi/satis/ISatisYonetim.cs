using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFMuhasebeUygulamasi.satis.Models;

namespace WPFMuhasebeUygulamasi.satis
{
    public interface ISatisYonetim
    {
        List<SatisDbModel> Liste();
        SatisDbModel Getir(int id);
        bool SatisYap(SatisDbModel model);
        void DataGridYenile(DataGrid dataGrid);
        bool Sil(int id);
    }
}
