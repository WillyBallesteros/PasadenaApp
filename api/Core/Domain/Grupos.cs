using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Grupos
    {
        public Grupos()
        {
            Productos = new HashSet<Productos>();
        }

        public int GrupoId { get; set; }
        public string GrupoNombre { get; set; }
        public bool? Activo { get; set; }
        public int? Orden { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
