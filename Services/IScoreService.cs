using Task1_Score.Model;

namespace Task1_Score.Services
{
    public interface IScoreService
    {
        public List<ScoreAppl> GetScoreAppl(string GRED, int BINTANG, int TAHUN);
    }
}
