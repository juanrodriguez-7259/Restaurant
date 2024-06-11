using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Services.RestaurantServices;

public class NewRestaurantRequest
{
    public string? Name { get; set; }
    public int MaxNumberOfSeats { get; set; }
}
