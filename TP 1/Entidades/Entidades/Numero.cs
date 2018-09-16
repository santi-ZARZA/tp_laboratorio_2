using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributo
        private Double numero;
        #endregion

        #region Propiedad
        private String SetNumero
        {
            set
            {
                if (ValidarNumero(value) != 0)
                {
                    numero = ValidarNumero(value);
                }
            }
        }
        #endregion

        #region Constructores
        public Numero() : this(0)
        {
        }

        public Numero(Double num)
        {
            numero = num;
        }

        public Numero(String strnum)
        {
            SetNumero = strnum;
        }
        #endregion

        #region Sobrecarga de Operadores
        public static Double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }

        public static Double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }

        public static Double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }

        public static Double operator /(Numero num1, Numero num2)
        {
            return num1.numero / num2.numero;
        }
        #endregion

        #region Metodos
        public String DecimalBinario(Double numero)
        {
            String retorno = "Valor Invalido";
            double auxnum = numero;
            string aux = "", ordenado = "";

            while (auxnum >= 0)
            {
                switch (auxnum % 2)
                {
                    case 0:
                        aux += "0";
                        auxnum = (int)auxnum / 2;
                        break;
                    case 1:
                        aux += "1";
                        auxnum = (int)auxnum / 2;
                        break;
                }
                if (auxnum == 0)
                {
                    break;
                }
            }

            for (int i = aux.Length - 1; i >= 0; i--)
            {
                ordenado += (aux[i]).ToString();
            }

            retorno = ordenado;

            return retorno;
        }

        public String DecimalBinario(String strnum)
        {
            Double aux = 0;
            Double.TryParse(strnum, out aux);

            return DecimalBinario(aux);
        }

        public String BinarioDecimal(String strnum)
        {
            String retorno = "Valor Invalido";
            string straux = strnum;
            double aux = 0, auxnum = 0;

            if (straux != null)
            {
                for (int i = straux.Length - 1, j = 0; i >= 0; i--, j++)
                {
                    if ((Double.TryParse(straux[i].ToString(), out auxnum) == true))
                    {
                        aux += auxnum * Math.Pow(2, j);
                    }
                }

                retorno = aux.ToString();
            }

            return retorno;
        }

        private Double ValidarNumero(String strnumero)
        {
            Double retorno = 0, aux;

            if (Double.TryParse(strnumero, out aux) == true)
            {
                retorno = aux;
            }

            return retorno;
        }
        #endregion

    }
}
