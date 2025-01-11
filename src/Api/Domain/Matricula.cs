using System;
using System.Collections.Generic;

namespace Api.Domain;

public partial class Matricula
{
    public long Id { get; set; }

    public int? CreditosInscritos { get; set; }

    public long IdEstudiante { get; set; }

    public long IdPeriodoAcademico { get; set; }

    public virtual ICollection<AsignaturasMatricula> AsignaturasMatriculas { get; set; } = new List<AsignaturasMatricula>();

    public virtual Usuario IdEstudianteNavigation { get; set; } = null!;

    public virtual PeriodoAcademico IdPeriodoAcademicoNavigation { get; set; } = null!;
}
