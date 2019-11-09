using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region ATRIBUTOS
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Propiedad de lectura y escritura de la lista privada como atributo alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atriburo privado clase
        /// </summary>
        public EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        /// <summary>
        /// propiedad de lectura y escritura del atributo privado instructor
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        } 
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de instancia privado
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD </param>
        /// <param name="instructor"> Profesor </param>
        public Jornada(EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Metodo de clase que garda en formato .txt la lista de Jornada que recibe como parametro
        /// </summary>
        /// <param name="jornada"> Lista del tipo Jornada a guardar</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            bool rtn = false;
            string path = AppDomain.CurrentDomain.BaseDirectory;

            Texto auxTexto = new Texto();
            rtn = auxTexto.Guardar(path + @"Jornada.txt", jornada.ToString());

            return rtn;
        }

        /// <summary>
        /// Metodo de clase que lee un archivo .txt en su directorio
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto auxTexto = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory;

            if (!auxTexto.Leer(path + @"Jornada.txt", out string rtn))
            {
                rtn = null;
            }

            return rtn.ToString();
        }

        /// <summary>
        /// Metodo de clase donde una Jornada no es igual a un alumno si este no este no cursa la clase de la Jornada
        /// </summary>
        /// <param name="j"> Jornada </param>
        /// <param name="a"> Alumno </param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Metodo de clase, donde una Jornada es igual a un alumno si este pertenece a la clase de esta Jornada
        /// </summary>
        /// <param name="j"> Jornada </param>
        /// <param name="a"> Alumno </param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return a == j.Clase;
        }

        /// <summary>
        /// Metodo de clase que a�ade a un alumno a la jornada si este no esta ya en ella
        /// </summary>
        /// <param name="j"> Jornada </param>
        /// <param name="a"> Alumno </param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool flag = false;
            foreach (Alumno item in j.Alumnos)
            {
                if (j == a && item == a)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// Retorna toda la informacion de la Jornada con todos sus alumnos y su informacion personal
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            if (this.Alumnos.Count > 0)
            {
                sb.Append("\nJORNADA:\n");
                sb.AppendFormat("CLASE DE: {0}. POR {1}\nALUMNOS:\n", this.Clase.ToString(), this.Instructor.ToString());

                foreach (Alumno item in this.Alumnos)
                {
                    sb.AppendFormat("{0}\n", item.ToString());
                }

                sb.AppendLine("<------------------------------------------------->\n");
            }

            return sb.ToString();
        } 
        #endregion
    }
}
