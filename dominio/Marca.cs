using System.ComponentModel;


namespace dominio
{
    public class Marca
    {
        public int Id { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        public Marca()
        {
            this.Descripcion = string.Empty;
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
