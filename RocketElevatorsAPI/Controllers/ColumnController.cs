using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RocketElevatorsAPI.Models;

namespace Column.Controllers {

    [Route("api/column")]
    [ApiController]

    public class ColumnsController : ControllerBase
    {
         private readonly RocketElevatorsContext _context;
         
         public ColumnsController(RocketElevatorsContext context)
        {
            _context = context;
        }

    [HttpGet]
        public async Task<ActionResult<IEnumerable<ColumnItems>>> GetColumns()
        {
            return await _context.columns.ToListAsync();
        }


         [HttpGet("{id}")]
        public async Task<ActionResult<ColumnItems>> GetColumns(int id)
        {
            var columnItems = await _context.columns.FindAsync(id);

            if (columnItems == null)
            {
                return NotFound();
            }

            return columnItems;
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, ColumnItems columnItems)
        {
            if (id != columnItems.id)
            {
                return BadRequest();
            }

            _context.Entry(columnItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColumnExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
    }
}