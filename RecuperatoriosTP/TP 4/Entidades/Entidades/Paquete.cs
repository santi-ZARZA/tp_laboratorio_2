using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Atributos

        private string _direccionEntrega;
        private EEstado estado;
        private string _trackingId;

        #endregion

        #region Propiedades
        public string DireccionEntrega { get { return this._direccionEntrega; } set { this._direccionEntrega = value; } }
        public EEstado Estado { get { return this.estado; } set { this.estado = value; } }
        public string TrackingId { get { return this._trackingId; } set { this._trackingId = value; } }
        #endregion

        #region Constructores

        public Paquete(string direccionEntrega, string trackingId)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingId = trackingId;
            this.Estado = EEstado.Ingresado;
        }

        #endregion

        #region Sobrecarga de Operadores

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;

            if(p1.TrackingId == p2.TrackingId)
            { retorno = true; }

            return retorno;
        }

        public static bool operator !=(Paquete p1, Paquete p2) { return !(p1 == p2); }

        #endregion

        #region Polimorfismo

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}\n", ((Paquete)elemento).TrackingId, ((Paquete)elemento).DireccionEntrega);
        }

        #endregion

        #region Delegado

        public delegate void DelegadoEstado(object sender, EventArgs e);

        #endregion

        #region Evento

        public event DelegadoEstado InformaEstado;

        #endregion

        #region Metodo

        public void MockCicloDeVida()
        {
            do
            {
                System.Threading.Thread.Sleep(4000);

                switch (this.Estado)
                {
                    case EEstado.Ingresado:
                        this.Estado = EEstado.EnViaje;
                        this.InformaEstado.Invoke(this, new EventArgs());
                        break;
                    case EEstado.EnViaje:
                        this.Estado = EEstado.Entregado;
                        this.InformaEstado.Invoke(this, new EventArgs());
                        break;
                    default:
                        break;
                }

            }while(this.Estado != EEstado.Entregado);

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch(TrackingIdRepetidoException excepcionNoEsperada)
            { throw excepcionNoEsperada; }
            catch (Exception Tira)
            { throw Tira; }

        }

        #endregion
    }
}
