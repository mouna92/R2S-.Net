using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2S.Data.Models;

namespace R2S.Data.Infrastructures
{
  public  interface IDataBaseFactory
    {
        r2sContext dbcontext { get; } //pour donner soit l'instance soit la méthode disposecore
    }
}
