using Haber.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Models.ViewModels
{
    public class ResponseResultModel<T>
    {
    
        public int TotalCount { get; set; }
        public string Message { get; set; }
        public EnumResponseResultType Type { get; set; }
        public string Error { get; set; }
        public T Data { get; set; }
    }

    public class ResponseResultModel
    {
        public string Message { get; set; }
        public EnumResponseResultType Type { get; set; }
        public string Error { get; set; }
    }
}
