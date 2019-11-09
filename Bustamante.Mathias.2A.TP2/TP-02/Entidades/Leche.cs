using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        #region Enumerados
        public enum ETipo { Entera, Descremada }
        #endregion

        #region Atributo
        private ETipo tipo;
        #endregion

        #region Constructores
        /// <summary>
        /// Por defecto, TIPO será ENTERA y se instanciara con sus atributos pasados como parametros
        /// </summary>
        /// <param name="marca"> Marca del producto </param>
        /// <param name="codigo"> Codigo de barras del producto </param>
        /// <param name="color"> Color de empaque del producto </param>
        public Leche(EMarca marca, string codigo, ConsoleColor color) : base(marca, codigo, color)
        {
            this.tipo = ETipo.Entera;
        }

        /// <summary>
        /// Se instanciara con sus atributos pasados como parametros
        /// </summary>
        /// <param name="marca"> Marca del producto </param>
        /// <param name="codigo"> Codigo de barras del producto </param>
        /// <param name="color"> Color de empaque del producto </param>
        /// <param name="tipo"> Tipo de producto: Entera, Descremada</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo) : this(marca, codigo, color)
        {
            this.tipo = tipo;
        } 
        #endregion

        #region Propiedad
        /// <summary>
        /// Leche tiene 20 calorías
        /// </summary>
        protected new short CantidadCalorias
        {
            get
            {
                return 20;
            }
        } 
        #endregion

        #region Metodo
        /// <summary>
        /// Retorna toda la informacion del productomas el tipo y sus atributos
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendFormat("TIPO : {0}", this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        } 
        #endregion
    }
}
