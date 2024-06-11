using ReservationManagement.Application;
using ReservationManagement.Application.Services.ReservationServices;
using ReservationManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

// Add application injections
builder.Services.AddApplication(); //builder.Services.AddTransient<ReservationService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//routes
app.MapGet("/reservations/{reservationId}", (ReservationService service, int reservationId) =>
{
    return service.GetReservationByIdAsync(reservationId);
})
.WithName("GetReservationById")
.WithOpenApi();

app.MapGet("/reservations", (ReservationService service) =>
{
    return service.ListAsync();
})
.WithName("GetReservations")
.WithOpenApi();

app.MapPost("/reservations", (ReservationService service, NewReservationRequest request) =>
{
    return service.CreateReservationAsync(request);
})
.WithName("CreateReservations")
.WithOpenApi();

app.Run();

