namespace Core.Payload
{
    public class RegisterPayload
    {
        public string NumeroCedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? CiudadId { get; set; }
        public int? PuntoVentaId { get; set; }
    }
}
