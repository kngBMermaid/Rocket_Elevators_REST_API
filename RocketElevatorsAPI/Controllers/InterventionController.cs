
using System.Collections.Generic;
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
        public string GetInterventions(ulong id)
        {
            var interventions = _context.Interventions.Where(intervention => intervention.Id == id).ToList();
            return interventions[0].Status;
        }
    }
}
    
