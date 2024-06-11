using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReservationManagement.Domain.Repositories;
using ReservationManagement.Infrastructure.Repository;

namespace ReservationManagement.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string inMemoryDatabaseName = configuration["InMemoryDatabaseName"] ?? throw new ArgumentNullException(nameof(configuration));
        services.AddDbContext<ApplicationDBContext>(options => options.UseInMemoryDatabase(inMemoryDatabaseName));
        services.AddScoped<IReservationRepository, InMemoryReservationRepository>();
        return services;
    }
}
