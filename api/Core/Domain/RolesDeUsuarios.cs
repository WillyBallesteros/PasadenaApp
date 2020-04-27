using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public partial class RolesDeUsuarios
    {
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
        public string Descripcion { get; set; }

        public virtual Roles Rol { get; set; }
        public virtual Usuarios Usuario { get; set; }
    }
}
