using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class quizmodel
    {
        public quizmodel()
        {
            this.candidatequizmodels = new List<candidatequizmodel>();
            this.jobs = new List<job>();
            this.questions = new List<question>();
            this.answers = new List<answer>();
        }

        public long id { get; set; }
        public Nullable<int> answersNumber { get; set; }
        public Nullable<int> duration { get; set; }
        public string name { get; set; }
        public Nullable<bool> penalty { get; set; }
        public Nullable<int> questionsNumber { get; set; }
        public virtual ICollection<candidatequizmodel> candidatequizmodels { get; set; }
        public virtual ICollection<job> jobs { get; set; }
        public virtual ICollection<question> questions { get; set; }
        public virtual ICollection<answer> answers { get; set; }
    }
}
