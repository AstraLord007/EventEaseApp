using System.Collections.Generic;

namespace EventEaseApp.Data
{
    public class EventService
    {
        public List<Event> GetEvents() => new()
        {
            new Event { Name = "Conferencia Tech", Date = DateTime.Now.AddDays(10), Location = "Buenos Aires" },
            new Event { Name = "Fiesta Corporativa", Date = DateTime.Now.AddDays(20), Location = "Salta" },
            new Event { Name = "Seminario de Marketing", Date = DateTime.Now.AddDays(30), Location = "Córdoba" }
        };
    }
}