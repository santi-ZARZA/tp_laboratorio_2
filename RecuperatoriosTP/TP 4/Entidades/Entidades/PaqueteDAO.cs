using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand _comando;
        private static SqlConnection _conexion;

        static PaqueteDAO()
        {
            PaqueteDAO._conexion = new SqlConnection(Entidades.Properties.Settings.Default.Servicios);
        }

        public static bool Insertar(Paquete p)
        {
            bool retorno = false;

            try
            {
                PaqueteDAO._conexion.Open();

                PaqueteDAO._comando = new SqlCommand("INSERT into [correo-sp-2017].[dbo].[Paquetes]([direccionEntrega],[trackingID],[alumno]) VALUES ('" + p.DireccionEntrega + "','" + p.TrackingId + "','Santiago Zarza')", PaqueteDAO._conexion);

                if(PaqueteDAO._comando.ExecuteNonQuery() > 0)
                {
                    retorno = true;
                }
            }
            catch(Exception e)
            { throw e; }
            finally
            { PaqueteDAO._conexion.Close(); }


            return retorno;
        }
    }
}
