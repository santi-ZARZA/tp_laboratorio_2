using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos

        private List<Thread> mockPaquetes;

        private List<Paquete> paquetes;

        #endregion

        #region Propiedad

        public List<Paquete> Paquetes { get { return this.paquetes; } set { this.paquetes = value; } }

        #endregion

        #region Constructor

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        #endregion

        #region Polimorfismo

        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            string retorno = "";

            foreach (Paquete item in this.Paquetes)
            {
                retorno += String.Format("{0} ({1})", item.ToString(), item.Estado)+"\n";
            }

            return retorno;
        }

        public override string ToString()
        {
            return ((IMostrar<List<Paquete>>)this).MostrarDatos(this);
        }

        #endregion

        #region Sobrecarga Operador

        public static Correo operator +(Correo c , Paquete p)
        {
            bool valida = false;

            foreach (Paquete item in c.paquetes)
            {
                if(item == p)
                {
                    valida = true;
                    break;
                }
            }

            if(!valida)
            {
                try
                {
                    Thread auxHilo = new Thread(p.MockCicloDeVida);
                    c.mockPaquetes.Add(auxHilo);
                    c.paquetes.Add(p);
                    auxHilo.Start();
                }
                catch (Exception e)
                { throw e; }
            }
            else
            {
                throw new TrackingIdRepetidoException("Paquete ya existente");
            }

            return c;
        }

        #endregion

        #region Metodo

        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                item.Abort();
            }
        }

        #endregion
    }
}
