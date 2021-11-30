using Dotnet6.Context;
using Microsoft.EntityFrameworkCore;

namespace Dotnet6.Extensions;

public static class DbContextConfigExtensions
{
    public static void ConfigureContext(this IServiceCollection services)
        => services.AddDbContext<ProductDbContext>((provider, builder) =>
             {
                 var configuration = provider.GetRequiredService<IConfiguration>();
                 builder.UseSqlite(configuration["ConnectionStrings:SqLite"]);
             });

}

