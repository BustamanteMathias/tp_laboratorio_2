using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bustamante.Mathias._2A
{
    public static class GuardarString
    {
        #region METODO DE EXTENSION
        public static bool Guardar(this string texto, string archivo)
        {
            string pathEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";

            try
            {
                StreamWriter f = new StreamWriter(pathEscritorio + archivo + ".txt", true);
                f.WriteLine(texto);
                f.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        } 
        #endregion
    }
}
