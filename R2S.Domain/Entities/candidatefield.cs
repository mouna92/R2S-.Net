using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class candidatefield
    {
        public candidatefield()
        {
            this.candidatefieldvalues = new List<candidatefieldvalue>();
        }

        public long id { get; set; }
        public string fieldName { get; set; }
        public Nullable<int> fieldType { get; set; }
        public virtual ICollection<candidatefieldvalue> candidatefieldvalues { get; set; }
    }
}
