using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using ClasesInstanciables;
using Excepciones;
using EntidadesAbstractas;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitarios
    {
        #region TEST UNITARIOS
        /// <summary>
        /// Metodo de test que comprueba alumno repetido y genera una excepcion
        /// </summary>
        [TestMethod]
        public void Test_AlumnoRepetido()
        {
            int ID_a2 = 2;                          // ID a1 = 1 

            Alumno a1 = new Alumno(1, "Jesucristo", "De Nazareth", "90000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Alumno a2 = new Alumno(ID_a2, "Dieguito", "Maradona", "37687769", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Universidad u = new Universidad();

            try
            {
                u += a1;
                u += a2;
                Assert.AreEqual(a1, a2);
            }
            catch (Exception)
            {
                throw new AlumnoRepetidoException();
            }
        }

        /// <summary>
        /// Metodo de test que valida rando de DNI dependiendo de su nacionalidad y genera una excepcion
        /// </summary>
        [TestMethod]
        public void Test_DNINacionalidadInvalida()
        {
            string DNI_FueraDeRango = "90000000";   // 90.000.000 A 99.999.999 | DNI FUERA DE RANGO EN ALUMNO a1

            Alumno a1 = new Alumno(1, "Jesucristo", "De Nazareth", DNI_FueraDeRango, Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Alumno a2 = new Alumno(2, "Dieguito", "Maradona", "37687769", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Universidad u = new Universidad();

            try
            {
                u += a1;
                u += a2;
            }
            catch (Exception)
            {
                throw new NacionalidadInvalidaException();
            }
        }

        /// <summary>
        /// Metodo de test que valida el formato numerico para la carga del DNI
        /// </summary>
        [TestMethod]
        public void Test_DNIValorNumerico()
        {
            string DNI_MalFormato = "90000000";     // SOLO NUMEROS

            Alumno a1 = new Alumno(1, "Jesucristo", "De Nazareth", DNI_MalFormato, Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Universidad u = new Universidad();

            try
            {
                u += a1;
            }
            catch (Exception)
            {
                throw new DniInvalidoException();
            }
        }

        /// <summary>
        /// Metodo de test que valida un tpo de clase si su valor es NULL
        /// </summary>
        [TestMethod]
        public void Test_ValorNull()
        {
            Universidad u = new Universidad();
            //u = null;                             //Coloco la clase en NULL

            try
            {
                Assert.IsNotNull(u);
            }
            catch (Exception)
            {
                throw new Exception("Valor NULL");
            }
        } 
        #endregion
    }
}
