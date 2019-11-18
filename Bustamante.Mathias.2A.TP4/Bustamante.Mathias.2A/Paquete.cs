using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bustamante.Mathias._2A
{
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
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("{0}", this.MostrarDatos(this));
            s.AppendFormat(" ({0})", this.Estado.ToString());

            return s.ToString();
        }

        public void MockCicloDeVida()
        {

            try
            {
                while (this.Estado != EEstado.Entregado)
                {
                    if (this.Estado == EEstado.Ingresado)
                    {

                        Console.WriteLine("ENTRE A CAMBIAR ESTADO... EnViaje");
                        Thread.Sleep(4000);
                        this.Estado = EEstado.EnViaje;

                        this.InformaEstado(this.Estado, EventArgs.Empty);

                        Console.WriteLine(this.ToString());
                    }
                    else
                    {

                        Console.WriteLine("ENTRE A CAMBIAR ESTADO... Entregado");
                        Thread.Sleep(4000);
                        this.Estado = EEstado.Entregado;

                        this.InformaEstado(this.Estado, EventArgs.Empty);

                        Console.WriteLine(this.ToString());
                    }
                }

                Console.WriteLine("ENTRE A LA FUNCION INSERTAR");
                PaqueteDAO.Insertar(this);
                Console.WriteLine("SALI DE LA FUNCION INSERTAR");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;

            return string.Format("{0} para {1}", p.TrackingID, p.DireccionEntrega);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool rtn = false;

            if (!(object.Equals(p1, null)) && !(object.Equals(p2, null)))
            {
                if (p1.TrackingID == p2.TrackingID)
                {
                    rtn = true;
                }
            }
            return rtn;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
