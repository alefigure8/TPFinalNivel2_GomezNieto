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
                DialogResult result = MessageBox.Show("El archivo ya existe. ¿Desea Remplazarlo?", "Ya existe", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    File.Delete(path);
                    File.Copy(file.FileName, path);
                    producto.ImagenURL = path;
                }
                else
                {
                    throw ex;
                }

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
                throw ex;
            }
        }
    }
}
