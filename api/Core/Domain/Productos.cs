using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Productos
    {
        public Productos()
        {
            Anuncios = new HashSet<Anuncios>();
        }

        public int ProductoId { get; set; }
        public string Plu { get; set; }
        public string ProductoNombre { get; set; }
        public int? MarcaId { get; set; }
        public int? GrupoId { get; set; }
        public int? PuntoVentaId { get; set; }
        public string ImagenNombre { get; set; }
        public byte[] ImagenData { get; set; }

        public virtual Grupos Grupo { get; set; }
        public virtual Marcas Marca { get; set; }
        public virtual PuntosDeVentas PuntoVenta { get; set; }
        public virtual ICollection<Anuncios> Anuncios { get; set; }
    }
}
