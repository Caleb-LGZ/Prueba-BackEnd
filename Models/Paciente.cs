using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Prueba_BackEnd.Models;

public partial class Paciente
{
    public int CedulaPaciente { get; set; }

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string PrimerApellido { get; set; } = null!;

    public string SegundoApellido { get; set; } = null!;

    public string? Correo { get; set; }

    public int TelefonoPaciente { get; set; }

    public int TelefonoContacto { get; set; }

    public string Genero { get; set; } = null!;

    public int ProvinciaId { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public DateTime FechaCreacion { get; set; }

    //public virtual ICollection<ConsultaMedica> ConsultaMedicas { get; set; } = new List<ConsultaMedica>();

    //[JsonIgnore]
    public virtual Provincia? Provincia { get; set; } = null!;




}
