using System;
using System.Collections.Generic;

namespace Vacunas_ProyectoWeb_GRUPO01.MVC.Models
{
    public partial class RegistroReporteIncidente
    {
        public int Id { get; set; }
        public int? PacienteId { get; set; }
        public int? CentroVacunacionId { get; set; }
        public string? Descripcion { get; set; }
        public int? AdministrativoSaludId { get; set; }
        public DateTime? FechaReporte { get; set; }
        public string? NivelImportancia { get; set; }

        public virtual AdministrativoSalud? AdministrativoSalud { get; set; }
        public virtual CentroVacunacion? CentroVacunacion { get; set; }
        public virtual Paciente? Paciente { get; set; }
    }
}
