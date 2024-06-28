using _03_Dominio.Repositorios;
using System;

namespace _02_Aplicacion
{
    public class BorrarCliente
    {
        private readonly ClienteRepositorio? _repositorio;
        private Guid clienteId;

        public BorrarCliente(ClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public BorrarCliente(Guid clienteId)
        {
            this.clienteId = clienteId;
        }

        public void Ejecutar(Guid id)
        {
            if (_repositorio != null)
            {
                try
                {
                    _repositorio.eliminar(id);
                }
                catch (Exception ex)
                {
                    // Aquí puedes manejar la excepción, por ejemplo, logueándola o lanzando una excepción personalizada.
                    throw new ApplicationException($"Error al borrar el cliente con ID {id}: {ex.Message}", ex);
                }
            }
            else
            {
                throw new InvalidOperationException("El repositorio no ha sido inicializado.");
            }
        }

        public void Ejecutar(BorrarCliente borrarCliente)
        {
            throw new NotImplementedException();
        }
    }
}
