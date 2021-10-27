using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FamilyToDo.Models;

namespace FamilyToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoesController : ControllerBase
    {
        private readonly TaskContext _context;

        public ToDoesController(TaskContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        // GET: api/ToDoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoDTO>>> GetTasks()
        {
            IQueryable<ToDo> tasks = _context.ToDo;
            tasks = tasks.Where(t => t.CompletionDate == null);

            return await tasks.Select(x => ToDoToDTO(x)).ToListAsync();

        }

        // GET: api/ToDoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDo>> GetToDo(long id)
        {
            var toDo = await _context.ToDo.FindAsync(id);

            if (toDo == null)
            {
                return NotFound();
            }

            return toDo;
        }

        // PUT: api/ToDoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDo(long id, ToDo toDo)
        {
            if (id != toDo.Id)
            {
                return BadRequest();
            }

            _context.Entry(toDo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ToDoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToDo>> CreateToDo(ToDo toDo)
        {
            _context.ToDo.Add(toDo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDo", new { id = toDo.Id }, toDo);
        }

        // DELETE: api/ToDoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDo(long id)
        {
            var toDo = await _context.ToDo.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }

            _context.ToDo.Remove(toDo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoExists(long id)
        {
            return _context.ToDo.Any(e => e.Id == id);
        }

        //Get by Assignment
        [HttpGet("assignment/{assignment}")]
        public async Task<IActionResult> GetByAssignment([FromRoute] string assignment)
        {
            IQueryable<ToDo> tasks = _context.ToDo;

            tasks = tasks.Where(t => t.Assignment.ToLower().Equals(assignment.ToLower()));

            return Ok(await tasks.ToArrayAsync());
        }

        //Get by Priority
        [HttpGet("priority")]
        public async Task<IActionResult> GetByPriority([FromRoute] short priority)
        {
            IQueryable<ToDo> tasks = _context.ToDo;

            tasks = tasks.OrderBy(t => t.Priority);

            return Ok(await tasks.ToArrayAsync());
        }

        // Get By Category
        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetByCategory([FromRoute] string category)
        {
            IQueryable<ToDo> tasks = _context.ToDo;

            tasks = tasks.Where(t => t.Category.ToLower().Equals(category.ToLower()));

            return Ok(await tasks.ToArrayAsync());
        }
        [HttpGet("nextdue/{count}")]
        public async Task<IActionResult> GetNextDueDate([FromRoute] int count)
        {
            IQueryable<ToDo> tasks = _context.ToDo;

            tasks = tasks.OrderBy(t => t.DueDate).Take(count);

            return Ok(await tasks.ToArrayAsync());
        }
        [HttpGet("duedate/{date}")]
        public async Task<IActionResult> GetByDate([FromRoute] DateTime date)
        {
            IQueryable<ToDo> tasks = _context.ToDo;
            tasks = tasks.Where(t => t.DueDate.Date.Equals(date.Date));

            return Ok(await tasks.ToArrayAsync());
        }
        private static ToDoDTO ToDoToDTO(ToDo todoItem) => new ToDoDTO
        {
            Id = todoItem.Id,
            Title = todoItem.Title,
            Discription = todoItem.Discription,
            Priority = todoItem.Priority,
            Category = todoItem.Category,
            DueDate = todoItem.DueDate,
            Assignment = todoItem.Assignment
        };
    }
    
}

