using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bustamante.Mathias._2A
{
    public class TrackingIdRepetidoException : Exception
    {
        #region CONSTRUCTORES
        public TrackingIdRepetidoException(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        public TrackingIdRepetidoException(string mensaje, Exception inner)
        {
            MessageBox.Show(mensaje + inner.Message);
        } 
        #endregion
    }
}
