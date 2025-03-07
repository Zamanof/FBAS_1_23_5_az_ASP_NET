using ASP_NET_23._Onion_Domain.Entities;

namespace ASP_NET_23._Onion_Domain.Interfaces;

public interface IUserRepository
{
    User GetById(int id);
    IEnumerable<User> GetAll();
    void Add(User user);
    void Save();
}
