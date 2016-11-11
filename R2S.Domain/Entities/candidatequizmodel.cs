using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class candidatequizmodel
    {
        public candidatequizmodel()
        {
            this.candidateanswers = new List<candidateanswer>();
        }

        public long id { get; set; }
        public Nullable<System.DateTime> passingDate { get; set; }
        public Nullable<long> candidate_cin { get; set; }
        public Nullable<long> job_id { get; set; }
        public Nullable<long> quizModel_id { get; set; }
        public virtual ICollection<candidateanswer> candidateanswers { get; set; }
        public virtual user user { get; set; }
        public virtual job job { get; set; }
        public virtual quizmodel quizmodel { get; set; }
    }
}
