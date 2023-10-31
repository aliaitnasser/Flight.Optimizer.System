using Flight.Optimizer.API.Entities;
using Flight.Optimizer.System.Data;

namespace Flight.Optimizer.System;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Process Started...");

        List<Passenger> passengers = await ProcessData.ProcessAPIAsync();

        AirplaneOptimizer airplaneOptimizer = new ();

        airplaneOptimizer.GeneratePassengerList(passengers);

        int airplanCapacity = 200;
        decimal price = airplaneOptimizer.GetOptimalSeatingArrangement(airplanCapacity);

        Console.WriteLine(price);

        Console.WriteLine("Process Ended...");
        Console.ReadLine();
    }
}