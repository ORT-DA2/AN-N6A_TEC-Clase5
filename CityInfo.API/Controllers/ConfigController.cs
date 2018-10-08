using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/dev")]
    public class ConfigController : Controller
    {
        private readonly IReadConfig configService;
        public ConfigController(IReadConfig service)
        {
            this.configService = service;
        }

        [HttpGet()]
        public IActionResult GetDev(int cityId)
        {
            return Ok(this.configService.GetDevName());

        }
    }
}