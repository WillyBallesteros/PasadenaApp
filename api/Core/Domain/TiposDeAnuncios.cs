using System.Collections.Generic;

namespace Core.Domain
{
    public class TiposDeAnuncios
    {
        public TiposDeAnuncios()
        {
            Anuncios = new HashSet<Anuncios>();
        }

        public int TipoAnuncioId { get; set; }
        public string TipoAnuncioNombre { get; set; }

        public virtual ICollection<Anuncios> Anuncios { get; set; }
    }
}
