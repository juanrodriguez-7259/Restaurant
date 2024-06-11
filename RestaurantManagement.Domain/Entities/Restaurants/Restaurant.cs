using RestaurantReservation.Core.Domain.Abstractions;

namespace RestaurantManagement.Domain.Entities.Restaurants
{
    public class Restaurant: Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxNumberOfSeats { get; set; }
    }
}
