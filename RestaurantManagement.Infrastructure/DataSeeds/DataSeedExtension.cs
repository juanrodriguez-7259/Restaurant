using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RestaurantManagement.Domain.Entities.Restaurants;
using RestaurantManagement.Domain.Repositories;

namespace RestaurantManagement.Infrastructure.DataSeeds;

public static class DataSeedExtension
{
    public static void SeedData(this IApplicationBuilder app, IServiceCollection services)
    {
        var respository = services.BuildServiceProvider().GetService<IRestaurantRepository>();

        if (respository != null)
            SeedDataToRepository(respository);
    }

    private static void SeedDataToRepository(IRestaurantRepository repository)
    {
        var faker = new Faker();

        for (int i = 0; i < 10; i++)
        {
            var customer = new Restaurant
            {
                Name = faker.Name.FirstName(),
                MaxNumberOfSeats = faker.Random.Number(10, 100),
            };

            repository.AddAndSaveAsync(customer).Wait();
        }
    }
}
