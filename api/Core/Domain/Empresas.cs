using System.Collections.Generic;

namespace Core.Domain
{
    public class Empresas
    {
        public Empresas()
        {
            PuntoVentasLink = new HashSet<EmpresasPuntoVentas>();
        }
        public int EmpresaId { get; set; }
        public int EmpresaNombre { get; set; }
        public string Nit { get; set; }
        public TiposDeEmpresas TipoEmpresa { get; set; }

        public virtual ICollection<EmpresasPuntoVentas> PuntoVentasLink { get; set; }
    }
}
