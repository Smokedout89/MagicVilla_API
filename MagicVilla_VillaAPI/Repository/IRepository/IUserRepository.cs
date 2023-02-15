namespace MagicVilla_VillaAPI.Repository.IRepository;

using Models;
using Models.DTO;

public interface IUserRepository
{
    bool IsUniqueUser(string username);
    Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
    Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO);
}