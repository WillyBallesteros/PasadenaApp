namespace Core.Dtos
{
    public class ProductoDto
    {
        public int ProductoId { get; set; }
        public string Plu { get; set; }
        public string ProductoNombre { get; set; }
        public int? MarcaId { get; set; }
        public int? GrupoId { get; set; }
        public int? PuntoVentaId { get; set; }
        public string ImagenNombre { get; set; }
        public byte[] ImagenData { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorAnterior { get; set; }
        public string Presentacion { get; set; }
        public string Detalle { get; set; }
        public int Cantidad { get; set; }

    }
}
