using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class education
    {
        public long id { get; set; }
        public Nullable<System.DateTime> dateEnd { get; set; }
        public Nullable<System.DateTime> dateStart { get; set; }
        public string degree { get; set; }
        public string institution { get; set; }
        public Nullable<long> candidate_cin { get; set; }
        public virtual user user { get; set; }
    }
}
