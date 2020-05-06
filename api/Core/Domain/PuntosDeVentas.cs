using System.Collections.Generic;

namespace Core.Domain
{
    public class PuntosDeVentas
    {
        public PuntosDeVentas()
        {
            Anuncios = new HashSet<Anuncios>();
            Productos = new HashSet<Productos>();
            Usuarios = new HashSet<Usuarios>();
            EmpresaLink = new HashSet<EmpresasPuntoVentas>();
        }

        public int PuntoVentaId { get; set; }
        public decimal Nit { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public string Contacto { get; set; }
        public int? CiudadId { get; set; }
        public string Logo { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public int? Estado { get; set; }

        public virtual Ciudades Ciudad { get; set; }
        public virtual ICollection<Anuncios> Anuncios { get; set; }
        public virtual ICollection<Productos> Productos { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
        public virtual ICollection<EmpresasPuntoVentas> EmpresaLink { get; set; }
    }
}
