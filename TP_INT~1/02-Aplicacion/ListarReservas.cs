using _02_Aplicacion.DTOs;
using _03_Dominio;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;
using System.Collections.Generic;

namespace _02_Aplicacion
{
    public class ListarReservas
    {
        private readonly IReservaRepositorio _repositorio;

        public ListarReservas(IReservaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public List<ReservaDTO> Ejecutar()
        {
            List<ReservaDTO> reservasDTOs = new List<ReservaDTO>();
            List<Reserva> reservas = _repositorio.ListarReservas();

            foreach (Reserva reserva in reservas)
            {
                ReservaDTO reservaDTO = new ReservaDTO(
                    reserva.Id(),
                    reserva.ClienteId(),
                    reserva.FechaInicio(),
                    reserva.FechaFin(),
                    reserva.Estado()
                );
                reservasDTOs.Add(reservaDTO);
            }

            return reservasDTOs;
        }
    }
}