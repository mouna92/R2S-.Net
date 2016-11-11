using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class notification
    {
        public long id { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string message { get; set; }
        public Nullable<long> job_id { get; set; }
        public Nullable<long> recruitmentManager_cin { get; set; }
        public virtual job job { get; set; }
        public virtual user user { get; set; }
    }
}
