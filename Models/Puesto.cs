using System;
using System.Collections.Generic;

namespace Prueba_BackEnd.Models;

public partial class Puesto
{
    public int PuestoId { get; set; }

    public string NombrePuesto { get; set; } = null!;

    public virtual ICollection<EmpleadoCaja> EmpleadoCajas { get; set; } = new List<EmpleadoCaja>();
}
