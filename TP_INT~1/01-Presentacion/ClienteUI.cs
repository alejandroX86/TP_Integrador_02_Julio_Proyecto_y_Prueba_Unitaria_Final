using _02_Aplicacion;
using _02_Aplicacion.DTOs;
using _03_Dominio.Repositorios;
using System;
using System.Collections.Generic;

namespace _01_Presentacion
{
    public class ClienteUI
    {
        private readonly CrearClientes _crearClientes;
        private readonly ListarClientes _listarClientes;
        private readonly BorrarCliente _borrarCliente;
        private readonly ActualizarClientes _actualizarClientes;

        public ClienteUI(ClienteRepositorio repositorio)
        {
            _crearClientes = new CrearClientes(repositorio);
            _listarClientes = new ListarClientes(repositorio);
            _borrarCliente = new BorrarCliente(repositorio);
            _actualizarClientes = new ActualizarClientes(repositorio);
        }

        public void MostrarMenu()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n--- Menú de Clientes ---");
                Console.WriteLine("1. Ingresar nuevo cliente");
                Console.WriteLine("2. Listar clientes");
                Console.WriteLine("3. Borrar cliente");
                Console.WriteLine("4. Actualizar cliente");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        IngresarCliente();
                        break;
                    case "2":
                        ListarClientes();
                        break;
                    case "3":
                        BorrarCliente();
                        break;
                    case "4":
                        ActualizarCliente();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        private void IngresarCliente()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nIngresar nuevo cliente:");
            Console.Write("Nombre: ");
            string? nombre = Console.ReadLine();

            Console.Write("Email: ");
            string? email = Console.ReadLine();

            Console.Write("Clave: ");
            string? clave = Console.ReadLine();

            Console.Write("Fecha de nacimiento (YYYY-MM-DD): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime fechaNacimiento))
            {
                if (nombre == null || email == null || clave == null)
                {
                    Console.WriteLine("Nombre, Email o Clave no pueden ser nulos. No se pudo crear el cliente.");
                    return;
                }

                try
                {
                    ClienteDTO nuevoCliente = new ClienteDTO(
                        Guid.NewGuid(),
                        nombre,
                        email,
                        clave,
                        fechaNacimiento
                    );

                    _crearClientes.Ejecutar(nuevoCliente);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Cliente ingresado con éxito.");
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (FormatException ex) when (ex.Message.Contains("email"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Email inválido. No se pudo crear el cliente.");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fecha de nacimiento inválida. No se pudo crear el cliente.");
            }
        }

        private void ListarClientes()
        {
            Console.WriteLine("\nListado de clientes:");
            List<ClienteDTO> clientes = _listarClientes.Ejecutar();

            if (clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
            }
            else
            {
                foreach (ClienteDTO cliente in clientes)
                {
                    Console.WriteLine($"ID: {cliente.Id()}");
                    Console.WriteLine($"Nombre: {cliente.Nombre()}");
                    Console.WriteLine($"Email: {cliente.Email()}");
                    Console.WriteLine($"Clave: {cliente.Clave()}");
                    Console.WriteLine($"Fecha de Nacimiento: {cliente.FechaNacimiento():yyyy-MM-dd}");
                    Console.WriteLine("--------------------");
                }
            }
        }

        private void BorrarCliente()
        {
            Console.WriteLine("\nBorrar cliente:");
            Console.Write("Ingrese el ID del cliente a borrar: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid clienteId))
            {
                try
                {
                    _borrarCliente.Ejecutar(clienteId);
                    Console.WriteLine("Cliente borrado con éxito.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al borrar el cliente: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("ID de cliente inválido.");
            }
        }

        private void ActualizarCliente()
        {
            Console.WriteLine("\nActualizar cliente:");
            Console.Write("Ingrese el ID del cliente a actualizar: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid clienteId))
            {
                try
                {
                    Console.Write("Nuevo nombre: ");
                    string? nuevoNombre = Console.ReadLine();

                    Console.Write("Nuevo email: ");
                    string? nuevoEmail = Console.ReadLine();

                    Console.Write("Nueva clave: ");
                    string? nuevaClave = Console.ReadLine();

                    Console.Write("Nueva fecha de nacimiento (YYYY-MM-DD): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime nuevaFechaNacimiento))
                    {
                        if (nuevoNombre != null && nuevoEmail != null && nuevaClave != null)
                        {
                            ClienteDTO clienteActualizado = new ClienteDTO(
                                clienteId,
                                nuevoNombre,
                                nuevoEmail,
                                nuevaClave,
                                nuevaFechaNacimiento
                            );

                            _actualizarClientes.Ejecutar(clienteActualizado);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Cliente actualizado con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("Nombre, Email o Clave no pueden ser nulos. No se pudo actualizar el cliente.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Fecha de nacimiento inválida. No se pudo actualizar el cliente.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar el cliente: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("ID de cliente inválido.");
            }
        }
    }
}