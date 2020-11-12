using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketElevatorsAPI.Models;
using RocketElevatorsAPI.Data;

namespace RocketElevatorsAPI.Controllers {

    [Route("api/[controller]")]
    [ApiController]

    public class BatteryController : ControllerBase
    {

        // Context 
        private readonly RocketElevatorsContext _context;

        public BatteryController(RocketElevatorsContext context)
        {
            _context = context;
        }

        // Get full list of batteries                                  
        // http://localhost:3000/api/batteries/all
        // GET: api/batteries/all           
        [HttpGet("all")]
        public IEnumerable<Battery> GetBatteries()
        {
            IQueryable<Battery> batteries =
            from battery in _context.Batteries
            select battery;
            return batteries.ToList();

        }

        // Get status of specific battery
        // http://localhost:3000/api/batteries/{id}
        // GET: api/batteries/{id}
        [HttpGet("{id}")]
        public string GetStatus(ulong id)
        {
            var batteries = _context.Batteries.Where(battery => battery.ID == id).ToList();
            return batteries[0].Status;
        }

        // Change status of specific battery
        // http://localhost:3000/api/batteries/{id}
        // PUT api/batteries/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(ulong id, Battery battery)
        {
            if (id != battery.ID)
            {
                return BadRequest();
            }

            _context.Entry(battery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (id != battery.ID)
                {
                    // Resource doesn't exist.
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
           
            return  Content("Status of Battery with ID #" + battery.ID + ": changed status to " + battery.Status);  
        }


    }

}