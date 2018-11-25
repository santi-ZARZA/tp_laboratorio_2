using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        public TrackingIdRepetidoException(string Mensaje) : base(Mensaje)
        {
        }

        public TrackingIdRepetidoException(string Mensaje, Exception Inner) : base(Mensaje, Inner)
        {
        }
    }
}
