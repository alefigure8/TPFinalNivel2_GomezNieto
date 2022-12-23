using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace helper
{
    public static class Validacion
    {
        public static bool esNumero(string numero)
        {
            decimal validar;
            if(decimal.TryParse(numero, out validar))
            {
                return true;
            }

            return false;
        }

        public static List<bool> estaVacio(List<TextBox> list)
        {
            List<bool> bools= new List<bool>();

            foreach(TextBox item in list)
            {
                if (string.IsNullOrEmpty(item.Text))
                {
                    bools.Add(true);
                }
                else
                {
                    bools.Add(false);

                }
            }

            return bools;
        }

        public static bool estaSeleccionado(ComboBox combo)
        {
            if (combo.SelectedIndex < 0)
            {
                return false;
            }

            return true;
        }

    }
}
