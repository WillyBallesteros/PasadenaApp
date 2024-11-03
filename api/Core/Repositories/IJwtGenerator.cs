using Core.Domain;

namespace Core.Repositories
{
    public interface IJwtGenerator
    {
        string CrearToken(Usuarios usuario);
    }
}
