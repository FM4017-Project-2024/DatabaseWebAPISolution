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
    public class EnergyPredictionItemsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public EnergyPredictionItemsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/EnergyPredictionItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnergyPredictionItem>>> GetENERGY_PREDICTION()
        {
            return await _context.ENERGY_PREDICTION.ToListAsync();
        }

        // GET: api/EnergyPredictionItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnergyPredictionItem>> GetEnergyPredictionItem(long id)
        {
            var energyPredictionItem = await _context.ENERGY_PREDICTION.FindAsync(id);

            if (energyPredictionItem == null)
            {
                return NotFound();
            }

            return energyPredictionItem;
        }

        // PUT: api/EnergyPredictionItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnergyPredictionItem(long id, EnergyPredictionItem energyPredictionItem)
        {
            if (id != energyPredictionItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(energyPredictionItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnergyPredictionItemExists(id))
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

        // POST: api/EnergyPredictionItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnergyPredictionItem>> PostEnergyPredictionItem(EnergyPredictionItem energyPredictionItem)
        {
            _context.ENERGY_PREDICTION.Add(energyPredictionItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnergyPredictionItem", new { id = energyPredictionItem.Id }, energyPredictionItem);
        }

        // DELETE: api/EnergyPredictionItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnergyPredictionItem(long id)
        {
            var energyPredictionItem = await _context.ENERGY_PREDICTION.FindAsync(id);
            if (energyPredictionItem == null)
            {
                return NotFound();
            }

            _context.ENERGY_PREDICTION.Remove(energyPredictionItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnergyPredictionItemExists(long id)
        {
            return _context.ENERGY_PREDICTION.Any(e => e.Id == id);
        }

        // GET: api/EnergyPredictionItems/latest
        [HttpGet("latest")]
        public async Task<ActionResult<EnergyPredictionItem>> GetLatestEnergyPredictionItem()
        {
            var latestPrediction = await _context.ENERGY_PREDICTION
                .OrderByDescending(e => e.DateTime)
                .FirstOrDefaultAsync();

            if (latestPrediction == null)
            {
                return NotFound();
            }

            return latestPrediction;
        }
    }
}
