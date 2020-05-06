using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "decimal(18,4)")]
        public decimal Valor { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal ValorAnterior { get; set; }
        public string Presentacion { get; set; }
        public string Detalle { get; set; }
        public int Cantidad { get; set; }

        public bool Destacado { get; set; }

        public virtual Grupos Grupo { get; set; }
        public virtual Marcas Marca { get; set; }
        public virtual PuntosDeVentas PuntoVenta { get; set; }
        public virtual ICollection<Anuncios> Anuncios { get; set; }
    }
}
