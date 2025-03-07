using ASP_NET_23._Onion_Application.DTOs;
using ASP_NET_23._Onion_Domain.Entities;
using ASP_NET_23._Onion_Domain.Services;
namespace ASP_NET_23._Onion_Application.Services;


public class UserAppService
{
    private readonly UserService _userService;

    public UserAppService(UserService userService)
    {
        _userService = userService;
    }
    public void CreateUser(UserDTO userDTO)
    {
        _userService.CreateUser(userDTO.FirstName, userDTO.LastName, userDTO.Email);
    }
    public IEnumerable<User> GetAllUsers()
    {
        return _userService.GetUsers();
    }
}
