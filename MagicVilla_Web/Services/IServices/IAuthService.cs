namespace MagicVilla_Web.Services.IServices;

using Models.DTO;

public interface IAuthService
{
    Task<T> LoginAsync<T>(LoginRequestDTO objToCreate);
    Task<T> RegisterAsync<T>(RegistrationRequestDTO objToCreate);
}