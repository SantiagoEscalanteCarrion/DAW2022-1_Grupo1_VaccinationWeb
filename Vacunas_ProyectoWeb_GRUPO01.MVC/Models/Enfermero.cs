using System;
using System.Collections.Generic;

namespace Vacunas_ProyectoWeb_GRUPO01.MVC.Models
{
    public partial class Enfermero
    {
        public Enfermero()
        {
            RegistroVacunacion = new HashSet<RegistroVacunacion>();
        }

        public int Id { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public string Distrito { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int CentroVacunacionId { get; set; }

        public virtual CentroVacunacion CentroVacunacion { get; set; } = null!;
        public virtual ICollection<RegistroVacunacion> RegistroVacunacion { get; set; }
    }
}
