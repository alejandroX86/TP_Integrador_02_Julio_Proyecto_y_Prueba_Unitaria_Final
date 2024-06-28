using _03_Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Aplicacion.DTOs
{
    public class ClienteDTO
    {
        private Guid id;
        private string nombre;
        private string email;
        private string clave;
        private DateTime fechaNacimiento;

        public ClienteDTO(Guid id, string nombre, string email, string clave, DateTime fechaNacimiento)
        {
            this.id = id;
            this.nombre = nombre;
            this.email = email;
            this.clave = clave;
            this.fechaNacimiento = fechaNacimiento;
        }

        public Guid Id()
        {
            return this.id;
        }

        public string Nombre()
        {
            return this.nombre;
        }
        public string Email()
        {
            return this.email;
        }
        public string Clave()
        {
            return this.clave;
        }
        public DateTime FechaNacimiento()
        {
            return this.fechaNacimiento;
        }
    }
}
