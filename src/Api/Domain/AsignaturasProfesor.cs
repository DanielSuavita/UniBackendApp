using System;
using System.Collections.Generic;

namespace Api.Domain;

public partial class AsignaturasProfesor
{
    public long Id { get; set; }

    public long IdProfesor { get; set; }

    public long IdAsignatura { get; set; }

    public virtual Asignatura IdAsignaturaNavigation { get; set; } = null!;

    public virtual Usuario IdProfesorNavigation { get; set; } = null!;
}
