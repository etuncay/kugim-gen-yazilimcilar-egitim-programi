using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Haber.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumYetki
    {
        [EnumMember(Value = "Yönetici")]
        Yonetici = 1,
        [EnumMember(Value = "Moderator")]
        Moderator = 2
    }
}
