using TrainingDay4.Model;

namespace TrainingDay4.Services
{
    public interface ISlabsServie
    {
        public List<Slabs> GetSlabs(int versionid);
    }
}
