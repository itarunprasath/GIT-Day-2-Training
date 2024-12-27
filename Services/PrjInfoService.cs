using TrainingDay4.Model;
using TrainingDay4.Repository;

namespace TrainingDay4.Services
{
    public class PrjInfoService : IPrjInfoService
    {
        private readonly IPrjInfoRepo _prjInfoRepo;

        public PrjInfoService(IPrjInfoRepo prjInfoRepo)
        {
            _prjInfoRepo = prjInfoRepo;
        }

        public List<PrjInfo> GetProjectInfo(string comprefno)
        {
            return _prjInfoRepo.GetProjectInfo(comprefno);
        }

    }
}
