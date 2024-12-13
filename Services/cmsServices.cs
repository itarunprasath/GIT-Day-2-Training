using Microsoft.AspNetCore.Cors.Infrastructure;
using Task1_CMS.Model;
using Task1_CMS.Repository;

namespace Task1_CMS.Service
{
    public class CmsServices : IcmsServices
    {

        public readonly IcmsRepo cmsRepo;
        private IcmsRepo _cmsRepo;
        private IcmsRepo _cmsRepos;

        public CmsServices(IcmsRepo cmsRepo)
        {
            _cmsRepos = cmsRepo;
        }

        public List<CMS> GetInfoCMS(string? ICNO, string? TRED)
        {
            //return _cmsRepo.GetInfoCMS(ICNO, TRED);
            var icno = string.IsNullOrEmpty(ICNO) ? null : ICNO;
            var tred = string.IsNullOrEmpty(TRED) ? null : TRED;

            return _cmsRepos.GetInfoCMS(icno, tred);
        }

    }
}
