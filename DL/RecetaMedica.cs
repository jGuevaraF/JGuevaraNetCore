using System;
using System.Collections.Generic;

namespace DL;

public partial class RecetaMedica
{
    public int IdReceta { get; set; }

    public DateTime? FechaConsulta { get; set; }

    public string? Diagnostico { get; set; }

    public string? NombreMedico { get; set; }

    public string? NotasAdicionales { get; set; }

    public int? IdPaciente { get; set; }

    public virtual Paciente? IdPacienteNavigation { get; set; }

    // Propiedades del Paciente denormalizadas
    public string? NombrePaciente { get; set; }
    public string? ApellidoPaterno { get; set; }
    public string? ApellidoMaterno { get; set; }
}
