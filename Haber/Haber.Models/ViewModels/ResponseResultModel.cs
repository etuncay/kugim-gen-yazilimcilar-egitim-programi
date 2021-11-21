using FluentValidation.Results;
using Haber.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Models.ViewModels
{
    public class ResponseResultModel<T> : ResponseResultModel
    {

        public int TotalCount { get; set; }
        public T Data { get; set; }
    }

    public class ResponseResultModel
    {
        public Dictionary<string, string> Messages { get; set; } = new Dictionary<string, string>();
        public string Message { get; set; } 
        public EnumResponseResultType Type { get; set; }
        public string Error { get; set; }

        public void SetErrors(ValidationResult validate)
        {
            Type = EnumResponseResultType.Error;

            foreach (var error in validate.Errors)
            {
                Messages.Add(error.PropertyName, error.ErrorMessage);
            }
        }

        public void SaveChange(int i, string message = "İşlem yapıldı")
        {
            if (i > 0)
            {
                Type = EnumResponseResultType.Success;
                Message = message;
            }
            else
            {
                Type = EnumResponseResultType.Error;
                Message = "İşlem yapılamadı";
            }
        }
    }


    public static  class ResponseResultMessageType
    {
        public static string KayitBulundu => "Kayıt bulundu.";
        public static string KayitBulunamadi => "Kayıt bulunamadı";
        public static string KadedilirkenHata => "Kayıt yapılırken hata çıkmıştır.";
        public static string BasariliIslem=> "Kayıt yapılırken hata çıkmıştır.";
        public static string BasarisizIslem => "Kayıt yapılırken hata çıkmıştır.";

    }

}
