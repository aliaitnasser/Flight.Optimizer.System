using Flight.Optimizer.API.Model;

namespace Flight.Optimizer.System;

public class AirplaneOptimizer
{
    private const int AirplaneCapacity = 200;
    public static List<Family> Families { get; set; } = new List<Family>();
    public static List<Passenger> SinglePassengers { get; set; } = new List<Passenger>();

    public void GeneratePassengerList(List<Passenger> passengers)
    {
        var familyDictionary = new Dictionary<string, Family>();

        foreach(var item in passengers)
        {
            var passenger = new Passenger
            {
                Id = item.Id,
                Age = item.Age,
                IsAdult = item.IsAdult,
                NeedsTwoSeats = item.NeedsTwoSeats,
                FamilyId = item.FamilyId
            };

            if(string.IsNullOrWhiteSpace(item.FamilyId) || string.Equals(item.FamilyId, "-"))
            {
                SinglePassengers.Add(passenger);
            }
            else
            {
                if(!familyDictionary.ContainsKey(item.FamilyId))
                {
                    var family = new Family { FamilyID = item.FamilyId };
                    familyDictionary[item.FamilyId] = family;
                    Families.Add(family);
                }
                familyDictionary[item.FamilyId].AddMember(passenger);
            }
        }
    }

    public decimal GetOptimalSeatingArrangement()
    {
        int seatsRemaining = AirplaneCapacity;
        decimal totalRevenue = 0m;

        // Prioritize individual passengers that require two seats
        var twoSeatPassengers = SinglePassengers.Where(p => p.NeedsTwoSeats);

        foreach(var passenger in twoSeatPassengers)
        {
            if(seatsRemaining < 2) break;  // Exit loop if no more seats for two-seat passengers

            totalRevenue += passenger.GetTicketPrice();
            seatsRemaining -= 2;
            Console.WriteLine($"Passenger with Two seates added.");
        }

        // Then handle families
        var sortedFamilies = Families.OrderByDescending(f => f.GetTotalPrice());

        foreach(var family in sortedFamilies)
        {
            int familySize = family.Members.Count + family.Members.Count(p => p.NeedsTwoSeats);
            if(seatsRemaining < familySize) continue;  // Skip to next family if not enough seats

            totalRevenue += family.GetTotalPrice();
            seatsRemaining -= familySize;
            Console.WriteLine($"Family {family.FamilyID} with {familySize} seates added.");

            if(seatsRemaining == 0) break;  // Exit loop if airplane is full
        }

        // Finally, handle individual passengers that require only one seat
        var singleSeatPassengers = SinglePassengers.Where(p => !p.NeedsTwoSeats);

        foreach(var passenger in singleSeatPassengers)
        {
            if(!passenger.IsAdult && passenger.Age < 12)
            {
                Console.WriteLine($"This passenger with age {passenger.Age} can not travel alone, required age 12 or more.");
                continue; //skip single passenger with age less than 12.
            }
            if(seatsRemaining == 0) break;  // Exit loop if airplane is full

            totalRevenue += passenger.GetTicketPrice();
            seatsRemaining -= 1;
            string type = passenger.IsAdult ? "Adult" : "Child";

            Console.WriteLine($"Passenger with One seat added. {type}");
        }

        return totalRevenue;
    }
}

