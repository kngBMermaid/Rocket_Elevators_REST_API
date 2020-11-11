using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RocketElevatorsAPI.Models;

namespace RocketElevatorsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorController : ControllerBase
    {
        // Context
        private readonly RocketElevatorsContext _context;

        public ElevatorController(RocketElevatorsContext context)
        {
            _context = context;

        }

        // Get full list of elevators                                   
        // https://localhost:3000/api/elevator/all
        // GET: api/elevator/all           
        [HttpGet("all")]
        public IEnumerable<Elevator> GetElevators()
        {
            IQueryable<Elevator> elevators =
            from elevator in _context.Elevators
            select elevator;
            return elevators.ToList();

        }

        // Retriving Status of All the Elevators not active             
        // https://localhost:3000/api/elevator/notinoperation
        // GET: api/elevator/inoperational           

        [HttpGet("inoperational")]
        public IEnumerable<Elevator> GetInoperationalElevators()
        {
            IQueryable<Elevator> elevators = 
            from elevator in _context.Elevators
            where elevator.Status.ToLower() != "active" // Gets elevators with either "Inactive" or "Intervention" status
            select elevator;

            return elevators.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Elevator>> GetElevators(ulong id)
        {
            var ElevatorItems = await _context.Elevators.FindAsync(id);

            if (ElevatorItems == null)
            {
                return NotFound();
            }

            return ElevatorItems; // We can GET Elevators data with it's ID
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(ulong id, Elevator elevator)
        {
            if (id != elevator.ID)
            {
                return BadRequest();
            }

           _context.Entry(elevator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
        
            return Ok(elevator);           
        } 

        [HttpPut("updatestatus/{id}")]
        public async Task<IActionResult> PutElevatorStatus(long id, ElevatorStatus elevator)
        {

            if (id != elevator.id)
            {
                return BadRequest();
            }

            var current_elevator = _context.Elevators.Find(elevator.id);
            current_elevator.status = elevator.status;

            if (elevator.status == "Intervention" || elevator.status == "Active" || elevator.status == "Inactive"){

                await _context.SaveChangesAsync();
                return NoContent();
            }

            else
            {
                return BadRequest();
            }
        }



    }
}