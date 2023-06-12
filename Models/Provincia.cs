using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Prueba_BackEnd.Models;

public partial class Provincia
{
    public int ProvinciaId { get; set; }

    public string Nombre { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Paciente>? Pacientes { get; set; } = new List<Paciente>();
}
