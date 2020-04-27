using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Anuncios
    {
        public int AnuncioId { get; set; }
        public string FechaCreacion { get; set; }
        public int? TipoAnuncioId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int? ProductoId { get; set; }
        public int? PuntoVentaId { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public int? ValorAnterior { get; set; }
        public int? ValorActual { get; set; }
        public int? PorcentajeDcto { get; set; }
        public string ImagenNombre { get; set; }
        public byte[] ImagenData { get; set; }
        public int? Destacado { get; set; }
        public int? DestacadoId { get; set; }
        public bool? Activo { get; set; }
        public int? Orden { get; set; }

        public virtual Productos Producto { get; set; }
        public virtual PuntosDeVentas PuntoVenta { get; set; }
        public virtual TiposDeAnuncios TipoAnuncio { get; set; }
    }
}
