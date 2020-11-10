using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Main.Models;

namespace Elevator.Controllers {

    [Route("api/elevatorstatus")]
    [ApiController]

    public class ElevatorStatusController : ControllerBase
    {
         private readonly MainContext _context;
         
         public ElevatorStatusController(MainContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IEnumerable<ElevatorItems> GetElevators()
        {
            IQueryable<ElevatorItems> status = from status in _context.elevators where status.status == "Inactive" || status.status == "Intervention" select status;
            
            return status;
        }

        [HttpGet("intervention")]

        public IEnumerable<ElevatorItems> GetInterventionElevators()
        {
            IQueryable<ElevatorItems> status = from status in _context.elevators where status.status == "Intervention" select status;
            
            return status;
        }

        [HttpGet("inactive")]
        public IEnumerable<ElevatorItems> GetInactiveElevators()
        {
            IQueryable<ElevatorItems> status = from status in _context.elevators where status.status == "Inactive" select status;
            
            return status;
        }
    }
}