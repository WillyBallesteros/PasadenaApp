using Microsoft.AspNetCore.Identity;

namespace Core.Domain
{
    public class Usuarios : IdentityUser
    {
        public string NumeroCedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public int? CiudadId { get; set; }
        public int? PuntoVentaId { get; set; }
        public int? TipoDocumentoId { get; set; }
        public bool? Activo { get; set; }
        public virtual Ciudades Ciudad { get; set; }
        public virtual PuntosDeVentas PuntoVenta { get; set; }
        public virtual TiposDeDocumentos TipoDocumento { get; set; }
    }
}
