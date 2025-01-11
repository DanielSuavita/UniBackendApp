using System;
using System.Collections.Generic;

namespace Api.Domain;

public partial class PeriodoAcademico
{
    public long Id { get; set; }

    public string? Periodo { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
