using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;    
using CommandAPI.Models;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommandContext _context;

        public CommandsController(CommandContext context) => _context = context;

        // Get: api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommand()
        {
            return _context.CommandItems;
        }

        // Get: api/commands/n
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = _context.CommandItems.Find(id);
            if( commandItem == null){
                return NotFound();
            }
            return commandItem;
        }

        // Post: api/commands/
        [HttpPost]
        public ActionResult<Command> PostCommandItem(Command command)
        {
            _context.CommandItems.Add(command);
            _context.SaveChanges();
            return CreatedAtAction("GetCommandById", new Command{Id = command.Id}, command);
        }

        // Put: api/commands/n
        [HttpPut("{id}")]
        public ActionResult PutCommandItem(int id, Command command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }
            _context.Entry(command).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        // Delete: api/commands/n
        [HttpDelete("{id}")]
        public ActionResult<Command> DeleteCommandItem(int id)
        {
            var commandItem = _context.CommandItems.Find(id);
            if( commandItem == null){
                return NotFound();
            }
            _context.CommandItems.Remove(commandItem);
            _context.SaveChanges();
            return commandItem;
        }
    }
    }