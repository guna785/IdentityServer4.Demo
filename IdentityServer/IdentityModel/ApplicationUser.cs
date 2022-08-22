using IdentityServer.Enums;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.IdentityModel
{
    public class ApplicationUser:IdentityUser<int>
    {
        [PersonalData]
        public string Name { get; set; }
        public Gender Gender { get; set; }
    }
}
