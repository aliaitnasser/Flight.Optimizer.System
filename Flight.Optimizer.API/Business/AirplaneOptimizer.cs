using Flight.Optimizer.API.Entities;

namespace Flight.Optimizer.System;

public class AirplaneOptimizer
{
    public static List<Family> Families { get; set; } = new List<Family>();
    public static List<Passenger> SinglePassengers { get; set; } = new List<Passenger>();

    /// <summary>
    /// Generating the passenger list
    /// </summary>
    /// <param name="passengers">passenger list</param>
    public void GeneratePassengerList(List<Passenger> passengers)
    {
        var familyDictionary = new Dictionary<string, Family>();

        foreach(var item in passengers)
        {
            var passenger = new Passenger
            {
                Id = item.Id,
                Age = item.Age,
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

    /// <summary>
    /// Calculating the optimal seating arrangement 
    /// </summary>
    /// <param name="airplanCapacity">the price</param>
    /// <returns></returns>
    public decimal GetOptimalSeatingArrangement(int airplanCapacity)
    {
        decimal totalRevenue = 0m;

        // Prioritize individual passengers that require two seats
        var twoSeatPassengers = SinglePassengers.Where(p => p.NeedsTwoSeats);

        foreach(var passenger in twoSeatPassengers)
        {
            if(airplanCapacity < 2) break;  // Exit loop if no more seats for two-seat passengers

            totalRevenue += passenger.GetTicketPrice();
            airplanCapacity -= 2;
            Console.WriteLine($"Passenger with Two seates added.");
        }

        // Then handle families
        var sortedFamilies = Families.OrderByDescending(f => f.GetTotalPrice());

        foreach(var family in sortedFamilies)
        {
            int familySize = family.Members.Count + family.Members.Count(p => p.NeedsTwoSeats);
            if(airplanCapacity < familySize) continue;  // Skip to next family if not enough seats

            totalRevenue += family.GetTotalPrice();
            airplanCapacity -= familySize;
            Console.WriteLine($"Family {family.FamilyID} with {familySize} seates added.");

            if(airplanCapacity == 0) break;  // Exit loop if airplane is full
        }

        // Finally, handle individual passengers that require only one seat
        var singleSeatPassengers = SinglePassengers.Where(p => !p.NeedsTwoSeats).OrderByDescending(p => p.Age);

        foreach(var passenger in singleSeatPassengers)
        {
            if(passenger.Age < 12)
            {
                Console.WriteLine($"This passenger with age {passenger.Age} can not travel alone, required age 12 or more.");
                continue; //skip single passenger with age less than 12.
            }
            if(airplanCapacity == 0) break;  // Exit loop if airplane is full

            totalRevenue += passenger.GetTicketPrice();
            airplanCapacity -= 1;
            string type = passenger.Age >= 18 ? "Adult" : "Child";

            Console.WriteLine($"Passenger with One seat added. {type},Age - {passenger.Age}");
        }

        return totalRevenue;
    }
}

