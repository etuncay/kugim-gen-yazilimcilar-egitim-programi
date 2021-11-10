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
    public enum EnumIcerikTipi
    {
        [EnumMember(Value = "Haber")]
        Haber = 1,
        [EnumMember(Value = "Galeri")]
        Galeri = 2
    }
}
