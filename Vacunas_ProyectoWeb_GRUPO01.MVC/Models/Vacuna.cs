using System;
using System.Collections.Generic;

namespace Vacunas_ProyectoWeb_GRUPO01.MVC.Models
{
    public partial class Vacuna
    {
        public Vacuna()
        {
            RegistroVacunacion = new HashSet<RegistroVacunacion>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Laboratorio { get; set; }
        public string? Procedencia { get; set; }

        public virtual ICollection<RegistroVacunacion> RegistroVacunacion { get; set; }
    }
}
