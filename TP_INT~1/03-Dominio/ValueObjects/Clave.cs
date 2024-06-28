using System;
using System.Text.RegularExpressions;

namespace _03_Dominio.ValueObjects
{
    public class Clave
    {
        private readonly string valor;

        public Clave(string valor)
        {
            ValidarClave(valor);
            this.valor = valor;
        }
//Profe aca implementamos un nivel de seguridad "fuerte" en la clave
        private void ValidarClave(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave))
            {
                throw new ArgumentException("La clave no puede estar vacía o ser solo espacios en blanco.");
            }

            if (clave.Length < 8)
            {
                throw new ArgumentException("La clave debe tener al menos 8 caracteres.");
            }

            if (!Regex.IsMatch(clave, @"[A-Z]"))
            {
                throw new ArgumentException("La clave debe contener al menos una letra mayúscula.");
            }

            if (!Regex.IsMatch(clave, @"[a-z]"))
            {
                throw new ArgumentException("La clave debe contener al menos una letra minúscula.");
            }

            if (!Regex.IsMatch(clave, @"\d"))
            {
                throw new ArgumentException("La clave debe contener al menos un número.");
            }

            if (!Regex.IsMatch(clave, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>/?]"))
            {
                throw new ArgumentException("La clave debe contener al menos un carácter especial.");
            }
        }

        public string Valor()
        {
            return this.valor;
        }

        public override string ToString()
        {
            return new string('*', this.valor.Length); // Oculta la clave real
        }
    }
}