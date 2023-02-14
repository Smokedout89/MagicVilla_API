namespace MagicVilla_Web.Models.VM;

using DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class VillaNumberDeleteVM
{
    public VillaNumberDeleteVM()
    {
        VillaNumber = new VillaNumberDTO();
    }

    public VillaNumberDTO VillaNumber { get; set; }

    [ValidateNever]
    public IEnumerable<SelectListItem> VillaList { get; set; }
}