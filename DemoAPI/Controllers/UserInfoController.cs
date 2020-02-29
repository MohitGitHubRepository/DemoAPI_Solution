using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Surve.Domain.Contracts;
using Survey.Core.Model;
using Survey.Core.ViewModels.AccountViewModel;
using System;

namespace API.SurveyApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        IUserService service;

        public UserInfoController(IUserService _userService)
        {
            service = _userService;
        }

        [HttpPost("profile/{userId}")]
        public IActionResult Profile( string userId)
        {
            try
            {
                User loggedInUser = service.GetUserByEmail(userId);
                if (!ReferenceEquals(loggedInUser, null))
                {
                    loggedInUser = service.GetUserByEmail(userId);
                }

                if (!ReferenceEquals(loggedInUser, null))
                {
                    loggedInUser.Password = "********";
                    return Ok(loggedInUser);
                }
                else
                {
                    return NotFound("User not found");
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
        [HttpPost("update")]
        public IActionResult UpdateUserInfo([FromBody] User userinfo )
        {
            //Need to implement correct logic to update Email or PhoneNumber
            if(User!=null)
            {
                User getUser = service.GetUserByEmail(userinfo.Email);
                if(getUser!=null)
                {
                    this.service.UpdateUser(userinfo, getUser);

                    return Ok("Details Updated");

                }
                else
                {
                   return  NotFound("User Not Found");
                }
            }
            else
            {
                return NotFound("Invalid User");
            }

        }

    }
}