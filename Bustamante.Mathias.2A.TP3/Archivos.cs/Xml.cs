using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml <T> : IArchivo <T>
    {
        #region METODOS
        /// <summary>
        /// Guarda en formato serializado .xml cualquier tipo de clase.
        /// </summary>
        /// <param name="archivo"> Parth del archivo</param>
        /// <param name="datos"> Cualquier tipo de dato a guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            bool rtn = false;
            try
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                StreamWriter f = new StreamWriter(archivo);
                s.Serialize(f, datos);
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
        /// Le� archivo serializado .xml y retorna el tipo de clase en salida por parametro.
        /// </summary>
        /// <param name="archivo"> Path del archivo </param>
        /// <param name="datos"> Salida de cualquier tipo de dato leido </param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            bool rtn = false;

            try
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                StreamReader f = new StreamReader(archivo);
                datos = (T)s.Deserialize(f);
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
