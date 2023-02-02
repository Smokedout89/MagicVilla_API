namespace MagicVilla_VillaAPI.Data
{
    using Models.DTO;

    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
        {
            new VillaDTO { Id = 1, Name = "Pool View" },
            new VillaDTO { Id = 2, Name = "Beach View" },
            new VillaDTO { Id = 3, Name = "Concrete View" }
        };
    }
}