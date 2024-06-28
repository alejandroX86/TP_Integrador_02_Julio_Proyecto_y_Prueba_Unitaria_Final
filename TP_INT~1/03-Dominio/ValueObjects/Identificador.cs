using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03_Dominio.ValueObjects
{
    public class Identificador
    {
        private Guid valor;

        public Identificador(Guid valor)
        {
            this.valor = valor;
        }

        public Guid Valor()
        {
            return this.valor;
        }
    }
}
