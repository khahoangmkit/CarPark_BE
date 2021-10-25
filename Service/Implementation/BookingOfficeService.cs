using Service1.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;
using Model.Repository;

namespace Service1.Implementation
{
    public class BookingOfficeService : IBookingOfficeService
    {
        private readonly IGenericRepository<BookingOffice> _bookingOfficeRepository;

        public BookingOfficeService(IGenericRepository<BookingOffice> bookingOfficeRepository)
        {
            _bookingOfficeRepository = bookingOfficeRepository;
        }
        
        public async Task CreateBookingOffice(BookingOffice bookingOffice)
        {
            await _bookingOfficeRepository.Create(bookingOffice).ConfigureAwait(false);
        }

        public async Task DeleteBookingOffice(int id)
        {
            try
            {
                var bookingOffice = await _bookingOfficeRepository.GetById(id).ConfigureAwait(false);
                await _bookingOfficeRepository.Delete(bookingOffice).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                throw;
            }
        }

        public async Task<BookingOffice> UpdateBookingOffice(BookingOffice bookingOffice)
        {
            var _bookingOffice = await _bookingOfficeRepository.GetById(bookingOffice.Id);
            if (_bookingOffice != null)
            {
                _bookingOffice.EndContractDeadline = bookingOffice.EndContractDeadline;
                _bookingOffice.StartContractDeadline = bookingOffice.StartContractDeadline;
                _bookingOffice.OfficeName = bookingOffice.OfficeName;
                _bookingOffice.OfficePhone = bookingOffice.OfficePhone;
                _bookingOffice.OfficePlace = bookingOffice.OfficePlace;
                _bookingOffice.OfficePrime = bookingOffice.OfficePrime;
                
                await _bookingOfficeRepository.Update(_bookingOffice).ConfigureAwait(false);
            }

            return _bookingOffice;
        }

        public async Task<List<BookingOffice>> GetAllBookingOffice()
        {
            return await _bookingOfficeRepository.GetAll().ConfigureAwait(false);
        }

        public async Task<BookingOffice> GetBookingOfficeById(int id)
        {
            return await _bookingOfficeRepository.GetById(id);
        }
    }
}
