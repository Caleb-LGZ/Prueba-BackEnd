using System;
using System.Collections.Generic;

namespace Prueba_BackEnd.Models;

public partial class MedicamentosConsultum
{
    public int MedicamentoId { get; set; }

    public int ConsultaId { get; set; }

    public string NombreMedicamento { get; set; } = null!;

    public int Cantidad { get; set; }

    public string? Indicaciones { get; set; }

    public virtual ConsultaMedica Consulta { get; set; } = null!;
}
