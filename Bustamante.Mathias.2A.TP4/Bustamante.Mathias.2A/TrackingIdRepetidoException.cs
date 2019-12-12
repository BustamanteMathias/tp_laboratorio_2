using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bustamante.Mathias._2A
{
    public class TrackingIdRepetidoException : Exception
    {
        #region CONSTRUCTORES
        public TrackingIdRepetidoException(string mensaje) : base (mensaje)
        {
        }

        public TrackingIdRepetidoException(string mensaje, Exception inner) : base (mensaje, inner)
        {
        } 
        #endregion
    }
}
