using ASP_NET_23._Onion_Application.DTOs;
using ASP_NET_23._Onion_Application.Services;
using ASP_NET_23._Onion_Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_23._Onion_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserAppService _userAppService;

        public UserController(UserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        [HttpGet]
        public IEnumerable<User> GetUsers (){
            return _userAppService.GetAllUsers();
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDTO userDTO)
        {
            _userAppService.CreateUser(userDTO);
            return Ok("User created successfully");
        }
    }
}
