using ShareCrypt.Data;
using ShareCrypt.Interfaces;
using ShareCrypt.Models;

namespace ShareCrypt.Repository
{
    public class FfRepo : IFfRepo
    {

        private readonly DataContext _context;

        public FfRepo(DataContext context)
        {
            _context = context;


        }

        public ICollection<FF> GetFF()
        {

            return _context.FF.OrderBy(p => p.FFID).ToList();


        }

    }
}
