//using RestaurantManagement.API.RouteHandlerExtensions;
using RestaurantManagement.Application;
using RestaurantManagement.Application.Services.RestaurantServices;
using RestaurantManagement.Infrastructure;
using RestaurantManagement.Infrastructure.DataSeeds;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add application injections
builder.Services.AddApplication();
// Add infrastructure injections
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.SeedData(builder.Services);
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// routes
app.MapGet("/restaurants/{customerId}", (RestaurantService service, int customerId) =>
{
    return service.GetRestaurantByIdAsync(customerId);
})
.WithName("GetRestaurantById")
.WithOpenApi();

app.MapGet("/restaurants", (RestaurantService service) =>
{
    return service.ListRestaurants();
})
.WithName("ListRestaurants")
.WithOpenApi();

app.MapPost("/restaurants", (RestaurantService service, NewRestaurantRequest request) =>
{
    return service.CreateRestaurantAsync(request);
})
.WithName("CreateRestaurant")
.WithOpenApi();
/*
app.MapDelete("/customer", (CustomerService service, int customerId) =>
{
    return service.DeleteCustomerAsync(customerId);
})
.WithName("DeleteCustomer")
.WithOpenApi();*/

app.Run();
