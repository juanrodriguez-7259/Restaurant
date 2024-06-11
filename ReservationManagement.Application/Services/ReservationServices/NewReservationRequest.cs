
namespace ReservationManagement.Application.Services.ReservationServices;

public class NewReservationRequest
{
    public string DateAndTime { get; set; }
    public int CustomerId { get; set; }
    public int RestaurantId { get; set; }
    public int NumberOfDinners { get; set; }
}
