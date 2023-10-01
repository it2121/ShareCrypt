using ShareCrypt.Data;
using ShareCrypt.Interfaces;
using ShareCrypt.Models;

namespace ShareCrypt.Repository
{
    public class SharedRepo : ISharedRepo
    {

        private readonly DataContext _context;

        public SharedRepo(DataContext context)
        {
            _context = context;


        }

        public ICollection<Shared> GetShared()
        {

            return _context.Shared.OrderBy(p => p.SharedToID).ToList();


        }




    }
}
