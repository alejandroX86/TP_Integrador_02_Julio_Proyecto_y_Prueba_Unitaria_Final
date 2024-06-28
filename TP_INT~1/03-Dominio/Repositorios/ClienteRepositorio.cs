using _03_Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace _03_Dominio.Repositorios
{
    public interface ClienteRepositorio
    {
        List<Cliente> listar();
        void grabar(Cliente cliente);
        void eliminar(Guid id);
        void actualizar(Cliente cliente);
        void actualizarCliente(Cliente cliente);
    }
}