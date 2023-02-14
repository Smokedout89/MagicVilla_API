namespace MagicVilla_Web.Models.VM;

using DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class VillaNumberUpdateVM
{
    public VillaNumberUpdateVM()
    {
        VillaNumber = new VillaNumberUpdateDTO();
    }

    public VillaNumberUpdateDTO VillaNumber { get; set; }

    [ValidateNever]
    public IEnumerable<SelectListItem> VillaList { get; set; }
}