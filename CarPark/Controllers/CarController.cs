using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Entity;
using Service1.Interface;

namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IParkingLotService _parkingLotService;

        public CarController(ICarService carService, IParkingLotService parkingLotService)
        {
            _carService = carService;
            _parkingLotService = parkingLotService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allCar = await _carService.GetAllCar().ConfigureAwait(false);
            return Ok(allCar);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _carService.GetCarById(id).ConfigureAwait(false);
            return Ok(car);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddCar(Car car)
        {
            var parkingLot = await _parkingLotService.GetBParkingLotById(car.ParkingLot.Id).ConfigureAwait(false);
            car.ParkingLot = parkingLot;
            await _carService.CreateCar(car).ConfigureAwait(false);
            return Ok(car);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carService.DeleteCar(id).ConfigureAwait(false);
            return Ok();
        }

        [HttpPut]
        public async Task<Car> UpdateCar(Car car)
        {
            return await _carService.UpdateCar(car).ConfigureAwait(false);
        }
        

    }
}