using System;
using CityInfo.API.Models;
using CityInfo.Contracts.DataAccess;
using CityInfo.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api")]
    public class UserController : BaseController
    {
        private readonly IUserService service;

        public UserController(ISessionRepository session, IUserService service) : base(session)
        {
            this.service = service;
        }

        [HttpPost("login")]
        public IActionResult Post([FromBody]LoginRequest login)
        {
            return Ok(this.service.Login(login.Username, login.Password));
        }


        [HttpPost("users")]
        public IActionResult Post([FromBody]UserRequest request)
        {
            var validation = this.ValidateToken("Admin");
            if (validation != null) return validation;

            this.service.Add(request.TransformToEntity());

            return Ok();
        }
    }
}