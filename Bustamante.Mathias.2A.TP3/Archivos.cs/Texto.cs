using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo <string>
    {
        #region METODOS
        /// <summary>
        /// Guarda cadena de texto en un archivo y retorna si lo logro con true
        /// </summary>
        /// <param name="archivo"> Path del archivo</param>
        /// <param name="datos"> Cadena de texto a guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            bool rtn = false;
            try
            {
                StreamWriter f = new StreamWriter(archivo);
                f.Write(datos);
                f.Close();
                rtn = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return rtn;
        }

        /// <summary>
        /// Recibe el path del archivo y retorna si lo logro con true, redirecciona la informacion del archivo en una salida por parametro
        /// </summary>
        /// <param name="archivo"> Path del archivo</param>
        /// <param name="datos"> Salida del archivo</param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool rtn = false;
            try
            {
                StreamReader f = new StreamReader(archivo);
                datos = f.ReadToEnd();
                f.Close();
                rtn = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return rtn;
        } 
        #endregion
    }
}
