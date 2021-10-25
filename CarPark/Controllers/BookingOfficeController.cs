using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Entity;
using Service1.Interface;

namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class BookingOfficeController : ControllerBase
    {
        private readonly IBookingOfficeService _bookingOfficeService;
        private readonly ITripService _tripService;

        public BookingOfficeController(
            IBookingOfficeService bookingOfficeService,
            ITripService tripService
            )
        {
            _bookingOfficeService = bookingOfficeService;
            _tripService = tripService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listBookingOffice = await _bookingOfficeService.GetAllBookingOffice().ConfigureAwait(false);
            return Ok(listBookingOffice);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingOfficeById(int id)
        {
            var bookingOffice = await _bookingOfficeService.GetBookingOfficeById(id).ConfigureAwait(false);
            return Ok(bookingOffice);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddBookingOffice(BookingOffice bookingOffice)
        {
            var trip = await _tripService.GetTripById(bookingOffice.Trip.Id).ConfigureAwait(false);
            bookingOffice.Trip = trip;
            await _bookingOfficeService.CreateBookingOffice(bookingOffice).ConfigureAwait(false);
            return Ok(bookingOffice);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingOffice(int id)
        {
            Console.WriteLine("ID : {0}", id);
            await _bookingOfficeService.DeleteBookingOffice(id).ConfigureAwait(false);
            return Ok();
        }

        [HttpPut]
        public async Task<BookingOffice> UpdateBookingOffice(BookingOffice bookingOffice)
        {
            return await _bookingOfficeService.UpdateBookingOffice(bookingOffice).ConfigureAwait(false);
        }
    }
}