using ShareCrypt.Models;

namespace ShareCrypt.Interfaces
{
    public interface ISharedRepo
    {

        ICollection<Shared> GetShared();

    }
}
