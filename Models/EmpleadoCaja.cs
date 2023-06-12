using System;
using System.Collections.Generic;

namespace Prueba_BackEnd.Models;

public partial class EmpleadoCaja
{
    public int EmpleadoId { get; set; }

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string PrimerApellido { get; set; } = null!;

    public string SegundoApellido { get; set; } = null!;

    public string NombreUsuario { get; set; } = null!;

    public int Identificacion { get; set; }

    public string Correo { get; set; } = null!;

    public string CorreoCaja { get; set; } = null!;

    public int CentromedicoId { get; set; }

    public int PuestoId { get; set; }

    public int ServicioId { get; set; }

    public int Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual CentroMedico Centromedico { get; set; } = null!;

    public virtual ICollection<ConsultaMedica> ConsultaMedicas { get; set; } = new List<ConsultaMedica>();

    public virtual Puesto Puesto { get; set; } = null!;

    public virtual Servicio Servicio { get; set; } = null!;
}
