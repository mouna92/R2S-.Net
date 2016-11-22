using R2S.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace R2S.GUI.Models
{
    public class JobViewModel : BaseViewModel
    {
        public IEnumerable<job>  Jobs { get; set; }
    }
    public class JobViewDetailsModel : BaseViewModel
    {
        public job Job { get; set; }
    }
}