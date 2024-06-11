using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ReservationManagement.Domain.Entities.Reservations;

namespace ReservationManagement.Infrastructure.Configuration;

public class ReservationConfiguration: IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.DateAndTime)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(r => r.NumberOfDinners)
            .IsRequired();

        builder.Property(r => r.RestaurantId)
            .IsRequired();

        builder.Property(r => r.CustomerId)
            .IsRequired();
    }
}

