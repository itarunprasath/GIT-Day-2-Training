using TrainingDay4.Model;

namespace TrainingDay4.Repository
{
    public interface IRCRepo
    {
        public List<RC> GetRCs(string cidbregno, string ssmno, string comname);
    }
}
