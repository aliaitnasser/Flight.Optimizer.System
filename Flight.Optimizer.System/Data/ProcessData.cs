using Flight.Optimizer.API.Entities;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Flight.Optimizer.System.Data;

public static class ProcessData
{
    public static async Task<List<Passenger>> ProcessAPIAsync()
    {
        using HttpClient client = new ();

        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var url = "http://localhost:5066/api/passenger";

        HttpResponseMessage response = await client.GetAsync(url);

        if(response.IsSuccessStatusCode)
        {
            string responseData = await response.Content.ReadAsStringAsync();

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            List<Passenger> passengers = JsonSerializer.Deserialize<List<Passenger>>(responseData, option) ?? throw new NullReferenceException();

            return passengers;
        }
        else
        {
            Console.WriteLine($"Failed to retrieve data. Status code: {response.StatusCode}");
            return new List<Passenger>();
        }
    }
}
