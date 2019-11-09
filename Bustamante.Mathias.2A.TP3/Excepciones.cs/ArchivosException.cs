using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Excepcion que controla si el el archivo es null
        /// </summary>
        /// <param name="e"> Excepcion </param>
        public ArchivosException(Exception e) : base("Archivo Exception")
        {
        } 
        #endregion
    }
}
