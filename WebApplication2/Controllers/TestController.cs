using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Servive_interfaces;
using WebApplication2.Attributes;
using WebApplication2.Filters;
using WebApplication2.Models.DTOs;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILifeTimeService _lifeTimeService1;
        private readonly ILifeTimeService _lifeTimeService2;

        public TestController(IUserService userService, ILifeTimeService lifeTimeService1, ILifeTimeService lifeTimeService2)
        {
            _userService = userService;
            _lifeTimeService1 = lifeTimeService1;
            _lifeTimeService2 = lifeTimeService2;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetUser()
        //{
        //    var user = await _userService.GetUser();

        //    return Ok(user);
        //}

        [HttpGet("lifetime")]
        public async Task<IActionResult> ServiceLifetime()
        {
            var guid = _lifeTimeService1.GetGuid();

            var guid2 = _lifeTimeService2.GetGuid();

            var message = "First: " + guid + " Second: " + guid2;

            return Ok(message);
        }

        //[CustomActionFilter]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailsAsync(int id)
        {
            return Ok(await _userService.GetUserDetailsAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateUserDto request)
        {
            await _userService.AddUserAsync(request);
            return Ok();
        }
    }
}