using Microsoft.AspNetCore.Identity;
using P1_Application.Boundaries;
using P1_Core.Entities;
using P1_Core.Interfaces;

namespace P1_Infrastructure.Identity
{
    //TODO change the name of this to something less confusing for the layered architecture
    public class ApplicationUser : IdentityUser
    {
        public DiscordUser DiscordUser { get; set; } = null!;
    }
}