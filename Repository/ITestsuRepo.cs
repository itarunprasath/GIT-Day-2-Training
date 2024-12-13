using TrainingDay4.Model;

namespace TrainingDay4.Repository
{
    public interface ITestsuRepo
    {
        public List<TestsuDetails> GetUserDetails();

        public TestsuDetails GetUserDetailsByUserid(string userId);
    }
}
