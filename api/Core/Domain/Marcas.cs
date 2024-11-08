﻿using System.Collections.Generic;

namespace Core.Domain
{
    public class Marcas
    {
        public Marcas()
        {
            Productos = new HashSet<Productos>();
        }

        public int MarcaId { get; set; }
        public string MarcaNombre { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
