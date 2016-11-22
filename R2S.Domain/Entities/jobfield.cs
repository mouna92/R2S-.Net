using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class jobfield
    {
        public jobfield()
        {
            this.jobfieldvalues = new List<jobfieldvalue>();
        }

        public long id { get; set; }
        public string fieldName { get; set; }
        public Nullable<int> fieldType { get; set; }
        public virtual ICollection<jobfieldvalue> jobfieldvalues { get; set; }

        public static readonly int TextField = 0;
        public static readonly int Radiobox = 1;
        public static readonly int Checkbox = 2;
    }
}
