using ShareCrypt.Data;
using ShareCrypt.Interfaces;
using ShareCrypt.Models;

namespace ShareCrypt.Repository
{
    public class OwnedFfRepo : IOwnedFfRepo
    {


        private readonly DataContext _context;

        public OwnedFfRepo(DataContext context)
        {
            _context = context;


        }

        public ICollection<OwnedFF> GetOwnedFF()
        {

            return _context.OwnedFF.OrderBy(p => p.FFID).ToList();


        }
    }
}
