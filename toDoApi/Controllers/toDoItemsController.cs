using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using toDoApi.Models;

namespace toDoApi.Controllers
{
    [Route("api/[toDoItems]")]
    [ApiController]
    public class toDoItemsController : ControllerBase
    {
        private readonly toDoContext _context;

        public toDoItemsController(toDoContext context)
        {
            _context = context;
        }

        // GET: api/toDoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<toDoItemDTO>>> GettoDoItems()
        {
            return await _context.TodoItems
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<toDoItemDTO>> GettoDoItem(long id)
        {
            var toDoItem = await _context.TodoItems.FindAsync(id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return ItemToDTO(toDoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatetoDoItem(long id, toDoItemDTO toDoItemDTO)
        {
            if (id != toDoItemDTO.Id)
            {
                return BadRequest();
            }

            var toDoItem = await _context.TodoItems.FindAsync(id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            toDoItem.Name = toDoItemDTO.Name;
            toDoItem.IsComplete = toDoItemDTO.IsComplete;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!toDoItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<toDoItemDTO>> CreatetoDoItem(toDoItemDTO toDoItemDTO)
        {
            var toDoItem = new toDoItem
            {
                IsComplete = toDoItemDTO.IsComplete,
                Name = toDoItemDTO.Name
            };

            _context.TodoItems.Add(toDoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GettoDoItem),
                new { id = toDoItem.Id },
                ItemToDTO(toDoItem));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetoDoItem(long id)
        {
            var toDoItem = await _context.TodoItems.FindAsync(id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(toDoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool toDoItemExists(long id) =>
             _context.TodoItems.Any(e => e.Id == id);

        private static toDoItemDTO ItemToDTO(toDoItem toDoItem) =>
            new toDoItemDTO
            {
                Id = toDoItem.Id,
                Name = toDoItem.Name,
                IsComplete = toDoItem.IsComplete
            };
    }
}
