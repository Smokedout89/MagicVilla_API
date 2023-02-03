namespace MagicVilla_VillaAPI.Repository;

using Data;
using Models;
using IRepository;

public class VillaRepository : Repository<Villa>, IVillaRepository
{
    private readonly ApplicationDbContext _db;
    public VillaRepository(ApplicationDbContext db)
        : base(db)
    {
        _db = db;
    }

    public async Task<Villa> UpdateAsync(Villa entity)
    {
        _db.Villas.Update(entity);
        entity.UpdatedDate = DateTime.Now;

        await _db.SaveChangesAsync();
        return entity;
    }
}