using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_PersistenciaDatos.MongoDBConnector
{
    public class MongoDBConnector
    {
        private readonly IMongoDatabase _database;

        public MongoDBConnector()
        {
            var connectionString = "mongodb://localhost:27017";
            var databaseName = "test";
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<UsuarioDocumento> UsuariosCollection
        {
            get { return _database.GetCollection<UsuarioDocumento>("clientes"); }
        }
    }
}
