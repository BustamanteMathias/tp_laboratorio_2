using Entidades;
using System;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        #region Constructor
        /// <summary>
        /// Constructor del formulario
        /// </summary>
        public FormCalculadora()                                                    //CONSTRUCTOR DE FORMULARIO, CARGA DE ITEMS DE COMBOBOX
        {
            InitializeComponent();
            cmbOperador.Items.Add("/");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("+");
        }
        #endregion

        #region Inicializar UI
        private void MiCalculadora_Load(object sender, EventArgs e)                 //INICIALIZAR UI
        {
            this.Text = "Calculadora de Bustamante Mathias del curso 2°A";
            this.btnOperar.Text = "Operar";
            this.btnCerrar.Text = "Cerrar";
            this.btnLimpiar.Text = "Limpiar";
            this.btnConvertirABinario.Text = "Convertir a Binario";
            this.btnConvertirADecimal.Text = "Convertir a Decimal";
            this.lblResultado.Text = "0";
            this.cmbOperador.Text = "/";
        }
        #endregion

        #region Eventos
        private void btnConvertirADecimal_Click(object sender, EventArgs e)         //EVENTO CLICK BOTON CONVERTIR A DECIMAL.
        {
            Numero n = new Numero();
            string rtn = n.BinarioDecimal(this.lblResultado.Text);
            this.lblResultado.Text = rtn;
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)         //EVENTO CLICK BOTON CONVERTIR A BINARIO.
        {

            Numero n = new Numero();
            string rtn = n.DecimalBinario(this.lblResultado.Text);
            this.lblResultado.Text = rtn;

        }

        private void btnCerrar_Click(object sender, EventArgs e)                    //EVENTO CLICK BOTON CERRAR, cierra formulario.
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)                   //EVENTO CLICK BOTON LIMPIAR, limpia Formulario.
        {
            this.Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)                    //EVENTO CLICK BOTON OPERAR, realiza operacion entre los operandos.
        {
            this.lblResultado.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
        }

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)   //EVENTO CLICK MENU DESPLEGABLE, se valida solo uso de operadores seteados.
        {
            this.cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// borra los datos de los TextBox, ComboBox y Label del formulario
        /// </summary>
        private void Limpiar()
        {
            this.lblResultado.Text = "0";
            this.txtNumero1.Text = "0";
            this.txtNumero2.Text = "0";
            this.cmbOperador.Text = "/";
        }

        /// <summary>
        /// El metodo recibira los dos números y el operador para luego llamar al método Operar de Calculadora y retornar el resultado
        /// </summary>
        /// <param name="numero1">Tomado del TextBox1</param>
        /// <param name="numero2">Tomado del TextBox2</param>
        /// <param name="operador">Tomado del ComboBox, operador de calculo</param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double rtn;

            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);

            rtn = Calculadora.Operar(n1, n2, operador);

            return rtn;
        }
        #endregion
        
    }
}
