namespace MagicVilla_Web.Services.IServices;

using Models.DTO;

public interface IVillaNumberService
{
    Task<T> GetAllAsync<T>();
    Task<T> GetAsync<T>(int id);
    Task<T> CreateAsync<T>(VillaNumberCreateDTO dto);
    Task<T> UpdateAsync<T>(VillaNumberUpdateDTO dto);
    Task<T> DeleteAsync<T>(int id);
}