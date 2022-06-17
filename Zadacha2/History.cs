using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Zadacha2
{
    public partial class History
    {
        public long Id { get; set; }
        public long? DataId { get; set; }
        public double? Summ { get; set; }

        [JsonIgnore]
        public virtual Datum? Data { get; set; }
    }
}
