namespace MagicVilla_Web.Services.IServices;

using Models;

public interface IBaseService
{
    APIResponse responseModel { get; set; }

    Task<T> SendAsync<T>(APIRequest apiRequest);
}