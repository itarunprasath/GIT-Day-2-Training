using Microsoft.AspNetCore.Cors.Infrastructure;
using Task1_CMS.Model;
using Task1_CMS.Repository;

namespace Task1_CMS.Service
{
    public interface IcmsServices
    {


        public List<CMS> GetInfoCMS(string? ICNO, string? TRED);


    }
}
