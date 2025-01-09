using System;
using System.Collections.Generic;

namespace Api.Domain;

public partial class Usuario
{
    public long Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<AsignaturasEstudiante> AsignaturasEstudianteIdEstudianteNavigations { get; set; } = new List<AsignaturasEstudiante>();

    public virtual ICollection<AsignaturasEstudiante> AsignaturasEstudianteIdProfesorNavigations { get; set; } = new List<AsignaturasEstudiante>();

    public virtual ICollection<Credito> Creditos { get; set; } = new List<Credito>();

    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();
}
