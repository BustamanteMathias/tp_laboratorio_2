using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bustamante.Mathias._2A
{
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
