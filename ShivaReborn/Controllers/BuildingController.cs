using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShivaReborn.Business.Interfaces;
using ShivaReborn.DataAccess.Models;
using ShivaReborn.DataAccess.Repositories;

namespace ShivaReborn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly IService<Building> _buildingService;

        public BuildingsController(IService<Building> buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet("GetBuildings")]
        public async Task<ActionResult<IEnumerable<Building>>> GetBuildings()
        {
            var buildings = await _buildingService.GetAllAsync();
            return Ok(buildings);
        }

        [HttpGet("GetOneBuilding")]
        public async Task<ActionResult<Building>> GetOneBuilding(int id)
        {
            return await _buildingService.GetAsync(id);
        }

        [HttpPost(Name = "AddBuilding")]
        public async Task<ActionResult<Building>> AddBuilding([FromBody] Building building)
        {
            return await _buildingService.AddAsync(building);
        }

        [HttpDelete(Name = "DeleteBuilding")]
        public async Task<ActionResult<Building>> DeleteBuilding(int id)
        {
            var building = await _buildingService.RemoveAsync(id);
            return Ok(building);
        }

        [HttpPatch(Name = "UpdateAnBuildingInfo")]
        public async Task<ActionResult<Building>> UpdateBuilding(int id, string country, string city,
            [FromBody] Floor[] floors)
        {
            var buildings = await _buildingService.GetAllAsync();
            var building = buildings.FirstOrDefault(u => u.Id == id);
            await _buildingService.RemoveAsync(id);

            if (building is null)
            {
                return NotFound();
            }

            building.country = country;
            building.city = city;

            await _buildingService.AddAsync(building);

            return Ok(building);
        }
    }
}