﻿namespace Flight.Optimizer.API.Entities;

public class Family
{
    private int _adultsCount = 0;
    private int _childrenCount = 0;
    public string FamilyID { get; set; } = string.Empty;
    public List<Passenger> Members { get; set; } = new();

    public void AddMember(Passenger passenger)
    {
        if(Members.Count > 4) throw new Exception("Family can not have more than 5 members");

        if(passenger.Age > 18)
        {
            if(_adultsCount > 1) throw new Exception("Family can not have more than 2 adults");
            _adultsCount++;
        }
        else
        {
            if(_childrenCount > 2) throw new Exception("Family can not have more than 3 children");
            _childrenCount++;
        }

        Members.Add(passenger);
    }

    public decimal GetTotalPrice()
    {
        return Members.Sum(member => member.GetTicketPrice());
    }
}
