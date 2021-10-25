using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Entity;
using Service1.Interface;

namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly ICarService _carService;
        private readonly ITripService _tripService;

        public TicketController(
            ITicketService ticketService,
            ICarService carService,
            ITripService tripService)
        {
            _ticketService = ticketService;
            _carService = carService;
            _tripService = tripService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allTicket = await _ticketService.GetAllTicket().ConfigureAwait(false);
            return Ok(allTicket);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(int id)
        {
            var ticket = await _ticketService.GetTicketById(id).ConfigureAwait(false);
            return Ok(ticket);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddTicket(Ticket ticket)
        {
            var trip = await _tripService.GetTripById(ticket.Trip.Id).ConfigureAwait(false);
            var car = await _carService.GetCarByLicensePlate(ticket.Car.LicensePlate).ConfigureAwait(false);
            ticket.Trip = trip;
            ticket.Car = car;
            await _ticketService.CreateTicket(ticket).ConfigureAwait(false);
            return Ok(ticket);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            await _ticketService.DeleteTicket(id).ConfigureAwait(false);
            return Ok();
        }

        [HttpPut]
        public async Task<Ticket> UpdateTicket(Ticket ticket)
        {
            return await _ticketService.UpdateTicket(ticket).ConfigureAwait(false);
        }

    }
}