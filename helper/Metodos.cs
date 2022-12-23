using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace helper
{
    static public class Metodos
    {
        static public void copiarImagen(Producto producto, OpenFileDialog file)
        {
            string path = ConfigurationManager.AppSettings["images-folder"] + file.SafeFileName;
            try
            {
                File.Copy(file.FileName, path);
                producto.ImagenURL = path;
            }
            catch (Exception ex)
            {
                // DialogResult result = MessageBox.Show("El archivo ya existe. ¿Desea Remplazarlo?", "Ya existe", MessageBoxButtons.OKCancel);

                //if (result == DialogResult.OK)
                //{
                //    File.Delete(path);
                //    File.Copy(file.FileName, path);
                //    producto.ImagenURL = path;
                //}
                //else
                //{
                    throw ex;
                //}

            }
        }

        public static void cargarimagen(PictureBox pictureBox, string image)
        {
            try
            {
                pictureBox.Load(image);
            }
            catch (Exception ex)
            {
                pictureBox.Load("https://i0.wp.com/thealmanian.com/wp-content/uploads/2019/01/product_image_thumbnail_placeholder.png");
            }
        }

        public static void vaciarTextBox(List<TextBox> lista)
        {
            foreach (var item in lista)
            {
                item.Text = string.Empty;
            }
        }

        public static void mostrarErrorCampoVacio(List<TextBox> listaTextBox, List<Label> listaLabel)
        {
            List<bool> boolsTxt = Validacion.estaVacio(listaTextBox);

            if (boolsTxt.Contains(true))
            {
                for (int i = 0; i < listaTextBox.Count(); i++)
                {
                    if (boolsTxt[i])
                    {
                        listaLabel[i].Visible = boolsTxt[i];
                        agregarToolTip(listaLabel[i], "Todos los campos son obligatorios");
                    }
                }
            }
        }

        public static void agregarToolTip(Label label, string msg)
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(label, msg);
        }

        public static void errorInvisible(List<Label> listaLabel)
        {
            foreach (var item in listaLabel)
            {
                item.Visible = false;
            }
        }

        public static void disableComboBox(ComboBox combo)
        {
            combo.DropDownStyle = ComboBoxStyle.Simple;
            combo.Enabled = false;
        }

        public static void enableComboBox(ComboBox combo)
        {
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.Enabled = true;
        }

        public static void textBoxReadOnly(List<TextBox> lista, bool read = true)
        {
            if(read)
            {
                foreach (var txt in lista)
                {
                    txt.ReadOnly = true;
                }
            }
            else
            {
                foreach (var txt in lista)
                {
                    txt.ReadOnly = false;
                }
            }
        }
    }
}
