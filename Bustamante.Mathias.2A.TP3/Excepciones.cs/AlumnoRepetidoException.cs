using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Excepcion que controla si la clase Alumno esta repetido con mensaje
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido.")
        {
        } 
        #endregion
    }
}
