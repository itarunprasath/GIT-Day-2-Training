using System.Data;
using System.Data.SqlClient;
using Task1_CMS.Model;

namespace Task1_CMS.Repository
{
    public interface IcmsRepo 
    {

        public List<CMS> GetInfoCMS(string? ICNO = null, string? TRED = null);

    }
}
