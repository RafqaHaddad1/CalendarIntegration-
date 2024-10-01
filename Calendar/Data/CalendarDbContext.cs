using Microsoft.EntityFrameworkCore;

namespace Calendar.Data
{
    public class CalendarDbContext  : DbContext
    {
        public CalendarDbContext(DbContextOptions<CalendarDbContext> options) : base(options)
        { 
              
        }
        public DbSet<Event> Event { get; set; }
    }
}
