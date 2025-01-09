using System;
using System.Collections.Generic;

namespace Api.Domain;

public partial class Asignatura
{
    public long Id { get; set; }

    public string? Nombre { get; set; }

    public int? CantidadCreditosNecesarios { get; set; }

    public virtual ICollection<AsignaturasEstudiante> AsignaturasEstudiantes { get; set; } = new List<AsignaturasEstudiante>();
}
