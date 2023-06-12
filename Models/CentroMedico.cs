using System;
using System.Collections.Generic;

namespace Prueba_BackEnd.Models;

public partial class CentroMedico
{
    public int CentromedicoId { get; set; }

    public string NombreCentromedico { get; set; } = null!;

    public int UnidadProgramatica { get; set; }

    public virtual ICollection<EmpleadoCaja> EmpleadoCajas { get; set; } = new List<EmpleadoCaja>();
}
