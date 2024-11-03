using System.Collections.Generic;

namespace Core.Domain
{
    public class Departamentos
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
