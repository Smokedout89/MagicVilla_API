namespace MagicVilla_VillaAPI.Data
{
    using Models.DTO;

    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
        {
            new VillaDTO { Id = 1, Name = "Pool View", Sqft = 100, Occupancy = 3},
            new VillaDTO { Id = 2, Name = "Beach View", Sqft = 200, Occupancy = 4},
            new VillaDTO { Id = 3, Name = "Concrete View", Sqft = 40, Occupancy = 2}
        };
    }
}