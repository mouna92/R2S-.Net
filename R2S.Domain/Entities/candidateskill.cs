using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class candidateskill
    {
        public Nullable<int> level { get; set; }
        public long candidate_cin { get; set; }
        public long skill_id { get; set; }
        public virtual user user { get; set; }
        public virtual skill skill { get; set; }
    }
}
