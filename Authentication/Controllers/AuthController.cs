using Microsoft.AspNetCore.Mvc;
using Surve.Domain.Contracts;
using Survey.Core.Model;
using Survey.Core.ViewModels.AccountViewModel;
using System;

namespace API.Authentication.Controllers
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
        public ActionResult RegisterUser([FromBody] User registerUser)
{
            if (ModelState.IsValid)
            {
                return Ok(service.CreateUser(registerUser));
            }
            else
            {
                //Exception 
                return Ok("Invalid Model");
            }

        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User logInModel  )
        {
            try
            {
                LoggedInUserViewModel loggedInUser = service.LoginUser(logInModel.Email, logInModel.Password);

                if (!ReferenceEquals(loggedInUser, null))
                {
                    //calling the function for the JWT token for respecting user
                    if (!ReferenceEquals(tokenGenerator, null))
                    {
                        string value = tokenGenerator.GetJWTToken(logInModel.Email);
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