using System;
using System.Collections.Generic;
using System.Linq;

namespace EventEaseApp.Data
{
    public class EventService
    {
        private List<Event> events = new()
        {
            new Event { Name = "Concierto Rock", Date = DateTime.Now.AddDays(7), Location = "Salta", Description = "Show en vivo" },
            new Event { Name = "Feria del Libro", Date = DateTime.Now.AddDays(14), Location = "Buenos Aires", Description = "Presentaciones y charlas" }
        };

        // 🔹 Obtener lista de eventos
        public List<Event> GetEvents() => events;

        // 🔹 Agregar un nuevo evento
        public void AddEvent(Event newEvent)
        {
            events.Add(newEvent);
        }

        // 🔹 Registrar asistencia de un usuario a un evento
        public void RegisterAttendance(Event ev, User user)
        {
            if (!ev.Attendees.Any(a => a.Email == user.Email))
            {
                ev.Attendees.Add(user);
            }
        }

        // 🔹 Cancelar asistencia de un usuario a un evento
        public void CancelAttendance(Event ev, User user)
        {
            var attendee = ev.Attendees.FirstOrDefault(a => a.Email == user.Email);
            if (attendee != null)
            {
                ev.Attendees.Remove(attendee);
            }
        }
    }
}