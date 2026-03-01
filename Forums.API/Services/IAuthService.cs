using Forums.API.Models.DTO.Auth;

namespace Forums.API.Services;

public interface IAuthService
{
    Task Register(RegistrationRequestDto registrationRequestDto);
    Task RegisterAdmin(RegistrationRequestDto registrationRequestDto);
    Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

}