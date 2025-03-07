using ASP_NET_23._Onion_Domain.Entities;
using ASP_NET_23._Onion_Domain.Interfaces;
using ASP_NET_23._Onion_Infrastructure.Data;

namespace ASP_NET_23._Onion_Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(User user)
    {
        _appDbContext.Users.Add(user);
    }

    public IEnumerable<User> GetAll()
    {
        return _appDbContext.Users.ToList() ;
    }

    public User GetById(int id)
    {
        return _appDbContext.Users.Find(id)!;
    }

    public void Save()
    {
        _appDbContext.SaveChanges();
    }
}
