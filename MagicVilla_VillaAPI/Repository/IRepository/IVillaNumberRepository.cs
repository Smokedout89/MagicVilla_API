namespace MagicVilla_VillaAPI.Repository.IRepository;

using Models;

public interface IVillaNumberRepository : IRepository<VillaNumber>
{
    Task<VillaNumber> UpdateAsync(VillaNumber entity);
}