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
    public enum EnumResponseResultType
    {
        [EnumMember(Value = "Success")]
        Success = 1,
        [EnumMember(Value = "Error")]
        Error = 2,
        [EnumMember(Value = "Info")]
        Info = 3,
        [EnumMember(Value = "Warning")]
        Warning = 4
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumStaticRole
    {
        [EnumMember(Value = "admin-role")]
        AdminRole = 1,
        [EnumMember(Value = "technical-service-role")]
        TechnicalServiceRole = 2,
        [EnumMember(Value = "inventory-role")]
        InventoryRole = 3
    }
}
