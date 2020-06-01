using System;
using System.Collections.Generic;

namespace WSVentas.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Ventas = new HashSet<Ventas>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
