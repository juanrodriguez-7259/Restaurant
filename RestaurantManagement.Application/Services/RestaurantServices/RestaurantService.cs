using RestaurantManagement.Domain.Entities.Restaurants;
using RestaurantManagement.Domain.Repositories;

namespace RestaurantManagement.Application.Services.RestaurantServices;

public class RestaurantService
{
    private readonly IRestaurantRepository _RestaurantRepository;

    public RestaurantService(IRestaurantRepository RestaurantRepository)
    {
        _RestaurantRepository = RestaurantRepository;
    }
    
    public async Task<int> CreateRestaurantAsync(NewRestaurantRequest request)
    {
        // Create a new Restaurant entity
        var restaurant = new Restaurant
        {
            Name = request.Name,
            MaxNumberOfSeats = request.MaxNumberOfSeats
        };

        // Add the Restaurant to the repository
        return await _RestaurantRepository.AddAndSaveAsync(restaurant);
    }
    
    public async Task DeleteRestaurantAsync(int id)
    {
        // Delete the Restaurant from the repository
        await _RestaurantRepository.DeleteByIdAsync(id);
    }
    
    public async Task<Restaurant?> GetRestaurantByIdAsync(int id)
    {
        // Get the Restaurant from the repository
        return await _RestaurantRepository.GetByIdAsync(id);
    }

    public async Task<List<Restaurant>> ListRestaurants()
    {
        // Get the Restaurant from the repository
        return await _RestaurantRepository.ListAsync();
    }
}

