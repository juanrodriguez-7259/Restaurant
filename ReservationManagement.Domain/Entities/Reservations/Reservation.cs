using RestaurantReservation.Core.Domain.Abstractions;

namespace ReservationManagement.Domain.Entities.Reservations;

public class Reservation: Entity
{
    public int Id { get; set; }
    public string DateAndTime { get; set; }
    public int CustomerId { get; set; }
    public int RestaurantId { get; set; }
    public int NumberOfDinners { get; set; }
}
