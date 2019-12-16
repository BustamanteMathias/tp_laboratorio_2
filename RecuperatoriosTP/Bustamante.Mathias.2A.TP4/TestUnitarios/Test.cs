using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bustamante.Mathias._2A

{
    /// <summary>
    /// Test Unitarios para validar instancia de Correo y Pquetes repetidos en listas de Correo.
    /// </summary>
    [TestClass]
    public class Test
    {
        /// <summary>
        /// Valida Instancia de Correo.
        /// </summary>
        [TestMethod]
        public void TestValidarCorreo()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }

        /// <summary>
        /// Valida si hay paquetes repetidos en lista de correo.
        /// </summary>
        [TestMethod]
        public void TestValidarPaquetesIGuales()
        {
            Correo c = new Correo();
            try
            {
                Paquete p1 = new Paquete("Paquete1", "000999000");
                Paquete p2 = new Paquete("Paquete2", "000999000");
                c += p1;
                c += p2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
        }
    }
}

