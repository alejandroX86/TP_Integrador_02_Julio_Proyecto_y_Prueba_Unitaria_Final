using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_Dominio.Entidades;

namespace _03_Dominio.Repositorios
{
    public interface IReservaRepositorio
    {
        List<Reserva> ListarReservas();
        void CrearReserva(Reserva reserva);
        void BorrarReserva(Guid id);
    }
}
