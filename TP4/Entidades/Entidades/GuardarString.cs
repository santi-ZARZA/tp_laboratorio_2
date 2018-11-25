using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {
        public static Boolean Guardar(this String texto,string archivo)
        {
            bool retorno = false;

            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo + ".txt";

            StreamWriter writer = new StreamWriter(ruta, true);

            if(writer != null)
            {
                writer.WriteLine(texto);
                retorno = true;
            }

            writer.Close();

            return retorno;
        }
    }
}
