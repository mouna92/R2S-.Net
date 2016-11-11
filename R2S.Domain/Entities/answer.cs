using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class answer
    {
        public answer()
        {
            this.quizmodels = new List<quizmodel>();
        }

        public long id { get; set; }
        public string answer1 { get; set; }
        public Nullable<bool> correct { get; set; }
        public Nullable<long> candidateAnswer_id { get; set; }
        public Nullable<long> question_id { get; set; }
        public virtual candidateanswer candidateanswer { get; set; }
        public virtual question question { get; set; }
        public virtual ICollection<quizmodel> quizmodels { get; set; }
    }
}
