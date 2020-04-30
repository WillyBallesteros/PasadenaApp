using System.Threading.Tasks;
using Core.Dtos;
using Core.Payload;
using Services.Handlers;

namespace Services.AuthService
{
    public interface IAuthService
    {
        Task<ResponsePackage<LoginDto>> Ingreso(LoginPayload payload);
        Task<ResponsePackage<RegisterDto>> Registro(RegisterPayload payload);
        Task<ResponsePackage<LoginDto>> GetUser();
        Task<ResponsePackage<RegisterDto>> UpdateUser(UpdateUserPayload payload);
    }
}
