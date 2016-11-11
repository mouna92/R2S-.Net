using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class candidatejob
    {
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> progress { get; set; }
        public long candidate_cin { get; set; }
        public long job_id { get; set; }
        public virtual job job { get; set; }
        public virtual user user { get; set; }
    }
}
