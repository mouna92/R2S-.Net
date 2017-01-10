using R2S.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace R2S.GUI.Models
{
    public class JobFieldViewModel : BaseViewModel
    {
        public List<jobfield> JobField { get; internal set; }
        public IEnumerable<jobfield> Jobs { get; set; }
    }
    
}