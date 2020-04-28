using System;

namespace Core.Dtos
{
    public class UsuarioDto
    {
        public UsuarioDto()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string NumeroCedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int CiudadId { get; set; }
        public int PuntoVentaId { get; set; }
        public bool Activo { get; set; }
    }
}
