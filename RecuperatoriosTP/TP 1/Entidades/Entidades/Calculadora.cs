using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        #region Metodos
        private static String ValidarOperador(string Operador)
        {
            string retorno = "+";

            if (Operador == "-" || Operador == "/" || Operador == "*")
            {
                retorno = Operador;
            }

            return retorno;
        }

        public Double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;

            switch (ValidarOperador(operador))
            {
                case "-":
                    retorno = num1 - num2;
                    break;
                case "*":
                    retorno = num1 * num2;
                    break;
                case "/":
                    retorno = num1 / num2;
                    break;
                default:
                    retorno = num1 + num2;
                    break;
            }

            return retorno;
        }
        #endregion
    }
}
