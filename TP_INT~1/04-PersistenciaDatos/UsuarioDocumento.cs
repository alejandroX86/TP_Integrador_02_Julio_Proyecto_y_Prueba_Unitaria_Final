using _03_Dominio.Entidades;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace _04_PersistenciaDatos
{
    public class UsuarioDocumento
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public string? Clave { get; set; } // Marcar como opcionalmente nullable

        public DateTime FechaNacimiento { get; set; }

        public UsuarioDocumento(ObjectId id, string nombre, string email, string? clave, DateTime fechaNacimiento)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Clave = clave; // Inicializar la propiedad Clave en el constructor si es posible
            FechaNacimiento = fechaNacimiento;
        }
    }
}



  





