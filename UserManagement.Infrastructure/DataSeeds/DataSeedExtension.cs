using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Domain.Entities.Customers;
using UserManagement.Domain.Repositories;

namespace UserManagement.Infrastructure.DataSeeds;

public static class DataSeedExtension
{
    public static void SeedData(this IApplicationBuilder app, IServiceCollection services)
    {
        var respository = services.BuildServiceProvider().GetService<ICustomerRepository>();

        if(respository != null)
            SeedDataToRepository(respository);
    }

    private static void SeedDataToRepository(ICustomerRepository repository)
    {
        var faker = new Faker();

        for (int i = 0; i < 10; i++)
        {
            var customer = new Customer
            {
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                Email = faker.Internet.Email()
            };

            repository.AddAndSaveAsync(customer).Wait();
        }
    }
}
