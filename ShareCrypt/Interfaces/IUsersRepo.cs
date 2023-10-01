using ShareCrypt.Models;

namespace ShareCrypt.Interfaces
{
    public interface IUsersRepo
    {

        ICollection<Users> GetUsers();



    }
}
