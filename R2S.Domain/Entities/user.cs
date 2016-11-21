using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace R2S.Data.Models
{
    public partial class user
    {
        public user()
        {
            this.candidatefieldvalues = new List<candidatefieldvalue>();
            this.candidatejobs = new List<candidatejob>();
            this.candidatequizmodels = new List<candidatequizmodel>();
            this.candidateskills = new List<candidateskill>();
            this.certifications = new List<certification>();
            this.educations = new List<education>();
            this.emailmodels = new List<emailmodel>();
            this.experiences = new List<experience>();
            this.interviews = new List<interview>();
            this.interviews1 = new List<interview>();
            this.notifications = new List<notification>();
            this.referhashes = new List<referhash>();
            this.users1 = new List<user>();
        }

        public long cin { get; set; }
        public bool active { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string street { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d MMMMM, yyyy}")]
        public Nullable<System.DateTime> birthday { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string gender { get; set; }
        public string lastname { get; set; }
        public string password { get; set; }
        public string tel { get; set; }
        public string username { get; set; }
        public Nullable<long> referee_cin { get; set; }
        public virtual ICollection<candidatefieldvalue> candidatefieldvalues { get; set; }
        public virtual ICollection<candidatejob> candidatejobs { get; set; }
        public virtual ICollection<candidatequizmodel> candidatequizmodels { get; set; }
        public virtual ICollection<candidateskill> candidateskills { get; set; }
        public virtual ICollection<certification> certifications { get; set; }
        public virtual ICollection<education> educations { get; set; }
        public virtual ICollection<emailmodel> emailmodels { get; set; }
        public virtual ICollection<experience> experiences { get; set; }
        public virtual ICollection<interview> interviews { get; set; }
        public virtual ICollection<interview> interviews1 { get; set; }
        public virtual ICollection<notification> notifications { get; set; }
        public virtual ICollection<referhash> referhashes { get; set; }
        public virtual ICollection<user> users1 { get; set; }
        public virtual user user1 { get; set; }
    }
}
