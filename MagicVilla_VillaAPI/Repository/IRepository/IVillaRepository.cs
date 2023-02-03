namespace MagicVilla_VillaAPI.Repository.IRepository;

using Models;

public interface IVillaRepository : IRepository<Villa>
{
    Task<Villa> UpdateAsync(Villa entity);
}