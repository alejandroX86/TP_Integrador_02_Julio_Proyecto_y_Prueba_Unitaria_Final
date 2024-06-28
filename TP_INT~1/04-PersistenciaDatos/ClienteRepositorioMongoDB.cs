using MongoDB.Driver;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace _04_PersistenciaDatos.Repositorios
{
    public class ClienteRepositorioMongoDB : ClienteRepositorio
    {
        private readonly IMongoCollection<UsuarioDocumento> _collection;

        public ClienteRepositorioMongoDB(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _collection = database.GetCollection<UsuarioDocumento>(collectionName);
        }

        public void grabar(Cliente cliente)
        {
            var documento = MapearUsuarioADocumento(cliente);
            _collection.InsertOne(documento);
        }

        public List<Cliente> listar()
        {
            var filtros = Builders<UsuarioDocumento>.Filter.Empty;
            var documentos = _collection.Find(filtros).ToList();
            return MapearDocumentosAUsuarios(documentos);
        }

        public void eliminar(Guid id)
        {
            var filtro = Builders<UsuarioDocumento>.Filter.Eq(u => u.Id, ObjectId.Parse(id.ToString()));
            var resultado = _collection.DeleteOne(filtro);

            if (resultado.DeletedCount == 0)
            {
                throw new InvalidOperationException($"No se encontró un cliente con el ID {id}.");
            }
        }

        public void actualizarCliente(Cliente cliente)
        {
            var filtro = Builders<UsuarioDocumento>.Filter.Eq(u => u.Id, ObjectId.Parse(cliente.Id().ToString()));
            var documento = MapearUsuarioADocumento(cliente);
            var actualizar = Builders<UsuarioDocumento>.Update
                .Set(u => u.Nombre, cliente.Nombre())
                .Set(u => u.Email, cliente.Email())
                .Set(u => u.Clave, cliente.Clave())
                .Set(u => u.FechaNacimiento, cliente.FechaNacimiento());

            var resultado = _collection.UpdateOne(filtro, actualizar);

            if (resultado.ModifiedCount == 0)
            {
                throw new InvalidOperationException($"No se encontró un cliente con el ID {cliente.Id()}.");
            }
        }

        private UsuarioDocumento MapearUsuarioADocumento(Cliente cliente)
        {
            return new UsuarioDocumento(
                ObjectId.GenerateNewId(),
                cliente.Nombre(),
                cliente.Email(),
                cliente.Clave(),
                cliente.FechaNacimiento()
            );
        }

        private List<Cliente> MapearDocumentosAUsuarios(List<UsuarioDocumento> documentos)
        {
            var clientes = new List<Cliente>();
            foreach (var documento in documentos)
            {
                // Validar si documento.Clave puede ser null
                string clave = documento.Clave ?? throw new ArgumentNullException(nameof(documento.Clave), "El campo 'clave' no puede ser nulo.");

                clientes.Add(new Cliente(
                    new Guid(documento.Id.ToString()),
                    documento.Nombre,
                    documento.Email,
                    clave,
                    documento.FechaNacimiento
                ));
            }
            return clientes;
        }

        public void actualizar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public static implicit operator ClienteRepositorioMongoDB(ClienteRepositorioMySQL v)
        {
            throw new NotImplementedException();
        }
    }
}