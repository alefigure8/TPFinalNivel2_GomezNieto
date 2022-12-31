﻿using System;
using System.ComponentModel;

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

        public Producto()
        { 
            this.Codigo = String.Empty;
            this.Nombre = String.Empty;
            this.Descripcion = String.Empty;
            this.ImagenURL = String.Empty;
            this.Precio = 0;
        }
    }
}
