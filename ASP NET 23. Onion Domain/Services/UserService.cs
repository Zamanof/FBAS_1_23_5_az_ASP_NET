using ASP_NET_23._Onion_Domain.Entities;
using ASP_NET_23._Onion_Domain.Interfaces;

namespace ASP_NET_23._Onion_Domain.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User GetUser(int id)
    {
        return _userRepository.GetById(id);
    }

    public IEnumerable<User> GetUsers()
    {
        return _userRepository.GetAll();
    }

    public void AddUser(User user)
    {
        _userRepository.Add(user);
    }

    public void CreateUser(string firstName, string lastName, string email)
    {
        var user = new User(){
            FirstName= firstName,
            LastName= lastName,
            Email= email
        };
        _userRepository.Add(user);
        _userRepository.Save();
    }
}
