using TrainingDay4.Model;

namespace TrainingDay4.Services
{
    public interface IRCService
    {
        public List<RC> GetRCs(string cidbregno, string ssmno, string comname);
    }
}
