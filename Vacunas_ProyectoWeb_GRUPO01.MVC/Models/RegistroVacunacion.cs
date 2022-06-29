using System;
using System.Collections.Generic;

namespace Vacunas_ProyectoWeb_GRUPO01.MVC.Models
{
    public partial class RegistroVacunacion
    {
        public int Id { get; set; }
        public int? CentroVacunacionId { get; set; }
        public int? PacienteId { get; set; }
        public int? EnfermeroId { get; set; }
        public int? NumeroDosis { get; set; }
        public DateTime? FechaVacunacion { get; set; }
        public int? PersonalRegistroId { get; set; }
        public int? VacunaId { get; set; }

        public virtual CentroVacunacion? CentroVacunacion { get; set; }
        public virtual Enfermero? Enfermero { get; set; }
        public virtual PersonalRegistro? PersonalRegistro { get; set; }
        public virtual Vacuna? Vacuna { get; set; }
    }
}
