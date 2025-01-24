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
    [Route("api/v2/[controller]")] 
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]

    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly GDDContext _context;

        public APIController(GDDContext context)
        {
            _context = context;
        }

        

        // GET: api/V2/GetSummaries
        /// <summary>
        /// Get all previous actions
        /// </summary>
        /// <returns></returns>
        [HttpGet("/API/V2/GetSummaries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        public async Task<ActionResult<IEnumerable<vwSummaries>>> GetSummaries()
        {
            
            var vwSummaries = from sa in _context.vwSummaries
                               select sa;
            return await vwSummaries.ToListAsync();


        }


// GET: api/V2/GetSummaries
        /// <summary>
        /// Get all previous actions
        /// </summary>
        /// <returns></returns>
        [HttpGet("/API/V2/GetActions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        public async Task<ActionResult<IEnumerable<vwActions>>> GetActions()
        {
            
            var vwActions = from sa in _context.vwActions
                               select sa;
            return await vwActions.ToListAsync();


        }


    }
}
