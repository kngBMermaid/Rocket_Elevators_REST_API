using System.Collections.Generic;
using System.Linq;
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

    }
}