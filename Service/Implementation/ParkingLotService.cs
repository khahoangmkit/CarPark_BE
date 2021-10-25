using Service1.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;
using Model.Repository;

namespace Service1.Implementation
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly IGenericRepository<ParkingLot> _parkingLotRepository;

        public ParkingLotService(IGenericRepository<ParkingLot> parkingLotRepository)
        {
            _parkingLotRepository = parkingLotRepository;
        }
        
        public async Task CreateParkingLot(ParkingLot parkingLot)
        {
            await _parkingLotRepository.Create(parkingLot).ConfigureAwait(false);
        }

        public async Task DeleteParkingLot(int id)
        {
            var parkingLot = await _parkingLotRepository.GetById(id).ConfigureAwait(false);
            if (parkingLot != null)
            {
                await _parkingLotRepository.Delete(parkingLot).ConfigureAwait(false);
            }
        }

        public async Task<ParkingLot> UpdateParkingLot(ParkingLot parkingLot)
        {
            var _parkingLot = await _parkingLotRepository.GetById(parkingLot.Id).ConfigureAwait(false);
            if (_parkingLot != null)
            {
                _parkingLot.ParkArea = parkingLot.ParkArea;
                _parkingLot.ParkName = parkingLot.ParkName;
                _parkingLot.ParkPlace = parkingLot.ParkPlace;
                _parkingLot.ParkPrice = parkingLot.ParkArea;
                _parkingLot.ParkStratus = parkingLot.ParkStratus;
                await _parkingLotRepository.Update(_parkingLot).ConfigureAwait(false);
            }

            return _parkingLot;
        }

        public async Task<List<ParkingLot>> GetAllParkingLot()
        {
            return await _parkingLotRepository.GetAll().ConfigureAwait(false);
        }

        public async Task<ParkingLot> GetBParkingLotById(int id)
        {
            return await _parkingLotRepository.GetById(id).ConfigureAwait(false);
        }
    }
}
