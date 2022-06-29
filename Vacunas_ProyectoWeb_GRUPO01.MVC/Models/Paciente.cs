﻿using System;
using System.Collections.Generic;

namespace Vacunas_ProyectoWeb_GRUPO01.MVC.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            RegistroReporteIncidente = new HashSet<RegistroReporteIncidente>();
        }

        public int Id { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public DateTime FechaEmisionDni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Numero { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public string Distrito { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int PersonalRegistroId { get; set; }
        public int EnfermeroId { get; set; }

        public virtual PersonalRegistro PersonalRegistro { get; set; } = null!;
        public virtual ICollection<RegistroReporteIncidente> RegistroReporteIncidente { get; set; }
    }
}
