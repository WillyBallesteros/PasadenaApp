using Core.Domain;

namespace Services.ContractService
{
    public interface IJwtGenerator
    {
        string CrearToken(Usuarios usuario);
    }
}
