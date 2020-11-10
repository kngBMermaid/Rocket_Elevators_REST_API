using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Main.Models;

namespace Lead.Controllers {

    [Route("api/lead")]
    [ApiController]

    public class LeadsController : ControllerBase
    {
         private readonly MainContext _context;
         
         public LeadsController(MainContext context)
        {
            _context = context;
        }

    [HttpGet]
        public async Task<ActionResult<IEnumerable<LeadItems>>> GetLeads()
        {
            return await _context.leads.ToListAsync();
        }

        [HttpGet("lastmonth")]
       // https://docs.microsoft.com/en-us/dotnet/csharp/linq/query-expression-basics
       // Allows the use of queries
        public IEnumerable<LeadItems> GetLead()
        {
            double ts = -30;
           

            //https://stackoverflow.com/questions/17799499/cannot-convert-lambda-expression-to-delegate-type (Lambda operator)
            // This allows us to fetch all leads recorded in the past 30 days that are not yet customers.

            IQueryable<LeadItems> last = from last30 in _context.leads
             where last30.created_at >= DateTime.Now.AddDays(ts) && last30.customer_id == null
             select last30;

            
            return last;
            
        }
    }
}