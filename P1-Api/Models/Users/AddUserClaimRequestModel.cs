using Microsoft.AspNetCore.Mvc;

namespace P1_Api.Models.Users
{
    public class AddUserClaimRequestModel
    {
        [FromRoute]
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}