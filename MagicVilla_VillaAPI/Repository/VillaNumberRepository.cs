namespace MagicVilla_VillaAPI.Repository;

using Data;
using Models;
using IRepository;

public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
{
    private readonly ApplicationDbContext _db;
    public VillaNumberRepository(ApplicationDbContext db)
        : base(db)
    {
        _db = db;
    }

    public async Task<VillaNumber> UpdateAsync(VillaNumber entity)
    {
        _db.VillaNumbers.Update(entity);
        entity.UpdatedDate = DateTime.Now;

        await _db.SaveChangesAsync();
        return entity;
    }
}