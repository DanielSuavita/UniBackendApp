using System;
using System.Collections.Generic;

namespace Api.Domain;

public partial class UsuarioRol
{
    public long Id { get; set; }

    public long IdUsuario { get; set; }

    public long IdRol { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
