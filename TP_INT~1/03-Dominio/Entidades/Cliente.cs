using _03_Dominio.ValueObjects;
using System;

namespace _03_Dominio.Entidades
{
    public class Cliente
    {
        private Identificador id;
        private Nombre nombre;
        private Email email;
        private Clave clave;
        private FechaNacimiento fechaNacimiento;

        public Cliente(Guid id, string nombre, string email, string clave, DateTime fechaNacimiento)
        {
            this.id = new Identificador(id);
            this.nombre = new Nombre(nombre);
            this.email = new Email(email);
            this.clave = new Clave(clave);
            this.fechaNacimiento = new FechaNacimiento(fechaNacimiento);

            if (!this.fechaNacimiento.EsMayorDeEdad())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new ArgumentException("El cliente debe ser mayor de 18 años.");
                
            }
        }

        public Guid Id()
        {
            return this.id.Valor();
        }

        public string Nombre()
        {
            return this.nombre.Valor();
        }

        public string Email()
        {
            return this.email.Valor();
        }

        public string Clave()
        {
            return this.clave.Valor();
        }

        public DateTime FechaNacimiento()
        {
            return this.fechaNacimiento.Valor();
        }
    }
}
