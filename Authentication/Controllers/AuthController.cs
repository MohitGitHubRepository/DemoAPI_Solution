using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Service;
using DemoAPI.Core.Contracts;
using DemoAPI.Core.Model;
using DemoAPI.Core.ViewModels.AccountViewModel;
using DemoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserService service;
        public readonly ITokenGenerator tokenGenerator;
        public AuthController(IUserService _userService, ITokenGenerator _tokenGenerator)
        {
            service = _userService;
            tokenGenerator = _tokenGenerator;
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

        [HttpPost("login")]
        public IActionResult Login([FromBody] LogInModel logInModel  )
        {
            try
            {
                LoggedInUserViewModel loggedInUser = service.LoginUser(logInModel.UserId, logInModel.Password);

                if (!ReferenceEquals(loggedInUser, null))
                {
                    //calling the function for the JWT token for respecting user
                    if (!ReferenceEquals(tokenGenerator, null))
                    {
                        string value = tokenGenerator.GetJWTToken(logInModel.UserId);
                        //returning the token to the consumer app
                        loggedInUser.Token = value;
                        return Ok(loggedInUser);
                    }
                    else
                    {
                        return Ok(loggedInUser);
                    }
                }
                else
                {
                    return StatusCode(204, "User not found");
                }
            }
            //catch (UserNotFoundException ex)
            //{
            //    return NotFound();
            //}
            catch (Exception ex)
            {
                return NotFound();
            }
        }

    }
}