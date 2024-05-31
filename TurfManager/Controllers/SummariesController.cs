using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mime;
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
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]

    [ApiController]
    public class SummariesController : ControllerBase
    {
        private readonly GDDContext _context;

        public SummariesController(GDDContext context)
        {
            _context = context;
        }

        // GET: api/Summaries
        /// <summary>
        /// Returns all summaries in the database. No JWT required.
        /// </summary>
        /// <param name="Last45"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
                                join a in _context.Action on s.SummaryAction equals a.ActionID
                                select s;
                summaries = summaries.OrderBy(s => s.SummaryDateWst);
                return await summaries.ToListAsync();
            }



        }
        // GET: api/Summaries/GetActionSummary
        /// <summary>
        /// Get an Overview of the last time each of the actions were performed.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetActionSummary/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ActionSummary>>> GetOverview()
        {
            
            var summaryActions = from sa in _context.ActionSummary
                               select sa;
            return await summaryActions.ToListAsync();


        }

        // GET: api/Summaries/GetCumulativeGDD
        /// <summary>
        /// Get the Cumulative GDD Since the last application of PGR. Requires JWT.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCumulativeGDD/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Summary>>> GetGDD()
        {

            // get the date the last PGR was applied
            var allPGRSummaries = from sum in _context.Summary
                                     where sum.SummaryAction == 1
                                     select sum;
            var dateofLastPGR = allPGRSummaries.Max(sum => sum.SummaryDateWst);
                      
            Debug.WriteLine(dateofLastPGR.ToString());

            // sum the total of SummaryGDDTotal since that date
            var summariesSince = from sum in _context.Summary
                                where sum.SummaryAction == null && 
                                sum.SummaryDateWst > dateofLastPGR
                                select sum;
            decimal sumofPGRSince = (decimal)summariesSince.AsEnumerable().Sum(row => row.SummaryGddtotal);
            Debug.WriteLine(sumofPGRSince.ToString());

            //return await Ok(sumofPGRSince.ToString());
            return Ok(sumofPGRSince);


            //return Ok();
            
            

        }

        // GET: api/Summaries/GetDateOfLastAction/{ActionID}
        /// <summary>
        /// Get the date of the last action logged -Requires JWT.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetDateOfLastAction/{id}")]
        public async Task<ActionResult<Summary>> GetDateOfLastAction(int id)
        {
            //get the date the last ActionID was logged.
            var allSummaries = from sum in _context.Summary
                             where sum.SummaryAction == id
                             select sum;
            var dateOfLastAction = allSummaries.Max(Summary => Summary.SummaryDateWst);

            return Ok(dateOfLastAction);
        }

        // GET: api/Summaries/5
        /// <summary>
        /// Get a specific Summary by ID (not really useful yet) Requires JWT.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetByID/{id}")]
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
        /// <summary>
        /// OLD: Create a Summary record (min and max temperature) for a specific date (send in a YYYYMMDD string) Uses Stored Prod = TO BE DEPRECATED. Requires JWT.
        /// </summary>
        /// <param name="DateString"></param>
        /// <returns></returns>

        [HttpPut("{DateString}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutSummary(string DateString)
        {
            // Generate the summary record here by DateString
            Debug.WriteLine(DateString);
            int RowsAffected = _context.Database.ExecuteSqlRaw("EXEC spGenerateSummaryForDateString @DATESTRING", new SqlParameter("@DATESTRING", DateString));
                

            if (RowsAffected != 1)
            {
                return BadRequest();
            }

            if (RowsAffected == 1)
            { 
                return Ok();

            }

            return new EmptyResult();


        }
        /// <summary>
        /// NEW: Generate a Summary Record for a specific date (send in YYYYMMDD as string) Requires JWT.
        /// </summary>
        /// <param name="inDate"></param>
        /// <returns></returns>

        [HttpPost("Generate/{inDate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GenerateSummary(string inDate)
        {
         
            // Get the MIN and MAX for the passed in datestring from the Temperatures table

            var dailyMinMax = from temperatures in _context.Temperatures
                              where temperatures.ReadingDateString == inDate
                              select temperatures;


            decimal maxTemp = (decimal)dailyMinMax.AsEnumerable().Max(row => row.ReadingValue);
            decimal minTemp = (decimal)dailyMinMax.AsEnumerable().Min(row => row.ReadingValue);
            decimal averageTemperature = (maxTemp + minTemp) / 2;
            decimal gddTotal = averageTemperature - 10;

            
            Debug.WriteLine(maxTemp.ToString());
            Debug.WriteLine(minTemp.ToString());

            // Now write a summary record with that min and max
                       

            DateTime formattedDate = DateTime.ParseExact(inDate, "yyyyMMdd",System.Globalization.CultureInfo.InvariantCulture);


            var summaryGeneratedAction = new Summary
            {
                SummaryDateGenerated = DateTime.Now,
                SummaryDateWst = formattedDate,
                SummaryDateString = inDate,
                SummaryAction = null,
                SummaryMaxTemp = maxTemp,
                SummaryMinTemp = minTemp,
                SummaryGddtotal = gddTotal
            };

            _context.Summary.Add(summaryGeneratedAction);
            await _context.SaveChangesAsync();



            return Ok();

        }


        // POST: api/Summaries
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// OLD: Log an Action to the Summary table. Send in an Action Integer. Replaced by POST: /api/Summaries/SummaryAction. Requires JWT.
        /// </summary>
        /// <param name="Action"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostSummary(int Action)
        {
            if (Action > 0)
            {
                //int RowsAffected = _context.Database.ExecuteSqlCommand("EXEC spGenerateSummaryAction @ACTION", new SqlParameter("@ACTION", Action));

                int RowsAffected = _context.Database.ExecuteSqlRaw("EXEC spGenerateSummaryAction @ACTION", new SqlParameter("@ACTION", Action));
                    if (RowsAffected == 1)
                    {
                        return Ok();
                    }
            }
            else
            {
                return BadRequest();
            }

            return BadRequest();


        }
        // PUT: api/SummaryAction/
        /// <summary>
        /// NEW: Log a new Action to the Summary Table. TO DO: Account for Timezone Offset. Requires JWT
        /// </summary>
        /// <returns></returns>
        [HttpPost("LogAction/{id}")]
        public async Task<ActionResult<Summary>> PostNewSummaryAction(int id)
        {
            // post a summary to the summary table with the action integer passed in (2 is mow)
            var summaryAction = new Summary
            {
                SummaryDateGenerated = DateTime.Now,
                SummaryDateWst = DateTime.Now,
                SummaryDateString = DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture),
                SummaryAction = id
            };

            _context.Summary.Add(summaryAction);
            await _context.SaveChangesAsync();



            return Ok();
            


        }


        // DELETE: api/Summaries/5
        /// <summary>
        /// Delete a specific Summary by ID - Requires JWT.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("DeleteByID/{id}")]

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
