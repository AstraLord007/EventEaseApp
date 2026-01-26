namespace EventEaseApp.Data
{
    public class EventService
    {
        private List<Event> events = new()
        {
            new Event { Name = "Concierto Rock", Date = DateTime.Now.AddDays(7), Location = "Salta", Description = "Show en vivo" },
            new Event { Name = "Feria del Libro", Date = DateTime.Now.AddDays(14), Location = "Buenos Aires", Description = "Presentaciones y charlas" }
        };

        public List<Event> GetEvents() => events;

        public void AddEvent(Event newEvent)
        {
            events.Add(newEvent);
        }

        // 🔹 Nuevo método: registrar asistencia
        public void RegisterAttendance(Event ev, User user)
        {
            if (!ev.Attendees.Any(a => a.Email == user.Email))
            {
                ev.Attendees.Add(user);
            }
        }
    }
}