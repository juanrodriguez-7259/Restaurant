using ReservationManagement.Domain.Entities.Reservations;

namespace ReservationManagement.Domain.Repositories;

public interface IReservationRepository
{
    Task<Reservation?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<List<Reservation>> ListAsync(CancellationToken cancellationToken = default);

    Task<int> AddAndSaveAsync(Reservation reservation, CancellationToken cancellationToken = default);

    Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
}

