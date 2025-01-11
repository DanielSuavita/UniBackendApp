using System;
using System.Collections.Generic;

namespace Api.Domain;

public partial class AsignaturasMatricula
{
    public long Id { get; set; }

    public long IdAsignatura { get; set; }

    public long IdMatricula { get; set; }

    public long IdProfesor { get; set; }

    public virtual Asignatura IdAsignaturaNavigation { get; set; } = null!;

    public virtual Matricula IdMatriculaNavigation { get; set; } = null!;

    public virtual Usuario IdProfesorNavigation { get; set; } = null!;
}
