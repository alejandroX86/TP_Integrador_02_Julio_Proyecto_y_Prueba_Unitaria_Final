using MongoDB.Driver;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace _04_PersistenciaDatos.Repositorios
{
    public class ReservaRepositorioMongoDB : IReservaRepositorio
    {
        private readonly IMongoCollection<ReservaDocumento> _collection;

        public ReservaRepositorioMongoDB(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _collection = database.GetCollection<ReservaDocumento>(collectionName);
        }

        public void CrearReserva(Reserva reserva)
        {
            var documento = MapearReservaADocumento(reserva);
            _collection.InsertOne(documento);
        }

        public List<Reserva> ListarReservas()
        {
            var filtros = Builders<ReservaDocumento>.Filter.Empty;
            var documentos = _collection.Find(filtros).ToList();
            return MapearDocumentosAReservas(documentos);
        }

        public void BorrarReserva(Guid id)
        {
            var filtro = Builders<ReservaDocumento>.Filter.Eq(r => r.Id, new ObjectId(id.ToString()));
            var resultado = _collection.DeleteOne(filtro);

            if (resultado.DeletedCount == 0)
            {
                throw new InvalidOperationException($"No se encontró una reserva con el ID {id}.");
            }
        }

        private ReservaDocumento MapearReservaADocumento(Reserva reserva)
        {
            return new ReservaDocumento(
                id: new ObjectId(reserva.Id().ToString()),
                clienteId: new ObjectId(reserva.ClienteId().ToString()),
                fechaInicio: reserva.FechaInicio(),
                fechaFin: reserva.FechaFin(),
                estado: reserva.Estado()
            );
        }

        private List<Reserva> MapearDocumentosAReservas(List<ReservaDocumento> documentos)
        {
            var reservas = new List<Reserva>();
            foreach (var documento in documentos)
            {
                reservas.Add(new Reserva(
                    Guid.Parse(documento.Id.ToString()), // Convertir ObjectId a Guid usando Guid.Parse
                    new Guid(documento.ClienteId.ToString()), // Convertir ObjectId a Guid
                    documento.FechaInicio,
                    documento.FechaFin,
                    documento.Estado
                ));
            }
            return reservas;
        }
    }
}
