using Microsoft.AspNetCore.Identity;
using P1_Core.Entities;
using P1_Core.Interfaces;

namespace P1_Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public DiscordUser DiscordUser { get; set; }
    }
}