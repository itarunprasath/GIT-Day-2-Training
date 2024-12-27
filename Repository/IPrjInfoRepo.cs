using TrainingDay4.Model;

namespace TrainingDay4.Repository
{
    public interface IPrjInfoRepo
    {
        public List<PrjInfo> GetProjectInfo(string comprefno);
    }
}
