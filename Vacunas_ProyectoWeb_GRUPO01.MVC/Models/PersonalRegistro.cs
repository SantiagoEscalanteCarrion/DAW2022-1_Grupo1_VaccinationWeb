using System;
using System.Collections.Generic;

namespace Vacunas_ProyectoWeb_GRUPO01.MVC.Models
{
    public partial class PersonalRegistro
    {
        public PersonalRegistro()
        {
            Paciente = new HashSet<Paciente>();
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

        public virtual ICollection<Paciente> Paciente { get; set; }
        public virtual ICollection<RegistroVacunacion> RegistroVacunacion { get; set; }
    }
}
