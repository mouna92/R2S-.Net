using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class job
    {
        public job()
        {
            this.candidatejobs = new List<candidatejob>();
            this.candidatequizmodels = new List<candidatequizmodel>();
            this.interviews = new List<interview>();
            this.referhashes = new List<referhash>();
            this.notifications = new List<notification>();
            this.rewards = new List<reward>();
            this.jobfieldvalues = new List<jobfieldvalue>();
            this.quizmodels = new List<quizmodel>();
            this.skills = new List<skill>();
        }

        public long id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public Nullable<double> salary { get; set; }
        public Nullable<int> status { get; set; }
        public virtual ICollection<candidatejob> candidatejobs { get; set; }
        public virtual ICollection<candidatequizmodel> candidatequizmodels { get; set; }
        public virtual ICollection<interview> interviews { get; set; }
        public virtual ICollection<referhash> referhashes { get; set; }
        public virtual ICollection<notification> notifications { get; set; }
        public virtual ICollection<reward> rewards { get; set; }
        public virtual ICollection<jobfieldvalue> jobfieldvalues { get; set; }
        public virtual ICollection<quizmodel> quizmodels { get; set; }
        public virtual ICollection<skill> skills { get; set; }
    }
}
