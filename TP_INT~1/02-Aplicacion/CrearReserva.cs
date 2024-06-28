using _03_Dominio._03_Dominio.ValueObjects;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;
using _03_Dominio.ValueObjects;
using System;

namespace _02_Aplicacion
{
    public class CrearReserva
    {
        private readonly IReservaRepositorio _repositorio;

        public CrearReserva(IReservaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(Guid idCliente, DateTime fechaInicio, DateTime fechaFin, string estado)
        {
            var reserva = new Reserva(Guid.NewGuid(), idCliente, fechaInicio, fechaFin, estado);
            _repositorio.CrearReserva(reserva);
        }
    }
}