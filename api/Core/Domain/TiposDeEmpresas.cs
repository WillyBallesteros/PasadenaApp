using System.Collections.Generic;

namespace Core.Domain
{
    public class TiposDeEmpresas
    {
        public TiposDeEmpresas()
        {
            Empresas = new HashSet<Empresas>();
        }
        public int TipoEmpresaId { get; set; }
        public int TipoEmpresaNombre { get; set; }

        public virtual ICollection<Empresas> Empresas { get; set; }
    }
}
