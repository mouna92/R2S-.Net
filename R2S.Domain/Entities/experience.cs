using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class experience
    {
        public long id { get; set; }
        public Nullable<System.DateTime> dateEnd { get; set; }
        public Nullable<System.DateTime> dateStart { get; set; }
        public string description { get; set; }
        public string jobTitle { get; set; }
        public string organization { get; set; }
        public string post { get; set; }
        public Nullable<long> candidate_cin { get; set; }
        public virtual user user { get; set; }
    }
}
