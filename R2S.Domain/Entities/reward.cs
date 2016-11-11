using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class reward
    {
        public long id { get; set; }
        public string points { get; set; }
        public Nullable<int> progress { get; set; }
        public Nullable<long> job_id { get; set; }
        public virtual job job { get; set; }
    }
}
