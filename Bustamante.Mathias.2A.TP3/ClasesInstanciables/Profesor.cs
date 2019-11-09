using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region ATRIBUTOS
        private Queue<EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de clase
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Constructor de instancia privado
        /// </summary>
        private Profesor()
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Constructor de instancia 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"> Argentino, Extranjero </param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Profesor().clasesDelDia;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Metodo privado donde asigna dos clases a un instructor
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                switch (random.Next(4))
                {
                    case 0:
                        this.clasesDelDia.Enqueue(EClases.Programacion);
                        break;
                    case 1:
                        this.clasesDelDia.Enqueue(EClases.Laboratorio);
                        break;
                    case 2:
                        this.clasesDelDia.Enqueue(EClases.Legislacion);
                        break;
                    case 3:
                        this.clasesDelDia.Enqueue(EClases.SPD);
                        break;
                }
            }
        }

        /// <summary>
        /// Muestra datos completos de la clase. Nombre completo, nacionalidad y su legajo.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos();
        }

        /// <summary>
        /// Retorna nombre completo, su nacionalidad y las dos clases que de ese dia
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n");
            foreach (EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return string.Format("{0}\nCLASES DEL DÍA {1}\n", base.ToString(), sb.ToString());
        }

        /// <summary>
        /// Retorna nombre completo, nacionalidad, su legajo y las clases que da por dia
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n");
            foreach (EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return string.Format("{0}\nCLASES DEL DIA: {1}", this.MostrarDatos(), sb.ToString());
        }

        /// <summary>
        /// Un profesor no es igual a una clase si este no la dicta
        /// </summary>
        /// <param name="i"> Profesor </param>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD </param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Un profesor es igual a una clase si este la da en sus dias
        /// </summary>
        /// <param name="i"> Profesor </param>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD </param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool rtn = false;
            foreach (EClases item in i.clasesDelDia)
            {
                if (item == clase)
                {
                    rtn = true;
                    break;
                }
            }
            return rtn;
        } 
        #endregion
    }
}
