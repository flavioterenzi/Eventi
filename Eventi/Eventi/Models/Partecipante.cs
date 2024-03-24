using System;
using System.Collections.Generic;

namespace Eventi.Models;

public partial class Partecipante
{
    public int PartecipanteId { get; set; }

    public string Nome { get; set; } = null!;

    public string Contatto { get; set; } = null!;

    public virtual ICollection<Contiene> Contienes { get; set; } = new List<Contiene>();
}
