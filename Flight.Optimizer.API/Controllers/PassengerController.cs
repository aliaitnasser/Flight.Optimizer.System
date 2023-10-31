using Flight.Optimizer.API.Entities;
using Flight.Optimizer.API.Repository;
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
