using TrainingDay4.Model;
using TrainingDay4.Repository;

namespace TrainingDay4.Services
{
    public class SlabsServie : ISlabsServie
    {
        private readonly ISlabsRepo _repo;
        public SlabsServie(ISlabsRepo repo)
        {
            _repo = repo;
        }
        public List<Slabs> GetSlabs(int versionid)
        {
            return _repo.GetSlabs(versionid);
        }
    }
}
