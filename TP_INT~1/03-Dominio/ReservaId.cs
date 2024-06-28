using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Dominio.ValueObjects
{
    public class ReservaId
    {
        public Guid Valor { get; private set; }

        public ReservaId(Guid valor)
        {
            Valor = valor;
        }
    }
}