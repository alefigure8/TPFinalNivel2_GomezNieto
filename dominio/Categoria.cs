using System.ComponentModel;

namespace dominio
{
    public class Categoria
    {
        public int Id { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public Categoria()
        {
            this.Descripcion = string.Empty;
        }
        public override string ToString()
        {
            return Descripcion;
        }
    }

}
