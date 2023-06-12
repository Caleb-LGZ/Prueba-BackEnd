using System;
using System.Collections.Generic;

namespace Prueba_BackEnd.Models;

public partial class Servicio
{
    public int ServicioId { get; set; }

    public string NombreServicio { get; set; } = null!;

    public virtual ICollection<EmpleadoCaja> EmpleadoCajas { get; set; } = new List<EmpleadoCaja>();
}
