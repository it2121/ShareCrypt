using ShareCrypt.DbAccess;
using ShareCrypt.Models;

namespace ShareCrypt.Data
{
    public class UserData : IUserData
    {


        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<Users>> GetAllUsers() =>
            _db.LoadData<Users, dynamic>("dbo.GetAllUsers", new { });

        public async Task<Users?> GetUser(int id)
        {
            var results = await _db.LoadData<Users, dynamic>(
                "dbo.GetUser",
                new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertUser(Users user) =>
            _db.SaveData("dbo.InsertUser", new { user.Username, user.Password, user.Email, user.Fullname });

        public Task UpdateUser(Users user) =>
            _db.SaveData("dbo.UpdateUser", user);

        public Task DeleteUser(int id) =>
            _db.SaveData("dbo.DeleteUser", new { ID = id });

    }
}
