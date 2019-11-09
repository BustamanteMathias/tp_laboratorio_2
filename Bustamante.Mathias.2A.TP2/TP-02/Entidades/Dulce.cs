using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        #region Constructor
        /// <summary>
        /// Se instanciara con sus atributos pasados como parametros
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Dulce(EMarca marca, string codigo, ConsoleColor color) : base(marca, codigo, color)
        {

        } 
        #endregion

        #region Propiedad
        /// <summary>
        /// Dulces tiene 80 calorías
        /// </summary>
        protected new short CantidadCalorias
        {
            get
            {
                return 80;
            }
        } 
        #endregion

        #region Metodo
        /// <summary>
        /// Retorna toda la informacion del productomas el tipo y sus atributos
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        } 
        #endregion
    }
}
