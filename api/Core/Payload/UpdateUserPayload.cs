namespace Core.Payload
{
    public class UpdateUserPayload
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int? TipoDocumentoId { get; set; }
        public string NumeroCedula { get; set; }
        public string Password { get; set; }
        public int? CiudadId { get; set; }
        public int? PuntoVentaId { get; set; }
        public ImagenPayload ImagenPerfil { get; set; }
    }
}
