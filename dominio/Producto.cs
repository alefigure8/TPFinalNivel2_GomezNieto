using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Producto
    {
        public int Id { get; set; }
        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public string ImagenURL { get; set; }
        [DisplayName("Marca")]
        public Marca MarcaInfo { get; set; }
        [DisplayName("Categoria")]
        public Categoria CategoriaInfo{ get; set; }

        public decimal Precio { get; set; }
    }
}
