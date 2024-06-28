using _02_Aplicacion;
using _02_Aplicacion.DTOs;
using _03_Dominio.Repositorios;

namespace _01_Presentacion
{
    public class EstadoDeReserva
    {
        public const string DISPONIBLE = "disponible";
        public const string RESERVADA = "reservada";
    }

    public class ReservaUI
    {
        private readonly CrearReserva _crearReserva;
        private readonly ListarReservas _listarReservas;
        private readonly BorrarReserva _borrarReserva;

        public ReservaUI(IReservaRepositorio repositorio)
        {
            _crearReserva = new CrearReserva(repositorio);
            _listarReservas = new ListarReservas(repositorio);
            _borrarReserva = new BorrarReserva(repositorio);
        }

        public void MostrarMenu()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n--- Menú de Reservas ---");
                Console.WriteLine("1. Crear nueva reserva");
                Console.WriteLine("2. Listar reservas");
                Console.WriteLine("3. Borrar reserva");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                string? opcion = Console.ReadLine();

                if (opcion == null)
                {
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    continue;
                }

                switch (opcion)
                {
                    case "1":
                        CrearReserva();
                        break;
                    case "2":
                        ListarReservas();
                        break;
                    case "3":
                        BorrarReserva();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        private void CrearReserva()
        {
            Console.WriteLine("\nCrear nueva reserva:");
            Console.Write("ID de Cliente: ");
            string? clienteIdStr = Console.ReadLine();

            if (clienteIdStr == null || !Guid.TryParse(clienteIdStr, out Guid clienteId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID de Cliente inválido. No se pudo crear la reserva.");
                return;
            }

            Console.Write("Fecha de Inicio (YYYY-MM-DD): ");
            string? fechaInicioStr = Console.ReadLine();

            if (fechaInicioStr == null || !DateTime.TryParse(fechaInicioStr, out DateTime fechaInicio))
            {
                Console.WriteLine("Fecha de Inicio inválida. No se pudo crear la reserva.");
                return;
            }

            Console.Write("Fecha de Fin (YYYY-MM-DD): ");
            string? fechaFinStr = Console.ReadLine();

            if (fechaFinStr == null || !DateTime.TryParse(fechaFinStr, out DateTime fechaFin))
            {
                Console.WriteLine("Fecha de Fin inválida. No se pudo crear la reserva.");
                return;
            }

            string estado = EstadoDeReserva.RESERVADA;
            _crearReserva.Ejecutar(clienteId, fechaInicio, fechaFin, estado);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Reserva creada con éxito.");
        }

        private void ListarReservas()
        {
            Console.WriteLine("\nListado de reservas:");
            List<ReservaDTO> reservas = _listarReservas.Ejecutar();

            if (reservas.Count == 0)
            {
                Console.WriteLine("Estado: Disponible");
            }
            else
            {
                foreach (ReservaDTO reserva in reservas)
                {
                    Console.WriteLine($"ID: {reserva.Id()}");
                    Console.WriteLine($"ID de Cliente: {reserva.ClienteId()}");
                    Console.WriteLine($"Fecha de Inicio: {reserva.FechaInicio():yyyy-MM-dd}");
                    Console.WriteLine($"Fecha de Fin: {reserva.FechaFin():yyyy-MM-dd}");
                    Console.WriteLine($"Estado: {reserva.Estado()}");
                    Console.WriteLine("--------------------");
                }
            }
        }

        private void BorrarReserva()
        {
            Console.WriteLine("\nBorrar reserva:");
            Console.Write("Ingrese el ID de la reserva a borrar: ");
            string? reservaIdStr = Console.ReadLine();

            if (reservaIdStr == null || !Guid.TryParse(reservaIdStr, out Guid reservaId))
            {
                Console.WriteLine("ID de Reserva inválido.");
                return;
            }

            try
            {
                _borrarReserva.Ejecutar(reservaId);
                Console.WriteLine("Reserva borrada con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al borrar la reserva: {ex.Message}");
            }
        }
    }
}