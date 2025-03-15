using Microsoft.AspNetCore.Mvc;
using MinOS_Rest_API.DAO;
using MinOS_Rest_API.Entities;

namespace MinOS_Rest_API.Controllers
{
    [ApiController]
    [Route("/user-api")]
    public class UserController : ControllerBase
    {
        public UserController() { }

        [HttpGet("/get-all-users")]
        public IActionResult GetAllUsers()
        {
            List<UserEntity> users = [];

            UserDAO userDAO = new();
            users = userDAO.GetAllUsers();

            return Ok(users);
        }
    }
}
