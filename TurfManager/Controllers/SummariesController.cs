using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TurfManager.Models;

namespace TurfManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SummariesController : ControllerBase
    {
        private readonly GDDContext _context;

        public SummariesController(GDDContext context)
        {
            _context = context;
        }

        // GET: api/Summaries
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Summary>>> GetSummary(bool Last45)
        {
            //var summaries = _context.Summary.AsQueryable();
            //return await summaries.ToListAsync();

            // sort by datewst decending

            if (Last45)
            {

                var summaries = from s in _context.Summary
                                where s.SummaryDateWst > DateTime.Now.AddDays(-45)
                                select s;
                summaries = summaries.OrderBy(s => s.SummaryDateWst);
                return await summaries.ToListAsync();

            }
            else
            {
                var summaries = from s in _context.Summary
                                select s;
                summaries = summaries.OrderBy(s => s.SummaryDateWst);
                return await summaries.ToListAsync();
            }


            


            


            



        }

        // GET: api/Summaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Summary>> GetSummary(int id)
        {
            var summary = await _context.Summary.FindAsync(id);

            if (summary == null)
            {
                return NotFound();
            }

            return summary;
        }

        // PUT: api/Summaries/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{DateString}")]
        //public async Task<IActionResult> PutSummary(int id, Summary summary)
        public async Task<IActionResult> PutSummary(string DateString)
        {



            // Generate the summary record here by DateString
            Debug.WriteLine(DateString);

            int RowsAffected = _context.Database.ExecuteSqlCommand("EXEC spGenerateSummaryForDateString @DATESTRING", new SqlParameter("@DATESTRING", DateString));


            if (RowsAffected != 1)
            {
                return BadRequest();

            }

            return new EmptyResult();

            
            

        }

        // POST: api/Summaries
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> PostSummary(int Action)
        {
            if (Action > 0)
            {
                int RowsAffected = _context.Database.ExecuteSqlCommand("EXEC spGenerateSummaryAction @ACTION", new SqlParameter("@ACTION", Action));


                if (RowsAffected != 1)
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
            return new EmptyResult();


        }

        // DELETE: api/Summaries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Summary>> DeleteSummary(int id)
        {
            var summary = await _context.Summary.FindAsync(id);
            if (summary == null)
            {
                return NotFound();
            }

            _context.Summary.Remove(summary);
            await _context.SaveChangesAsync();

            return summary;
        }

        private bool SummaryExists(int id)
        {
            return _context.Summary.Any(e => e.SummaryId == id);
        }
    }
}
