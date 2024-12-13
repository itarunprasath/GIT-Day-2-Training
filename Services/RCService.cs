using TrainingDay4.Model;
using TrainingDay4.Repository;

namespace TrainingDay4.Services
{
    public class RCService : IRCService
    {
        private readonly IRCRepo _rCRepo;

        public RCService(IRCRepo rCRepo)
        {
            _rCRepo = rCRepo;
        }

        public List<RC> GetRCs(string cidbregno, string ssmno, string comname)

        {
            return _rCRepo.GetRCs(cidbregno, ssmno, comname);
        }

    }
}
