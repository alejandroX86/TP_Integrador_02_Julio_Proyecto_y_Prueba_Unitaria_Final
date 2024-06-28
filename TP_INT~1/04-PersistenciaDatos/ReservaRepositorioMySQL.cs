using _03_Dominio;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace _04_PersistenciaDatos
{
    public class ReservaRepositorioMySQL : IReservaRepositorio
    {
        private MySqlConnection connection;

        public ReservaRepositorioMySQL()
        {
            string connectionString = "Server=localhost;Port=3307;Database=test;Uid=root;Pwd=root;";
            connection = new MySqlConnection(connectionString);
        }

        public void CrearReserva(Reserva reserva)
        {
            using (MySqlCommand comando = new MySqlCommand(
                "INSERT INTO reservas (id, cliente_id, fecha_inicio, fecha_fin, estado) VALUES (@id, @cliente_id, @fecha_inicio, @fecha_fin, @estado)",
                connection
            ))
            {
                comando.Parameters.Add("@id", MySqlDbType.Guid).Value = reserva.Id();
                comando.Parameters.Add("@cliente_id", MySqlDbType.Guid).Value = reserva.ClienteId();
                comando.Parameters.Add("@fecha_inicio", MySqlDbType.DateTime).Value = reserva.FechaInicio();
                comando.Parameters.Add("@fecha_fin", MySqlDbType.DateTime).Value = reserva.FechaFin();
                comando.Parameters.Add("@estado", MySqlDbType.VarChar).Value = reserva.Estado();
                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<Reserva> ListarReservas()
        {
            List<Reserva> reservas = new List<Reserva>();
            using (MySqlCommand command = new MySqlCommand(
                "SELECT id, cliente_id, fecha_inicio, fecha_fin, estado FROM reservas",
                connection
            ))
            {
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Guid id = reader.GetGuid(0);
                        Guid clienteId = reader.GetGuid(1);
                        DateTime fechaInicio = reader.GetDateTime(2);
                        DateTime fechaFin = reader.GetDateTime(3);
                        string estado = reader.GetString(4);
                        Reserva reserva = new Reserva(id, clienteId, fechaInicio, fechaFin, estado);
                        reservas.Add(reserva);
                    }
                }
                connection.Close();
            }
            return reservas;
        }

        public void BorrarReserva(Guid id)
        {
            using (MySqlCommand comando = new MySqlCommand(
                "DELETE FROM reservas WHERE id = @id",
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
                        throw new InvalidOperationException($"No se encontró una reserva con el ID {id}.");
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}