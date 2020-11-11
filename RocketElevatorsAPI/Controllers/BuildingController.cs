using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RocketElevatorsAPI.Models;

// using Microsoft.EntityFrameworkCore;
// using MySql.Data;
// using MySql.Data.MySqlClient;

namespace RocketElevatorsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        // Context
        private readonly RocketElevatorsContext _context;

        public BuildingController(RocketElevatorsContext context)
        {
            _context = context;

        }

        // Get full list of buildings                                  
        // https://localhost:3000/api/building/all
        // GET: api/building/all           
        [HttpGet("all")]
        public IEnumerable<Building> GetBuildings()
        {
            IQueryable<Building> buildings  =
            from building in _context.Buildings
            select building;
            return buildings.ToList();

        }

        // Retrieve list of Buildings requiring intervention 
        // https://localhost:3000/api/building/intervention
        // GET: api/building/intervention             
        [HttpGet("intervention")]
        public IEnumerable<Building> GetBuildingsIntervention() 
        {
            IQueryable<Building> buildings = 
            from building in _context.Buildings
            join battery in _context.Batteries on building.ID equals battery.BuildingID
            join column in _context.Columns on battery.ID equals column.BatteryID
            join elevator in _context.Elevators on column.ID equals elevator.ColumnID
            where elevator.Status == "intervention" || column.Status == "intervention" || battery.Status == "intervention"
            select building;
            return buildings.ToList();
        }

    }
}