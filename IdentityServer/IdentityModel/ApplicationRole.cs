using Microsoft.AspNetCore.Identity;

namespace IdentityServer.IdentityModel
{
    public class ApplicationRole:IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
