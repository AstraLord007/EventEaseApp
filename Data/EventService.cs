using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace EventEaseApp.Data
{
    public class EventService
    {
        private readonly IJSRuntime _jsRuntime;
        private List<Event> events = new()
        {
            new Event { Name = "Concierto Rock", Date = DateTime.Now.AddDays(7), Location = "Salta", Description = "Show en vivo" },
            new Event { Name = "Feria del Libro", Date = DateTime.Now.AddDays(14), Location = "Buenos Aires", Description = "Presentaciones y charlas" }
        };

        public EventService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task InitializeAsync()
        {
            var eventsJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "events");
            if (!string.IsNullOrEmpty(eventsJson))
            {
                var storedEvents = JsonSerializer.Deserialize<List<Event>>(eventsJson);
                if (storedEvents != null)
                {
                    events = storedEvents;
                }
            }
        }

        public List<Event> GetEvents() => events;

        public async Task AddEvent(Event newEvent)
        {
            events.Add(newEvent);
            await SaveEvents();
        }

        public async Task RegisterAttendance(Event ev, User user)
        {
            if (!ev.Attendees.Any(a => a.Email == user.Email))
            {
                ev.Attendees.Add(user);
                await SaveEvents();
            }
        }

        public async Task CancelAttendance(Event ev, User user)
        {
            var attendee = ev.Attendees.FirstOrDefault(a => a.Email == user.Email);
            if (attendee != null)
            {
                ev.Attendees.Remove(attendee);
                await SaveEvents();
            }
        }

        private async Task SaveEvents()
        {
            var eventsJson = JsonSerializer.Serialize(events);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "events", eventsJson);
        }
    }
}