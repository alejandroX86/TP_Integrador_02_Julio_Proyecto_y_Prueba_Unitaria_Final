using MySql.Data.MySqlClient;

namespace _04_PersistenciaDatos.MySQLConnector
{
    public class MySQLConnectionSingleton
    {
        private static MySQLConnectionSingleton? instance = null;
        private MySqlConnection connection;

        private MySQLConnectionSingleton(string server, int port, string database, string user, string password)
        {
            string connectionString = $"Server={server};Port={port};Database={database};User Id={user};Password={password};";
            connection = new MySqlConnection(connectionString);
        }

        public static MySQLConnectionSingleton Instance(string server, int port, string database, string user, string password)
        {
            if (instance == null)
            {
                instance = new MySQLConnectionSingleton(server, port, database, user, password);
            }
            return instance;
        }

        public MySqlConnection GetConnection()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}