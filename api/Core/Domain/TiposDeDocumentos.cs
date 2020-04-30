using System.Collections.Generic;

namespace Core.Domain
{
    public class TiposDeDocumentos
    {
        public TiposDeDocumentos()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int TipoDocumentoId { get; set; }
        public string TipoDocumentoNombre { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
