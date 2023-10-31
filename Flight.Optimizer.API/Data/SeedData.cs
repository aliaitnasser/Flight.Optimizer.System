using Flight.Optimizer.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Flight.Optimizer.API.Data;

public class SeedData
{
    public static async Task SeedAsync(DataContext context)
    {
        if(await context.Passengers.AnyAsync()) return;

        var passengersData = await File.ReadAllTextAsync("Data/passengers.json");

        var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var passengers = JsonSerializer.Deserialize<List<Passenger>>(passengersData, option)!;

        foreach(var passenger in passengers)
        {
            context.Passengers.Add(passenger);
        }
        await context.SaveChangesAsync();
    }
}
