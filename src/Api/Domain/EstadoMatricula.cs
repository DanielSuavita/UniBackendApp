using System;
using System.Collections.Generic;

namespace Api.Domain;

public partial class EstadoMatricula
{
    public long Id { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<AsignaturasEstudiante> AsignaturasEstudiantes { get; set; } = new List<AsignaturasEstudiante>();
}
