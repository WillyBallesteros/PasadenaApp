using System;
using System.Collections.Generic;

namespace Dominio
{
    public partial class TiposDeAnuncios
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
