using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Excepcion que controla el formato del DNI con mensaje
        /// </summary>
        public DniInvalidoException() : base ("DNI formato incorrecto")
        {
        }

        /// <summary>
        /// Excepcion que controla el formato del DNI sin mensaje
        /// </summary>
        /// <param name="e"> Excepcion </param>
        public DniInvalidoException(Exception e) :base( e.ToString())
        {
        }

        /// <summary>
        /// Excepcion que controla el formato del DNI con mensaje recibido como parametro
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message) : base(message)
        {
        }

        /// <summary>
        /// Excepcion que controla el formato del DNI con mensaje recibido como parametro mas el mensaje de la Excepcion base
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e) : this(message + e.ToString())
        {
        }
    }
}
