using Task1_Score.Model;

namespace Task1_Score.Repository
{
    public interface IScoreRepo
    {
        public List<ScoreAppl> GetScoreAppl(string GRED, int BINTANG, int TAHUN);
    }
}
