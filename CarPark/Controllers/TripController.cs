using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.DBContext;
using Model.Entity;
using Service1.Interface;

namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;

        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allTrip = await _tripService.GetAllTrip().ConfigureAwait(false);
            return Ok(allTrip);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTripById(int id)
        {
            var trip = await _tripService.GetTripById(id).ConfigureAwait(false);
            return Ok(trip);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddTrip(Trip trip)
        {
            await _tripService.CreateTrip(trip).ConfigureAwait(false);
            return Ok(trip);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip(int id)
        {
            await _tripService.DeleteTrip(id).ConfigureAwait(false);
            return Ok();
        }

        [HttpPut]
        public async Task<Trip> UpdateTrip(Trip trip)
        {
            return await _tripService.UpdateTrip(trip).ConfigureAwait(false);
        }
    }
}