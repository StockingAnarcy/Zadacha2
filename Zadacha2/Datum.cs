using System;
using System.Collections.Generic;

namespace Zadacha2
{
    public partial class Datum
    {
        public Datum()
        {
            Histories = new HashSet<History>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public long? AccNum { get; set; }
        public string? SoderzhOper { get; set; }
        public double? Summa { get; set; }

        public virtual ICollection<History> Histories { get; set; }
    }
}
