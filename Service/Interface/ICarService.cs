using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;

namespace Service1.Interface
{
    public interface ICarService
    {
        public Task CreateCar(Car car);
        public Task DeleteCar(int employeeId);
        public Task<Car> UpdateCar(Car car);
        public Task<List<Car>> GetAllCar();
        public Task<Car> GetCarById(int carId);
        Task<Car> GetCarByLicensePlate(string licensePlate);
    }
}
