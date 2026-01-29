using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Data
{
    public class Event
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Identificador único

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La ubicación es obligatoria")]
        [StringLength(200, ErrorMessage = "La ubicación no puede superar los 200 caracteres")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres")]
        public string Description { get; set; } = string.Empty;

        public List<User> Attendees { get; set; } = new();
    }
}