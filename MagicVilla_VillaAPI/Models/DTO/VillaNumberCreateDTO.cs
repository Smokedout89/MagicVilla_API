namespace MagicVilla_VillaAPI.Models.DTO
{
    using System.ComponentModel.DataAnnotations;

    public class VillaNumberCreateDTO
    {
        [Required]
        public int VillaNo { get; set; }
        [Required]
        public int VillaId { get; set; }
        public string SpecialDetails { get; set; }
    }
}
