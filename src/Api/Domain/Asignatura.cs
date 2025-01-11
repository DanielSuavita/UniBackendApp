using System;
using System.Collections.Generic;

namespace Api.Domain;

public partial class Asignatura
{
    public long Id { get; set; }

    public string? Nombre { get; set; }

    public string? Codigo { get; set; }

    public int? CantidadCreditosNecesarios { get; set; }

    public virtual ICollection<AsignaturasMatricula> AsignaturasMatriculas { get; set; } = new List<AsignaturasMatricula>();

    public virtual ICollection<AsignaturasProfesor> AsignaturasProfesors { get; set; } = new List<AsignaturasProfesor>();
}
