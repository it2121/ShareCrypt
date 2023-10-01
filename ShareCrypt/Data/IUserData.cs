using ShareCrypt.Models;

namespace ShareCrypt.Data
{
    public interface IUserData
    {
        Task DeleteUser(int id);
        Task<IEnumerable<Users>> GetAllUsers();
        Task<Users?> GetUser(int id);
        Task InsertUser(Users user);
        Task UpdateUser(Users user);
    }
}