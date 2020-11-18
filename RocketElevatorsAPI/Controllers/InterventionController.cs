xzusing System.Collections.Generic;
using System.Data;
using System.Linq;
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
        [HttpGet("{id}")]
        public IEnumerable<Intervention> GetInterventions(int id)
        {
            var interventions = await _context.interventions.FindAsync(id);

            if (interventions == null)
            {
                return NotFound();
            }
        
            return interventions;  // GET method to fetch Interventions data with ID
        } 


        [HttpGet("status")]
       public IEnumerable<Intervention> GetInterventions()
       {
           IQueryable<InterventionItems> status = from intStatus in _context.interventions where intStatus.status == "Pending" || intStatus.intervention_datetime_start == null select intStatus;
           return status;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, Interventions interventions)
        {
            if (id != interventions.id)
            {
                return BadRequest();
            }

            _context.Entry(interventions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterventionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(interventions);      
        }

        [HttpPut("begin/{id}")]

        public string beginintervention(int id)
        {
            var intervention = _context.interventions.Find(id);
            intervention.status = "In Progress";
            intervention.intervention_datetime_start = DateTime.Now;
            _context.interventions.Update(intervention);
            _context.SaveChanges();
            return "Intervention is now in progress";
        }

        [HttpPut("end/{id}")]

        public string endintervention(int id)
        {
            var intervention = _context.interventions.Find(id);
            intervention.result = "Completed";
            intervention.status = "Completed";
            intervention.intervention_datetime_end = DateTime.Now;
            _context.interventions.Update(intervention);
            _context.SaveChanges();
            return "Intervention is completed";
        }
        private bool InterventionExists(int id)
        {
            return _context.interventions.Any(e => e.id == id);
        }

    }
}