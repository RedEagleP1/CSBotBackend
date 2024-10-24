using System.Security.Claims;

namespace P1_Application.Boundaries
{
    public interface IUserClaimsService
    {
        Task AddClaimToUser(string userId, string claimType, string claimValue);
        Task<IEnumerable<Claim>> GetClaimsFromUser(string userId);
        Task DeleteUserClaim(string userId, string claimType, string claimValue);
    }
}