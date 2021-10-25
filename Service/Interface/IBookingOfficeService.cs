using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;

namespace Service1.Interface
{
    public interface IBookingOfficeService
    {
        public Task CreateBookingOffice(BookingOffice bookingOffice);
        public Task DeleteBookingOffice(int id);
        public Task<BookingOffice> UpdateBookingOffice(BookingOffice bookingOffice);
        public Task<List<BookingOffice>> GetAllBookingOffice();
        public Task<BookingOffice> GetBookingOfficeById(int id);
    }
}
