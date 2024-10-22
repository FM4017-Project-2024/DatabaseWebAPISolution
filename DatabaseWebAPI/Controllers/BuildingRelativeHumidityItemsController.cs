using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseWebAPI.Models;

namespace DatabaseWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingRelativeHumidityItemsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public BuildingRelativeHumidityItemsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/BuildingRelativeHumidityItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingRelativeHumidityItem>>> GetBUILDING_REL_HUMIDITY()
        {
            return await _context.BUILDING_REL_HUMIDITY.ToListAsync();
        }

        // GET: api/BuildingRelativeHumidityItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingRelativeHumidityItem>> GetBuildingRelativeHumidityItem(long id)
        {
            var buildingRelativeHumidityItem = await _context.BUILDING_REL_HUMIDITY.FindAsync(id);

            if (buildingRelativeHumidityItem == null)
            {
                return NotFound();
            }

            return buildingRelativeHumidityItem;
        }

        // PUT: api/BuildingRelativeHumidityItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuildingRelativeHumidityItem(long id, BuildingRelativeHumidityItem buildingRelativeHumidityItem)
        {
            if (id != buildingRelativeHumidityItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(buildingRelativeHumidityItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingRelativeHumidityItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BuildingRelativeHumidityItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BuildingRelativeHumidityItem>> PostBuildingRelativeHumidityItem(BuildingRelativeHumidityItem buildingRelativeHumidityItem)
        {
            _context.BUILDING_REL_HUMIDITY.Add(buildingRelativeHumidityItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuildingRelativeHumidityItem", new { id = buildingRelativeHumidityItem.Id }, buildingRelativeHumidityItem);
        }

        // DELETE: api/BuildingRelativeHumidityItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuildingRelativeHumidityItem(long id)
        {
            var buildingRelativeHumidityItem = await _context.BUILDING_REL_HUMIDITY.FindAsync(id);
            if (buildingRelativeHumidityItem == null)
            {
                return NotFound();
            }

            _context.BUILDING_REL_HUMIDITY.Remove(buildingRelativeHumidityItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuildingRelativeHumidityItemExists(long id)
        {
            return _context.BUILDING_REL_HUMIDITY.Any(e => e.Id == id);
        }

        // GET: api/BuildingRelativeHumidityItems/latest
        [HttpGet("latest")]
        public async Task<ActionResult<BuildingRelativeHumidityItem>> GetLatestBuildingRelativeHumidityItem()
        {
            var latestRelHumidity = await _context.BUILDING_REL_HUMIDITY.OrderByDescending(t => t.RelHumidityDateTime).FirstAsync();

            if (latestRelHumidity == null)
            {
                return NotFound();
            }

            return latestRelHumidity;
        }
    }
}
