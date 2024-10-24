using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using P1_Application.Boundaries;
using P1_Application.Exceptions;
using P1_Infrastructure.Identity;


namespace P1_Infrastructure.Services
{
    public class UserClaimsService : IUserClaimsService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;
        public UserClaimsService(ILogger logger, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task AddClaimToUser(string userId, string claim, string value)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                //TODO We should alter this 
                throw new UserNotFoundException(_logger, "User not found");
            }
            var newClaim = new Claim(claim, value);
            var result = await _userManager.AddClaimAsync(user, newClaim);

            if (!result.Succeeded)
            {
                throw new P1Exception(_logger, "Failed to add claim to user");
            }
        }

        public async Task<IEnumerable<Claim>> GetClaimsFromUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new P1Exception(_logger, "User not found");
            }
            var claims = await _userManager.GetClaimsAsync(user);
            if (claims == null)
            {
                throw new P1Exception(_logger, "Failed to get claims");
            }
            return claims;
        }

        public async Task DeleteUserClaim(string userId, string claimType, string claimValue)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new P1Exception(_logger, "User not found");
            }
            var claim = new Claim(claimType, claimValue);
            var result = await _userManager.RemoveClaimAsync(user, claim);

            if (!result.Succeeded)
            {
                throw new P1Exception(_logger, "Failed to delete claim from user");
            }
        }

    }


    public class UserNotFoundException : P1Exception
    {
        public UserNotFoundException(ILogger logger, string message) :base(logger, message)
        {
        }

    }
}