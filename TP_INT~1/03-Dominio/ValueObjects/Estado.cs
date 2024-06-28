using System;

namespace _03_Dominio.ValueObjects
{
    public class Estado : IEquatable<Estado>
    {
        public string Valor { get; }

        public Estado(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                throw new ArgumentException("El valor del estado no puede ser nulo o vacío.", nameof(valor));
            }

            Valor = valor;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Estado);
        }

        public bool Equals(Estado? other)
        {
            return other != null && Valor == other.Valor;
        }

        public override int GetHashCode()
        {
            return Valor.GetHashCode();
        }

        public static bool operator ==(Estado? left, Estado? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Estado? left, Estado? right)
        {
            return !Equals(left, right);
        }
    }
}
