using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region ATRIBUTOS
        public enum ENacionalidad { Argentino, Extranjero }

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado apellido, valida internamente la carga correcta del dato
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = ValidarNombreApellido(value); }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado dni, valida internamente la carga correcta del dato
        /// </summary>
        public int DNI
        {
            get { return this.dni; }
            set { this.dni = ValidadDni(this.nacionalidad, value); }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado nombre, valida internamente la carga correcta del dato
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = ValidarNombreApellido(value); }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado dni, valida internamente la carga correcta del dato
        /// </summary>
        public string StringToDNI
        {
            set { this.dni = ValidadDni(this.Nacionalidad, value); }
        }
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        public Persona()
        {

        }
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"> Argentino, Extranjero </param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"> Argentino, Extrajero </param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Retorna nombre completo y su nacionalidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("NOMBRE COMPLETO: {0}, {1}\nNACIONALIDAD: {2}\n", this.Apellido, this.Nombre, this.Nacionalidad);
        }

        /// <summary>
        /// Valida el rango del DNI dependiendo su nacionalidad
        /// </summary>
        /// <param name="nacionalidad"> Argentino, Extranjero </param>
        /// <param name="dato"> DNI formato int </param>
        /// <returns></returns>
        private int ValidadDni(ENacionalidad nacionalidad, int dato)
        {
            int rtn = ValidadDni(nacionalidad, dato.ToString());
            return rtn;
        }

        /// <summary>
        /// Valida el rango del DNI dependiendo su nacionalidad
        /// </summary>
        /// <param name="nacionalidad"> Argentino, Extranjero  </param>
        /// <param name="dato"> DNI formato string </param>
        /// <returns></returns>
        private int ValidadDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            int rtn = 0;

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:

                    if (int.TryParse(dato, out dni))
                    {
                        if (dni > 0 && dni < 90000000)
                        {
                            rtn = dni;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException();
                        }
                    }
                    else
                    {
                        throw new DniInvalidoException();
                    }
                    break;
                case ENacionalidad.Extranjero:

                    if (int.TryParse(dato, out dni))
                    {
                        if (dni >= 90000000 && dni < 100000000)
                        {
                            rtn = dni;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException();
                        }
                    }
                    else
                    {
                        throw new DniInvalidoException();
                    }
                    break;
            }
            return rtn;
        }

        /// <summary>
        /// Valida si es correcto el tipo de dato para nombre y apellido
        /// </summary>
        /// <param name="dato"> Nombre/Apellido </param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string rtn = "";
            bool flag = false;

            foreach (char item in dato)
            {
                if (char.IsDigit(item))
                {
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                rtn = dato;
            }

            return rtn;
        }
        #endregion
    }
}
