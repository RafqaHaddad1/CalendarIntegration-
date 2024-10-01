using Calendar.Data;

namespace Calendar.ViewModel
{
    public class EventListViewModel
    {
        public IEnumerable<Event> GetEvents()
        {
            // Logic to retrieve events from a data source
            // Replace with actual implementation
            return new List<Event>
            {
                new Event { Subject = "Event 1", Description = "Description 1", Start = DateTime.Now, End = DateTime.Now.AddHours(1), ThemeColor = "#FF0000", IsFullDay = false },
                new Event { Subject = "Event 2", Description = "Description 2", Start = DateTime.Now.AddDays(1), End = DateTime.Now.AddDays(1).AddHours(1), ThemeColor = "#00FF00", IsFullDay = true }
            };
        }
    }
}
