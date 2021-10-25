using Service1.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;
using Model.Repository;

namespace Service1.Implementation
{
    public class TripService : ITripService
    {
        private readonly IGenericRepository<Trip> _tripRepository;

        public TripService(IGenericRepository<Trip> tripRepository)
        {
            _tripRepository = tripRepository;
        }
        public async Task CreateTrip(Trip trip)
        {
            await _tripRepository.Create(trip);
        }

        public async Task DeleteTrip(int id)
        {
            var _ticket = await _tripRepository.GetById(id).ConfigureAwait(false);
            await _tripRepository.Delete(_ticket);
        }

        public async Task<Trip> UpdateTrip(Trip trip)
        {
            var _trip = await _tripRepository.GetById(trip.Id).ConfigureAwait(false);
            if (_trip != null)
            {
                _trip.Destination = trip.Destination;
                _trip.Driver = trip.Driver;
                _trip.CarType = trip.CarType;
                _trip.DepartureDate = trip.DepartureDate;
                _trip.DepartureDate = trip.DepartureTime;
                _trip.BookedTicketNumber = trip.BookedTicketNumber;
                _trip.MaximumOnlineTicketNumber = trip.MaximumOnlineTicketNumber;

                await _tripRepository.Update(_trip).ConfigureAwait(false);
            }

            return _trip;
        }

        public async Task<List<Trip>> GetAllTrip()
        {
            return await _tripRepository.GetAll().ConfigureAwait(false);
        }

        public async Task<Trip> GetTripById(int id)
        {
            return await _tripRepository.GetById(id).ConfigureAwait(false);
        }
    }
}
