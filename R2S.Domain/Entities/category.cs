using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class category
    {
        public category()
        {
            this.questions = new List<question>();
            this.questions1 = new List<question>();
        }

        public long id { get; set; }
        public string name { get; set; }
        public virtual ICollection<question> questions { get; set; }
        public virtual ICollection<question> questions1 { get; set; }
    }
}
