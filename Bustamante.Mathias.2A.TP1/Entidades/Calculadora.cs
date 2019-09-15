using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Metodos
        /// <summary>
        /// Validar que el operador recibido sea valido + - * /.
        /// </summary>
        /// <param name="operador">Operador aritmetico</param>
        /// <returns>Operador aritmetico valido, en el caso contrario retorna "+"</returns>
        private static string ValidarOperador(string operador)
        {

            if (operador != "-" && operador != "/" && operador != "*")
            {
                operador = "+";
            }

            return operador;
        }

        /// <summary>
        /// Valida y realiza la operacion pedida entre ambos números
        /// </summary>
        /// <param name="num1">Operando1</param>
        /// <param name="num2">Operando2</param>
        /// <param name="operador">Operador aritmetico</param>
        /// <returns>Resultado de calculo entre dos clases del tipo Numero</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double rtn = 0;
            string auxOp;

            auxOp = ValidarOperador(operador);

            switch (auxOp)
            {
                case "+":
                    rtn = num1 + num2;
                    break;

                case "*":
                    rtn = num1 * num2;
                    break;

                case "/":
                    rtn = num1 / num2;
                    break;

                case "-":
                    rtn = num1 - num2;
                    break;
            }

            return rtn;
        } 
        #endregion
    }
}
