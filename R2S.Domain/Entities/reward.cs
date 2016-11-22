using System;
using System.Collections.Generic;

namespace R2S.Data.Models
{
    public partial class reward
    {
        public long id { get; set; }
        public string points { get; set; }
        public Nullable<int> progress { get; set; }
        public Nullable<long> job_id { get; set; }
        public virtual job job { get; set; }

        public string progressString
        {
            get
            {
                switch (progress)
                {
                    case 0: return "STARTED";
                    case 1: return "FAILED";
                    case 2: return "PASSED QUIZ";
                    case 3: return "REFUSED";
                    case 4: return "PASSED";
                    default: return "";
                }
            }
        }
    }
}
