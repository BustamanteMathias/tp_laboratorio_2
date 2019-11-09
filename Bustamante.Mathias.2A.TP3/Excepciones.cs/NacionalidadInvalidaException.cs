using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        #region CONSTRUCTORES
        /// <summary>
        /// Excepcion que controla el DNI si corresponde a su nacionalidad con mensaje
        /// </summary>
        public NacionalidadInvalidaException() : base("La nacionalidad no se coincide con el numero de DNI.")
        {
        }

        /// <summary>
        /// Excepcion que controla el DNI si corresponde a su nacionalidad con mensaje recibido como parametro
        /// </summary>
        /// <param name="message"> Mensaje </param>
        public NacionalidadInvalidaException(string message) : base(message)
        {
        } 
        #endregion
    }
}
