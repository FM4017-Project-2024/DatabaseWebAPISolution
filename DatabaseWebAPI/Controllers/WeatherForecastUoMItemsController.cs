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
    public class WeatherForecastUoMItemsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public WeatherForecastUoMItemsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/WeatherForecastUoMItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecastUoMItem>>> GetWEATHER_FORECAST_UOM()
        {
            return await _context.WEATHER_FORECAST_UOM.ToListAsync();
        }

        // GET: api/WeatherForecastUoMItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecastUoMItem>> GetWeatherForecastUoMItem(int id)
        {
            var weatherForecastUoMItem = await _context.WEATHER_FORECAST_UOM.FindAsync(id);

            if (weatherForecastUoMItem == null)
            {
                return NotFound();
            }

            return weatherForecastUoMItem;
        }

        // PUT: api/WeatherForecastUoMItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherForecastUoMItem(int id, WeatherForecastUoMItem weatherForecastUoMItem)
        {
            if (id != weatherForecastUoMItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(weatherForecastUoMItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherForecastUoMItemExists(id))
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

        // POST: api/WeatherForecastUoMItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeatherForecastUoMItem>> PostWeatherForecastUoMItem(WeatherForecastUoMItem weatherForecastUoMItem)
        {
            _context.WEATHER_FORECAST_UOM.Add(weatherForecastUoMItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeatherForecastUoMItem", new { id = weatherForecastUoMItem.Id }, weatherForecastUoMItem);
        }

        // DELETE: api/WeatherForecastUoMItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherForecastUoMItem(int id)
        {
            var weatherForecastUoMItem = await _context.WEATHER_FORECAST_UOM.FindAsync(id);
            if (weatherForecastUoMItem == null)
            {
                return NotFound();
            }

            _context.WEATHER_FORECAST_UOM.Remove(weatherForecastUoMItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherForecastUoMItemExists(int id)
        {
            return _context.WEATHER_FORECAST_UOM.Any(e => e.Id == id);
        }

        // GET: api/WeatherForecastUoM/uom/{attribute}
        [HttpGet("uom/{attribute}")]
        public async Task<ActionResult<string>> GetUoMByAttribute(string attribute)
        {
            // Find the UoM entry based on the attribute name (case-insensitive search)
            var uomItem = await _context.WEATHER_FORECAST_UOM
                .FirstOrDefaultAsync(u => u.Attribute.Equals(attribute, StringComparison.OrdinalIgnoreCase));

            // If the attribute doesn't exist, return a 404 NotFound response
            if (uomItem == null)
            {
                return NotFound($"No UoM found for attribute '{attribute}'.");
            }

            // Return the UoM as a plain string
            return Ok(uomItem.UoM);
        }
    }
}
