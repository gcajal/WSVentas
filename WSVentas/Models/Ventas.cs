using System;
using System.Collections.Generic;

namespace WSVentas.Models
{
    public partial class Ventas
    {
        public Ventas()
        {
            Concepto = new HashSet<Concepto>();
        }

        public long Id { get; set; }
        public long? IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<Concepto> Concepto { get; set; }
    }
}
