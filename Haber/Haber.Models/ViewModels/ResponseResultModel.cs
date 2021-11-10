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
    }


}
