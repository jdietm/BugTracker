using AlphaBugTracker.DAL;
using AlphaBugTracker.Models;

namespace AlphaBugTracker.BLL
{
    public class UserBusinessLogic
    {

        IRepository<Users> repo;
        public UserBusinessLogic(IRepository<Users> repoArg)
        {
            repo = repoArg;
        }

        public void UpdateNameAndPassword(Users user)
        {
            repo.Update(user);
            repo.Save();
        }
    }
}
