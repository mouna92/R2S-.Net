using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class question
    {
        public question()
        {
            this.answers = new List<answer>();
            this.categories = new List<category>();
            this.quizmodels = new List<quizmodel>();
        }

        public long id { get; set; }
        public string question1 { get; set; }
        public string score { get; set; }
        public Nullable<int> type { get; set; }
        public Nullable<long> candidateAnswer_id { get; set; }
        public Nullable<long> category_id { get; set; }
        public virtual ICollection<answer> answers { get; set; }
        public virtual candidateanswer candidateanswer { get; set; }
        public virtual category category { get; set; }
        public virtual ICollection<category> categories { get; set; }
        public virtual ICollection<quizmodel> quizmodels { get; set; }
    }
}
