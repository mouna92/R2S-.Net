using R2S.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace R2S.GUI.Models
{
    public class SkillsViewModel : BaseViewModel
    {
        public IEnumerable<skill> Skills { get; set; }
    }

    public class SkillsViewDetailsModel : BaseViewModel
    {
        public skill Skill { get; set; }
    }
}