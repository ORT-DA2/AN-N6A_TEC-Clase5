using Microsoft.AspNetCore.Mvc;
using CityInfo.Contracts.DataAccess;

namespace CityInfo.API.Controllers
{
    public class BaseController : Controller
    {
        private readonly ISessionRepository session;
        public BaseController(ISessionRepository session)
        {
            this.session = session;
        }

        public IActionResult ValidateToken(string role)
        {
            string token = this.HttpContext.Request.Headers["Authorization"];
            // VALIDAMOS EL TOKEN
            if (!this.session.IsValidToken(token))
            {
                return StatusCode(401, "Invalid Token");
            }
            // CHECKEAMOS QUE EL TOKEN TENGA LOS PERMISOS NECESARIOS
            if (!session.HasLevel(token, role))
            {
                return StatusCode(403, $"The user is not {role}");
            }

            return null;

        }
    }
}
