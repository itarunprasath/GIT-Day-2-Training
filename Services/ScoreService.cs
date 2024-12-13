using Task1_Score.Model;
using Task1_Score.Repository;

namespace Task1_Score.Services
{
    public class ScoreService: IScoreService
    {
        private readonly IScoreRepo _scoreRepo;
        //private IScoreRepo _scoreRepo;

        public ScoreService(IScoreRepo scoreRepo)
        {
            _scoreRepo = scoreRepo;
        }

        public List<ScoreAppl> GetScoreAppl(string GRED, int BINTANG, int TAHUN)
        {
            return _scoreRepo.GetScoreAppl(GRED, BINTANG, TAHUN);
        }
    }
}
