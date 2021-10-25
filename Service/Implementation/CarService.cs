using Service1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;
using Model.Repository;

namespace Service1.Implementation
{
    public class CarService : ICarService
    {
        private readonly IGenericRepository<Car> _carRepository;

        public CarService(IGenericRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }
        
        public async Task CreateCar(Car car)
        {
           await _carRepository.Create(car).ConfigureAwait(false);
        }

        public async Task DeleteCar(int carId)
        {
            try
            {
                var car = await _carRepository.GetById(carId).ConfigureAwait(false);
                await _carRepository.Delete(car).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Car> UpdateCar(Car car)
        {
            var carTemp = await _carRepository.GetById(car.Id).ConfigureAwait(false);
            if (carTemp != null)
            {
                carTemp.Company = car.Company;
                carTemp.CarColor = car.CarColor;
                carTemp.CarType = car.CarType;
                carTemp.LicensePlate = car.LicensePlate;
                carTemp.ParkingLot = car.ParkingLot;

                await _carRepository.Update(carTemp).ConfigureAwait(false);
            }

            return carTemp;
        }

        public async Task<List<Car>> GetAllCar()
        {
            return await _carRepository.GetAll().ConfigureAwait(false);
        }

        public async Task<Car> GetCarById(int carId)
        {
            return await _carRepository.GetById(carId);
        }
        public async Task<Car> GetCarByLicensePlate(string licensePlate)
        {
            return _carRepository.FindByCondition(item => item.LicensePlate == licensePlate).FirstOrDefault();
        }
    }
}
