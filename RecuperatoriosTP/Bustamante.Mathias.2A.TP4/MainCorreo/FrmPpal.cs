using Bustamante.Mathias._2A;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        #region ATRIBUTOS
        private Correo correo;
        #endregion

        #region CONSTRUCTOR
        public FrmPpal()
        {
            InitializeComponent();

            this.Text = "Correo UTN por Mathias.Bustamante.2A";
            this.groupBox1.Text = "Estados Paquetes";
            this.groupBox2.Text = "Paquete";
            this.lblEstadoIngresado.Text = "Ingresado";
            this.lblEstadoEnViaje.Text = "En Viaje";
            this.lblEstadoEntregado.Text = "Entregado";
            this.lblTrakingID.Text = "Traking ID";
            this.lblDireccion.Text = "Dirección";
            this.btnAgregar.Text = "Agregar";
            this.btnMostrarTodos.Text = "Mostrar Todos";
        }
        #endregion

        #region METODOS
        
        /// <summary>
        /// Actualiza estados de Paquetes en ListBox
        /// </summary>
        private void ActualizarEstados()
        {
            LimpiarListBox();

            foreach (Paquete item in this.correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(item);
                        break;

                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(item);
                        break;

                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(item);
                        break;
                }
            }

            void LimpiarListBox()
            {
                this.lstEstadoIngresado.Items.Clear();
                this.lstEstadoEnViaje.Items.Clear();
                this.lstEstadoEntregado.Items.Clear();
            }
        }

        /// <summary>
        /// Actualiza estados de los Paquetes en RichBox.
        /// </summary>
        /// <typeparam name="T"> Clase generica proveniente de interfaz </typeparam>
        /// <param name="elemento"> Elemento a agregar en RichBox </param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!object.Equals(elemento, null))
            {
                string info = string.Empty;
                Correo c;
                Paquete p;

                if (elemento is Correo)
                {
                    c = (Correo)elemento;
                    foreach (Paquete item in c.Paquetes)
                    {
                        info += item.ToString() + "\n";
                    }
                }
                else
                {
                    p = (Paquete)elemento;
                    info += p.ToString() + "\n";
                }
                
                this.rtbMostrar.Text = info;
                info.Guardar("Salida");
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                (elemento.MostrarDatos(elemento)).Guardar("salida");
            }
        }
        #endregion

        #region EVENTOS
        /// <summary>
        /// Evento LOAD de formulario.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.correo = new Correo();
        }

        /// <summary>
        /// Evento de botón AGREGAR, insertara Paquete al proceso de envio.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = null;

            if ((this.mtxtTrakingID.Text == string.Empty) || (this.txtDireccion.Text == string.Empty))
            {
                MessageBox.Show("   LLENAR TODOS LOS CAMPOS!\n- Tracking ID\n- Direccion");
            }
            else
            {
                p = new Paquete(this.txtDireccion.Text, this.mtxtTrakingID.Text);
                p.InformaEstado += this.paq_InformaEstado;
            }

            try
            {
                this.correo += p;
            }
            catch (TrackingIdRepetidoException tError)
            {
                MessageBox.Show(tError.Message);
            }
            catch (Exception)
            {
            }
            finally
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// Evento CLOSING del formulario.
        /// </summary>ç
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// Evento del botón MOSTRAR TODOS. Actualiza estados en RichBox de Paquetes en cursos.
        /// </summary>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Evento que retorna estado del Paquete.
        /// </summary>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// Evento de Click Secundario en el Form que actualizara estados en RichBox.
        /// </summary>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
        #endregion
    }
}
