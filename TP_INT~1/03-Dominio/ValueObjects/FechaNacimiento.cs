using System;

namespace _03_Dominio.ValueObjects
{
    public class FechaNacimiento
    {
        private DateTime valor;

        public FechaNacimiento(DateTime valor)
        {
            this.valor = valor;
        }

        public bool EsMayorDeEdad()
        {
            int edad = DateTime.Today.Year - valor.Year;
            if (valor.Date > DateTime.Today.AddYears(-edad)) edad--;
            return edad >= 18;
        }

        public DateTime Valor()
        {
            return this.valor;
        }
    }
}
