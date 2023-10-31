using Flight.Optimizer.API.Entities;
using Flight.Optimizer.System;
using Flight.Optimizer.Tests.Builders;

namespace Flight.Optimizer.Tests;

[TestClass]
public class AirplaneOptimizerTests
{
    private AirplaneOptimizer _optimizer;

    [TestInitialize]
    public void Setup()
    {
        _optimizer = new AirplaneOptimizer();
        AirplaneOptimizer.Families.Clear();
        AirplaneOptimizer.SinglePassengers.Clear();
    }

    [TestMethod]
    public void GetOptimalSeatingArrangement_WithNoPassengers()
    {
        var revenue = _optimizer.GetOptimalSeatingArrangement(100);

        Assert.AreEqual(0m, revenue);
    }

    [TestMethod]
    public void GetOptimalSeatingArrangement_WithSinglePassengers()
    {
        AirplaneOptimizer.SinglePassengers = new List<Passenger>
        {
            new Passenger { Age = 30, NeedsTwoSeats = false },
            new Passenger { Age = 25, NeedsTwoSeats = false }
        };

        var revenue = _optimizer.GetOptimalSeatingArrangement(2);

        Assert.AreEqual(500m, revenue);
    }

    [TestMethod]
    public void GetOptimalSeatingArrangement_WithFamilyPassengers()
    {
        var family = new Family { FamilyID = "F" };
        family.AddMember(new Passenger { Age = 40, NeedsTwoSeats = false });
        family.AddMember(new Passenger { Age = 35, NeedsTwoSeats = false });
        AirplaneOptimizer.Families.Add(family);

        var revenue = _optimizer.GetOptimalSeatingArrangement(4);

        Assert.AreEqual(500m, revenue);
    }

    [TestMethod]
    public void GetOptimalSeatingArrangement()
    {
        AirplaneOptimizer.SinglePassengers = new List<Passenger>
        {
            new Passenger { Age = 30, NeedsTwoSeats = true }
        };

        var family = new Family { FamilyID = "F" };
        family.AddMember(new Passenger { Age = 40, NeedsTwoSeats = false });
        family.AddMember(new Passenger { Age = 10, NeedsTwoSeats = false });
        AirplaneOptimizer.Families.Add(family);

        var revenue = _optimizer.GetOptimalSeatingArrangement(4);

        Assert.AreEqual(900m, revenue);
    }

    [TestMethod]
    public void GetOptimalSeatingArrangement_ShouldNotAddTheSecondFamily()
    {
        var family1 = FamilyBuilder.CreateDefault().WithFullMembers().Build();
        var family2 = FamilyBuilder.CreateDefault().WithFullMembers().Build();

        AirplaneOptimizer.Families.Add(family1);
        AirplaneOptimizer.Families.Add(family2);

        var revenue = _optimizer.GetOptimalSeatingArrangement(9);

        Assert.AreEqual(950m, revenue);
    }

}
