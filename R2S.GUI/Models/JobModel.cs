using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using R2S.Data.Models;


namespace R2S.GUI.Models
{
    public class JobModel
    {


        public long id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public double salary { get; set; }
        public int status { get; set; }
        public int x1 { get; set; }

        public int x2 { get; set; }

    }
}

