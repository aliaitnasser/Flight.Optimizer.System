using Flight.Optimizer.API.Entities;
using System.Runtime.CompilerServices;

namespace Flight.Optimizer.Tests.Builders;

internal class FamilyBuilder
{
    private readonly Family _family;

    public FamilyBuilder(Family family)
    {
        _family = family;
    }

    internal static FamilyBuilder CreateDefault()
    {
        return new FamilyBuilder(new());
    }

    internal FamilyBuilder WithFullMembers()
    {
        var adult1 = new Passenger { Age = 30 };
        var adult2 = new Passenger { Age = 35 };
        var child1 = new Passenger { Age = 10 };
        var child2 = new Passenger { Age = 7 };
        var child3 = new Passenger { Age = 5 };

        _family.AddMember(adult1);
        _family.AddMember(adult2);
        _family.AddMember(child1);
        _family.AddMember(child2);
        _family.AddMember(child3);

        return this;
    }

    internal FamilyBuilder WithTwoAdults()
    {
        var adult1 = new Passenger { Age = 30 };
        var adult2 = new Passenger { Age = 35 };

        _family.AddMember(adult1);
        _family.AddMember(adult2);

        return this;
    }

    internal FamilyBuilder WithThreeChildren()
    {
        var adult1 = new Passenger { Age = 30 };
        var child1 = new Passenger { Age = 10 };
        var child2 = new Passenger { Age = 7 };
        var child3 = new Passenger { Age = 5 };

        _family.AddMember(adult1);
        _family.AddMember(child1);
        _family.AddMember(child2);
        _family.AddMember(child3);

        return this;
    }
    internal Family Build()
    {
        return _family;
    }
}
