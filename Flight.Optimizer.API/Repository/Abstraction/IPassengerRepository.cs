using Flight.Optimizer.API.Model;

namespace Flight.Optimizer.API.Repository.Abstraction;

public interface IPassengerRepository
{
    Task<List<Passenger>> GetAllPassengersAsync();
}
