using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using R2S.Data.Models;
using R2S.Service;

namespace R2S.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            /* System.Console.WriteLine("Start: ");
             r2sContext context=new r2sContext();
             emailmodel e=new emailmodel() {content = "Bonjour",name = "model2"};

             context.emailmodels.Add(e);
             context.SaveChanges();

             System.Console.WriteLine("success");
             System.Console.ReadLine();*/
            System.Console.WriteLine("Start: ");

            IJobService service = new JobService();
            

            System.Console.WriteLine(service.GetMany().ToList());
            System.Console.ReadLine();
            System.Console.WriteLine("success");

        }

    }
    }

