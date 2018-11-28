using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Test_Unitario
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// PaquetesDelCorreo, verifica la instacia de un nuevo objeto de clase Correo, de no ser asi lanza una excepcion
        /// </summary>
        /// <returns>se retorna True(verdadero) de Haberse producido la Excepcion, caso contrario retornara false(falso).</returns>
        [TestMethod]
        public bool PaquetesDelCorreo()
        {
            bool retorno = false;

            Correo Verifica = new Correo();

            if(Verifica == null)
            {

                Assert.Fail();
                try
                { }
                catch(Exception)
                { retorno = true; }
            }

            return retorno;
        }

        /// <summary>
        /// VerificaIgualdad Valida Que no se Pueda recibir dos(2) paquetes con el mismo 'TrackingID', caso de Ser el mismo se lanzara una Excepcion
        /// </summary>
        /// <returns>Se retorna True(verdadero) de no poder Cargar el Segundo Paquete repetido, de haberse podido cargar se retornara false(falso).</returns>
        [TestMethod]
        public bool VerificaIgualdad()
        {
            bool retorno = false;

            Correo correoPrueba = new Correo();

            if(!PaquetesDelCorreo())
            {
                Paquete aux1 = new Paquete("Direccion X", "1111");
                Paquete aux2 = new Paquete("Direccion X", "1111");

                correoPrueba += aux1;

                try
                {
                    correoPrueba += aux2;
                    Assert.Fail();
                }
#pragma warning disable CS0168 // La variable 'ExceptionEsperada' se ha declarado pero nunca se usa
                catch(TrackingIdRepetidoException ExceptionEsperada)
#pragma warning restore CS0168 // La variable 'ExceptionEsperada' se ha declarado pero nunca se usa
                { retorno = true; }
#pragma warning disable CS0168 // La variable 'Inesperada' se ha declarado pero nunca se usa
                catch(Exception Inesperada)
#pragma warning restore CS0168 // La variable 'Inesperada' se ha declarado pero nunca se usa
                { retorno = true; }
            }

            return retorno;
        }
    }
}
