using TrainingDay4.Model;
using TrainingDay4.Repository;

namespace TrainingDay4.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepo _usersRepo;

        public UsersService(IUsersRepo usersRepo)
        {
            _usersRepo = usersRepo;
        }

        public List<Users> GetUsers()
        {
            return _usersRepo.GetUsers();
        }

    }
}
