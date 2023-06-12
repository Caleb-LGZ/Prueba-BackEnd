using System;
using System.Collections.Generic;

namespace Prueba_BackEnd.Models;

public partial class ConsultaMedica
{
    public int ConsultaId { get; set; }

    public int PacienteId { get; set; }

    public int EmpleadoId { get; set; }

    public int SignosId { get; set; }

    public string Causa { get; set; } = null!;

    public string Diagnostico { get; set; } = null!;

    public string Observaciones { get; set; } = null!;

    public string Sintomas { get; set; } = null!;

    public int MedicamentoId { get; set; }

    public DateTime FechaHora { get; set; }

    public virtual EmpleadoCaja Empleado { get; set; } = null!;

    public virtual ICollection<MedicamentosConsultum> MedicamentosConsulta { get; set; } = new List<MedicamentosConsultum>();

    public virtual Paciente Paciente { get; set; } = null!;

    public virtual SignosVitale Signos { get; set; } = null!;
}
