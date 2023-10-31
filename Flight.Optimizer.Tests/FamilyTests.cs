using Flight.Optimizer.API.Entities;
using Flight.Optimizer.Tests.Builders;

namespace Flight.Optimizer.Tests;

[TestClass]
public class FamilyTests
{
    [TestMethod]
    public void AddMember_ShouldAddAPassengerToFamily()
    {
        // Arrange
        var family = FamilyBuilder.CreateDefault().Build();
        var passenger = new Passenger { Age = 40 };
        // Act
        family.AddMember(passenger);

        // Assert
        Assert.AreEqual(1, family.Members.Count);
        Assert.AreSame(passenger, family.Members.Single());
    }

    [TestMethod]
    public void AddMember_ShouldFailToAddAPassengerToFullFamily()
    {
        // Arrange
        var family = FamilyBuilder.CreateDefault().WithFullMembers().Build();

        // Act
        Exception ex = Assert.ThrowsException<Exception>(() => family.AddMember(new Passenger { Age = 40 }));

        Assert.IsNotNull(ex);
        Assert.IsNotNull(ex.Message);
        Assert.AreEqual(ex.Message, "Family can not have more than 5 members");
    }

    [TestMethod]
    public void AddMember_ShouldFailToAddMoreThanTwoAdults()
    {
        // Arrange
        var family = FamilyBuilder.CreateDefault().WithTwoAdults().Build();

        // Act
        Exception ex = Assert.ThrowsException<Exception>(() => family.AddMember(new Passenger { Age = 40 }));

        Assert.IsNotNull(ex);
        Assert.IsNotNull(ex.Message);
        Assert.AreEqual(ex.Message, "Family can not have more than 2 adults");
    }
}
