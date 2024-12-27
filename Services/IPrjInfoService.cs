using TrainingDay4.Model;

namespace TrainingDay4.Services
{
    public interface IPrjInfoService
    {
        public List<PrjInfo> GetProjectInfo(string comprefno);
    }
}
