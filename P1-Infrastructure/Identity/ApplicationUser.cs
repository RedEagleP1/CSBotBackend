using Microsoft.AspNetCore.Identity;
using P1_Core.Entities;

namespace P1_Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ulong DiscordId { get; set; }
        public User User {get;set;}
    }
}