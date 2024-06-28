using _01_Presentacion;
using _02_Aplicacion;
using _02_Aplicacion.DTOs;
using _03_Dominio.Repositorios;
using _04_PersistenciaDatos;
using _04_PersistenciaDatos.MongoDBConnector;
using _04_PersistenciaDatos.Repositorios;

class Program
{
    static void Main(string[] args)
    {
        ClienteRepositorio? repositorioClientes = null;
        IReservaRepositorio? repositorioReservas = null;

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Trabajo Practico de Laboratorio de Software");
            Console.WriteLine("Proyecto Hotel: Arquitectura DDD");
            Console.WriteLine();
            Console.WriteLine("Profesor: Daniel Alejandro Fernandez");
            Console.WriteLine("Alumnos: Julia Avalos");
        
            Console.WriteLine("         Eduardo Arizza");
            Console.WriteLine("         Gonzalo Arizza");
            Console.WriteLine("         Omar Bazar");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Seleccione el tipo de base de datos:");
            Console.WriteLine("1. Base de Datos en Memoria");
            Console.WriteLine("2. Base de Datos en MySQL");
            Console.WriteLine("3. Base de Datos en MongoDB");
            Console.WriteLine("4. Ir a Menu Clientes");
            Console.WriteLine("5. Ir a Menu Reservas");
            Console.WriteLine("6. Salir");
            Console.Write("Opción: ");
            
            string? opcion = Console.ReadLine();

            if (opcion == null)
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case "1":
                    repositorioClientes = new ClienteRepositorioEnMemoria();
                    repositorioReservas = new ReservaRepositorioEnMemoria();
                    Console.WriteLine("Base de datos en Memoria seleccionada con éxito. Presione Enter para continuar.");
                    Console.ReadLine();
                    break;
                case "2":
                    repositorioClientes = new ClienteRepositorioMySQL();
                    repositorioReservas = new ReservaRepositorioMySQL();
                    Console.WriteLine("Base de datos en MySQL seleccionada con éxito. Presione Enter para continuar.");
                    Console.ReadLine();
                    break;
                case "3":
                    repositorioClientes = new ClienteRepositorioMongoDB("mongodb://localhost:27017", "test", "clientes");
                    repositorioReservas = new ReservaRepositorioMongoDB("mongodb://localhost:27017", "test", "reservas");
                    Console.WriteLine("Base de datos en MongoDB seleccionada con éxito. Presione Enter para continuar.");
                    Console.ReadLine();
                    break;
                case "4":
                    if (repositorioClientes != null)
                    {
                        ClienteUI clienteUI = new ClienteUI(repositorioClientes);
                        clienteUI.MostrarMenu();
                    }
                    else
                    {
                        Console.WriteLine("Debes seleccionar una base de datos primero.");
                        Console.ReadLine();
                    }
                    break;
                case "5":
                    if (repositorioReservas != null)
                    {
                        ReservaUI reservaUI = new ReservaUI(repositorioReservas);
                        reservaUI.MostrarMenu();
                    }
                    else
                    {
                        Console.WriteLine("Debes seleccionar una base de datos primero.");
                        Console.ReadLine();
                    }
                    break;
                case "6":
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}

