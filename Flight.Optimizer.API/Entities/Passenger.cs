namespace Flight.Optimizer.API.Entities;

public class Passenger
{
    public int Id { get; set; }
    public int Age { get; set; }
    public bool NeedsTwoSeats { get; set; }
    public string FamilyId { get; set; } = string.Empty;
    public decimal GetTicketPrice()
    {
        if(Age >= 12)
            return NeedsTwoSeats ? 500m : 250m;
        return 150m;
    }
}
