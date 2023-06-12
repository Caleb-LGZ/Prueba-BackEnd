using System;
using System.Collections.Generic;

namespace Prueba_BackEnd.Models;

public partial class SignosVitale
{
    public int SignosId { get; set; }

    public double Temperatura { get; set; }

    public double FrecuenciaCardiaca { get; set; }

    public double FrecuenciaRespiratoria { get; set; }

    public double Altura { get; set; }

    public double Peso { get; set; }

    public DateTime FechaHora { get; set; }

    public virtual ICollection<ConsultaMedica> ConsultaMedicas { get; set; } = new List<ConsultaMedica>();
}
