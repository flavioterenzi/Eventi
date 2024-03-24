using System;
using System.Collections.Generic;

namespace Eventi.Models;

public partial class Contiene
{
    public int ContieneId { get; set; }

    public int PartecipanteRif { get; set; }

    public int EventiRif { get; set; }

    public virtual Evento EventiRifNavigation { get; set; } = null!;

    public virtual Partecipante PartecipanteRifNavigation { get; set; } = null!;
}
