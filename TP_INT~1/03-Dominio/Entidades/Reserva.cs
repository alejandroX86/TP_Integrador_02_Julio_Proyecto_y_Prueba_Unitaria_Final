using _03_Dominio._03_Dominio.ValueObjects;
using _03_Dominio.Entidades;
using _03_Dominio.ValueObjects;
using System;

namespace _03_Dominio.Entidades
{
    public class Reserva
    {
        private readonly ReservaId id;
        private readonly ClienteId clienteId;
        private readonly FechaReserva fechaReserva;
        private readonly Estado estado;

        public Reserva(Guid id, Guid clienteId, DateTime fechaInicio, DateTime fechaFin, string estado)
        {
            this.id = new ReservaId(id);
            this.clienteId = new ClienteId(clienteId);
            this.fechaReserva = new FechaReserva(fechaInicio, fechaFin);
            this.estado = new Estado(estado);
        }

        public Guid Id()
        {
            return this.id.Valor;
        }

        public Guid ClienteId()
        {
            return this.clienteId.Valor;
        }

        public DateTime FechaInicio()
        {
            return this.fechaReserva.FechaInicio;
        }

        public DateTime FechaFin()
        {
            return this.fechaReserva.FechaFin;
        }

        public string Estado()
        {
            return this.estado.Valor;
        }
    }
}