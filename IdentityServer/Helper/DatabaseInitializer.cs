using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Helper
{
    public static class DatabaseInitializer
    {
        public static void PopulateIdentityServer(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

            var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

            context.Database.Migrate();

            foreach (var client in Config.Clients)
            {
                var item = context.Clients.Where(c => c.ClientId == client.ClientId).FirstOrDefault();

                if (item == null)
                {
                    context.Clients.Add(client.ToEntity());
                }
            }

            foreach (var resource in Config.ApiResources)
            {
                var item = context.ApiResources.Where(c => c.Name == resource.Name).FirstOrDefault();

                if (item == null)
                {
                    context.ApiResources.Add(resource.ToEntity());
                }
            }

            foreach (var scope in Config.ApiScopes)
            {
                var item = context.ApiScopes.Where(c => c.Name == scope.Name).FirstOrDefault();

                if (item == null)
                {
                    context.ApiScopes.Add(scope.ToEntity());
                }
            }

            context.SaveChanges();
        }
    }
}
