using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class referhash
    {
        public string hash { get; set; }
        public Nullable<System.DateTime> generateAt { get; set; }
        public Nullable<long> employee_cin { get; set; }
        public Nullable<long> job_id { get; set; }
        public virtual job job { get; set; }
        public virtual user user { get; set; }
    }
}
