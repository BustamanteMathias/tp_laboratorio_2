using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bustamante.Mathias._2A
{
    /// <summary>
    /// Implementa interfaz IMostrar con su tipo generico Paquete
    /// </summary>
    public class Paquete : IMostrar<Paquete>
    {

        #region ATRIBUTOS
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region PROPIEDADES
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }
        #endregion

        #region TIPOS ANIDADOS
        public delegate void DelegadoEstado(object sender, EventArgs e);
        #endregion

        #region EVENTOS
        public event DelegadoEstado InformaEstado;
        #endregion

        #region ENUMERADOS
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion

        #region CONSTRUCTOR
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Retorna informacion del Paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("{0}", this.MostrarDatos(this));
            s.AppendFormat(" ({0})", this.Estado.ToString());

            return s.ToString();
        }

        /// <summary>
        /// Har� que el paquete cambie de estadoentre INGRESADO - EN VIAJE - ENTREGADO colocando demora de 4seg entre cada uno y hace INSERT a la tabla DB
        /// </summary>
        public void MockCicloDeVida()
        {
            try
            {
                while (this.Estado != EEstado.Entregado)
                {
                    if (this.Estado == EEstado.Ingresado)
                    {
                        Thread.Sleep(4000);
                        this.Estado = EEstado.EnViaje;
                        this.InformaEstado(this.Estado, EventArgs.Empty);
                    }
                    else
                    {
                        Thread.Sleep(4000);
                        this.Estado = EEstado.Entregado;
                        this.InformaEstado(this.Estado, EventArgs.Empty);
                    }
                }
                PaqueteDAO.Insertar(this);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Retorna la informacion de este paquete
        /// </summary>
        /// <param name="elemento"> Elemento a informar </param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;

            return string.Format("{0} para {1}", p.TrackingID, p.DireccionEntrega);
        }

        /// <summary>
        /// Dos paquetes ser�n iguales siempre y cuando su Tracking ID sea el mismo.
        /// </summary>
        /// <param name="p1"> Paquete 1 </param>
        /// <param name="p2"> Paquete 2 </param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (!(object.Equals(p1, null)) && !(object.Equals(p2, null)))
            {
                if (p1.TrackingID == p2.TrackingID)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Dos paquetes ser�n distintos siempre y cuando su Tracking ID sea diferente.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
