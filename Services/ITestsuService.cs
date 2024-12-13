using TrainingDay4.Model;

namespace TrainingDay4.Services
{
    public interface ITestsuService
    {
        public List<TestsuDetails> GetUserDetails();

        public TestsuDetails GetUserDetails(string firstName);

        public TestsuDetails GetUserDetailsByUserid(string userid);
    }
}
