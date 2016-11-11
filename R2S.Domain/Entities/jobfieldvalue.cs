using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class jobfieldvalue
    {
        public long id { get; set; }
        public string value { get; set; }
        public Nullable<long> job_id { get; set; }
        public Nullable<long> jobField_id { get; set; }
        public virtual job job { get; set; }
        public virtual jobfield jobfield { get; set; }
    }
}
