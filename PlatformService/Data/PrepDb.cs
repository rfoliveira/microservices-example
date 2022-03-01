using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                System.Console.WriteLine("--> Seeding data");
                
                context.Platforms.AddRange(
                    new Platform { Name = "Dot net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform { Name = "Sql Server express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform { Name = "Kubernetes", Publisher = "Cloud Native Conputing Foundation", Cost = "Free" }
                );

                context.SaveChanges();
            }
            else 
            {
                System.Console.WriteLine("--> We already have data");
            }
        }
    }
}