using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class skill
    {
        public skill()
        {
            this.candidateskills = new List<candidateskill>();
            this.jobs = new List<job>();
        }

        public long id { get; set; }
        public string name { get; set; }
        public virtual ICollection<candidateskill> candidateskills { get; set; }
        public virtual ICollection<job> jobs { get; set; }
    }
}
