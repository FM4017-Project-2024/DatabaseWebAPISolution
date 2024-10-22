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
    public class BuildingTemperatureItemsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public BuildingTemperatureItemsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/BuildingTemperatureItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingTemperatureItem>>> GetBUILDING_TEMP()
        {
            return await _context.BUILDING_TEMP.ToListAsync();
        }

        // GET: api/BuildingTemperatureItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingTemperatureItem>> GetBuildingTemperatureItem(long id)
        {
            var buildingTemperatureItem = await _context.BUILDING_TEMP.FindAsync(id);

            if (buildingTemperatureItem == null)
            {
                return NotFound();
            }

            return buildingTemperatureItem;
        }

        // PUT: api/BuildingTemperatureItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuildingTemperatureItem(long id, BuildingTemperatureItem buildingTemperatureItem)
        {
            if (id != buildingTemperatureItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(buildingTemperatureItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingTemperatureItemExists(id))
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

        // POST: api/BuildingTemperatureItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BuildingTemperatureItem>> PostBuildingTemperatureItem(BuildingTemperatureItem buildingTemperatureItem)
        {
            _context.BUILDING_TEMP.Add(buildingTemperatureItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuildingTemperatureItem", new { id = buildingTemperatureItem.Id }, buildingTemperatureItem);
        }

        // DELETE: api/BuildingTemperatureItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuildingTemperatureItem(long id)
        {
            var buildingTemperatureItem = await _context.BUILDING_TEMP.FindAsync(id);
            if (buildingTemperatureItem == null)
            {
                return NotFound();
            }

            _context.BUILDING_TEMP.Remove(buildingTemperatureItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuildingTemperatureItemExists(long id)
        {
            return _context.BUILDING_TEMP.Any(e => e.Id == id);
        }

        // GET: api/BuildingTemperatureItems/latest
        [HttpGet("latest")]
        public async Task<ActionResult<BuildingTemperatureItem>> GetLatestBuildingTemperatureItem()
        {
            var latestTemp = await _context.BUILDING_TEMP.OrderByDescending(t => t.TempDateTime).FirstAsync();

            if (latestTemp == null)
            {
                return NotFound();
            }

            return latestTemp;
        }
    }
}
