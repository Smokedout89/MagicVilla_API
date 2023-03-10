namespace MagicVilla_VillaAPI.Models.DTO
{
    using System.ComponentModel.DataAnnotations;

    public class VillaNumberDTO
    {
        [Required] 
        public int VillaNo { get; set; }
        [Required]
        public int VillaId { get; set; }
        public string SpecialDetails { get; set; }
        public VillaDTO Villa { get; set; }
    }
}
