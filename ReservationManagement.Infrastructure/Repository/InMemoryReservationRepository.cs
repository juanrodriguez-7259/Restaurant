using ReservationManagement.Domain.Entities.Reservations;
using ReservationManagement.Domain.Repositories;

namespace ReservationManagement.Infrastructure.Repository;

public class InMemoryReservationRepository: IReservationRepository
{
    private static readonly List<Reservation> _items = [];

    public InMemoryReservationRepository() { }

    public Task<Reservation?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var reservation = _items != null ? _items.FirstOrDefault(i => i.Id == id) : null;
        return Task.FromResult(reservation);
    }

    public Task<List<Reservation>> ListAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_items);
    }

    public Task<int> AddAndSaveAsync(Reservation item, CancellationToken cancellationToken)
    {
        int id = _items.Count > 0 ? _items.Max(i => i.Id) + 1 : 1;
        item.Id = id;
        _items.Add(item);

        return Task.FromResult(item.Id);
    }

    public Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
    {
        _items.RemoveAll(i => i.Id == id);

        return Task.CompletedTask;
    }
}
