using System;
using System.Collections.Generic;

namespace Eventi.Models;

public partial class Evento
{
    public int EventiId { get; set; }

    public string Nome { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public DateTime Data { get; set; }

    public string Luogo { get; set; } = null!;

    public int CapacitaMassima { get; set; }

    public virtual ICollection<Contiene> Contienes { get; set; } = new List<Contiene>();

    public virtual ICollection<Risorsa> Risorsas { get; set; } = new List<Risorsa>();

   
}
