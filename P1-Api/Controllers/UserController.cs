using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using P1_Api.Models.Users;
using P1_Application.Boundaries;
using P1_Application.Exceptions;
using P1_Infrastructure.Identity;

namespace P1_Api.Controllers
{

    public class UserController : BaseController {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;
        public UserController(IMediator mediatr, ILogger<UserController> logger, ApplicationContext context, UserManager<ApplicationUser> userManager) : base(logger, context) {
            _userManager = userManager;
            _mediator = mediatr;
        }

        [HttpPut("addClaimToUser/{userId}")]
        public async Task<IActionResult> AddClaimToUser([FromRoute] string userId, [FromBody] AddUserClaimRequestModel model){
            
            // try
            // {
            //     // Add claim to user
            //     await _mediator.Send(new AddUserClaimCommand { UserId = userId, ClaimType = model.ClaimType, ClaimValue = model.ClaimValue });
            // }
            // catch (UserNotFoundException e)
            // {
            //     _logger.LogError(e, $"An error occurred while adding claim to user with Id {userId}");
            //     return NotFound(e.Message);
            // }
            return Ok();
        }


        [HttpGet("getClaimsFromUser/{userId}")]
        public async Task<IActionResult> GetClaimsFromUser([FromRoute] string userId) {
            try
            {
                // Get user from id
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null){
                    return NotFound();
                }
                // Get claim(s) from user
                var claims = await _userManager.GetClaimsAsync(user);
                if (claims == null)
                {
                    return NotFound();
                }    
                return Ok(claims);        
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"Error occurred in getting claim from user with ID: {userId}");
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("deleteUserClaim/{userId}")]
        public async Task<IActionResult> DeleteClaimFromUser([FromRoute] string userId,[FromBody] AddUserClaimRequestModel claimRequest)
        {
            try
            {
                // Get user
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return NotFound();
                }
                var claim = new Claim(claimRequest.ClaimType, claimRequest.ClaimValue);
                // Delete claim
                await _userManager.RemoveClaimAsync(user, claim);
                
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while deleting the claim \"{claimRequest}\" from user with Id {userId}");
                return BadRequest();
            }
        }
    }
}