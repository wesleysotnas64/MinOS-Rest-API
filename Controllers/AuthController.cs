using Microsoft.AspNetCore.Mvc;
using MinOS_Rest_API.DAO;
using MinOS_Rest_API.DTO.Request;
using MinOS_Rest_API.DTO.Response;
using MinOS_Rest_API.Entities;

namespace MinOS_Rest_API.Controllers
{
    [ApiController]
    [Route("/login-api")]
    public class AuthController : ControllerBase
    {
        public AuthController() { }

        [HttpPost("/login-get-access")]
        public IActionResult Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            AuthDAO authDAO = new AuthDAO();
            

            LoginResponseDTO loginResponseDTO = authDAO.Login(loginRequestDTO);

            return Ok(loginResponseDTO);
        }
    }
}
