using Microsoft.AspNetCore.Mvc;
using Calendar.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Controllers
{
    [Route("Calendar")]
    public class CalendarController : Controller
    {
        private readonly CalendarDbContext _context;

        public CalendarController(CalendarDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetEvents")]
        public IActionResult GetEvents()
        {
            var events = _context.Event.ToList();
            return Json(events);
        }

        [HttpPost("AddEvent")]
        public IActionResult AddEvent([FromBody] Event newEvent)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Event.Add(newEvent);
                    _context.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    // Log the exception (if logging is set up) and return a bad request with the error message
                    Console.WriteLine($"Error adding event: {ex.Message}");
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }


        [HttpPost("UpdateEvent")]
        public IActionResult UpdateEvent( Event updatedEvent)
        {
            if (ModelState.IsValid)
            {
                var existingEvent = _context.Event.Find(updatedEvent.EventID);
                if (existingEvent != null)
                {
                    // Update the existing employee with new values
                    _context.Entry(existingEvent).CurrentValues.SetValues(updatedEvent);

                    _context.Event.Update(existingEvent);
                    _context.SaveChanges();
                    return Ok();
                }

                return NotFound();
            }

            return BadRequest(ModelState);
        }
    }
}
