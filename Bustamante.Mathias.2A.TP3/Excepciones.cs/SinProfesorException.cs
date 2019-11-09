using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Excepcion que controla si hay profesor para alguna de estas clases. Programacion, Laboratorio, Legislacion, SPD 
        /// </summary>
        public SinProfesorException() : base("No hay profesor para la clase.")
        {
        } 
        #endregion
    }
}
