namespace MagicVilla_VillaAPI.Models.DTO
{
    using System.ComponentModel.DataAnnotations;

    public class VillaDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public int Occupancy { get; set; }
        public int Sqft { get; set; }
    }
}
