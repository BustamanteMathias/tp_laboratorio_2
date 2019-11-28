using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bustamante.Mathias._2A

{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestValidarCorreo()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }

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

