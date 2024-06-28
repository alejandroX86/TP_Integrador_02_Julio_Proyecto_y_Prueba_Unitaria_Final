using _03_Dominio.Entidades;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace _04_PersistenciaDatos
{
    public class ReservaDocumento
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public ObjectId ClienteId { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }

        // Constructor que inicializa todas las propiedades necesarias
        public ReservaDocumento(ObjectId id, ObjectId clienteId, DateTime fechaInicio, DateTime fechaFin, string estado)
        {
            Id = id;
            ClienteId = clienteId;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Estado = estado ?? throw new ArgumentNullException(nameof(estado), "El estado no puede ser null.");
        }
    }
}
