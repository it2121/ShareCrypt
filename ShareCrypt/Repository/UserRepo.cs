using ShareCrypt.Data;
using ShareCrypt.Interfaces;
using ShareCrypt.Models;

namespace ShareCrypt.Repository
{
    public class UserRepo :IUsersRepo
    {
        private readonly DataContext _context;

        public UserRepo(DataContext context) 
        {
            _context = context;


        }

        public ICollection<Users> GetUsers()
        {

            return _context.Users.OrderBy(p => p.ID).ToList();


        }
         
    }
}
