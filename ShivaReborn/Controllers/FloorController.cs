using Microsoft.AspNetCore.Mvc;
using ShivaReborn.Business.Interfaces;
using ShivaReborn.DataAccess.Models;


namespace ShivaReborn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorsController : ControllerBase
    {
        private readonly IService<Floor> _floorService;

        public FloorsController(IService<Floor> floorService)
        {
            _floorService = floorService;
        }

        [HttpGet("GetFloors")]
        public async Task<ActionResult<IEnumerable<Floor>>> GetFloors()
        {
            var floors = await _floorService.GetAllAsync();
            return Ok(floors);
        }

        [HttpGet("GetOneFloor")]
        public async Task<ActionResult<Floor>> GetOneFloor(string id)
        {
            return await _floorService.GetAsync(id);
        }

        [HttpPost(Name = "AddFloor")]
        public async Task<ActionResult<Floor>> AddFloor([FromBody] Floor floor)
        {
            return await _floorService.AddAsync(floor);
        }

        [HttpDelete(Name = "DeleteFloor")]
        public async Task<ActionResult<Floor>> DeleteFloor(string id)
        {
            var floor = await _floorService.RemoveAsync(id);
            return Ok(floor);
        }

        [HttpPatch(Name = "UpdateAnFloorInfo")]
        public async Task<ActionResult<Floor>> UpdateFloor(string id, string name, [FromBody]Place[] places)
        {
            var floors = await _floorService.GetAllAsync();
            var floor = floors.FirstOrDefault(u => u.Id == id);
            await _floorService.RemoveAsync(id);
            if (floor is null)
            {
                return NotFound();
            }
            
            floor.name = name;
            floor.places = places;
            
            await _floorService.AddAsync(floor);

            return Ok(floor);
        }
    }
}