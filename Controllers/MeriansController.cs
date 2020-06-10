using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;    
using CommandAPI.Models;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeriansController : ControllerBase
    {
        private readonly MerianContext _context;

        public MeriansController(MerianContext context) => _context = context;

        // Get: api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Merian>> GetCommand()
        {
            return _context.ProductItems;
        }

        // Get: api/commands/n
        [HttpGet("Abc/{id}")]
        public ActionResult<Merian> GetCommandById(int id)
        {
            var commandItem = _context.ProductItems.Find(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            return commandItem;
        }

        // Post: api/commands/
        [HttpPost]
        public ActionResult<Merian> PostCommandItem(Merian command)
        {
            _context.ProductItems.Add(command);
            _context.SaveChanges();
            return CreatedAtAction("GetCommandById", new Merian { Id = command.Id }, command);
        }

        // Put: api/commands/n
        [HttpPut("{id}")]
        public ActionResult PutCommandItem(int id, Merian command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            _context.Entry(command).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        // Delete: api/commands/n
        [HttpDelete("{id}")]
        public ActionResult<Merian> DeleteCommandItem(int id)
        {
            var commandItem = _context.ProductItems.Find(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            _context.ProductItems.Remove(commandItem);
            _context.SaveChanges();
            return commandItem;
        }
    }
}