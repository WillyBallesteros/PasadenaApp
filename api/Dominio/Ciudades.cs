using System;
using System.Collections.Generic;

namespace Dominio
{
    public partial class Ciudades
    {
        public Ciudades()
        {
            PuntosDeVentas = new HashSet<PuntosDeVentas>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int CiudadId { get; set; }
        public int? DepartamentoId { get; set; }
        public string CiudadNombre { get; set; }

        public virtual Departamentos Departamento { get; set; }
        public virtual ICollection<PuntosDeVentas> PuntosDeVentas { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
