using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Core.Contracts;
using DemoAPI.Core.ViewModels.AccountViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserService service;

        public AuthController(IUserService userService)
        {
            service = userService;
        }
        [HttpPost("register_user")]
        public ActionResult RegisterUser([FromBody] RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                return Ok(service.CreateUser(service.MapUser(registerViewModel)));
            }
            else
            {
                //Exception 
                return Ok("Invalid Model");
            }

        }
    }
}