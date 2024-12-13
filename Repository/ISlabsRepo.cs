using TrainingDay4.Model;

namespace TrainingDay4.Repository
{
    public interface ISlabsRepo
    {
        public List<Slabs> GetSlabs(int versionid);
    }
}
