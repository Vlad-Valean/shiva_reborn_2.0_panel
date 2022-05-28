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
        public async Task<ActionResult<Building>> GetOneBuilding(string id)
        {
            var buildings = await _buildingService.GetAllAsync();
            var building = buildings.FirstOrDefault(u => u.Id == id);

            if (building is null)
            {
                return NotFound();
            }

            return Ok(building);
        }

        [HttpPost(Name = "AddBuilding")]
        public async Task<ActionResult<Building>> AddBuilding([FromBody] Building building)
        {
            var buildings = await _buildingService.GetAllAsync();
            if (building is null)
            {
                return BadRequest();
            }

            var buildingsList = buildings.ToList();
            buildingsList.Remove(building);
            buildings = buildingsList.AsEnumerable();
            return Ok(building);
        }

        [HttpDelete(Name = "DeleteBuilding")]
        public async Task<ActionResult<Building>> DeleteBuilding(string id)
        {
            var building = await _buildingService.RemoveAsync(id);
            return Ok(building);
        }

        [HttpPatch(Name = "UpdateAnBuildingInfo")]
        public async Task<ActionResult<Building>> UpdateBuilding(string id, [FromBody]Floor[] floors, string country, string city)
        {
            var buildings = await _buildingService.GetAllAsync();
            var building = buildings.FirstOrDefault(u => u.Id == id);

            await _buildingService.RemoveAsync(id);

            building.floors = floors;
            building.country = country;
            building.city = city;

            await _buildingService.AddAsync(building);
            
            return Ok(building);
        }
    }
}