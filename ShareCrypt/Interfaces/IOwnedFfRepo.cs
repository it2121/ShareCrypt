using ShareCrypt.Models;

namespace ShareCrypt.Interfaces
{
    public interface IOwnedFfRepo
    {
        ICollection<OwnedFF> GetOwnedFF();

    }
}
