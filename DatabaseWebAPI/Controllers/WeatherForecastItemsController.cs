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
    public class WeatherForecastItemsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public WeatherForecastItemsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/WeatherForecastItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecastItem>>> GetWEATHER_FORECAST()
        {
            return await _context.WEATHER_FORECAST.ToListAsync();
        }

        // GET: api/WeatherForecastItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecastItem>> GetWeatherForecastItem(long id)
        {
            var weatherForecastItem = await _context.WEATHER_FORECAST.FindAsync(id);

            if (weatherForecastItem == null)
            {
                return NotFound();
            }

            return weatherForecastItem;
        }

        // PUT: api/WeatherForecastItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherForecastItem(long id, WeatherForecastItem weatherForecastItem)
        {
            if (id != weatherForecastItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(weatherForecastItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherForecastItemExists(id))
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

        // POST: api/WeatherForecastItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeatherForecastItem>> PostWeatherForecastItem(WeatherForecastItem weatherForecastItem)
        {
            _context.WEATHER_FORECAST.Add(weatherForecastItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeatherForecastItem", new { id = weatherForecastItem.Id }, weatherForecastItem);
        }

        // DELETE: api/WeatherForecastItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherForecastItem(long id)
        {
            var weatherForecastItem = await _context.WEATHER_FORECAST.FindAsync(id);
            if (weatherForecastItem == null)
            {
                return NotFound();
            }

            _context.WEATHER_FORECAST.Remove(weatherForecastItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherForecastItemExists(long id)
        {
            return _context.WEATHER_FORECAST.Any(e => e.Id == id);
        }

        // GET: api/WeatherForecastItems/latest
        [HttpGet("latest")]
        public async Task<ActionResult<IEnumerable<WeatherForecastItem>>> GetLatestWeatherForecastItems()
        {
            // Find the latest DateTime value in the table
            var latestDateTime = await _context.WEATHER_FORECAST.MaxAsync(w => w.DateTime);

            // Retrieve all rows with the latest DateTime value
            var latestForecastItems = await _context.WEATHER_FORECAST
                .Where(w => w.DateTime == latestDateTime)
                .ToListAsync();

            // If no items are found, return a 404 NotFound response
            if (!latestForecastItems.Any())
            {
                return NotFound("No weather forecast items found for the latest DateTime.");
            }

            return Ok(latestForecastItems);
        }
    }
}
