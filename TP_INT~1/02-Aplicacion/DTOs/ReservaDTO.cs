namespace _02_Aplicacion.DTOs
{
    public class ReservaDTO
    {
        private Guid id;
        private Guid clienteId;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private Guid guid;
        private string estado = string.Empty; // Inicializar estado aquí

        public ReservaDTO(Guid id, Guid clienteId, DateTime fechaInicio, DateTime fechaFin)
        {
            this.id = id;
            this.clienteId = clienteId;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
        }

        public ReservaDTO(Guid guid, Guid clienteId, DateTime fechaInicio, DateTime fechaFin, string estado)
        {
            this.guid = guid;
            this.clienteId = clienteId;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.estado = estado; // Inicializar estado en el constructor
        }

        public Guid Id()
        {
            return id;
        }

        public Guid ClienteId()
        {
            return clienteId;
        }

        public DateTime FechaInicio()
        {
            return fechaInicio;
        }

        public DateTime FechaFin()
        {
            return fechaFin;
        }

        public object Estado()
        {
            return estado;
        }
    }
}
