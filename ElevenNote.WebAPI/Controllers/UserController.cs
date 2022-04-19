using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevenNote.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElevenNote.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegister model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var registerResult = await _service.RegisterUserASync(model);
        if (registerResult)
        {
            return Ok("User was registered.");
        }
        return BadRequest("User could not be registered.");
    }
    [HttpGet("{userId:int")]
    public async Task<IActionResult> GetById()
    {
        var userDetail = await _service.GetUserByIdAsync(userId);

        if (userDetail is null)
        {
            return NotFound();
        }

        return Ok(userDetail);
    }


}
