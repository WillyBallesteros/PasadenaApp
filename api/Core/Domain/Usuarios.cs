using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Usuarios
    {
        public Usuarios()
        {
            RolesDeUsuarios = new HashSet<RolesDeUsuarios>();
        }

        public int UsuarioId { get; set; }
        public string NumeroCedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public int? CiudadId { get; set; }
        public int? PuntoVentaId { get; set; }
        public bool? Activo { get; set; }

        public virtual Ciudades Ciudad { get; set; }
        public virtual PuntosDeVentas PuntoVenta { get; set; }
        public virtual ICollection<RolesDeUsuarios> RolesDeUsuarios { get; set; }
    }
}
