using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;
using _04_PersistenciaDatos.MySQLConnector;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace _04_PersistenciaDatos
{
    public class ClienteRepositorioMySQL : ClienteRepositorio
    {
        private MySqlConnection connection;

        public ClienteRepositorioMySQL()
        {
            string connectionString = "Server=localhost;Port=3307;Database=test;Uid=root;Pwd=root;";
            connection = new MySqlConnection(connectionString);
        }

        public void grabar(Cliente usuario)
        {
            using (MySqlCommand comando = new MySqlCommand(
                "INSERT INTO usuarios (id, nombre, email, clave, fecha_nacimiento) VALUES (@id, @nombre, @email, @clave, @fecha_nacimiento)",
                connection
            ))
            {
                comando.Parameters.Add("@id", MySqlDbType.Guid).Value = usuario.Id();
                comando.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = usuario.Nombre();
                comando.Parameters.Add("@email", MySqlDbType.VarChar).Value = usuario.Email();
                comando.Parameters.Add("@clave", MySqlDbType.VarChar).Value = usuario.Clave();
                comando.Parameters.Add("@fecha_nacimiento", MySqlDbType.DateTime).Value = usuario.FechaNacimiento();
                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<Cliente> listar()
        {
            List<Cliente> usuarios = new List<Cliente>();
            using (MySqlCommand command = new MySqlCommand(
                "SELECT id, nombre, email, clave, fecha_nacimiento FROM usuarios",
                connection
            ))
            {
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Guid id = reader.GetGuid(0);
                        String nombre = reader.GetString(1);
                        String email = reader.GetString(2);
                        String clave = reader.GetString(3);
                        DateTime fechaNacimiento = reader.GetDateTime(4);
                        Cliente usuario = new Cliente(id, nombre, email, clave, fechaNacimiento);
                        usuarios.Add(usuario);
                    }
                }
                connection.Close();
            }
            return usuarios;
        }

        public void eliminar(Guid id)
        {
            using (MySqlCommand comando = new MySqlCommand(
                "DELETE FROM usuarios WHERE id = @id",
                connection
            ))
            {
                comando.Parameters.Add("@id", MySqlDbType.Guid).Value = id;

                try
                {
                    connection.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas == 0)
                    {
                        throw new InvalidOperationException($"No se encontró un cliente con el ID {id}.");
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void actualizarCliente(Cliente cliente)
        {
            using (MySqlCommand comando = new MySqlCommand(
                "UPDATE usuarios SET nombre = @nombre, email = @email, clave = @clave, fecha_nacimiento = @fecha_nacimiento WHERE id = @id",
                connection
            ))
            {
                comando.Parameters.Add("@id", MySqlDbType.Guid).Value = cliente.Id();
                comando.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = cliente.Nombre();
                comando.Parameters.Add("@email", MySqlDbType.VarChar).Value = cliente.Email();
                comando.Parameters.Add("@clave", MySqlDbType.VarChar).Value = cliente.Clave();
                comando.Parameters.Add("@fecha_nacimiento", MySqlDbType.DateTime).Value = cliente.FechaNacimiento();

                try
                {
                    connection.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas == 0)
                    {
                        throw new InvalidOperationException($"No se encontró un cliente con el ID {cliente.Id()}.");
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void actualizar(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}