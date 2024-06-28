using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Dominio
{
    using System;

    namespace _03_Dominio.ValueObjects
    {
        public class FechaReserva
        {
            public DateTime FechaInicio { get; private set; }
            public DateTime FechaFin { get; private set; }

            public FechaReserva(DateTime fechaInicio, DateTime fechaFin)
            {
                FechaInicio = fechaInicio;
                FechaFin = fechaFin;
            }
        }
    }
}
