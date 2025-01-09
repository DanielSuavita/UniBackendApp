using System;
using System.Collections.Generic;

namespace Api.Domain;

public partial class AsignaturasEstudiante
{
    public long Id { get; set; }

    public long IdEstudiante { get; set; }

    public long IdAsignatura { get; set; }

    public long IdProfesor { get; set; }

    public long IdEstado { get; set; }

    public virtual Asignatura IdAsignaturaNavigation { get; set; } = null!;

    public virtual EstadoMatricula IdEstadoNavigation { get; set; } = null!;

    public virtual Usuario IdEstudianteNavigation { get; set; } = null!;

    public virtual Usuario IdProfesorNavigation { get; set; } = null!;
}
