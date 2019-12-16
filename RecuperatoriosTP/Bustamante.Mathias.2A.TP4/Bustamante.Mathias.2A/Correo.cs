using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bustamante.Mathias._2A
{
    /// <summary>
    /// Implementar� la interfaz IMostrar con List<Paquete> como su tipo generico
    /// </summary>
    public class Correo : IMostrar<List<Paquete>>
    {
        #region ATRIBUTOS
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region PROPIEDAD
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }
        #endregion

        #region CONSTRUCTOR
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        #endregion

        #region METODOS

        /// <summary>
        /// Cerrar� todos los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            if (!object.Equals(this.mockPaquetes, null))
            {
                foreach (Thread item in this.mockPaquetes)
                {
                    if (item.IsAlive)
                    {
                        item.Abort();
                    }
                }
            }
        }

        /// <summary>
        /// Retornara informacion de cada uno de los paquetes que contenga la lista.
        /// </summary>
        /// <param name="elementos"> Lista de paquetes </param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            Correo p = (Correo)elementos;
            StringBuilder s = new StringBuilder();

            foreach (Paquete item in p.Paquetes)
            {
                s.AppendLine(item.ToString());
            }

            return s.ToString();
        }

        /// <summary>
        /// De no estar repetido, agrega el paquete a la lista de paquetes. Si el paquete ya se encuentra en la lista genera Exception TrackingIdRepetidoException
        /// </summary>
        /// <param name="c"> Correo con su lista </param>
        /// <param name="p"> Paquete a agregar en lista </param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            bool flagRepetido = false;

            if (!object.Equals(p, null))
            {
                foreach (Paquete item in c.Paquetes)
                {
                    if (item == p)
                    {
                        flagRepetido = true;
                        throw new TrackingIdRepetidoException("El paquete ya esta en la lista.");
                    }
                }

                if (!flagRepetido)
                {
                    c.Paquetes.Add(p);

                    Thread thread = new Thread(p.MockCicloDeVida);
                    c.mockPaquetes.Add(thread);
                    thread.Start();
                }
            }

            return c;
        } 
        #endregion
    }
}
