using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;

namespace Service1.Interface
{
    public interface ITripService
    {
        public Task CreateTrip(Trip trip);
        public Task DeleteTrip(int id);
        public Task<Trip> UpdateTrip(Trip trip);
        public Task<List<Trip>> GetAllTrip();
        public Task<Trip> GetTripById(int id);
    }
}
