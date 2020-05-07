using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Surve.Domain.Contracts;
using Survey.Core.Model;
using Survey.Core.ViewModels.AccountViewModel;
using Survey.Domain.AuthServices.RefreshToken;
using System;

namespace API.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserService service;
        public readonly ITokenGenerator tokenGenerator;
        public readonly IRefreshTokenGenerator refreshTokenGenerator;
        public AuthController(IUserService _userService, ITokenGenerator _tokenGenerator, IRefreshTokenGenerator IRefreshTokenGenerator)
        {
            service = _userService;
            tokenGenerator = _tokenGenerator;
            refreshTokenGenerator = IRefreshTokenGenerator;
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
        [HttpPost("refresh")]
        public IActionResult Refresh(string token,  string refreshToken)
        {
            var principal = refreshTokenGenerator.GetPrincipalFromExpiredToken(token);
            var username = principal.Identity.Name;
            var savedRefreshToken = refreshTokenGenerator.GetRefreshToken(username); //retrieve the refresh token from a data store
            if (savedRefreshToken != refreshToken)
                throw new SecurityTokenException("Invalid refresh token");
            string value = tokenGenerator.GetJWTToken(username);
            var newJwtToken = value;
            var newRefreshToken = refreshTokenGenerator.GenerateRefreshToken();
            refreshTokenGenerator.DeleteRefreshToken(username, refreshToken);
            refreshTokenGenerator.SaveRefreshToken(username, newRefreshToken);

            return new ObjectResult(new
            {
                token = newJwtToken,
                refreshToken = newRefreshToken
            });
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
                        string refreshToken = refreshTokenGenerator.GenerateRefreshToken();
                        loggedInUser.Token = value;
                        loggedInUser.RefreshToken = refreshToken;
                        refreshTokenGenerator.SaveRefreshToken(logInModel.Email, refreshToken);
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