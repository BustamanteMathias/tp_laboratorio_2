using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region ATRIBUTOS

        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta; 
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"> Argentino, Extranjero</param>
        /// <param name="claseQueToma"> Programacion, Laboratorio, Legislacion, SPD </param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"> Argentino, Extranjero</param>
        /// <param name="claseQueToma"> Programacion, Laboratorio, Legislacion, SPD </param>
        /// <param name="estadoCuenta"> AlDia, Deudor, Becado </param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Muestra datos completos de la clase, nombre completo, nacionalidad, legajo y su estado de cuenta
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return string.Format("{0}\nEstado de cuenta: {1}\n", base.MostrarDatos(), this.estadoCuenta.ToString());
        }

        /// <summary>
        /// Un alumno es diferente a una clase cuando no esta en ella
        /// </summary>
        /// <param name="a"> Alumno </param>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD </param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            bool rtn = false;
            if (a.claseQueToma != clase)
            {
                rtn = true;
            }
            return rtn;
        }

        /// <summary>
        /// Un alumno es igual a una clase si su clase es la misma y su estado no es deudor
        /// </summary>
        /// <param name="a"> Alumno </param>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            bool rtn = false;
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                rtn = true;
            }
            return rtn;
        }

        /// <summary>
        /// Retorna la clase que toma
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASE DE {0}\n", this.claseQueToma.ToString());
        }

        /// <summary>
        /// Muestra datos completos de la clase, nombre completo, nacionalidad, legajo, estado de cuenta y la clase que toma
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.MostrarDatos());
            sb.AppendFormat("TOMA CLASES DE: {0}\n", this.claseQueToma.ToString());
            return sb.ToString();
        } 
        #endregion
    }
}
