using Flight.Optimizer.API.Entities;

namespace Flight.Optimizer.API.Repository;

public interface IPassengerRepository
{
    Task<List<Passenger>> GetAllPassengersAsync();
}
