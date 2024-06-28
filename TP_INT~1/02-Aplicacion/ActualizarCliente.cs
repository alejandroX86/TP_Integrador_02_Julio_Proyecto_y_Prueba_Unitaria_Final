using _02_Aplicacion.DTOs;
using _03_Dominio;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;
using System;

namespace _02_Aplicacion
{
    public class ActualizarClientes
    {
        private readonly ClienteRepositorio _repositorio;

        public ActualizarClientes(ClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(ClienteDTO clienteDTO)
        {
            Cliente clienteActualizado = new Cliente(
                clienteDTO.Id(),
                clienteDTO.Nombre(),
                clienteDTO.Email(),
                clienteDTO.Clave(),
                clienteDTO.FechaNacimiento()
            );

            try
            {
                _repositorio.actualizar(clienteActualizado);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al actualizar el cliente: {ex.Message}", ex);
            }
        }
    }
}