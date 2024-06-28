using System;
using System.Collections.Generic;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;

namespace _04_PersistenciaDatos
{
    public class ClienteRepositorioEnMemoria : ClienteRepositorio
    {
        private List<Cliente> clientes = new List<Cliente>();

        public List<Cliente> listar()
        {
            return clientes;
        }

        public void grabar(Cliente cliente)
        {
            clientes.Add(cliente);
        }

        public void eliminar(Guid id)
        {
            clientes.RemoveAll(c => c.Id() == id);
        }

        public void actualizarCliente(Cliente cliente)
        {
            int index = clientes.FindIndex(c => c.Id() == cliente.Id());
            if (index != -1)
            {
                clientes[index] = cliente;
            }
            else
            {
                throw new InvalidOperationException($"No se encontró un cliente con el ID {cliente.Id()}.");
            }
        }

        public void actualizar(Cliente cliente)
        {
            int index = clientes.FindIndex(c => c.Id() == cliente.Id());
            if (index != -1)
            {
                clientes[index] = cliente;
            }
            else
            {
                throw new InvalidOperationException($"No se encontró un cliente con el ID {cliente.Id()}.");
            }
        }
    }
}