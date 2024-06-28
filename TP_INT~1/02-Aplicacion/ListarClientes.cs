using _02_Aplicacion.DTOs;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Aplicacion
{
    public class ListarClientes
    {
        private ClienteRepositorio repositorio;

        public ListarClientes(ClienteRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<ClienteDTO> Ejecutar()
        {
            List<ClienteDTO> usuariosDTO = new List<ClienteDTO>();
            List<Cliente> clientes = this.repositorio.listar();
            foreach (Cliente cliente in clientes)
            {
                ClienteDTO usuarioDTO = new ClienteDTO(
                    cliente.Id(),
                    cliente.Nombre(),
                    cliente.Email(),
                    cliente.Clave(),
                    cliente.FechaNacimiento()
                );
                usuariosDTO.Add(usuarioDTO);
            }
            return usuariosDTO;
        }
    }
}
