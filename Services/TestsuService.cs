using TrainingDay4.Model;
using TrainingDay4.Repository;

namespace TrainingDay4.Services
{
    public class TestsuService : ITestsuService
    {
        private readonly ITestsuRepo _userRepo;
        public TestsuService(ITestsuRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public List<TestsuDetails> GetUserDetails()
        {
            return _userRepo.GetUserDetails();
        }
        public TestsuDetails GetUserDetails(string firstname)
        {
            var userDetails = _userRepo.GetUserDetails();
            var userdetail = userDetails.Where(x => x.FirstName.ToLower() == firstname.ToLower());

            return userdetail.FirstOrDefault();
        }

        public TestsuDetails GetUserDetailsByUserid(string userid)
        {
            return _userRepo.GetUserDetailsByUserid(userid);
        }
    }
}
