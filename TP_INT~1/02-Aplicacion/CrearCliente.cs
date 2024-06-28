using _02_Aplicacion.DTOs;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;

namespace _02_Aplicacion
{
    public class CrearClientes
    {
        private ClienteRepositorio repositorio;

        public CrearClientes(ClienteRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Ejecutar(ClienteDTO usuarioDTO)
        {
            this.repositorio.grabar(new Cliente(
                usuarioDTO.Id(),
                usuarioDTO.Nombre(),
                usuarioDTO.Email(),
                usuarioDTO.Clave(),
                usuarioDTO.FechaNacimiento()
            ));
        }
    }
}