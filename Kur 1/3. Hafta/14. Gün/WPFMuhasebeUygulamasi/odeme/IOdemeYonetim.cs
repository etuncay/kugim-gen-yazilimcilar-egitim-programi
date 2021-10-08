using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMuhasebeUygulamasi.odeme.Models;

namespace WPFMuhasebeUygulamasi.odeme
{
    public interface IOdemeYonetim
    {
        List<OdemeDbModel> Liste();
        bool OdemeYap(OdemeDbModel model);
    }
}
