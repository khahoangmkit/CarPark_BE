using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Entity;
using Service1.Interface;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]/[action]")]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingLotService _parkingLotService;

        public ParkingController(IParkingLotService parkingLotService)
        {
            _parkingLotService = parkingLotService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allParkingLot = await _parkingLotService.GetAllParkingLot().ConfigureAwait(false);
            return Ok(allParkingLot);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParkingLotById(int id)
        {
            var parkingLot = await _parkingLotService.GetBParkingLotById(id).ConfigureAwait(false);
            return Ok(parkingLot);
        }
        
        [HttpPost]
        public async Task AddParkingLot(ParkingLot parkingLot)
        {
            await _parkingLotService.CreateParkingLot(parkingLot).ConfigureAwait(false);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParkingLot(int id)
        {
            await _parkingLotService.DeleteParkingLot(id).ConfigureAwait(false);
            return Ok();
        }

        [HttpPut]
        public async Task<ParkingLot> UpdateParkingLot(ParkingLot parkingLot)
        {
            return await _parkingLotService.UpdateParkingLot(parkingLot).ConfigureAwait(false);
        }
    }
}