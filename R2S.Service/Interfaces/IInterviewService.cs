using System.Security.Cryptography.X509Certificates;
using R2S.Data.Models;
using Service.pattern;

namespace R2S.Service.Interfaces
{
    public interface IInterviewService : IServiceGenerique<interview>
    {
        void refresh(interview interview);
    }
}