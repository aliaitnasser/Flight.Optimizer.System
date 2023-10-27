using Flight.Optimizer.API.Model;
using Flight.Optimizer.API.Repository.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Flight.Optimizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController: ControllerBase
    {
        private readonly IPassengerRepository _passengerRepository;

        public PassengerController(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Passenger>>> GetAllPassengersAsync()
        {
            return Ok(await _passengerRepository.GetAllPassengersAsync());
        }
    }
}
