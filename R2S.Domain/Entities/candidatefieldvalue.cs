using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class candidatefieldvalue
    {
        public long id { get; set; }
        public string value { get; set; }
        public Nullable<long> candidate_cin { get; set; }
        public Nullable<long> candidateField_id { get; set; }
        public virtual candidatefield candidatefield { get; set; }
        public virtual user user { get; set; }
    }
}
