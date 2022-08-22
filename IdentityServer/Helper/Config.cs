using IdentityServer4.Models;

namespace IdentityServer.Helper
{
    public static class Config
    {
        public static List<Client> Clients = new List<Client>
    {
            new Client
            {
                ClientId = "identity-server-demo-web",
                AllowedGrantTypes = new List<string> { GrantType.AuthorizationCode },
                RequireClientSecret = false,
                RequireConsent = false,
                RedirectUris = new List<string> { "http://localhost:3006/signin-callback.html" },
                PostLogoutRedirectUris = new List<string> { "http://localhost:3006/" },
                AllowedScopes = { "identity-server-demo-api", "write", "read", "openid", "profile", "email" },
                AllowedCorsOrigins = new List<string>
                {
                    "http://localhost:3006",
                },
                AccessTokenLifetime = 86400
            }
    };

        public static List<ApiResource> ApiResources = new List<ApiResource>
    {
        new ApiResource
        {
            Name = "identity-server-demo-api",
            DisplayName = "Identity Server Demo API",
            Scopes = new List<string>
            {
                "write",
                "read"
            }
        }
    };

        public static IEnumerable<ApiScope> ApiScopes = new List<ApiScope>
    {
        new ApiScope("openid"),
        new ApiScope("profile"),
        new ApiScope("email"),
        new ApiScope("read"),
        new ApiScope("write"),
        new ApiScope("identity-server-demo-api")
    };
    }
}
