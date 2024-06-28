using System;
using System.Collections.Generic;
using _03_Dominio;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;

namespace _04_PersistenciaDatos
{
    public class ReservaRepositorioEnMemoria : IReservaRepositorio
    {
        private List<Reserva> reservas = new List<Reserva>();

        public void CrearReserva(Reserva reserva)
        {
            reservas.Add(reserva);
        }

        public List<Reserva> ListarReservas()
        {
            return reservas;
        }

        public void BorrarReserva(Guid id)
        {
            reservas.RemoveAll(r => r.Id() == id);
        }

       
    }
}