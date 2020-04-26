using System;
using System.Collections.Generic;

namespace Dominio
{
    public partial class Departamentos
    {
        public Departamentos()
        {
            Ciudades = new HashSet<Ciudades>();
        }

        public int DepartamentoId { get; set; }
        public string DepartamentoNombre { get; set; }

        public virtual ICollection<Ciudades> Ciudades { get; set; }
    }
}
