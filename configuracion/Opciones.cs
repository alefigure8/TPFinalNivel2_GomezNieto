using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuracion
{
    public static class Opciones
    {
        public struct Folder
        {
             public const string IMAGE = "imageApp";
             public const string ROOTIMAGE = @"\img\";
             public const string ICONO = "logo_main.ico";
             public const string PRIMERO = "back_2_fill.png";
             public const string ANTERIOR = "left_fill.png";
             public const string SIGUIENTE = "right_fill.png";
             public const string ULTIMA = "forward_2_fill.png";
             public const string PLACEHOLDER = "imgPlaceholder.jpg";
             public const string IMPRIMIR = "printer_medium_icon.png";
             public const string GUARDARARCHIVO = "folder_medium_icon.png";
             public const string EXPORTAR = "export_medium_icon.png";
             public const string CONFIGURACION = "configure.png";
             public const string LOGO = "logo_generic.jpg";
             public const string ELIMINAR = "delete.png";
             public const string VERSION = "version_fill.png";
             public const string AUTOR = "user_3_fill.png";
             public const string GITHUB = "github_fill.png";
             public const string WEB = "web_fill.png";
             public const string MAIL = "mail_fill.png";
        }
        public struct Buscador
        {
            public const string TODOS = ".Todos";
        }

        public struct Campo
        {
            public const string NOMBRE = "Nombre";
            public const string DESCRIPCION = "Descripcion";
            public const string PRECIO = "Precio";
            public const string CODIGO = "Codigo";
            public const string CATEGORIA = "Categoria";
            public const string MARCA = "Marca";
            public const string ID = "Id";
            public const string URLIMAGEN = "ImagenUrl";
            public const string IDMARCA = "IdMarca";
            public const string IDCATEGORIA = "IdCategoria";
            public const string DESCMARCA = "MarcaDescripcion";
            public const string DESCCATEGORIA = "CategoriaDescripcion";
        }

        public struct Numero
        {
            public const string CINCUENTA = "50";
            public const string TREINTA = "30";
            public const string VEINTE = "20";
            public const string DIEZ = "10";
        }

        public struct CriterioTexto
        {
            public const string INCLUYE = "Alguna Palabra";
            public const string CONTIENE = "Palabra Exacta";
            public const string EMPIEZA = "Empieza con";
            public const string TERMINA = "Termina con";
        }

        public struct CriterioNumero
        {
            public const string MENOR = "Menor a";
            public const string IGUAL = "Igual a";
            public const string MAYOR = "Mayor a";
        }

        public struct MensajeError
        {
            public const string LISTAERROR = "La lista no pudo cargarse";
            public const string MARCAERROR = "La lista de marcas no pudo cargarse";
            public const string PRODUCTOERROR = "Los productos no pudieron cargarse";
            public const string MENSAJENUMERO = "Debe ingresar un número";
            public const string CAMPOVACIO = "Por favor, seleccione una opción";
            public const string ORDENARLISTADO = "No se pudo ordenar el listado";
            public const string ERRORCARGAMARCA = "Error al cargar en Marca";
            public const string MARCAYAEXISTE = "La Marca ya existe";
            public const string CAMPOVACIOTEXTO = "Debe completar el campo antes de enviar";
        }

        public struct MensajeExito
        {
            public const string EXITOCARGARMENSAJE = "La marca se agregó con éxito";
        }

        public struct Paginacion
        {
            public const string ADELANTE = "Adelante";
            public const string ATRAS = "Atrás";
            public const string PAGINA = "Página";
            public const string PRIMERA = "Primera";
        }

        public struct PaginacionControl
        {
            public const string ADELANTE = "adealnte";
            public const string ATRAS = "anterior";
        }

        public struct DBTablas
        {
            public const string MARCAS = "MARCAS";
            public const string CATEGORIAS = "CATEGORIAS";
            public const string ARTICULOS = "ARTICULOS";
        }

        public struct Btn
        {
            public const string AGREGAR = "Agregar";
            public const string MODIFICAR = "Modificar";
            public const string EDITAR = "Editar";
            public const string CANCELAR = "Cancelar";
            public const string REGRESAR = "Regresar";
        }

    }
}
