using HomeWork.Service.Models.AuthModel;

namespace HomeWork.Core.AuthServices;

public interface IAuthService
{
    Task<LoginResponse> Login(LoginModel loginModel);
    Task<RegisterResponse> Register(RegisterModel registerModel);
}
