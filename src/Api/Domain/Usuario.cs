using System;
using System.Collections.Generic;

namespace Api.Domain;

public partial class Usuario
{
    public long Id { get; set; }

    public string? Nombre { get; set; }

    public string? Documento { get; set; }

    public virtual ICollection<AsignaturasMatricula> AsignaturasMatriculas { get; set; } = new List<AsignaturasMatricula>();

    public virtual ICollection<AsignaturasProfesor> AsignaturasProfesors { get; set; } = new List<AsignaturasProfesor>();

    public virtual ICollection<Credito> Creditos { get; set; } = new List<Credito>();

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();

    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();
}
