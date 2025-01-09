using System;
using System.Collections.Generic;

namespace Api.Domain;

public partial class Rol
{
    public long Id { get; set; }

    public string? Rol1 { get; set; }

    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();
}
