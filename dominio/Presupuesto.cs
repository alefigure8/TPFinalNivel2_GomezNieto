using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Presupuesto : Producto
    {
        public int cantidad { get; set; }
        public decimal total { get; set; }
    }
}
