using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurfManager.Models;

namespace TurfManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")] 
    [ApiController]
    public class TemperaturesController : ControllerBase
    {
        private readonly GDDContext _context;

        public TemperaturesController(GDDContext context)
        {
            _context = context;
        }

        // GET: api/Temperatures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Temperatures>>> GetTemperatures(bool? ShowAll)
        {
            // Only show the last 10 days worth in the main GET
            var Temperatures = _context.Temperatures.AsQueryable();
            DateTime TenDaysAgo = DateTime.Now.AddDays(-30);


            if (ShowAll == null)
            {
                Temperatures = _context.Temperatures.Where(i => i.ReadingDateTimeWst > TenDaysAgo);
            }
            if (ShowAll == true)
            {
                Temperatures = _context.Temperatures;
            }



            //return await _context.Temperatures.ToListAsync();
            return await Temperatures.ToListAsync();

        }

        // GET: api/Temperatures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Temperatures>> GetTemperatures(int id)
        {
            var temperatures = await _context.Temperatures.FindAsync(id);

            if (temperatures == null)
            {
                return NotFound();
            }

            return temperatures;
        }

        // PUT: api/Temperatures/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemperatures(int id, Temperatures temperatures)
        {
            if (id != temperatures.ReadingKey)
            {
                return BadRequest();
            }

            _context.Entry(temperatures).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemperaturesExists(id))
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

        // POST: api/Temperatures
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Temperatures>> PostTemperatures(Temperatures temperatures)
        {
            _context.Temperatures.Add(temperatures);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTemperatures", new { id = temperatures.ReadingKey }, temperatures);
        }



        /// <summary>
        /// POST: api/Temperatures/Log/YYYYMMDD NEW: Post a temperature to the database
        /// </summary>
        /// <param name="inDateString"></param>
        /// <param name="inTemperature"></param>
        /// <returns></returns>
        /// 
        [HttpPost("Log/{inDateString}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Temperatures>> LogTemperature(string inDateString, decimal inTemperature)
        {

            var TemperatureLog = new Temperatures
            {
                ReadingDateString = inDateString,
                ReadingValue = inTemperature,
                ReadingDateTimeWst = DateTime.Now
            };
            _context.Temperatures.Add(TemperatureLog);
            await _context.SaveChangesAsync();
            return Ok();

        }



        // DELETE: api/Temperatures/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Temperatures>> DeleteTemperatures(int id)
        {
            var temperatures = await _context.Temperatures.FindAsync(id);
            if (temperatures == null)
            {
                return NotFound();
            }

            _context.Temperatures.Remove(temperatures);
            await _context.SaveChangesAsync();

            return temperatures;
        }

        private bool TemperaturesExists(int id)
        {
            return _context.Temperatures.Any(e => e.ReadingKey == id);
        }
    }
}
