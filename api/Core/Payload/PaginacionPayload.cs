namespace Core.Payload
{
    public class PaginacionPayload
    {
        public string NombreProducto { get; set; }
        public int GroupId { get; set; }
        public int NumeroPagina { get; set; }
        public int CantidadElementos { get; set; }
    }
}
