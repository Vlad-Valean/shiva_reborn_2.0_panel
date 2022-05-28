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
    public class PlacesController : ControllerBase
    {
        private readonly IService<Place> _placeService;

        public PlacesController(IService<Place> placeService)
        {
            _placeService = placeService;
        }

        [HttpGet("GetPlaces")]
        public async Task<ActionResult<IEnumerable<Place>>> GetPlaces()
        {
            var places = await _placeService.GetAllAsync();
            return Ok(places);
        }

        [HttpGet("GetOnePlace")]
        public async Task<ActionResult<Place>> GetOnePlace(string id)
        {
            return await _placeService.GetAsync(id);
        }

        [HttpPost(Name = "AddPlace")]
        public async Task<ActionResult<Place>> AddPlace([FromBody] Place place)
        {
            return await _placeService.AddAsync(place);
        }

        [HttpDelete(Name = "DeletePlace")]
        public async Task<ActionResult<Place>> DeletePlace(string id)
        {
            var place = await _placeService.RemoveAsync(id);
            return Ok(place);
        }

        [HttpPatch(Name = "UpdateAnPlaceInfo")]
        public async Task<ActionResult<Place>> UpdatePlace(string id, string name, bool isAssigned,
            [FromBody] User user)
        {
            var places = await _placeService.GetAllAsync();
            var place = places.FirstOrDefault(u => u.Id == id);
            if (place is null)
            {
                return NotFound();
            }
            await _placeService.RemoveAsync(id);
            place.name = name;
            place.isAssigned = isAssigned;

            await _placeService.AddAsync(place);

            return Ok(place);
        }
    }
}