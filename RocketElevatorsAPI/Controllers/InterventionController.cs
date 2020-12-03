using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RocketElevatorsAPI.Models;
using RocketElevatorsAPI.Data;


namespace RocketElevatorsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionController : ControllerBase
    {
        // Context
        private readonly RocketElevatorsContext _context;

        public InterventionController(RocketElevatorsContext context)
        {
            _context = context;

        }

        // Get full list of interventions                                    
         
        [HttpGet("all")]
        public IEnumerable<Intervention> GetInterventions()
        {
            IQueryable<Intervention> interventions =
            from intervention in _context.Interventions
            select intervention;
            return interventions.ToList();

        }
        [HttpGet("status")]
        public IEnumerable<Intervention> GetIntervention()
        {
     
           IQueryable<Intervention> status = from Status in _context.Interventions where Status.Status == "Pending" || Status.InterventionStart == null select Status;
           return status;
        }

        [HttpPut("start/{id}")]

        public string startintervention(ulong Id)
        {
            var intervention = _context.Interventions.Find(Id);
            intervention.Status = "In Progress";
            intervention.InterventionStart = DateTime.UtcNow;
            _context.Interventions.Update(intervention);
            _context.SaveChanges();
            return "Intervention is now started";
        }

        [HttpPut("finish/{id}")]

        public string endintervention(ulong Id)
        {
            var intervention = _context.Interventions.Find(Id);
            intervention.Result = "Completed";
            intervention.Status = "Completed";
            intervention.InterventionStop = DateTime.UtcNow;
            _context.Interventions.Update(intervention);
            _context.SaveChanges();
            return "Intervention is completed";
        }
        private bool InterventionExists(ulong Id)
        {
            return _context.Interventions.Any(e => e.Id == Id);
        }

        [HttpGet("Customer/{customer_id}")]
        public async Task<ActionResult<Intervention>> GetCustomer(long customer_id)
        {
            var intervention = await _context.interventions.FindAsync(customer_id);

            if (intervention == null)
            {
                return NotFound();
            }

            return intervention;
        }
      
    }
}