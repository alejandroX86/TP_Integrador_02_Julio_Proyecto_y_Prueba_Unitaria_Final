// Archivo ClienteId.cs en el namespace _03_Dominio.ValueObjects
using System;

namespace _03_Dominio.ValueObjects
{
    public class ClienteId
    {
        public Guid Valor { get; private set; }

        public ClienteId(Guid valor)
        {
            Valor = valor;
        }
    }
}