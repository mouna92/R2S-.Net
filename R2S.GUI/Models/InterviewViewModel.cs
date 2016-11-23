using System.Collections.Generic;
using R2S.Data.Models;

namespace R2S.GUI.Models
{
    public class InterviewViewModel : BaseViewModel
    {
        public IEnumerable<interview> Interviews { get; set; }
    }

    public class InterviewViewDetailsModel : BaseViewModel
    {
        public interview Interview { get; set; }
    }
}