using System;
using System.Collections.Generic;

namespace Vacunas_ProyectoWeb_GRUPO01.MVC.Models
{
    public partial class CentroVacunacion
    {
        public CentroVacunacion()
        {
            Enfermero = new HashSet<Enfermero>();
            RegistroReporteIncidente = new HashSet<RegistroReporteIncidente>();
            RegistroVacunacion = new HashSet<RegistroVacunacion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Distrito { get; set; } = null!;
        public string Direccion { get; set; } = null!;

        public virtual ICollection<Enfermero> Enfermero { get; set; }
        public virtual ICollection<RegistroReporteIncidente> RegistroReporteIncidente { get; set; }
        public virtual ICollection<RegistroVacunacion> RegistroVacunacion { get; set; }
    }
}
