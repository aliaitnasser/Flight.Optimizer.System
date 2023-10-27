using Flight.Optimizer.API.Model;
using Flight.Optimizer.System.Data;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flight.Optimizer.System;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Process Started...");

        List<Passenger> passengers = await ProcessData.ProcessAPIAsync();

        AirplaneOptimizer airplaneOptimizer = new ();

        airplaneOptimizer.GeneratePassengerList(passengers);

        decimal price = airplaneOptimizer.GetOptimalSeatingArrangement();

        Console.WriteLine(price);

        Console.WriteLine("Process End...");
        Console.ReadLine();
    }
}