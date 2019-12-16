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
        /// <summary>
        /// M�todo de extensi�n para la clase String. Guarda archivo de texto en el escritorio de la m�quina.
        /// </summary>
        /// <param name="texto"> Valor actual del String </param>
        /// <param name="archivo"> Nombre del archivo a guardar </param>
        /// <returns></returns>
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
