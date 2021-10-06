using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFMuhasebeUygulamasi
{
    public abstract class ABSBaseDbModel
    {
        public  void DosyaKontrolEt(string dosyaYolu)
        {
            if (!File.Exists(dosyaYolu))
            {
                File.Create(dosyaYolu);
            }
        }

        public abstract void DataGridYenile(DataGrid dataGrid);
    }
}
