using System;
using System.Collections.Generic;

namespace Dominio
{
    public partial class Roles
    {
        public Roles()
        {
            RolesDeUsuarios = new HashSet<RolesDeUsuarios>();
        }

        public int RolId { get; set; }
        public string RolNombre { get; set; }

        public virtual ICollection<RolesDeUsuarios> RolesDeUsuarios { get; set; }
    }
}
