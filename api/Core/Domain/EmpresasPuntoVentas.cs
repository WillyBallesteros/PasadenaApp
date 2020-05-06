namespace Core.Domain
{
    public class EmpresasPuntoVentas
    {
        public int EmpresaId { get; set; }
        public Empresas Empresa { get; set; }

        public int PuntoVentaId { get; set; }
        public PuntosDeVentas PuntoDeVenta { get; set; }
    }
}
