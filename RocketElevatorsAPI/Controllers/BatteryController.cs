using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RocketElevatorsAPI.Models;

namespace Battery.Controllers {

    [Route("api/battery")] // batteries endpoint.
    [ApiController]

    public class BatteryController : ControllerBase
    {
         private readonly RocketElevatorsContext _context;
         
         public BatteryController(RocketElevatorsContext context)
        {
            _context = context;
        }

    [HttpGet]
        public async Task<ActionResult<IEnumerable<BatteryItems>>> GetBatteries()
        {
            return await _context.batteries.ToListAsync();
        }


         [HttpGet("{id}")]
        public async Task<ActionResult<BatteryItems>> GetBatteries(int id)
        {
            var batteryItems = await _context.batteries.FindAsync(id);

            if (batteryItems == null)
            {
                return NotFound();
            }

            return batteryItems;  
        } 
            [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, BatteryItems batteryItems)
        {
            if (id != batteryItems.id)
            {
                return BadRequest();
            }

            _context.Entry(batteryItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatteryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(batteryItems);   
        }


    }

}