using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketElevatorsAPI.Models;

namespace RocketElevatorsAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ColumnsController : ControllerBase
    {

        // Context
        private readonly RocketElevatorsContext _context;
         
        public ColumnsController(RocketElevatorsContext context)
        {
            _context = context;
        }

        // Get full list of columns                          
        // http://localhost:3000/api/columns/all
        // GET: api/columns/all           
        [HttpGet("all")]
        public IEnumerable<Column> GetColumns()
        {
            IQueryable<Column> columns =
            from column in _context.Columns
            select column;
            return columns.ToList();

        }

        // Get status of specific battery
        // http://localhost:3000/api/batteries/{id}
        // GET: api/columns/{id}
        [HttpGet("{id}")]
        public string GetStatus(ulong id)
        {
            var columns = _context.Columns.Where(column => column.ID == id).ToList();
            return columns[0].Status;
        }

        // Change status of specific column
        // http://localhost:3000/api/columns/{id}
        // PUT api/columns/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(ulong id, Column column)
        {
            if (id != column.ID)
            {
                return BadRequest();
            }

            _context.Entry(column).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (id != column.ID)
                {
                    // Resource doesn't exist.
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Content("Status of Column with ID #" + column.ID + ": changed status to " + column.Status);
        }
    }
}