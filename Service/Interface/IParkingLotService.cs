using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;

namespace Service1.Interface
{
    public interface IParkingLotService
    {
        public Task CreateParkingLot(ParkingLot parkingLot);
        public Task DeleteParkingLot(int id);
        public Task<ParkingLot> UpdateParkingLot(ParkingLot parkingLot);
        public Task<List<ParkingLot>> GetAllParkingLot();
        public Task<ParkingLot> GetBParkingLotById(int id);
    }
}
