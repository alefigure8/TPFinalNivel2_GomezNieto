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

        public static bool estaVacio(List<string> list)
        {
            if(list.Contains("") && list.Contains(null))
            {
                return true;
            }

            return false;
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
