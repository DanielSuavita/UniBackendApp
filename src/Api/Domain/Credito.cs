using System;
using System.Collections.Generic;

namespace Api.Domain;

public partial class Credito
{
    public long Id { get; set; }

    public int? Cantidad { get; set; }

    public long IdUsuario { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
