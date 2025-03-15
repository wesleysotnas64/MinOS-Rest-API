using Microsoft.AspNetCore.Mvc;
using MinOS_Rest_API.Entities;
using MinOS_Rest_API.DAO;

namespace MinOS_Rest_API.Controllers
{
    [ApiController]
    [Route("/accesslevel-api")]
    public class AccsessLevelController : ControllerBase
    {
        public AccsessLevelController() { }

        [HttpGet("/get-all-accesslevels")]
        public IActionResult GetAllAccessLevels()
        {
            List<AccessLevelEntity> accessLevels = [];

            AccessLevelDAO accessLevelDAO = new();
            accessLevels = accessLevelDAO.GetAllAccessLevels();

            return Ok(accessLevels);
        }
    }
}
