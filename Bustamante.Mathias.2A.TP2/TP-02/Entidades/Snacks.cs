using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        #region Constructor
        /// <summary>
        /// Se instanciara con sus atributos pasados como parametros
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Snacks(EMarca marca, string codigo, ConsoleColor color) : base(marca, codigo, color)
        {
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Snacks tiene 104 calorías
        /// </summary>
        protected new short CantidadCalorias
        {
            get
            {
                return 104;
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

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        } 
        #endregion
    }
}
