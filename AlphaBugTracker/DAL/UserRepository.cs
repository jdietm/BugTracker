using AlphaBugTracker.Data;
using AlphaBugTracker.Models;
using Microsoft.AspNetCore.Identity;

namespace AlphaBugTracker.DAL
{
    public class UserRepository : IRepository<Users>
    {
        private readonly UserManager<Users> _userManager;
        private readonly ApplicationDbContext _context;


        public UserRepository(UserManager<Users> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public void Create(Users? entity)
        {
            if (entity != null) _userManager.CreateAsync(entity).Wait();
        }

        public void Delete(int? id)
        {
            if (id != null) _userManager.DeleteAsync(_userManager.Users.First(u => Equals(u.Id, id))).Wait();
        }

        public Users? Get(Func<Users, bool>? firstFunction)
        {

            Users? userS = null;

            if (firstFunction != null)
            {
                userS = _userManager.Users.First(firstFunction);

            }
            return userS;
        }

        public ICollection<Users>? GetList(Func<Users, bool>? whereFunction)
        {
            List<Users> userS = null;
            if (whereFunction != null)
            {
                userS = _userManager.Users.Where(whereFunction).ToList();
            }
            return userS;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Users? entity)
        {
            if (entity is not null) _userManager.UpdateAsync(entity);
        }
    }
}
