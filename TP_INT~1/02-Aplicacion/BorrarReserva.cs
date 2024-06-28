using _03_Dominio.Repositorios;
using System;

namespace _02_Aplicacion
{
    public class BorrarReserva
    {
        private readonly IReservaRepositorio _repositorio;

        public BorrarReserva(IReservaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(Guid id)
        {
            try
            {
                _repositorio.BorrarReserva(id);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new ApplicationException($"Error al eliminar la reserva con ID {id}: {ex.Message}", ex);
            }
        }
    }
}