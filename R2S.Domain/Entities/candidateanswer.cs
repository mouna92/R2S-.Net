using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class candidateanswer
    {
        public candidateanswer()
        {
            this.answers = new List<answer>();
            this.questions = new List<question>();
        }

        public long id { get; set; }
        public Nullable<long> candidateQuizModel_id { get; set; }
        public virtual ICollection<answer> answers { get; set; }
        public virtual candidatequizmodel candidatequizmodel { get; set; }
        public virtual ICollection<question> questions { get; set; }
    }
}
