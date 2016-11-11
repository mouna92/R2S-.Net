using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class emailmodel
    {
        public long id { get; set; }
        public string content { get; set; }
        public string name { get; set; }
        public Nullable<long> recruitmentManager_cin { get; set; }
        public virtual user user { get; set; }
    }
}
