using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using configuracion;

namespace helper
{
    static public class Metodos
    {
        static public void copiarImagen(Producto producto, OpenFileDialog file, TextBox txtImagen)
        {
            string path = ConfigurationManager.AppSettings[Opciones.Folder.IMAGE];
            //string path = Path.GetDirectoryName(Application.StartupPath) + Opciones.Folder.IMAGE + file.SafeFileName;
            //Path.GetDirectoryName(Directory.GetCurrentDirectory().Replace(@"\bin", "")) + Opciones.Folder.IMAGE
            Console.WriteLine(path);
            if (!Directory.Exists(path))
            {                                      
                Directory.CreateDirectory(path);
            }

            try
            {
                File.Copy(file.FileName, path + file.SafeFileName);
                producto.ImagenURL = path + file.SafeFileName;
                txtImagen.Text = path + file.SafeFileName;
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show("El archivo ya existe. ¿Desea Remplazarlo?", "Ya existe", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    File.Delete(path + file.SafeFileName);
                    File.Copy(file.FileName, path + file.SafeFileName);
                    producto.ImagenURL = path + file.SafeFileName;
                    txtImagen.Text = path + file.SafeFileName;
                }
                else
                {
                    throw ex;
                }
            }
        }

        static public bool borrarImagen(Producto producto, OpenFileDialog file, TextBox txtImagen)
        {
            try
            {
                //string path = producto.ImagenURL;
                //File.Delete(path);
                producto.ImagenURL = "";
                txtImagen.Text = "";

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
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
                string path = Path.GetDirectoryName(Directory.GetCurrentDirectory().Replace(@"\bin", "")) + Opciones.Folder.ROOTIMAGE;
                pictureBox.Load(path + Opciones.Folder.PLACEHOLDER);
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

        public static void buscarEnLista<T>(List<T> listaCategoria, ComboBox combo, Button btn)
        {
            if ((listaCategoria.Any(x => x.ToString() == combo.Text)))
            {
                btn.Visible = true;
            }
            else
            {
                btn.Visible = false;
            }
        }
    }
}
