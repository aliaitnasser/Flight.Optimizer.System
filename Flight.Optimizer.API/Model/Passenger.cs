namespace Flight.Optimizer.API.Model;

public class Passenger
{
    public int Id { get; set; }
    public int Age { get; set; }
    public bool IsAdult { get; set; }
    public bool NeedsTwoSeats { get; set; }
    public string FamilyId { get; set; } = string.Empty;
    public decimal GetTicketPrice()
    {
        if(IsAdult)
            return NeedsTwoSeats ? 500m : 250m;
        return 150m;
    }
}
