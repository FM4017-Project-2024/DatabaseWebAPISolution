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
    public class BuildingEnergyMeterItemsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public BuildingEnergyMeterItemsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/BuildingEnergyMeterItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingEnergyMeterItem>>> GetBUILDING_ENERGY_METER()
        {
            return await _context.BUILDING_ENERGY_METER.ToListAsync();
        }

        // GET: api/BuildingEnergyMeterItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingEnergyMeterItem>> GetBuildingEnergyMeterItem(long id)
        {
            var buildingEnergyMeterItem = await _context.BUILDING_ENERGY_METER.FindAsync(id);

            if (buildingEnergyMeterItem == null)
            {
                return NotFound();
            }

            return buildingEnergyMeterItem;
        }

        // PUT: api/BuildingEnergyMeterItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuildingEnergyMeterItem(long id, BuildingEnergyMeterItem buildingEnergyMeterItem)
        {
            if (id != buildingEnergyMeterItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(buildingEnergyMeterItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingEnergyMeterItemExists(id))
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

        // POST: api/BuildingEnergyMeterItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BuildingEnergyMeterItem>> PostBuildingEnergyMeterItem(BuildingEnergyMeterItem buildingEnergyMeterItem)
        {
            _context.BUILDING_ENERGY_METER.Add(buildingEnergyMeterItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuildingEnergyMeterItem", new { id = buildingEnergyMeterItem.Id }, buildingEnergyMeterItem);
        }

        // DELETE: api/BuildingEnergyMeterItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuildingEnergyMeterItem(long id)
        {
            var buildingEnergyMeterItem = await _context.BUILDING_ENERGY_METER.FindAsync(id);
            if (buildingEnergyMeterItem == null)
            {
                return NotFound();
            }

            _context.BUILDING_ENERGY_METER.Remove(buildingEnergyMeterItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuildingEnergyMeterItemExists(long id)
        {
            return _context.BUILDING_ENERGY_METER.Any(e => e.Id == id);
        }

        // GET: api/BuildingEnergyMeterItems/latest
        [HttpGet("latest")]
        public async Task<ActionResult<BuildingEnergyMeterItem>> GetLatestBuildingEnergyMeterItem()
        {
            var latestEnergyMeter = await _context.BUILDING_ENERGY_METER.OrderByDescending(t => t.EnergyMeterDateTime).FirstAsync();

            if (latestEnergyMeter == null)
            {
                return NotFound();
            }

            return latestEnergyMeter;
        }
    }
}
