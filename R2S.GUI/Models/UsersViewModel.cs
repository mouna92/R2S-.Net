using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using R2S.Data.Models;

namespace R2S.GUI.Models
{
    public class UsersIndexViewModel : BaseViewModel
    {
        public IEnumerable<user> Users { get; set; }
    }

    public class UsersDetailsViewModel : BaseViewModel
    {
        public user NewUser { get; set; }
    }
}