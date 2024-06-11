using ReservationManagement.Domain.Entities.Reservations;
using ReservationManagement.Domain.Repositories;

namespace ReservationManagement.Application.Services.ReservationServices;

public class ReservationService
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationService(IReservationRepository customerRepository)
    {
        _reservationRepository = customerRepository;
    }

    public async Task<int> CreateReservationAsync(NewReservationRequest request)
    {
        // Create a new reservation entity
        var reservation = new Reservation
        {
            DateAndTime = request.DateAndTime,
            CustomerId = request.CustomerId,
            RestaurantId = request.RestaurantId,
            NumberOfDinners = request.NumberOfDinners
        };

        // Add the customer to the repository
        return await _reservationRepository.AddAndSaveAsync(reservation);
    }

    public async Task DeleteReservationAsync(int id)
    {
        // Delete the customer from the repository
        await _reservationRepository.DeleteByIdAsync(id);
    }

    public async Task<Reservation?> GetReservationByIdAsync(int id)
    {
        // Get the customer from the repository
        return await _reservationRepository.GetByIdAsync(id);
    }

    public async Task<List<Reservation>> ListAsync()
    {
        // Get the customer from the repository
        //return await _reservationRepository.
        return await _reservationRepository.ListAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        // Get the customer from the repository
        //return await _reservationRepository.
        await _reservationRepository.DeleteByIdAsync(id);
    }
}
