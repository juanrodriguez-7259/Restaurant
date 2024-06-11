

using Microsoft.EntityFrameworkCore;
using ReservationManagement.Domain.Entities.Reservations;

namespace ReservationManagement.Infrastructure;

public class ApplicationDBContext: DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.ApplyConfiguration(new ReservationConfiguration());
    }

    public DbSet<Reservation> Reservations { get; set; }
}
