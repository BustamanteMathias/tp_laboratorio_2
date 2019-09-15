using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos

        private double numero; 

        #endregion


        #region Constructores
        /// <summary>
        /// Por defecto el compilador inicializa el atributo double en 0.
        /// </summary>
        public Numero()
        {
        }

        /// <summary>
        /// Crea objeto Numero con el parametro double ingresado, reutiliza codigo llevandolo al constructor con parametro de string
        /// </summary>
        /// <param name="numero">Valor a setear en el atributo privado de Numero</param>
        public Numero(double numero) : this(numero.ToString())
        {
        }

        /// <summary>
        /// Crea objeto Numero con el parametro string ingresado
        /// </summary>
        /// <param name="strNumero">Valor a setear en el atributo privado de Numero</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion
        

        #region Metodos
        /// <summary>
        /// Convierte de ser posible un valor binario a decimal
        /// </summary>
        /// <param name="binario">Valor a convertir a decimal</param>
        /// <returns>De ser posible retorna valor binario convertido a decimal, de lo contrario "Valor invalido"</returns>
        public string BinarioDecimal(string binario)
        {

            char[] array = binario.ToCharArray();               // CONVIERTO STRING EN ARRAY
            Array.Reverse(array);                               // SE INVIERTE DE DERECHA A IZQUIERDA: 16-8-4-2-1

            bool validacion = true;
            int suma = 0;
            string rtn = "";

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != '0' && array[i] != '1')
                {
                    validacion = false;
                    break;
                }
            }

            if (validacion)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        suma += (int)Math.Pow(2, i);
                    }
                }

                rtn = suma.ToString();
            }
            else
            {
                rtn = "Numero Invalido";
            }

            return rtn;
        }

        /// <summary>
        /// Convierte de ser posible un valor decimal a binario recibiendo como parametro un double
        /// </summary>
        /// <param name="numero">Valor a convertir a binario</param>
        /// <returns>De ser posible retorna valor decimal convertido a binario, de lo contrario "Numero invalido"</returns>
        public string DecimalBinario(double numero)
        {
            string rtn = numero.ToString();

            rtn = DecimalBinario(rtn);

            return rtn;
        }

        /// <summary>
        /// Convierte de ser posible un valor decimal a binario recibiendo como parametro un string
        /// </summary>
        /// <param name="numero">Valor a convertir a binario</param>
        /// <returns>De ser posible retorna valor decimal convertido a binario, de lo contrario "Numero invalido</returns>
        public string DecimalBinario(string numero)
        {
            String cadena = "";
            int num;

            if (int.TryParse(numero, out num) == false)
            {
                cadena = "Numero Invalido";
            }
            else if (num > 0)
            {
                while (num > 0)
                {
                    if (num % 2 == 0)
                    {
                        cadena = "0" + cadena;
                    }
                    else
                    {
                        cadena = "1" + cadena;
                    }
                    num = (int)(num / 2);
                }
            }
            else
            {
                if (num == 0)
                {
                    cadena = "0";
                }
                else
                {
                    cadena = "Numero Invalido";
                }
            }

            return cadena;
        }

        /// <summary>
        /// Valida antes de setear el a Numero si el parametro es casteable a double
        /// </summary>
        /// <param name="strNumero">Valor a ser casteado a double</param>
        /// <returns>De ser posible castea string a double, de lo contrario retorna 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double rtn;

            if (double.TryParse(strNumero, out rtn) == false)
            {
                rtn = 0;
            }

            return rtn;
        }

        /// <summary>
        /// Asignara un valor al atributo numero, previa validacion.
        /// </summary>
        private string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }
        #endregion


        #region Sobrecarga de Operadores
        /// <summary>
        /// Resta dos clases del tipo Numero
        /// </summary>
        /// <param name="n1">Operando1</param>
        /// <param name="n2">Operando2</param>
        /// <returns>Resta entre los atributos privados de clase Numero "numero"</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double rtn = n1.numero - n2.numero;

            return rtn;
        }

        /// <summary>
        /// Multiplica dos clases del tipo Numero
        /// </summary>
        /// <param name="n1">Operando1</param>
        /// <param name="n2">Operando2</param>
        /// <returns>Multiplicacion entre los atributos privados de clase Numero "numero"</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double rtn = n1.numero * n2.numero;

            return rtn;
        }

        /// <summary>
        /// Divide dos clases del tipo Numero, valida division por 0
        /// </summary>
        /// <param name="n1">Operando1</param>
        /// <param name="n2">Operando2</param>
        /// <returns>Multiplicacion entre los atributos privados de clase Numero "numero", si Operando2 es == 0 entonces retorna un double.MinValue</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double rtn;

            if (n2.numero == 0)
            {
                rtn = double.MinValue;
            }
            else
            {
                rtn = n1.numero / n2.numero;
            }

            return rtn;
        }

        /// <summary>
        /// Suma dos clases del tipo Numero
        /// </summary>
        /// <param name="n1">Operando1</param>
        /// <param name="n2">Operando2</param>
        /// <returns>Suma entre los atributos privados de clase Numero "numero"</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double rtn = n1.numero + n2.numero;

            return rtn;
        } 
        #endregion
    }
}
