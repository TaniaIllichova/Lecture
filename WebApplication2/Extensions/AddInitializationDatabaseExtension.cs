using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace WebApplication2.Extensions
{
    public static class AddInitializationDatabaseExtension
    {
        public static void UseInitializeDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();

            var amstedReportService = serviceScope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
            amstedReportService.Database.Migrate();
        }
    }
}
